/****************************************************************************
 Copyright:      Kai Riedel based on LUFA Library
 Author:         Kai Riedel
 Remarks:        AVR AT90USB1287
 Version:        18.04.2013
 Description:    Temperature Data Logger with radio sensors
//------------------------------------------------------------------------------*/

/*
             LUFA Library
     Copyright (C) Dean Camera, 2010.

  dean [at] fourwalledcubicle [dot] com
           www.lufa-lib.org
*/

/*
  Copyright 2010  Dean Camera (dean [at] fourwalledcubicle [dot] com)

  Permission to use, copy, modify, distribute, and sell this
  software and its documentation for any purpose is hereby granted
  without fee, provided that the above copyright notice appear in
  all copies and that both that the copyright notice and this
  permission notice and warranty disclaimer appear in supporting
  documentation, and that the name of the author not be used in
  advertising or publicity pertaining to distribution of the
  software without specific, written prior permission.

  The author disclaim all warranties with regard to this
  software, including all implied warranties of merchantability
  and fitness.  In no event shall the author be liable for any
  special, indirect or consequential damages or any damages
  whatsoever resulting from loss of use, data or profits, whether
  in an action of contract, negligence or other tortious action,
  arising out of or in connection with the use or performance of
  this software.
*/

/** \file
 *
 *  Main source file for the TemperatureDataLogger project. This file contains the main tasks of
 *  the project and is responsible for the initial application hardware configuration.
 */

#include "TempDataLogger.h"


/** LUFA Mass Storage Class driver interface configuration and state information. This structure is
 *  passed to all Mass Storage Class driver functions, so that multiple instances of the same class
 *  within a device can be differentiated from one another.
 */
USB_ClassInfo_MS_Device_t Disk_MS_Interface =
	{
		.Config =
			{
				.InterfaceNumber           = 0,

				.DataINEndpointNumber      = MASS_STORAGE_IN_EPNUM,
				.DataINEndpointSize        = MASS_STORAGE_IO_EPSIZE,
				.DataINEndpointDoubleBank  = false,

				.DataOUTEndpointNumber     = MASS_STORAGE_OUT_EPNUM,
				.DataOUTEndpointSize       = MASS_STORAGE_IO_EPSIZE,
				.DataOUTEndpointDoubleBank = false,

				.TotalLUNs                 = 1,
			},
	};

/** Buffer to hold the previously generated HID report, for comparison purposes inside the HID class driver. */
uint8_t PrevHIDReportBuffer[GENERIC_REPORT_SIZE];

/** LUFA HID Class driver interface configuration and state information. This structure is
 *  passed to all HID Class driver functions, so that multiple instances of the same class
 *  within a device can be differentiated from one another.
 */
USB_ClassInfo_HID_Device_t Generic_HID_Interface =
	{
		.Config =
			{
				.InterfaceNumber              = 1,

				.ReportINEndpointNumber       = GENERIC_IN_EPNUM,
				.ReportINEndpointSize         = GENERIC_EPSIZE,
				.ReportINEndpointDoubleBank   = false,

				.PrevReportINBuffer           = PrevHIDReportBuffer,
				.PrevReportINBufferSize       = sizeof(PrevHIDReportBuffer),
			},
	};

/* global variables */

/** Non-volatile Logging Interval value in EEPROM, stored as a number of 500ms ticks */
uint16_t EEMEM LoggingInterval500MS_EEPROM = DEFAULT_LOG_INTERVAL;

/** SRAM Logging Interval value fetched from EEPROM, stored as a number of 500ms ticks */
uint16_t LoggingInterval500MS_SRAM;

/** store the day of actual logfile */
uint8_t oldday;

/** store name or location sensor 1 */
char Sensor1Name_SRAM[9];
char EEMEM Sensor1Name_EEPROM[8] = DEFAULT_SENSOR1_NAME;
int8_t Sensor1Correction_SRAM;
int8_t Sensor1PreviousValue;
int8_t Sensor1MinValue=0;
int8_t Sensor1MaxValue;
bool Sensor1Received=false;
uint8_t EEMEM Sensor1Correction_EEPROM;

/** store name or location and value of sensor 2 */
char Sensor2Name_SRAM[9];
char EEMEM Sensor2Name_EEPROM[8] = DEFAULT_SENSOR2_NAME;
int8_t Sensor2Value=0;
int8_t Sensor2PreviousValue;
int8_t Sensor2Correction_SRAM;
int8_t Sensor2MinValue;
int8_t Sensor2MaxValue;
bool Sensor2Received=false;
uint8_t EEMEM Sensor2Correction_EEPROM;

/** store name or location and value of sensor 3 */
char Sensor3Name_SRAM[9];
char EEMEM Sensor3Name_EEPROM[8] = DEFAULT_SENSOR3_NAME;
int8_t Sensor3Value=0;
int8_t Sensor3PreviousValue;
int8_t Sensor3Correction_SRAM;
int8_t Sensor3MinValue;
int8_t Sensor3MaxValue;
bool Sensor3Received=false;
uint8_t EEMEM Sensor3Correction_EEPROM;

/** Total number of 500ms logging ticks elapsed since the last log value was recorded */
uint16_t CurrentLoggingTicks;

/** From radio modul received data */
uint8_t DataReceived;

/** radio telegram content and assigned variables */
char recbuf[10];
uint8_t bufferposition;
uint8_t Checksum;
uint8_t rec_started;

/** radio timeout counters */
uint16_t Sensor2Timeout;
uint16_t Sensor3Timeout;

/** logfile successful created */
bool LogfileCreateSuccess;

/** receiver restart */
bool ReceiverRestart;

/** free memory on device */
uint32_t FreeMemory;

/** days left for data logging */
uint16_t DaysLeft_SRAM;
uint16_t EEMEM DaysLeft_EEPROM;

/** FAT Fs structure to hold the internal state of the FAT driver for the Dataflash contents. */
FATFS DiskFATState;

/** FAT Fs structure to hold a FAT file handle for the log data write destination. */
FIL TempLogFile;

/** counter for web enable*/
uint16_t WebEnableCounter;

//uint8_t rx_position;
//char RXBuffer[15];

/** ISR to manage the reception of data from the serial port */
/*ISR(USART1_RX_vect, ISR_BLOCK)
{
	RXBuffer[rx_position++] = UDR1;                       // reveive 15 characters from UART
	if (rx_position > sizeof RXBuffer-1)
    {
        rx_position = 0;
        lcd_pos(2,1);
        lcd_print_str(RXBuffer);                           // display answer from webserver

        _delay_ms(5000);
        Serial_ShutDown();                                 // disable uart
        POWER_ENABLE_Port_Write &= ~(1<<POWER_ENABLE);     // disable web module LDO
    }
}*/

/** ISR to handle the 500ms ticks for sampling and data logging */
ISR(TIMER1_COMPA_vect, ISR_BLOCK)
{
	uint8_t LEDMask = LEDs_GetLEDs();
	uint8_t Day,  Month,  Year;
	uint8_t Hour, Minute, Second;
	uint8_t Timer=0;
	char LineBuffer[30];
    int8_t Temperature=0;
    uint8_t Humidity=0;

	if (!(LOCAL_Port_Read & (1<<LOCAL)))
	{
		DS1307_GetDate(&Day,  &Month,  &Year);
		DS1307_GetTime(&Hour, &Minute, &Second);

		/* Write date, time to lcd */

        if (LCD_MODUL==2)
        {
            sprintf(LineBuffer, "%02d%02d%02d %02d:%02d:%02d ", Day, Month, Year, Hour, Minute, Second);
            lcd_pos(2,1);
            lcd_print_str(LineBuffer);
        }
        else
        {
            sprintf(LineBuffer, "%02d.%02d.%02d,%02d:%02d:%02d  ", Day, Month, Year, Hour, Minute, Second);
            lcd_pos(4,1);
            lcd_print_str(LineBuffer);
            lcd_pos(2,1);
            lcd_print_str(Sensor2Name_SRAM);
            lcd_pos(3,1);
            lcd_print_str(Sensor3Name_SRAM);
        }

        lcd_pos(1,1);
		lcd_print_str(Sensor1Name_SRAM);

		//Temperature = Temperature_GetTemperature()+Sensor1Correction_SRAM;  // if use of local NTC
		HYT321_GetData(&Humidity, &Temperature);
		Temperature += Sensor1Correction_SRAM;

        if (LCD_MODUL==2)
        {
            lcd_print_value (Temperature, "#C  ", '+', 1, 8, 2, 0);
            lcd_print_value (Humidity, "% ", '/', 1, 13, 2, 0);
        }
		else
        {
            lcd_print_value (Temperature, "#C", '+', 1, 10, 2, 0);
            lcd_print_value (Humidity, "% ", '/', 1, 15, 2, 0);
            lcd_pos (1, 20);
            if (Temperature > Sensor1PreviousValue + 1) lcd_write (0, 1);
            else if (Temperature < Sensor1PreviousValue - 1) lcd_write (1, 1);
            else lcd_print_str ("~");
        }

        if (Sensor1Received)
        {
            if (Temperature < Sensor1MinValue) Sensor1MinValue = Temperature;
            if (Temperature > Sensor1MaxValue) Sensor1MaxValue = Temperature;
        }
        else
        {
           Sensor1MinValue = Temperature;
           Sensor1MaxValue = Temperature;
           Sensor1Received = true;
        }

        Sensor1PreviousValue = Temperature;

        // optional check sensor timeout interval
        /*if (LCD_MODUL==4)
        {
            Sensor2Timeout++;
            Sensor3Timeout++;

            if (Sensor2Timeout>2400)			// no Sensor2 values received in 20 minutes
            {
                Sensor2Value=0;
                lcd_pos(2,10);
                lcd_print_str("---#C      ");
            }

            if (Sensor3Timeout>2400)			// no Sensor3 values received in 20 minutes
            {
                Sensor3Value=0;
                lcd_pos(3,10);
                lcd_print_str("---#C      ");
            }

            if (((Sensor2Timeout > 600) | (Sensor3Timeout > 600)) & !ReceiverRestart) // no sensor values after 5 minutes
            {
                Disable_receiver();             // restart receiver
                RFM12_Init();			        // init RFM12 radio modul
                Enable_receiver();
                ReceiverRestart = true;         // only one receiver restartd
                Sensor2Timeout = 0;
                Sensor3Timeout = 0;
            }

        }*/

		/* write minimum and maximum values */
        if (!(MAX_Port_Read & (1<<MAXSWITCH)))
        {
           lcd_init();                     // clear display because interferences could cause lcd fault
           lcd_print_str(Sensor1Name_SRAM);
           lcd_pos(LCD_MODUL,1);
           sprintf (LineBuffer, "D:%3d I:%3d L:%3d", DaysLeft_SRAM, LoggingInterval500MS_SRAM/2,
                   (LoggingInterval500MS_SRAM-CurrentLoggingTicks)/2);
           lcd_print_str(LineBuffer);

           if (Sensor1Received)
           {
            lcd_print_value (Sensor1MinValue, "#C/", '+', 1, 6+LCD_MODUL, 2, 0);
            lcd_print_value (Sensor1MaxValue, "#C", '+', 1, 12+LCD_MODUL, 2, 0);
            }

           if (LCD_MODUL==4)
           {
               lcd_pos(2,1);
               lcd_print_str(Sensor2Name_SRAM);
               lcd_pos(3,1);
               lcd_print_str(Sensor3Name_SRAM);

               if (Sensor2Received)
               {
                lcd_print_value (Sensor2MinValue, "#C/", '+',  2, 10, 2, 0);
                lcd_print_value (Sensor2MaxValue, "#C", '+',  2, 16, 2, 0);
               }
               if (Sensor3Received)
               {
                lcd_print_value (Sensor3MinValue, "#C/", '+', 3, 10, 2, 0);
                lcd_print_value (Sensor3MaxValue, "#C", '+', 3, 16, 2, 0);
                }
           }

            while (!(MAX_Port_Read & (1<<MAXSWITCH)))      // wait until key is released
            {
               _delay_ms(100);
               if (Timer++>30)                              // clear min/max store
               {
                  Sensor1Received = false;
                  Sensor2Received = false;
                  Sensor3Received = false;
                  lcd_pos(LCD_MODUL,1);
                  lcd_print_str("Clear Min/Max Store");
               }
            }

            lcd_print_value (Sensor1PreviousValue, "#C      ", '+', 1, 10, 2, 0);
            if (LCD_MODUL==4)
            {
                lcd_print_value (Sensor2Value, "#C      ", '+', 2, 10, 2, 0);
                lcd_print_value (Sensor3Value, "#C      ", '+', 3, 10, 2, 0);
            }
        }
    }

    if(Sensor2Received&Sensor3Received)         // transmit values to webserver only if sensor values received
    {

        if(WebEnableCounter++ == WEB_LOGGING_INTERVAL) POWER_ENABLE_Port_Write |= (1<<POWER_ENABLE);      // activate web module LDO
        if(WebEnableCounter == 30)
        {
            Serial_ShutDown();                                 // disable uart after 15 seconds
            POWER_ENABLE_Port_Write &= ~(1<<POWER_ENABLE);     // disable web module LDO
        }

        if(WebEnableCounter>(WEB_LOGGING_INTERVAL+30))   // transmit values to webserver cosm 15 seconds after activation of module
        {
            Serial_Init(9600, 0);   // initialize uart
            _delay_ms(100);

            /*Serial_TxString("PUT /v2/feeds/");
            Serial_TxString(FEED_ID);
            Serial_TxString(".csv HTTP/1.1\r\n");
            Serial_TxString("Host: api.xively.com\r\n");
            Serial_TxString("X-ApiKey: ");
            Serial_TxString(API_KEY);
            Serial_TxString("\r\n");

            Serial_TxString("Content-Length: 11\r\n");
            Serial_TxString("Content-Type: text/csv\r\n");
            Serial_TxString("Connection: close\r\n");
            Serial_TxString("\r\n");

            Serial_TxString("0,");
            sprintf(LineBuffer, "%3d\n", Temperature);
            Serial_TxString(LineBuffer);

            Serial_TxString("1,");
            sprintf(LineBuffer, "%3d\r\n", Humidity);
            Serial_TxString(LineBuffer);*/

            Serial_TxString("POST /update HTTP/1.1\n");
            Serial_TxString("Host: api.thingspeak.com\n");
            Serial_TxString("Connection: close\n");
            Serial_TxString("X-THINGSPEAKAPIKEY: ");
            Serial_TxString(writeAPIKey);
            Serial_TxString("\n");
            Serial_TxString("Content-Type: application/x-www-form-urlencoded\n");
            if (LCD_MODUL==4) Serial_TxString("Content-Length: 43"); //length of send data
            else Serial_TxString("Content-Length: 21");
            Serial_TxString("\n\n");

            Serial_TxString("field1=");
            sprintf(LineBuffer, "%3d", Temperature);
            Serial_TxString(LineBuffer);

            Serial_TxString("&field2=");
            sprintf(LineBuffer, "%3d", Humidity);
            Serial_TxString(LineBuffer);

            if (LCD_MODUL==4)
            {
                Serial_TxString("&field3=");
                sprintf(LineBuffer, "%3d", Sensor2Value);
                Serial_TxString(LineBuffer);

                Serial_TxString("&field4=");
                sprintf(LineBuffer, "%3d", Sensor3Value);
                Serial_TxString(LineBuffer);
            }

            Serial_TxString("\r\n");

            // UCSR1B |= (1 << RXCIE1);    // enable rx interrupt to get answer from webserver

           // _delay_ms(1500);

           // Serial_ShutDown();          // disable uart

           // POWER_ENABLE_Port_Write &= ~(1<<POWER_ENABLE);     // disable web module LDO
            WebEnableCounter=0;        // reset weblogging counter
        }
    }

	/* Check to see if the logging interval has expired */
	if (CurrentLoggingTicks++ < LoggingInterval500MS_SRAM)
	  return;

	/* Reset log tick counter to prepare for next logging interval */
	CurrentLoggingTicks = 0;

	LEDs_SetAllLEDs(LEDMASK_USB_BUSY);

	/* Only log when not connected to a USB host */
	if (!(LOCAL_Port_Read & (1<<LOCAL)))
	{
		uint16_t BytesWritten;

        if ((Day != oldday) & (LogfileCreateSuccess==true)) 	/* new day -> new logfile */
		{
			LEDs_SetAllLEDs(LEDMASK_USB_NOTREADY);
			/* Close the log file */
			CloseLogFile();
			DaysLeft_SRAM--;			                         // decrement day counter
			eeprom_update_word(&DaysLeft_EEPROM, DaysLeft_SRAM); // update eeprom value

			_delay_ms(250);
			/* Mount and open new log file on the Dataflash FAT partition */
			OpenLogFile();
			_delay_ms(250);
		}

		if ((LogfileCreateSuccess==true)&(Sensor2Received&Sensor3Received))
		{
			BytesWritten = sprintf(LineBuffer, "%02d:%02d:%02d,%d,%d,%d,%d\r\n", Hour, Minute, Second,
			Temperature, Humidity, Sensor2Value, Sensor3Value);

			f_write(&TempLogFile, LineBuffer, BytesWritten, &BytesWritten);
			f_sync(&TempLogFile);
		}

       	LEDs_SetAllLEDs(LEDS_NO_LEDS);

       	/* write tendency sign to lcd */
       	if (LCD_MODUL==4)
       	{
          lcd_pos (1, 20);
  	   	  if (Temperature > Sensor1PreviousValue + 1) lcd_write (0, 1);
  		    else if (Temperature < Sensor1PreviousValue - 1) lcd_write (1, 1);
          else lcd_print_str ("~");
          Sensor1PreviousValue = Temperature;

          lcd_pos(2,20);
          if (Sensor2Value > Sensor2PreviousValue) lcd_write (0, 1);
          else if (Sensor2Value < Sensor2PreviousValue) lcd_write (1, 1);
          else lcd_print_str ("~");
          Sensor2PreviousValue = Sensor2Value;

          lcd_pos(3,20);
          if (Sensor3Value > Sensor3PreviousValue) lcd_write (0, 1);
          else if (Sensor3Value < Sensor3PreviousValue) lcd_write (1, 1);
          else lcd_print_str ("~");
          Sensor3PreviousValue = Sensor3Value;

          LEDs_SetAllLEDs(LEDS_NO_LEDS);
        }
	}
	else LEDs_SetAllLEDs(LEDMask);
}

/** Main program entry point. This routine contains the overall program flow, including initial
 *  setup of all components and the main program loop.
 */
int main(void)
{
	SetupHardware();

	/* Mount and open the log file on the Dataflash FAT partition */
	OpenLogFile();

	LEDs_SetAllLEDs(LEDMASK_USB_NOTREADY);

	sei();                                       // enable all interrupts

	/* Discard the first sample from the temperature sensor, as it is generally incorrect */
	//volatile uint8_t Dummy = Temperature_GetTemperature();
	//(void)Dummy;

	for (;;)
	{
		if (!(LOCAL_Port_Read & (1<<LOCAL)))    // mode: temperature logging
		{
			RFM12_Port_Write &=~ (1<<NSEL); //NSEL = 0, chip select -> activ
			if (RFM12_Port_Read&(1<<SDO)) RadioReceive();
		}
		else
		{
        MS_Device_USBTask(&Disk_MS_Interface);      // USB mode -> connection to pc
        HID_Device_USBTask(&Generic_HID_Interface);
        USB_USBTask();
		}
	}
}

/** Receive telegram from radio modul*/
void RadioReceive(void)
{
    cli();                                          // disable all interrupts
   	DataReceived = (uchar) Spi16(0xb000);           // receiver FIFO read command

	if ((DataReceived == ETX)&rec_started)			// ETX -> end of telegram
    {
		bufferposition--;							// array last position (contents checksum)
		Checksum -= recbuf[bufferposition];			// correct checksum (the last value in array is the checksum)
		if (Checksum == recbuf[bufferposition]) 	// Checksum OK -> display new value
		{
		   recbuf[bufferposition] = '\0';			// set end of string, delete checksum
			if (recbuf[0]=='A')					    // Sensor A
			{
			        Sensor2Value = atoi(&recbuf[1]);		 // convert in integer
			        if (Sensor2Value != 0)
                    {
                        Sensor2Value -= 50;                       // check if conversion is ok, correct value with offset
                        Sensor2Value += Sensor2Correction_SRAM;  // correct value if conversion ok
                    }
			        else Sensor2Value = Sensor2PreviousValue;   // wrong values received

			        if (recbuf[1] == 'X')                         // display battery warning message
			        {
			            lcd_pos(2,10);
			            lcd_print_str("BATTERY    ");
			        }
               else lcd_print_value (Sensor2Value, "#C     ", '+', 2, 10, 2, 0);

              if (Sensor2Received)
              {
                  if (Sensor2Value < Sensor2MinValue) Sensor2MinValue = Sensor2Value;
                  if (Sensor2Value > Sensor2MaxValue) Sensor2MaxValue = Sensor2Value;
              }
              else
              {
                  Sensor2MinValue = Sensor2Value;
                  Sensor2MaxValue = Sensor2Value;
                  Sensor2Received = true;
              }

             Sensor2Timeout = 0;								 // reset timeout
			}
			if (recbuf[0]=='B')					                    // Sensor B
			{
			        Sensor3Value = atoi(&recbuf[1]);		 		// convert in integer
			        if (Sensor3Value != 0)
                    {
                        Sensor3Value -= 50;                         // check if conversion is ok, correct value with offset
                        Sensor3Value += Sensor3Correction_SRAM; 	// correct value if conversion ok
                    }
                    else Sensor3Value = Sensor3PreviousValue;       // // wrong values received

                    if (recbuf[1] == 'X')                         // display battery warning message
			        {
			            lcd_pos(3,10);
                        lcd_print_str("BATTERY    ");
			        }
              else lcd_print_value (Sensor3Value, "#C     ", '+', 3, 10, 2, 0);
              if (Sensor3Received)
              {
                  if (Sensor3Value < Sensor3MinValue) Sensor3MinValue = Sensor3Value;
                  if (Sensor3Value > Sensor3MaxValue) Sensor3MaxValue = Sensor3Value;
              }
              else
              {
                  Sensor3MinValue = Sensor3Value;
                  Sensor3MaxValue = Sensor3Value;
                  Sensor3Received = true;
              }
              Sensor3Timeout = 0;								 // reset timeout
            }
		}
        RestartFifoFill_receiver();
	    //Disable_receiver();
		rec_started = 0;
		bufferposition = 0;
		//Enable_receiver();
    }
    else
    {
		if (DataReceived == STX) 				// STX -> start of telegram -> save following characters
		 {
			rec_started = 1;
			Checksum = 0;
		 }
		else if ((rec_started) && (bufferposition < 6)) 	// save telegram content, n -> next array position
		{
		recbuf[bufferposition++] = DataReceived;
		Checksum += DataReceived;
		}
		else if (bufferposition>=5)					// over 5 characters received -> reject telegram
		{
        RestartFifoFill_receiver();
		//Disable_receiver();
		rec_started = 0;
		bufferposition = 0;
		//Enable_receiver();
 	    }
	}
	sei();                                          // enable all interrupts
}


/** Opens the log file on the Dataflash's FAT formatted partition according to the current date */
void OpenLogFile(void)
{
	char LogFileName[12];

	/* Get the current date for the filename as "X_DDMMYY.txt", X --> Sensor number */
	uint8_t Day, Month, Year;
	DS1307_GetDate(&Day, &Month, &Year);
	oldday=Day;
	sprintf(LogFileName, "%02d%02d%02d.txt", Day, Month, Year);

	f_mount(0, &DiskFATState);
	f_open(&TempLogFile, LogFileName, FA_OPEN_ALWAYS | FA_WRITE);
	f_lseek(&TempLogFile, TempLogFile.fsize);

	if (!(LOCAL_Port_Read & (1<<LOCAL)))
	{
		LogfileCreateSuccess = true;

		if (DaysLeft_SRAM > 0)
		{
			LogfileCreateSuccess = true;
		}
		else
		{
			LogfileCreateSuccess = false;
			CloseLogFile();
			lcd_pos(4,1);
			lcd_print_str("Memory full...      ");
			_delay_ms(2000);
		}
	}
	else
	{
		f_getfree (0, (DWORD*)&FreeMemory,(FATFS**)&DiskFATState);
	}
}

/** Closes the open data log file on the Dataflash's FAT formatted partition */
void CloseLogFile(void)
{
	/* Sync any data waiting to be written, unmount the storage device */
	f_sync(&TempLogFile);
	f_close(&TempLogFile);

}

/** Configures the board hardware and chip peripherals for the demo's functionality. */
void SetupHardware(void)
{
	/* Disable watchdog if enabled by bootloader/fuses */
	MCUSR &= ~(1 << WDRF);
	wdt_disable();

	/* Disable clock division */
	clock_prescale_set(clock_div_1);

	/* Hardware Initialization */
	LEDs_Init();
	SPI_Init(SPI_SPEED_FCPU_DIV_2 | SPI_SCK_LEAD_FALLING | SPI_SAMPLE_TRAILING | SPI_MODE_MASTER);
	//ADC_Init(ADC_FREE_RUNNING | ADC_PRESCALE_128);
	//Temperature_Init();     // if use of local NTC on AT90USBKey
	Dataflash_Init();
	//Serial_Init(9600, 0);   // initialize uart

	TWI_Init();
	lcd_init();
	GetCorrectionValues();

	MAX_Port_DDR &= MAX_DataInput;      //connection of max/min switch
	MAX_Port_Write |= (1<<MAXSWITCH);

    POWER_ENABLE_Port_Write &= ~(1<<POWER_ENABLE);      //disable Wiznet module
    POWER_ENABLE_Port_DDR |= POWER_ENABLE_DataOutput;

	DDRE |= 0x80;                       //disable UVCON - Q1 at AT90USBKey Board
	PORTE &= 0x7F;

	LOCAL_Port_DDR &= LOCAL_DataInput;  //determine if connect to usb
    if ((LOCAL_Port_Read & (1<<LOCAL))) USB_Init();  // init USB only if connected to pc

	/* Fetch logging interval from EEPROM */
	LoggingInterval500MS_SRAM = eeprom_read_word(&LoggingInterval500MS_EEPROM);

	/* Check if the logging interval is invalid (0xFF) indicating that the EEPROM is blank */
	if (LoggingInterval500MS_SRAM == 0xFF) LoggingInterval500MS_SRAM = DEFAULT_LOG_INTERVAL;


	/* Clear Dataflash sector protections, if enabled */
	DataflashManager_ResetDataflashProtections();

	/* Only if not connected to pc usb interface */
	if (!(LOCAL_Port_Read & (1<<LOCAL)))
	{
		char LineBuffer[16];
		int8_t Temperature=0;
        uint8_t Humidity=0;

       	lcd_print_str("Datalogger V1.1");
		lcd_pos (2,1);
		lcd_print_str("Kai Riedel, 2013");

        if (LCD_MODUL==4)
        {
            lcd_pos(3,1);
            sprintf (LineBuffer, "Days: %d", DaysLeft_SRAM);
            lcd_print_str(LineBuffer);

            lcd_pos(4,1);
            sprintf (LineBuffer, "Interval: %ds", LoggingInterval500MS_SRAM/2);
            lcd_print_str(LineBuffer);
        }

		_delay_ms(1500);

		lcd_clear();
		lcd_print_str(Sensor1Name_SRAM);

		//Temperature = Temperature_GetTemperature()+Sensor1Correction_SRAM; // if use of local NTC

		HYT321_GetData(&Humidity, &Temperature);

        if (LCD_MODUL==2)
        {
            lcd_print_value (Temperature+Sensor1Correction_SRAM, "#C", '+', 1, 8, 2, 0);
            lcd_print_value (Humidity, "% ", '/', 1, 13, 2, 0);
        }

        if (LCD_MODUL==4)
        {
            lcd_print_value (Temperature+Sensor1Correction_SRAM, "#C", '+', 1, 10, 2, 0);
            lcd_print_value (Humidity, "% ", '/', 1, 15, 2, 0);

            lcd_pos(2,1);
            lcd_print_str(Sensor2Name_SRAM);
            lcd_pos(2,10);
            lcd_print_str("---#C  ");

            lcd_pos(3,1);
            lcd_print_str(Sensor3Name_SRAM);
            lcd_pos(3,10);
            lcd_print_str("---#C  ");
        }

		RFM12_Init();			// init RFM12 radio modul

		Enable_receiver();		// enable radio receiver

		/* 500ms logging interval timer configuration */
        OCR1A   = (((F_CPU / 1024) / 2) - 1);
        TCCR1B  = (1 << WGM12) | (1 << CS12) | (1 << CS10);
        TIMSK1  = (1 << OCIE1A); // enable Timer 1 interrupt
	}
}

void GetCorrectionValues (void)
{
	/*	Fetch sensor names from EEPROM if not to USB connected*/
	eeprom_read_block(&Sensor1Name_SRAM,&Sensor1Name_EEPROM,8);
	if (Sensor1Name_SRAM[0] == 0xFF) sprintf(Sensor1Name_SRAM, DEFAULT_SENSOR1_NAME);

	eeprom_read_block(&Sensor2Name_SRAM,&Sensor2Name_EEPROM,8);
	if (Sensor2Name_SRAM[0] == 0xFF) sprintf(Sensor2Name_SRAM, DEFAULT_SENSOR2_NAME);

	eeprom_read_block(&Sensor3Name_SRAM,&Sensor3Name_EEPROM,8);
	if (Sensor3Name_SRAM[0] == 0xFF) sprintf(Sensor3Name_SRAM, DEFAULT_SENSOR3_NAME);

	/* Fetch correction values from EEPROM */
	Sensor1Correction_SRAM = eeprom_read_byte(&Sensor1Correction_EEPROM);
	Sensor2Correction_SRAM = eeprom_read_byte(&Sensor2Correction_EEPROM);
	Sensor3Correction_SRAM = eeprom_read_byte(&Sensor3Correction_EEPROM);

	/* Check if the correction values are invalid (0xFF) indicating that the EEPROM is blank */
	if (Sensor1Correction_SRAM == 0xFF) Sensor1Correction_SRAM = 0;
	if (Sensor2Correction_SRAM == 0xFF) Sensor2Correction_SRAM = 0;
	if (Sensor3Correction_SRAM == 0xFF) Sensor3Correction_SRAM = 0;

	/* Fetch days left from EEPROM */
	DaysLeft_SRAM = eeprom_read_word(&DaysLeft_EEPROM);
	if (DaysLeft_SRAM == 0xFFFF) DaysLeft_SRAM = 50;

}

/** Event handler for the library USB Connection event. */
void EVENT_USB_Device_Connect(void)
{
	LEDs_SetAllLEDs(LEDMASK_USB_ENUMERATING);

	/* Close the log file so that the host has exclusive filesystem access */
	CloseLogFile();

	lcd_clear();
	lcd_print_str("Connected to PC");

}

/** Event handler for the library USB Disconnection event. */
void EVENT_USB_Device_Disconnect(void)
{
	LEDs_SetAllLEDs(LEDMASK_USB_NOTREADY);

	/* Mount and open the log file on the Dataflash FAT partition */
	OpenLogFile();
}

/** Event handler for the library USB Configuration Changed event. */
void EVENT_USB_Device_ConfigurationChanged(void)
{
	bool ConfigSuccess = true;

	ConfigSuccess &= MS_Device_ConfigureEndpoints(&Disk_MS_Interface);
	ConfigSuccess &= HID_Device_ConfigureEndpoints(&Generic_HID_Interface);

	LEDs_SetAllLEDs(ConfigSuccess ? LEDMASK_USB_READY : LEDMASK_USB_ERROR);

}

void EVENT_USB_Device_Suspend(void)
{
    USB_ResetInterface();
}

/** Event handler for the library USB Control Request reception event. */
void EVENT_USB_Device_ControlRequest(void)
{
	MS_Device_ProcessControlRequest(&Disk_MS_Interface);
	HID_Device_ProcessControlRequest(&Generic_HID_Interface);
}

/** Mass Storage class driver callback function the reception of SCSI commands from the host, which must be processed.
 *
 *  \param[in] MSInterfaceInfo  Pointer to the Mass Storage class interface configuration structure being referenced
 */
bool CALLBACK_MS_Device_SCSICommandReceived(USB_ClassInfo_MS_Device_t* const MSInterfaceInfo)
{
	bool CommandSuccess;

	LEDs_SetAllLEDs(LEDMASK_USB_BUSY);
	CommandSuccess = SCSI_DecodeSCSICommand(MSInterfaceInfo);
	LEDs_SetAllLEDs(LEDMASK_USB_READY);

	return CommandSuccess;
}

/** HID class driver callback function for the creation of HID reports to the host.
 *
 *  \param[in]     HIDInterfaceInfo  Pointer to the HID class interface configuration structure being referenced
 *  \param[in,out] ReportID    Report ID requested by the host if non-zero, otherwise callback should set to the
 *                             generated report ID
 *  \param[in]     ReportType  Type of the report to create, either HID_REPORT_ITEM_In or HID_REPORT_ITEM_Feature
 *  \param[out]    ReportData  Pointer to a buffer where the created report should be stored
 *  \param[out]    ReportSize  Number of bytes written in the report (or zero if no report is to be sent
 *
 *  \return Boolean true to force the sending of the report, false to let the library determine if it needs to be sent
 */
bool CALLBACK_HID_Device_CreateHIDReport(USB_ClassInfo_HID_Device_t* const HIDInterfaceInfo,
                                         uint8_t* const ReportID,
                                         const uint8_t ReportType,
                                         void* ReportData,
                                         uint16_t* const ReportSize)
{
	Device_Report_t* ReportParams = (Device_Report_t*)ReportData;
	int8_t Temperature=0;
    uint8_t Humidity=0;

	DS1307_GetDate(&ReportParams->Day,  &ReportParams->Month,  &ReportParams->Year);
	DS1307_GetTime(&ReportParams->Hour, &ReportParams->Minute, &ReportParams->Second);

	ReportParams->LogInterval500MS = LoggingInterval500MS_SRAM;

	//GetCorrectionValues();

	ReportParams->Sensor1Correction = Sensor1Correction_SRAM;
	ReportParams->Sensor2Correction = Sensor2Correction_SRAM;
	ReportParams->Sensor3Correction = Sensor3Correction_SRAM;

    //Temperature = Temperature_GetTemperature();   // if use of local NTC
    HYT321_GetData(&Humidity, &Temperature);

	ReportParams->Sensor1Temperature = Temperature+Sensor1Correction_SRAM;
	ReportParams->Sensor1Humidity = Humidity;

	ReportParams->FreeMemory = FreeMemory;

    memcpy (ReportParams->Sensor1Name, Sensor1Name_SRAM, 8);
    memcpy (ReportParams->Sensor2Name, Sensor2Name_SRAM, 8);
    memcpy (ReportParams->Sensor3Name, Sensor3Name_SRAM, 8);

	*ReportSize = sizeof(Device_Report_t);
	return true;
}

/** HID class driver callback function for the processing of HID reports from the host.
 *
 *  \param[in] HIDInterfaceInfo  Pointer to the HID class interface configuration structure being referenced
 *  \param[in] ReportID    Report ID of the received report from the host
 *  \param[in] ReportType  The type of report that the host has sent, either HID_REPORT_ITEM_Out or HID_REPORT_ITEM_Feature
 *  \param[in] ReportData  Pointer to a buffer where the created report has been stored
 *  \param[in] ReportSize  Size in bytes of the received HID report
 */
void CALLBACK_HID_Device_ProcessHIDReport(USB_ClassInfo_HID_Device_t* const HIDInterfaceInfo,
                                          const uint8_t ReportID,
                                          const uint8_t ReportType,
                                          const void* ReportData,
                                          const uint16_t ReportSize)
{
	Device_Report_t* ReportParams = (Device_Report_t*)ReportData;

	DS1307_SetDate(ReportParams->Day,  ReportParams->Month,  ReportParams->Year);
	DS1307_SetTime(ReportParams->Hour, ReportParams->Minute, ReportParams->Second);

	/* If the logging interval has changed from its current value, write it to EEPROM */
	if (LoggingInterval500MS_SRAM != ReportParams->LogInterval500MS)
	{
		LoggingInterval500MS_SRAM = ReportParams->LogInterval500MS;
		eeprom_update_word(&LoggingInterval500MS_EEPROM, LoggingInterval500MS_SRAM);
	}

	if (Sensor1Correction_SRAM != ReportParams->Sensor1Correction)
	{
		Sensor1Correction_SRAM = ReportParams->Sensor1Correction;
		eeprom_update_byte(&Sensor1Correction_EEPROM, Sensor1Correction_SRAM);
	}

	if (Sensor2Correction_SRAM != ReportParams->Sensor2Correction)
	{
		Sensor2Correction_SRAM = ReportParams->Sensor2Correction;
		eeprom_update_byte(&Sensor2Correction_EEPROM, Sensor2Correction_SRAM);
	}

	if (Sensor3Correction_SRAM != ReportParams->Sensor3Correction)
	{
		Sensor3Correction_SRAM = ReportParams->Sensor3Correction;
		eeprom_update_byte(&Sensor3Correction_EEPROM, Sensor3Correction_SRAM);
	}

	if (DaysLeft_SRAM  != ReportParams->DaysLeft)
	{
		DaysLeft_SRAM  = ReportParams->DaysLeft;
		eeprom_update_word(&DaysLeft_EEPROM, DaysLeft_SRAM);
	}


    lcd_clear();

    memcpy (Sensor1Name_SRAM, ReportParams->Sensor1Name, 8);
    eeprom_update_block(&Sensor1Name_SRAM, &Sensor1Name_EEPROM, 8);
    lcd_print_str(Sensor1Name_SRAM);

    if (LCD_MODUL==4)
    {
        memcpy (Sensor2Name_SRAM, ReportParams->Sensor2Name, 8);
        eeprom_update_block(&Sensor2Name_SRAM, &Sensor2Name_EEPROM, 8);
        lcd_pos(2,1);
        lcd_print_str(Sensor2Name_SRAM);

        memcpy (Sensor3Name_SRAM, ReportParams->Sensor3Name, 8);
        eeprom_update_block(&Sensor3Name_SRAM, &Sensor3Name_EEPROM, 8);
        lcd_pos(3,1);
        lcd_print_str(Sensor3Name_SRAM);
    }

    lcd_pos(LCD_MODUL, 1);
    lcd_print_str("Config new...");
}
