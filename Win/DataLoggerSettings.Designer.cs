namespace Project1HostApp
{
    partial class frmDataloggerSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataloggerSettings));
            this.btnSetValues = new System.Windows.Forms.Button();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblLoggingInterval = new System.Windows.Forms.Label();
            this.nudLogInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.btnGetValues = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtlocation3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudcorrection3 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblfreemem = new System.Windows.Forms.Label();
            this.lbldays = new System.Windows.Forms.Label();
            this.cBTime = new System.Windows.Forms.CheckBox();
            this.txtdayleft = new System.Windows.Forms.TextBox();
            this.txtfreemem = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtlocation2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudcorrection2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txttemp1 = new System.Windows.Forms.TextBox();
            this.txtlocation1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudcorrection1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dGVFiles = new System.Windows.Forms.DataGridView();
            this.Datei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dateiname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBTimer = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReadFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBCurve0 = new System.Windows.Forms.CheckBox();
            this.cBCurve3 = new System.Windows.Forms.CheckBox();
            this.cBCurve2 = new System.Windows.Forms.CheckBox();
            this.cBCurve1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerclockstatus = new System.Windows.Forms.Timer(this.components);
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudLogInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection3)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFiles)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetValues
            // 
            this.btnSetValues.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSetValues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSetValues.Location = new System.Drawing.Point(246, 97);
            this.btnSetValues.Name = "btnSetValues";
            this.btnSetValues.Size = new System.Drawing.Size(77, 30);
            this.btnSetValues.TabIndex = 0;
            this.btnSetValues.Text = "Set Values";
            this.btnSetValues.UseVisualStyleBackColor = true;
            this.btnSetValues.Click += new System.EventHandler(this.btnSetValues_Click);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(124, 68);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(109, 21);
            this.dtpTime.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(39, 72);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Device Time:";
            // 
            // lblLoggingInterval
            // 
            this.lblLoggingInterval.AutoSize = true;
            this.lblLoggingInterval.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggingInterval.Location = new System.Drawing.Point(15, 106);
            this.lblLoggingInterval.Margin = new System.Windows.Forms.Padding(0);
            this.lblLoggingInterval.Name = "lblLoggingInterval";
            this.lblLoggingInterval.Size = new System.Drawing.Size(103, 13);
            this.lblLoggingInterval.TabIndex = 3;
            this.lblLoggingInterval.Text = "Logging Interval:";
            // 
            // nudLogInterval
            // 
            this.nudLogInterval.Location = new System.Drawing.Point(125, 102);
            this.nudLogInterval.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.nudLogInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLogInterval.Name = "nudLogInterval";
            this.nudLogInterval.Size = new System.Drawing.Size(50, 21);
            this.nudLogInterval.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nudLogInterval, "interval for data logging on device");
            this.nudLogInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLogInterval.ValueChanged += new System.EventHandler(this.nudLogInterval_ValueChanged);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(183, 106);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(47, 13);
            this.lblSeconds.TabIndex = 6;
            this.lblSeconds.Text = "Seconds";
            // 
            // btnGetValues
            // 
            this.btnGetValues.Location = new System.Drawing.Point(246, 29);
            this.btnGetValues.Name = "btnGetValues";
            this.btnGetValues.Size = new System.Drawing.Size(77, 30);
            this.btnGetValues.TabIndex = 7;
            this.btnGetValues.Text = "Get Values";
            this.btnGetValues.UseVisualStyleBackColor = true;
            this.btnGetValues.Click += new System.EventHandler(this.btnGetValues_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(40, 37);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(78, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Device Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(124, 34);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(109, 21);
            this.dtpDate.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 342);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 310);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.txtlocation3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.nudcorrection3);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(461, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 149);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sensor 3";
            // 
            // txtlocation3
            // 
            this.txtlocation3.Location = new System.Drawing.Point(124, 31);
            this.txtlocation3.MaxLength = 8;
            this.txtlocation3.Name = "txtlocation3";
            this.txtlocation3.Size = new System.Drawing.Size(86, 21);
            this.txtlocation3.TabIndex = 9;
            this.txtlocation3.Text = "Sensor 3";
            this.toolTip1.SetToolTip(this.txtlocation3, "Input location or name of rf-sensor B");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(62, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Location:";
            // 
            // nudcorrection3
            // 
            this.nudcorrection3.Location = new System.Drawing.Point(124, 66);
            this.nudcorrection3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudcorrection3.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudcorrection3.Name = "nudcorrection3";
            this.nudcorrection3.Size = new System.Drawing.Size(51, 21);
            this.nudcorrection3.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nudcorrection3, "correction value for rf-sensor B");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "°C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Temp. Correction:";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.AutoSize = true;
            this.groupBoxSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxSettings, 3);
            this.groupBoxSettings.Controls.Add(this.lblfreemem);
            this.groupBoxSettings.Controls.Add(this.lbldays);
            this.groupBoxSettings.Controls.Add(this.cBTime);
            this.groupBoxSettings.Controls.Add(this.btnSetValues);
            this.groupBoxSettings.Controls.Add(this.txtdayleft);
            this.groupBoxSettings.Controls.Add(this.txtfreemem);
            this.groupBoxSettings.Controls.Add(this.lblDate);
            this.groupBoxSettings.Controls.Add(this.nudLogInterval);
            this.groupBoxSettings.Controls.Add(this.lblSeconds);
            this.groupBoxSettings.Controls.Add(this.dtpDate);
            this.groupBoxSettings.Controls.Add(this.lblLoggingInterval);
            this.groupBoxSettings.Controls.Add(this.dtpTime);
            this.groupBoxSettings.Controls.Add(this.btnGetValues);
            this.groupBoxSettings.Controls.Add(this.lblTime);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(682, 149);
            this.groupBoxSettings.TabIndex = 10;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "General Settings";
            // 
            // lblfreemem
            // 
            this.lblfreemem.AutoSize = true;
            this.lblfreemem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfreemem.Location = new System.Drawing.Point(399, 38);
            this.lblfreemem.Margin = new System.Windows.Forms.Padding(0);
            this.lblfreemem.Name = "lblfreemem";
            this.lblfreemem.Size = new System.Drawing.Size(85, 13);
            this.lblfreemem.TabIndex = 8;
            this.lblfreemem.Text = "Free Memory:";
            // 
            // lbldays
            // 
            this.lbldays.AutoSize = true;
            this.lbldays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldays.Location = new System.Drawing.Point(422, 70);
            this.lbldays.Margin = new System.Windows.Forms.Padding(0);
            this.lbldays.Name = "lbldays";
            this.lbldays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbldays.Size = new System.Drawing.Size(62, 18);
            this.lbldays.TabIndex = 8;
            this.lbldays.Text = "Days Left:";
            this.lbldays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbldays.UseCompatibleTextRendering = true;
            // 
            // cBTime
            // 
            this.cBTime.AutoSize = true;
            this.cBTime.Checked = true;
            this.cBTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBTime.Location = new System.Drawing.Point(246, 70);
            this.cBTime.Name = "cBTime";
            this.cBTime.Size = new System.Drawing.Size(135, 17);
            this.cBTime.TabIndex = 10;
            this.cBTime.Text = "Use Actual Date / Time";
            this.toolTip1.SetToolTip(this.cBTime, "use actual system values or set the values in the input fields (may be old values" +
                    ")");
            this.cBTime.UseVisualStyleBackColor = true;
            // 
            // txtdayleft
            // 
            this.txtdayleft.Location = new System.Drawing.Point(488, 69);
            this.txtdayleft.Name = "txtdayleft";
            this.txtdayleft.Size = new System.Drawing.Size(90, 21);
            this.txtdayleft.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtdayleft, "available days for data logging on device");
            // 
            // txtfreemem
            // 
            this.txtfreemem.Location = new System.Drawing.Point(488, 34);
            this.txtfreemem.Name = "txtfreemem";
            this.txtfreemem.Size = new System.Drawing.Size(90, 21);
            this.txtfreemem.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtfreemem, "info about memory space on device");
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.txtlocation2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nudcorrection2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(232, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 149);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensor 2";
            // 
            // txtlocation2
            // 
            this.txtlocation2.Location = new System.Drawing.Point(124, 31);
            this.txtlocation2.MaxLength = 8;
            this.txtlocation2.Name = "txtlocation2";
            this.txtlocation2.Size = new System.Drawing.Size(86, 21);
            this.txtlocation2.TabIndex = 9;
            this.txtlocation2.Text = "Sensor 2";
            this.toolTip1.SetToolTip(this.txtlocation2, "Input location or name of rf-sensor A");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Location:";
            // 
            // nudcorrection2
            // 
            this.nudcorrection2.Location = new System.Drawing.Point(124, 66);
            this.nudcorrection2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudcorrection2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudcorrection2.Name = "nudcorrection2";
            this.nudcorrection2.Size = new System.Drawing.Size(51, 21);
            this.nudcorrection2.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nudcorrection2, "correction value for rf-sensor A");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Temp. Correction:";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.txttemp1);
            this.groupBox2.Controls.Add(this.txtlocation1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudcorrection1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 149);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor 1";
            // 
            // txttemp1
            // 
            this.txttemp1.Location = new System.Drawing.Point(124, 99);
            this.txttemp1.Name = "txttemp1";
            this.txttemp1.ReadOnly = true;
            this.txttemp1.Size = new System.Drawing.Size(86, 21);
            this.txttemp1.TabIndex = 9;
            // 
            // txtlocation1
            // 
            this.txtlocation1.Location = new System.Drawing.Point(124, 31);
            this.txtlocation1.MaxLength = 8;
            this.txtlocation1.Name = "txtlocation1";
            this.txtlocation1.Size = new System.Drawing.Size(86, 21);
            this.txtlocation1.TabIndex = 9;
            this.txtlocation1.Text = "Sensor 1";
            this.toolTip1.SetToolTip(this.txtlocation1, "Input location or name of sensor 1 (local sensor)");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Actual Values:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Location:";
            // 
            // nudcorrection1
            // 
            this.nudcorrection1.Location = new System.Drawing.Point(124, 65);
            this.nudcorrection1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudcorrection1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudcorrection1.Name = "nudcorrection1";
            this.nudcorrection1.Size = new System.Drawing.Size(51, 21);
            this.nudcorrection1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nudcorrection1, "correction value for local sensor");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "°C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Temp. Correction:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dGVFiles);
            this.splitContainer1.Panel1.Controls.Add(this.cBTimer);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnReadFolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(688, 310);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 11;
            // 
            // dGVFiles
            // 
            this.dGVFiles.AllowUserToAddRows = false;
            this.dGVFiles.AllowUserToDeleteRows = false;
            this.dGVFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dGVFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGVFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datei,
            this.Dateiname});
            this.dGVFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVFiles.Location = new System.Drawing.Point(0, 0);
            this.dGVFiles.Name = "dGVFiles";
            this.dGVFiles.ReadOnly = true;
            this.dGVFiles.RowHeadersVisible = false;
            this.dGVFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dGVFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVFiles.Size = new System.Drawing.Size(204, 245);
            this.dGVFiles.TabIndex = 13;
            this.toolTip1.SetToolTip(this.dGVFiles, "choose logging file to display");
            this.dGVFiles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGVFiles_CellMouseClick);
            // 
            // Datei
            // 
            this.Datei.HeaderText = "Date";
            this.Datei.Name = "Datei";
            this.Datei.ReadOnly = true;
            // 
            // Dateiname
            // 
            this.Dateiname.HeaderText = "Filename";
            this.Dateiname.Name = "Dateiname";
            this.Dateiname.ReadOnly = true;
            // 
            // cBTimer
            // 
            this.cBTimer.AutoSize = true;
            this.cBTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBTimer.Location = new System.Drawing.Point(0, 245);
            this.cBTimer.Name = "cBTimer";
            this.cBTimer.Size = new System.Drawing.Size(204, 17);
            this.cBTimer.TabIndex = 14;
            this.cBTimer.Text = "Read actual values (5s interval)";
            this.toolTip1.SetToolTip(this.cBTimer, "read local sensor values (maximum 120 values -> 10 min)");
            this.cBTimer.UseVisualStyleBackColor = true;
            this.cBTimer.CheckedChanged += new System.EventHandler(this.cBTimer_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClear.Location = new System.Drawing.Point(0, 262);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(204, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear Graph";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReadFolder
            // 
            this.btnReadFolder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReadFolder.Location = new System.Drawing.Point(0, 285);
            this.btnReadFolder.Name = "btnReadFolder";
            this.btnReadFolder.Size = new System.Drawing.Size(204, 25);
            this.btnReadFolder.TabIndex = 12;
            this.btnReadFolder.Text = "Read folder...";
            this.toolTip1.SetToolTip(this.btnReadFolder, "choose folder with logging datas");
            this.btnReadFolder.UseVisualStyleBackColor = true;
            this.btnReadFolder.Click += new System.EventHandler(this.btnReadFolder_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.zedGraphControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 310);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(474, 279);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.cBCurve0);
            this.panel1.Controls.Add(this.cBCurve3);
            this.panel1.Controls.Add(this.cBCurve2);
            this.panel1.Controls.Add(this.cBCurve1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 19);
            this.panel1.TabIndex = 1;
            // 
            // cBCurve0
            // 
            this.cBCurve0.AutoSize = true;
            this.cBCurve0.Checked = true;
            this.cBCurve0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBCurve0.Location = new System.Drawing.Point(3, 3);
            this.cBCurve0.Name = "cBCurve0";
            this.cBCurve0.Size = new System.Drawing.Size(140, 17);
            this.cBCurve0.TabIndex = 1;
            this.cBCurve0.Text = "Sensor 1 - Temperature";
            this.cBCurve0.UseVisualStyleBackColor = true;
            // 
            // cBCurve3
            // 
            this.cBCurve3.AutoSize = true;
            this.cBCurve3.Checked = true;
            this.cBCurve3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBCurve3.Location = new System.Drawing.Point(345, 3);
            this.cBCurve3.Name = "cBCurve3";
            this.cBCurve3.Size = new System.Drawing.Size(68, 17);
            this.cBCurve3.TabIndex = 1;
            this.cBCurve3.Text = "Sensor 3";
            this.cBCurve3.UseVisualStyleBackColor = true;
            // 
            // cBCurve2
            // 
            this.cBCurve2.AutoSize = true;
            this.cBCurve2.Checked = true;
            this.cBCurve2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBCurve2.Location = new System.Drawing.Point(273, 3);
            this.cBCurve2.Name = "cBCurve2";
            this.cBCurve2.Size = new System.Drawing.Size(68, 17);
            this.cBCurve2.TabIndex = 1;
            this.cBCurve2.Text = "Sensor 2";
            this.cBCurve2.UseVisualStyleBackColor = true;
            // 
            // cBCurve1
            // 
            this.cBCurve1.AutoSize = true;
            this.cBCurve1.Checked = true;
            this.cBCurve1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBCurve1.Location = new System.Drawing.Point(148, 3);
            this.cBCurve1.Name = "cBCurve1";
            this.cBCurve1.Size = new System.Drawing.Size(119, 17);
            this.cBCurve1.TabIndex = 1;
            this.cBCurve1.Text = "Sensor 1 - Humidity";
            this.cBCurve1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCopyright,
            this.toolStripStatusLabelDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(702, 24);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCopyright
            // 
            this.toolStripStatusLabelCopyright.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelCopyright.Name = "toolStripStatusLabelCopyright";
            this.toolStripStatusLabelCopyright.Size = new System.Drawing.Size(82, 19);
            this.toolStripStatusLabelCopyright.Text = "K. Riedel, 2011";
            this.toolStripStatusLabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelDate
            // 
            this.toolStripStatusLabelDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
            this.toolStripStatusLabelDate.Size = new System.Drawing.Size(35, 19);
            this.toolStripStatusLabelDate.Text = "Date";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Logdateien (*.txt)|*.txt";
            // 
            // timerclockstatus
            // 
            this.timerclockstatus.Enabled = true;
            this.timerclockstatus.Interval = 500;
            this.timerclockstatus.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerRead
            // 
            this.timerRead.Interval = 5000;
            this.timerRead.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmDataloggerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(702, 366);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(704, 400);
            this.Name = "frmDataloggerSettings";
            this.Text = "Temperature DataLogger";
            this.Load += new System.EventHandler(this.frmDataloggerSettings_Load);
            this.Resize += new System.EventHandler(this.frmDataloggerSettings_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudLogInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection3)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcorrection1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVFiles)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetValues;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLoggingInterval;
        private System.Windows.Forms.NumericUpDown nudLogInterval;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Button btnGetValues;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnReadFolder;
        private System.Windows.Forms.DataGridView dGVFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TextBox txtlocation1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudcorrection1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerclockstatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtlocation3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudcorrection3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtlocation2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudcorrection2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datei;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dateiname;
        private System.Windows.Forms.TextBox txttemp1;
        private System.Windows.Forms.TextBox txtdayleft;
        private System.Windows.Forms.TextBox txtfreemem;
        private System.Windows.Forms.Label lbldays;
        private System.Windows.Forms.Label lblfreemem;
        private System.Windows.Forms.CheckBox cBTime;
        private System.Windows.Forms.CheckBox cBCurve0;
        private System.Windows.Forms.CheckBox cBCurve2;
        private System.Windows.Forms.CheckBox cBCurve1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCopyright;
        private System.Windows.Forms.CheckBox cBCurve3;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.CheckBox cBTimer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

