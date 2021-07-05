namespace BioSeqDB
{
  partial class BioSeqBackupOffsite
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
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtTargetPath = new System.Windows.Forms.TextBox();
      this.btnFindTargetPath = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbUser = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnFolderPicker = new System.Windows.Forms.Button();
      this.grpRecurrence = new System.Windows.Forms.GroupBox();
      this.pnlWeek = new System.Windows.Forms.Panel();
      this.label12 = new System.Windows.Forms.Label();
      this.chkWeekSaturday = new System.Windows.Forms.CheckBox();
      this.chkWeekFriday = new System.Windows.Forms.CheckBox();
      this.chkWeekThursday = new System.Windows.Forms.CheckBox();
      this.chkWeekWednesday = new System.Windows.Forms.CheckBox();
      this.chkWeekTuesday = new System.Windows.Forms.CheckBox();
      this.chkWeekMonday = new System.Windows.Forms.CheckBox();
      this.chkWeekSunday = new System.Windows.Forms.CheckBox();
      this.txtWeekWeek = new System.Windows.Forms.TextBox();
      this.radWeekRule1 = new System.Windows.Forms.RadioButton();
      this.pnlDay = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.radDaySubrule2 = new System.Windows.Forms.RadioButton();
      this.txtDayDay = new System.Windows.Forms.TextBox();
      this.radDaySubrule1 = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.radYearly = new System.Windows.Forms.RadioButton();
      this.radMonthly = new System.Windows.Forms.RadioButton();
      this.radWeekly = new System.Windows.Forms.RadioButton();
      this.radDaily = new System.Windows.Forms.RadioButton();
      this.pnlYear = new System.Windows.Forms.Panel();
      this.cmbYearMonths = new System.Windows.Forms.ComboBox();
      this.txtYearDayOfMonth = new System.Windows.Forms.TextBox();
      this.radYearEvery = new System.Windows.Forms.RadioButton();
      this.pnlMonth = new System.Windows.Forms.Panel();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbMonthDayOfWeek = new System.Windows.Forms.ComboBox();
      this.txtMonthMonths2 = new System.Windows.Forms.TextBox();
      this.cmbMonthFirst = new System.Windows.Forms.ComboBox();
      this.radMonthSubrule2 = new System.Windows.Forms.RadioButton();
      this.txtMonthMonths1 = new System.Windows.Forms.TextBox();
      this.txtMonthDay = new System.Windows.Forms.TextBox();
      this.radMonthSubrule1 = new System.Windows.Forms.RadioButton();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.txtScheduledTOD = new System.Windows.Forms.TextBox();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.dgvFolders = new System.Windows.Forms.DataGridView();
      this.colChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colCompress = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.colRetention = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colFolderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.button1 = new System.Windows.Forms.Button();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtLastBackupTimeEnd = new System.Windows.Forms.TextBox();
      this.txtLastBackupDateEnd = new System.Windows.Forms.TextBox();
      this.lblLastBackupEnd = new System.Windows.Forms.Label();
      this.txtLastBackupTime = new System.Windows.Forms.TextBox();
      this.txtLastBackupDate = new System.Windows.Forms.TextBox();
      this.lblLastBackupBegin = new System.Windows.Forms.Label();
      this.grpRecurrence.SuspendLayout();
      this.pnlWeek.SuspendLayout();
      this.pnlDay.SuspendLayout();
      this.pnlYear.SuspendLayout();
      this.pnlMonth.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(712, 40);
      this.label4.TabIndex = 13;
      this.label4.Text = "The priority folders on the storage repository are backed up to a target device. " +
    " The backup is scheduled on a regular basis and the individual managing this pro" +
    "cess is notified.";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 85);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(151, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Target device and folder:";
      // 
      // txtTargetPath
      // 
      this.txtTargetPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtTargetPath.Location = new System.Drawing.Point(12, 101);
      this.txtTargetPath.Name = "txtTargetPath";
      this.txtTargetPath.ReadOnly = true;
      this.txtTargetPath.Size = new System.Drawing.Size(536, 20);
      this.txtTargetPath.TabIndex = 1;
      this.txtTargetPath.TextChanged += new System.EventHandler(this.txtDBPath_TextChanged);
      // 
      // btnFindTargetPath
      // 
      this.btnFindTargetPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindTargetPath.Location = new System.Drawing.Point(546, 100);
      this.btnFindTargetPath.Name = "btnFindTargetPath";
      this.btnFindTargetPath.Size = new System.Drawing.Size(31, 22);
      this.btnFindTargetPath.TabIndex = 2;
      this.btnFindTargetPath.Text = "...";
      this.btnFindTargetPath.UseVisualStyleBackColor = true;
      this.btnFindTargetPath.Click += new System.EventHandler(this.btnFindTargetPath_Click);
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(586, 571);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(89, 22);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "Run backup";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatAppearance.BorderSize = 2;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(681, 571);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(124, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Managing individual:";
      // 
      // cmbUser
      // 
      this.cmbUser.FormattingEnabled = true;
      this.cmbUser.Location = new System.Drawing.Point(138, 55);
      this.cmbUser.Margin = new System.Windows.Forms.Padding(2);
      this.cmbUser.Name = "cmbUser";
      this.cmbUser.Size = new System.Drawing.Size(83, 21);
      this.cmbUser.Sorted = true;
      this.cmbUser.TabIndex = 33;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 124);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(157, 13);
      this.label5.TabIndex = 35;
      this.label5.Text = "Priority folders to back up:";
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkAll.Location = new System.Drawing.Point(15, 144);
      this.chkAll.Name = "chkAll";
      this.chkAll.Size = new System.Drawing.Size(71, 17);
      this.chkAll.TabIndex = 39;
      this.chkAll.Text = "(all/none)";
      this.chkAll.UseVisualStyleBackColor = true;
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Location = new System.Drawing.Point(594, 190);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(130, 23);
      this.btnDelete.TabIndex = 38;
      this.btnDelete.Text = "Remove unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnFolderPicker
      // 
      this.btnFolderPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFolderPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFolderPicker.Location = new System.Drawing.Point(594, 161);
      this.btnFolderPicker.Name = "btnFolderPicker";
      this.btnFolderPicker.Size = new System.Drawing.Size(130, 23);
      this.btnFolderPicker.TabIndex = 37;
      this.btnFolderPicker.Text = "Folder picker...";
      this.btnFolderPicker.UseVisualStyleBackColor = true;
      this.btnFolderPicker.Click += new System.EventHandler(this.btnFolderPicker_Click);
      // 
      // grpRecurrence
      // 
      this.grpRecurrence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.grpRecurrence.Controls.Add(this.pnlWeek);
      this.grpRecurrence.Controls.Add(this.pnlDay);
      this.grpRecurrence.Controls.Add(this.panel1);
      this.grpRecurrence.Controls.Add(this.radYearly);
      this.grpRecurrence.Controls.Add(this.radMonthly);
      this.grpRecurrence.Controls.Add(this.radWeekly);
      this.grpRecurrence.Controls.Add(this.radDaily);
      this.grpRecurrence.Controls.Add(this.pnlYear);
      this.grpRecurrence.Controls.Add(this.pnlMonth);
      this.grpRecurrence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.grpRecurrence.Location = new System.Drawing.Point(12, 354);
      this.grpRecurrence.Name = "grpRecurrence";
      this.grpRecurrence.Size = new System.Drawing.Size(557, 178);
      this.grpRecurrence.TabIndex = 185;
      this.grpRecurrence.TabStop = false;
      this.grpRecurrence.Text = "Schedule:";
      // 
      // pnlWeek
      // 
      this.pnlWeek.Controls.Add(this.label12);
      this.pnlWeek.Controls.Add(this.chkWeekSaturday);
      this.pnlWeek.Controls.Add(this.chkWeekFriday);
      this.pnlWeek.Controls.Add(this.chkWeekThursday);
      this.pnlWeek.Controls.Add(this.chkWeekWednesday);
      this.pnlWeek.Controls.Add(this.chkWeekTuesday);
      this.pnlWeek.Controls.Add(this.chkWeekMonday);
      this.pnlWeek.Controls.Add(this.chkWeekSunday);
      this.pnlWeek.Controls.Add(this.txtWeekWeek);
      this.pnlWeek.Controls.Add(this.radWeekRule1);
      this.pnlWeek.Location = new System.Drawing.Point(105, 61);
      this.pnlWeek.Name = "pnlWeek";
      this.pnlWeek.Size = new System.Drawing.Size(390, 87);
      this.pnlWeek.TabIndex = 175;
      this.pnlWeek.Visible = false;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(138, 13);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(51, 13);
      this.label12.TabIndex = 193;
      this.label12.Text = "week(s)";
      // 
      // chkWeekSaturday
      // 
      this.chkWeekSaturday.AutoSize = true;
      this.chkWeekSaturday.Location = new System.Drawing.Point(202, 59);
      this.chkWeekSaturday.Name = "chkWeekSaturday";
      this.chkWeekSaturday.Size = new System.Drawing.Size(76, 17);
      this.chkWeekSaturday.TabIndex = 184;
      this.chkWeekSaturday.Text = "Saturday";
      this.chkWeekSaturday.UseVisualStyleBackColor = true;
      this.chkWeekSaturday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekFriday
      // 
      this.chkWeekFriday.AutoSize = true;
      this.chkWeekFriday.Location = new System.Drawing.Point(121, 59);
      this.chkWeekFriday.Name = "chkWeekFriday";
      this.chkWeekFriday.Size = new System.Drawing.Size(60, 17);
      this.chkWeekFriday.TabIndex = 183;
      this.chkWeekFriday.Text = "Friday";
      this.chkWeekFriday.UseVisualStyleBackColor = true;
      this.chkWeekFriday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekThursday
      // 
      this.chkWeekThursday.AutoSize = true;
      this.chkWeekThursday.Location = new System.Drawing.Point(38, 59);
      this.chkWeekThursday.Name = "chkWeekThursday";
      this.chkWeekThursday.Size = new System.Drawing.Size(78, 17);
      this.chkWeekThursday.TabIndex = 182;
      this.chkWeekThursday.Text = "Thursday";
      this.chkWeekThursday.UseVisualStyleBackColor = true;
      this.chkWeekThursday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekWednesday
      // 
      this.chkWeekWednesday.AutoSize = true;
      this.chkWeekWednesday.Location = new System.Drawing.Point(282, 39);
      this.chkWeekWednesday.Name = "chkWeekWednesday";
      this.chkWeekWednesday.Size = new System.Drawing.Size(92, 17);
      this.chkWeekWednesday.TabIndex = 181;
      this.chkWeekWednesday.Text = "Wednesday";
      this.chkWeekWednesday.UseVisualStyleBackColor = true;
      this.chkWeekWednesday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekTuesday
      // 
      this.chkWeekTuesday.AutoSize = true;
      this.chkWeekTuesday.Location = new System.Drawing.Point(202, 40);
      this.chkWeekTuesday.Name = "chkWeekTuesday";
      this.chkWeekTuesday.Size = new System.Drawing.Size(74, 17);
      this.chkWeekTuesday.TabIndex = 180;
      this.chkWeekTuesday.Text = "Tuesday";
      this.chkWeekTuesday.UseVisualStyleBackColor = true;
      this.chkWeekTuesday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekMonday
      // 
      this.chkWeekMonday.AutoSize = true;
      this.chkWeekMonday.Location = new System.Drawing.Point(121, 40);
      this.chkWeekMonday.Name = "chkWeekMonday";
      this.chkWeekMonday.Size = new System.Drawing.Size(70, 17);
      this.chkWeekMonday.TabIndex = 179;
      this.chkWeekMonday.Text = "Monday";
      this.chkWeekMonday.UseVisualStyleBackColor = true;
      this.chkWeekMonday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // chkWeekSunday
      // 
      this.chkWeekSunday.AutoSize = true;
      this.chkWeekSunday.Location = new System.Drawing.Point(38, 40);
      this.chkWeekSunday.Name = "chkWeekSunday";
      this.chkWeekSunday.Size = new System.Drawing.Size(68, 17);
      this.chkWeekSunday.TabIndex = 178;
      this.chkWeekSunday.Text = "Sunday";
      this.chkWeekSunday.UseVisualStyleBackColor = true;
      this.chkWeekSunday.CheckedChanged += new System.EventHandler(this.chkWeekFriday_CheckedChanged);
      // 
      // txtWeekWeek
      // 
      this.txtWeekWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtWeekWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtWeekWeek.ForeColor = System.Drawing.Color.Black;
      this.txtWeekWeek.Location = new System.Drawing.Point(104, 11);
      this.txtWeekWeek.MaxLength = 3;
      this.txtWeekWeek.Name = "txtWeekWeek";
      this.txtWeekWeek.Size = new System.Drawing.Size(28, 20);
      this.txtWeekWeek.TabIndex = 174;
      this.txtWeekWeek.Text = "1";
      this.txtWeekWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtWeekWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtWeekWeek.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtWeekWeek_KeyUp);
      // 
      // radWeekRule1
      // 
      this.radWeekRule1.AutoSize = true;
      this.radWeekRule1.Checked = true;
      this.radWeekRule1.Location = new System.Drawing.Point(12, 11);
      this.radWeekRule1.Name = "radWeekRule1";
      this.radWeekRule1.Size = new System.Drawing.Size(94, 17);
      this.radWeekRule1.TabIndex = 173;
      this.radWeekRule1.TabStop = true;
      this.radWeekRule1.Text = "Recur every";
      this.radWeekRule1.UseVisualStyleBackColor = true;
      // 
      // pnlDay
      // 
      this.pnlDay.Controls.Add(this.label13);
      this.pnlDay.Controls.Add(this.radDaySubrule2);
      this.pnlDay.Controls.Add(this.txtDayDay);
      this.pnlDay.Controls.Add(this.radDaySubrule1);
      this.pnlDay.Location = new System.Drawing.Point(97, 53);
      this.pnlDay.Name = "pnlDay";
      this.pnlDay.Size = new System.Drawing.Size(390, 87);
      this.pnlDay.TabIndex = 174;
      this.pnlDay.Visible = false;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(103, 13);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(41, 13);
      this.label13.TabIndex = 193;
      this.label13.Text = "day(s)";
      // 
      // radDaySubrule2
      // 
      this.radDaySubrule2.AutoSize = true;
      this.radDaySubrule2.Location = new System.Drawing.Point(12, 47);
      this.radDaySubrule2.Name = "radDaySubrule2";
      this.radDaySubrule2.Size = new System.Drawing.Size(111, 17);
      this.radDaySubrule2.TabIndex = 179;
      this.radDaySubrule2.Text = "Every weekday";
      this.radDaySubrule2.UseVisualStyleBackColor = true;
      this.radDaySubrule2.CheckedChanged += new System.EventHandler(this.radDaySubrule2_CheckedChanged);
      // 
      // txtDayDay
      // 
      this.txtDayDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtDayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtDayDay.ForeColor = System.Drawing.Color.Black;
      this.txtDayDay.Location = new System.Drawing.Point(69, 11);
      this.txtDayDay.MaxLength = 3;
      this.txtDayDay.Name = "txtDayDay";
      this.txtDayDay.Size = new System.Drawing.Size(28, 20);
      this.txtDayDay.TabIndex = 174;
      this.txtDayDay.Text = "1";
      this.txtDayDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtDayDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtDayDay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDayDay_KeyUp);
      // 
      // radDaySubrule1
      // 
      this.radDaySubrule1.AutoSize = true;
      this.radDaySubrule1.Checked = true;
      this.radDaySubrule1.Location = new System.Drawing.Point(12, 11);
      this.radDaySubrule1.Name = "radDaySubrule1";
      this.radDaySubrule1.Size = new System.Drawing.Size(57, 17);
      this.radDaySubrule1.TabIndex = 173;
      this.radDaySubrule1.TabStop = true;
      this.radDaySubrule1.Text = "Every";
      this.radDaySubrule1.UseVisualStyleBackColor = true;
      this.radDaySubrule1.CheckedChanged += new System.EventHandler(this.radDaySubrule1_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Location = new System.Drawing.Point(88, 26);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1, 85);
      this.panel1.TabIndex = 171;
      // 
      // radYearly
      // 
      this.radYearly.AutoSize = true;
      this.radYearly.Location = new System.Drawing.Point(14, 95);
      this.radYearly.Name = "radYearly";
      this.radYearly.Size = new System.Drawing.Size(60, 17);
      this.radYearly.TabIndex = 3;
      this.radYearly.TabStop = true;
      this.radYearly.Text = "Yearly";
      this.radYearly.UseVisualStyleBackColor = true;
      this.radYearly.Click += new System.EventHandler(this.radYearly_Click);
      // 
      // radMonthly
      // 
      this.radMonthly.AutoSize = true;
      this.radMonthly.Location = new System.Drawing.Point(14, 72);
      this.radMonthly.Name = "radMonthly";
      this.radMonthly.Size = new System.Drawing.Size(69, 17);
      this.radMonthly.TabIndex = 2;
      this.radMonthly.TabStop = true;
      this.radMonthly.Text = "Monthly";
      this.radMonthly.UseVisualStyleBackColor = true;
      this.radMonthly.Click += new System.EventHandler(this.radMonthly_Click);
      // 
      // radWeekly
      // 
      this.radWeekly.AutoSize = true;
      this.radWeekly.Location = new System.Drawing.Point(14, 49);
      this.radWeekly.Name = "radWeekly";
      this.radWeekly.Size = new System.Drawing.Size(67, 17);
      this.radWeekly.TabIndex = 1;
      this.radWeekly.TabStop = true;
      this.radWeekly.Text = "Weekly";
      this.radWeekly.UseVisualStyleBackColor = true;
      this.radWeekly.CheckedChanged += new System.EventHandler(this.radWeekly_Click);
      this.radWeekly.Click += new System.EventHandler(this.radWeekly_Click);
      // 
      // radDaily
      // 
      this.radDaily.AutoSize = true;
      this.radDaily.Location = new System.Drawing.Point(14, 26);
      this.radDaily.Name = "radDaily";
      this.radDaily.Size = new System.Drawing.Size(53, 17);
      this.radDaily.TabIndex = 0;
      this.radDaily.TabStop = true;
      this.radDaily.Text = "Daily";
      this.radDaily.UseVisualStyleBackColor = true;
      this.radDaily.Click += new System.EventHandler(this.radDaily_Click);
      // 
      // pnlYear
      // 
      this.pnlYear.Controls.Add(this.cmbYearMonths);
      this.pnlYear.Controls.Add(this.txtYearDayOfMonth);
      this.pnlYear.Controls.Add(this.radYearEvery);
      this.pnlYear.Location = new System.Drawing.Point(157, 19);
      this.pnlYear.Name = "pnlYear";
      this.pnlYear.Size = new System.Drawing.Size(390, 87);
      this.pnlYear.TabIndex = 187;
      this.pnlYear.Visible = false;
      // 
      // cmbYearMonths
      // 
      this.cmbYearMonths.FormattingEnabled = true;
      this.cmbYearMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
      this.cmbYearMonths.Location = new System.Drawing.Point(71, 9);
      this.cmbYearMonths.Name = "cmbYearMonths";
      this.cmbYearMonths.Size = new System.Drawing.Size(88, 21);
      this.cmbYearMonths.TabIndex = 182;
      this.cmbYearMonths.SelectedIndexChanged += new System.EventHandler(this.cmbYearMonths_SelectedIndexChanged);
      // 
      // txtYearDayOfMonth
      // 
      this.txtYearDayOfMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtYearDayOfMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtYearDayOfMonth.ForeColor = System.Drawing.Color.Black;
      this.txtYearDayOfMonth.Location = new System.Drawing.Point(165, 9);
      this.txtYearDayOfMonth.MaxLength = 3;
      this.txtYearDayOfMonth.Name = "txtYearDayOfMonth";
      this.txtYearDayOfMonth.Size = new System.Drawing.Size(28, 20);
      this.txtYearDayOfMonth.TabIndex = 174;
      this.txtYearDayOfMonth.Text = "1";
      this.txtYearDayOfMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtYearDayOfMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtYearDayOfMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtYearDayOfMonth_KeyUp);
      // 
      // radYearEvery
      // 
      this.radYearEvery.AutoSize = true;
      this.radYearEvery.Location = new System.Drawing.Point(12, 11);
      this.radYearEvery.Name = "radYearEvery";
      this.radYearEvery.Size = new System.Drawing.Size(57, 17);
      this.radYearEvery.TabIndex = 173;
      this.radYearEvery.TabStop = true;
      this.radYearEvery.Text = "Every";
      this.radYearEvery.UseVisualStyleBackColor = true;
      // 
      // pnlMonth
      // 
      this.pnlMonth.Controls.Add(this.label11);
      this.pnlMonth.Controls.Add(this.label10);
      this.pnlMonth.Controls.Add(this.label9);
      this.pnlMonth.Controls.Add(this.label2);
      this.pnlMonth.Controls.Add(this.cmbMonthDayOfWeek);
      this.pnlMonth.Controls.Add(this.txtMonthMonths2);
      this.pnlMonth.Controls.Add(this.cmbMonthFirst);
      this.pnlMonth.Controls.Add(this.radMonthSubrule2);
      this.pnlMonth.Controls.Add(this.txtMonthMonths1);
      this.pnlMonth.Controls.Add(this.txtMonthDay);
      this.pnlMonth.Controls.Add(this.radMonthSubrule1);
      this.pnlMonth.Location = new System.Drawing.Point(92, 24);
      this.pnlMonth.Name = "pnlMonth";
      this.pnlMonth.Size = new System.Drawing.Size(390, 87);
      this.pnlMonth.TabIndex = 173;
      this.pnlMonth.Visible = false;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(319, 50);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(55, 13);
      this.label11.TabIndex = 194;
      this.label11.Text = "month(s)";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(234, 50);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(53, 13);
      this.label10.TabIndex = 193;
      this.label10.Text = "of every";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(192, 13);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(55, 13);
      this.label9.TabIndex = 192;
      this.label9.Text = "month(s)";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(99, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 191;
      this.label2.Text = "of every";
      // 
      // cmbMonthDayOfWeek
      // 
      this.cmbMonthDayOfWeek.FormattingEnabled = true;
      this.cmbMonthDayOfWeek.Items.AddRange(new object[] {
            "day",
            "week day",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
      this.cmbMonthDayOfWeek.Location = new System.Drawing.Point(145, 46);
      this.cmbMonthDayOfWeek.Name = "cmbMonthDayOfWeek";
      this.cmbMonthDayOfWeek.Size = new System.Drawing.Size(89, 21);
      this.cmbMonthDayOfWeek.TabIndex = 181;
      this.cmbMonthDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cmbMonthDayOfWeek_SelectedIndexChanged);
      // 
      // txtMonthMonths2
      // 
      this.txtMonthMonths2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMonthMonths2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMonthMonths2.ForeColor = System.Drawing.Color.Black;
      this.txtMonthMonths2.Location = new System.Drawing.Point(289, 47);
      this.txtMonthMonths2.MaxLength = 3;
      this.txtMonthMonths2.Name = "txtMonthMonths2";
      this.txtMonthMonths2.Size = new System.Drawing.Size(28, 20);
      this.txtMonthMonths2.TabIndex = 183;
      this.txtMonthMonths2.Text = "1";
      this.txtMonthMonths2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMonthMonths2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtMonthMonths2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMonthMonths2_KeyUp);
      // 
      // cmbMonthFirst
      // 
      this.cmbMonthFirst.FormattingEnabled = true;
      this.cmbMonthFirst.Items.AddRange(new object[] {
            "first",
            "second",
            "third",
            "fourth",
            "last"});
      this.cmbMonthFirst.Location = new System.Drawing.Point(65, 46);
      this.cmbMonthFirst.Name = "cmbMonthFirst";
      this.cmbMonthFirst.Size = new System.Drawing.Size(74, 21);
      this.cmbMonthFirst.TabIndex = 180;
      this.cmbMonthFirst.SelectedIndexChanged += new System.EventHandler(this.cmbMonthFirst_SelectedIndexChanged);
      // 
      // radMonthSubrule2
      // 
      this.radMonthSubrule2.AutoSize = true;
      this.radMonthSubrule2.Location = new System.Drawing.Point(12, 47);
      this.radMonthSubrule2.Name = "radMonthSubrule2";
      this.radMonthSubrule2.Size = new System.Drawing.Size(47, 17);
      this.radMonthSubrule2.TabIndex = 179;
      this.radMonthSubrule2.TabStop = true;
      this.radMonthSubrule2.Text = "The";
      this.radMonthSubrule2.UseVisualStyleBackColor = true;
      this.radMonthSubrule2.CheckedChanged += new System.EventHandler(this.radMonthSubrule2_CheckedChanged);
      // 
      // txtMonthMonths1
      // 
      this.txtMonthMonths1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMonthMonths1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMonthMonths1.ForeColor = System.Drawing.Color.Black;
      this.txtMonthMonths1.Location = new System.Drawing.Point(158, 11);
      this.txtMonthMonths1.MaxLength = 3;
      this.txtMonthMonths1.Name = "txtMonthMonths1";
      this.txtMonthMonths1.Size = new System.Drawing.Size(28, 20);
      this.txtMonthMonths1.TabIndex = 176;
      this.txtMonthMonths1.Text = "1";
      this.txtMonthMonths1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMonthMonths1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtMonthMonths1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMonthMonths1_KeyUp);
      // 
      // txtMonthDay
      // 
      this.txtMonthDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMonthDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMonthDay.ForeColor = System.Drawing.Color.Black;
      this.txtMonthDay.Location = new System.Drawing.Point(65, 11);
      this.txtMonthDay.MaxLength = 3;
      this.txtMonthDay.Name = "txtMonthDay";
      this.txtMonthDay.Size = new System.Drawing.Size(28, 20);
      this.txtMonthDay.TabIndex = 174;
      this.txtMonthDay.Text = "22";
      this.txtMonthDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMonthDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayDay_KeyPress);
      this.txtMonthDay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMonthDay_KeyUp);
      // 
      // radMonthSubrule1
      // 
      this.radMonthSubrule1.AutoSize = true;
      this.radMonthSubrule1.Location = new System.Drawing.Point(12, 11);
      this.radMonthSubrule1.Name = "radMonthSubrule1";
      this.radMonthSubrule1.Size = new System.Drawing.Size(47, 17);
      this.radMonthSubrule1.TabIndex = 173;
      this.radMonthSubrule1.TabStop = true;
      this.radMonthSubrule1.Text = "Day";
      this.radMonthSubrule1.UseVisualStyleBackColor = true;
      this.radMonthSubrule1.CheckedChanged += new System.EventHandler(this.radMonthSubrule1_CheckedChanged);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(583, 484);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(83, 13);
      this.label7.TabIndex = 189;
      this.label7.Text = "Next backup:";
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(617, 544);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(91, 13);
      this.label8.TabIndex = 190;
      this.label8.Text = "*** overdue ***";
      // 
      // txtScheduledTOD
      // 
      this.txtScheduledTOD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txtScheduledTOD.Location = new System.Drawing.Point(586, 519);
      this.txtScheduledTOD.Name = "txtScheduledTOD";
      this.txtScheduledTOD.ReadOnly = true;
      this.txtScheduledTOD.Size = new System.Drawing.Size(155, 20);
      this.txtScheduledTOD.TabIndex = 191;
      this.txtScheduledTOD.Text = "04:30";
      this.txtScheduledTOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // dtpStart
      // 
      this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpStart.Location = new System.Drawing.Point(586, 501);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(155, 20);
      this.dtpStart.TabIndex = 192;
      // 
      // dgvFolders
      // 
      this.dgvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChecked,
            this.colID,
            this.colCompress,
            this.colRetention,
            this.colFolderPath});
      this.dgvFolders.Location = new System.Drawing.Point(15, 161);
      this.dgvFolders.MultiSelect = false;
      this.dgvFolders.Name = "dgvFolders";
      this.dgvFolders.RowHeadersVisible = false;
      this.dgvFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvFolders.Size = new System.Drawing.Size(573, 174);
      this.dgvFolders.TabIndex = 194;
      this.dgvFolders.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFolders_CellBeginEdit);
      // 
      // colChecked
      // 
      this.colChecked.HeaderText = "";
      this.colChecked.Name = "colChecked";
      this.colChecked.Width = 20;
      // 
      // colID
      // 
      this.colID.HeaderText = "ID";
      this.colID.Name = "colID";
      // 
      // colCompress
      // 
      this.colCompress.HeaderText = "Compress";
      this.colCompress.Name = "colCompress";
      this.colCompress.Width = 60;
      // 
      // colRetention
      // 
      this.colRetention.HeaderText = "Retention";
      this.colRetention.Name = "colRetention";
      // 
      // colFolderPath
      // 
      this.colFolderPath.HeaderText = "Path";
      this.colFolderPath.Name = "colFolderPath";
      this.colFolderPath.Width = 1000;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(594, 100);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(130, 22);
      this.button1.TabIndex = 195;
      this.button1.Text = "Recover...";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(12, 573);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(570, 20);
      this.txtMemo.TabIndex = 196;
      // 
      // label14
      // 
      this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(12, 557);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(255, 13);
      this.label14.TabIndex = 197;
      this.label14.Text = "Memo (to help identify task in notifications):";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.txtLastBackupTimeEnd);
      this.groupBox1.Controls.Add(this.txtLastBackupDateEnd);
      this.groupBox1.Controls.Add(this.lblLastBackupEnd);
      this.groupBox1.Controls.Add(this.txtLastBackupTime);
      this.groupBox1.Controls.Add(this.txtLastBackupDate);
      this.groupBox1.Controls.Add(this.lblLastBackupBegin);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(588, 342);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(156, 139);
      this.groupBox1.TabIndex = 202;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Last backup";
      // 
      // txtLastBackupTimeEnd
      // 
      this.txtLastBackupTimeEnd.Location = new System.Drawing.Point(6, 113);
      this.txtLastBackupTimeEnd.Name = "txtLastBackupTimeEnd";
      this.txtLastBackupTimeEnd.ReadOnly = true;
      this.txtLastBackupTimeEnd.Size = new System.Drawing.Size(145, 20);
      this.txtLastBackupTimeEnd.TabIndex = 207;
      this.txtLastBackupTimeEnd.Text = "04:30";
      this.txtLastBackupTimeEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtLastBackupDateEnd
      // 
      this.txtLastBackupDateEnd.Location = new System.Drawing.Point(6, 94);
      this.txtLastBackupDateEnd.Name = "txtLastBackupDateEnd";
      this.txtLastBackupDateEnd.ReadOnly = true;
      this.txtLastBackupDateEnd.Size = new System.Drawing.Size(145, 20);
      this.txtLastBackupDateEnd.TabIndex = 205;
      // 
      // lblLastBackupEnd
      // 
      this.lblLastBackupEnd.AutoSize = true;
      this.lblLastBackupEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLastBackupEnd.Location = new System.Drawing.Point(3, 78);
      this.lblLastBackupEnd.Name = "lblLastBackupEnd";
      this.lblLastBackupEnd.Size = new System.Drawing.Size(33, 13);
      this.lblLastBackupEnd.TabIndex = 206;
      this.lblLastBackupEnd.Text = "End:";
      // 
      // txtLastBackupTime
      // 
      this.txtLastBackupTime.Location = new System.Drawing.Point(6, 50);
      this.txtLastBackupTime.Name = "txtLastBackupTime";
      this.txtLastBackupTime.ReadOnly = true;
      this.txtLastBackupTime.Size = new System.Drawing.Size(145, 20);
      this.txtLastBackupTime.TabIndex = 204;
      this.txtLastBackupTime.Text = "04:30";
      this.txtLastBackupTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtLastBackupDate
      // 
      this.txtLastBackupDate.Location = new System.Drawing.Point(6, 31);
      this.txtLastBackupDate.Name = "txtLastBackupDate";
      this.txtLastBackupDate.ReadOnly = true;
      this.txtLastBackupDate.Size = new System.Drawing.Size(145, 20);
      this.txtLastBackupDate.TabIndex = 202;
      // 
      // lblLastBackupBegin
      // 
      this.lblLastBackupBegin.AutoSize = true;
      this.lblLastBackupBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLastBackupBegin.Location = new System.Drawing.Point(3, 15);
      this.lblLastBackupBegin.Name = "lblLastBackupBegin";
      this.lblLastBackupBegin.Size = new System.Drawing.Size(43, 13);
      this.lblLastBackupBegin.TabIndex = 203;
      this.lblLastBackupBegin.Text = "Begin:";
      // 
      // BioSeqBackupOffsite
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(767, 604);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.dgvFolders);
      this.Controls.Add(this.dtpStart);
      this.Controls.Add(this.txtScheduledTOD);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.grpRecurrence);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnFolderPicker);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cmbUser);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnFindTargetPath);
      this.Controls.Add(this.txtTargetPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqBackupOffsite";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Backup Folders to an Offsite Target";
      this.grpRecurrence.ResumeLayout(false);
      this.grpRecurrence.PerformLayout();
      this.pnlWeek.ResumeLayout(false);
      this.pnlWeek.PerformLayout();
      this.pnlDay.ResumeLayout(false);
      this.pnlDay.PerformLayout();
      this.pnlYear.ResumeLayout(false);
      this.pnlYear.PerformLayout();
      this.pnlMonth.ResumeLayout(false);
      this.pnlMonth.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtTargetPath;
    private System.Windows.Forms.Button btnFindTargetPath;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cmbUser;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnFolderPicker;
    private System.Windows.Forms.GroupBox grpRecurrence;
    private System.Windows.Forms.Panel pnlYear;
    private System.Windows.Forms.ComboBox cmbYearMonths;
    private System.Windows.Forms.TextBox txtYearDayOfMonth;
    private System.Windows.Forms.RadioButton radYearEvery;
    private System.Windows.Forms.Panel pnlMonth;
    private System.Windows.Forms.ComboBox cmbMonthDayOfWeek;
    private System.Windows.Forms.TextBox txtMonthMonths2;
    private System.Windows.Forms.ComboBox cmbMonthFirst;
    private System.Windows.Forms.RadioButton radMonthSubrule2;
    private System.Windows.Forms.TextBox txtMonthMonths1;
    private System.Windows.Forms.TextBox txtMonthDay;
    private System.Windows.Forms.RadioButton radMonthSubrule1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton radYearly;
    private System.Windows.Forms.RadioButton radMonthly;
    private System.Windows.Forms.RadioButton radWeekly;
    private System.Windows.Forms.RadioButton radDaily;
    private System.Windows.Forms.Panel pnlWeek;
    private System.Windows.Forms.CheckBox chkWeekSaturday;
    private System.Windows.Forms.CheckBox chkWeekFriday;
    private System.Windows.Forms.CheckBox chkWeekThursday;
    private System.Windows.Forms.CheckBox chkWeekWednesday;
    private System.Windows.Forms.CheckBox chkWeekTuesday;
    private System.Windows.Forms.CheckBox chkWeekMonday;
    private System.Windows.Forms.CheckBox chkWeekSunday;
    private System.Windows.Forms.TextBox txtWeekWeek;
    private System.Windows.Forms.RadioButton radWeekRule1;
    private System.Windows.Forms.Panel pnlDay;
    private System.Windows.Forms.RadioButton radDaySubrule2;
    private System.Windows.Forms.TextBox txtDayDay;
    private System.Windows.Forms.RadioButton radDaySubrule1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtScheduledTOD;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.DataGridView dgvFolders;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colChecked;
    private System.Windows.Forms.DataGridViewTextBoxColumn colID;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colCompress;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRetention;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFolderPath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtLastBackupTimeEnd;
    private System.Windows.Forms.TextBox txtLastBackupDateEnd;
    private System.Windows.Forms.Label lblLastBackupEnd;
    private System.Windows.Forms.TextBox txtLastBackupTime;
    private System.Windows.Forms.TextBox txtLastBackupDate;
    private System.Windows.Forms.Label lblLastBackupBegin;
  }
}