namespace BioSeqDB
{
  partial class BioSeqUI
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqUI));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.cmbUser = new System.Windows.Forms.ComboBox();
      this.picHelp = new System.Windows.Forms.PictureBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbSeqDB = new System.Windows.Forms.ComboBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnRestore = new System.Windows.Forms.Button();
      this.btnBackup = new System.Windows.Forms.Button();
      this.btnLIMSEdit = new System.Windows.Forms.Button();
      this.label8 = new System.Windows.Forms.Label();
      this.txtStandardReference = new System.Windows.Forms.TextBox();
      this.btnNotifications = new System.Windows.Forms.Button();
      this.chkDetailSamples = new System.Windows.Forms.CheckBox();
      this.btnDeleteDB = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.lstSampleIDs = new System.Windows.Forms.ListBox();
      this.label7 = new System.Windows.Forms.Label();
      this.lblKipper = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtVersions = new System.Windows.Forms.TextBox();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.lblDB = new System.Windows.Forms.Label();
      this.txtDB = new System.Windows.Forms.TextBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.mnuAssemble = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuExtract = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cmbAnalysis = new System.Windows.Forms.ToolStripComboBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.ConfirmDBDelete = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnDeleteDBYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnDeleteDBNo = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.backgroundWorker_Versions = new System.ComponentModel.BackgroundWorker();
      this.backgroundWorker_SampleIDs = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkGray;
      this.splitContainer1.Panel1.Controls.Add(this.cmbUser);
      this.splitContainer1.Panel1.Controls.Add(this.picHelp);
      this.splitContainer1.Panel1.Controls.Add(this.label6);
      this.splitContainer1.Panel1.Controls.Add(this.label2);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1.Controls.Add(this.cmbSeqDB);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.panel1);
      this.splitContainer1.Panel2.Controls.Add(this.btnRestore);
      this.splitContainer1.Panel2.Controls.Add(this.btnBackup);
      this.splitContainer1.Panel2.Controls.Add(this.btnLIMSEdit);
      this.splitContainer1.Panel2.Controls.Add(this.label8);
      this.splitContainer1.Panel2.Controls.Add(this.txtStandardReference);
      this.splitContainer1.Panel2.Controls.Add(this.btnNotifications);
      this.splitContainer1.Panel2.Controls.Add(this.chkDetailSamples);
      this.splitContainer1.Panel2.Controls.Add(this.btnDeleteDB);
      this.splitContainer1.Panel2.Controls.Add(this.label4);
      this.splitContainer1.Panel2.Controls.Add(this.lstSampleIDs);
      this.splitContainer1.Panel2.Controls.Add(this.label7);
      this.splitContainer1.Panel2.Controls.Add(this.lblKipper);
      this.splitContainer1.Panel2.Controls.Add(this.label5);
      this.splitContainer1.Panel2.Controls.Add(this.txtVersions);
      this.splitContainer1.Panel2.Controls.Add(this.txtPath);
      this.splitContainer1.Panel2.Controls.Add(this.label3);
      this.splitContainer1.Panel2.Controls.Add(this.lblDB);
      this.splitContainer1.Panel2.Controls.Add(this.txtDB);
      this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
      this.splitContainer1.Size = new System.Drawing.Size(876, 514);
      this.splitContainer1.SplitterDistance = 39;
      this.splitContainer1.TabIndex = 0;
      // 
      // cmbUser
      // 
      this.cmbUser.FormattingEnabled = true;
      this.cmbUser.Location = new System.Drawing.Point(38, 10);
      this.cmbUser.Margin = new System.Windows.Forms.Padding(2);
      this.cmbUser.Name = "cmbUser";
      this.cmbUser.Size = new System.Drawing.Size(83, 21);
      this.cmbUser.Sorted = true;
      this.cmbUser.TabIndex = 32;
      this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
      // 
      // picHelp
      // 
      this.picHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.picHelp.BackgroundImage = global::BioSeqDB.Properties.Resources.help;
      this.picHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picHelp.Location = new System.Drawing.Point(840, 2);
      this.picHelp.Margin = new System.Windows.Forms.Padding(2);
      this.picHelp.Name = "picHelp";
      this.picHelp.Size = new System.Drawing.Size(35, 35);
      this.picHelp.TabIndex = 31;
      this.picHelp.TabStop = false;
      this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(444, 13);
      this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(252, 13);
      this.label6.TabIndex = 18;
      this.label6.Text = "Select \'<new...> to create a new database.";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(158, 13);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(124, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Sequence database:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(2, 13);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "User:";
      // 
      // cmbSeqDB
      // 
      this.cmbSeqDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSeqDB.FormattingEnabled = true;
      this.cmbSeqDB.Items.AddRange(new object[] {
            "",
            "<new...>"});
      this.cmbSeqDB.Location = new System.Drawing.Point(286, 9);
      this.cmbSeqDB.Margin = new System.Windows.Forms.Padding(2);
      this.cmbSeqDB.Name = "cmbSeqDB";
      this.cmbSeqDB.Size = new System.Drawing.Size(154, 21);
      this.cmbSeqDB.Sorted = true;
      this.cmbSeqDB.TabIndex = 14;
      this.cmbSeqDB.SelectedIndexChanged += new System.EventHandler(this.cmbSeqDB_SelectedIndexChanged);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.Transparent;
      this.panel1.BackgroundImage = global::BioSeqDB.Properties.Resources.Explorer;
      this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Location = new System.Drawing.Point(833, 67);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(32, 32);
      this.panel1.TabIndex = 7;
      this.panel1.Click += new System.EventHandler(this.panel1_Click);
      // 
      // btnRestore
      // 
      this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnRestore.Location = new System.Drawing.Point(279, 173);
      this.btnRestore.Margin = new System.Windows.Forms.Padding(2);
      this.btnRestore.Name = "btnRestore";
      this.btnRestore.Size = new System.Drawing.Size(87, 22);
      this.btnRestore.TabIndex = 38;
      this.btnRestore.Text = "Restore...";
      this.toolTip1.SetToolTip(this.btnRestore, "Restore database version");
      this.btnRestore.UseVisualStyleBackColor = true;
      this.btnRestore.Click += new System.EventHandler(this.mnuRestore_Click);
      // 
      // btnBackup
      // 
      this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnBackup.Location = new System.Drawing.Point(188, 173);
      this.btnBackup.Margin = new System.Windows.Forms.Padding(2);
      this.btnBackup.Name = "btnBackup";
      this.btnBackup.Size = new System.Drawing.Size(87, 22);
      this.btnBackup.TabIndex = 37;
      this.btnBackup.Text = "Backup...";
      this.toolTip1.SetToolTip(this.btnBackup, "Backup database");
      this.btnBackup.UseVisualStyleBackColor = true;
      this.btnBackup.Click += new System.EventHandler(this.mnuBackup_Click);
      // 
      // btnLIMSEdit
      // 
      this.btnLIMSEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLIMSEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLIMSEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLIMSEdit.Location = new System.Drawing.Point(521, 439);
      this.btnLIMSEdit.Margin = new System.Windows.Forms.Padding(2);
      this.btnLIMSEdit.Name = "btnLIMSEdit";
      this.btnLIMSEdit.Size = new System.Drawing.Size(344, 22);
      this.btnLIMSEdit.TabIndex = 36;
      this.btnLIMSEdit.Text = "LIMS edit sample identifiers";
      this.toolTip1.SetToolTip(this.btnLIMSEdit, "Task notifications");
      this.btnLIMSEdit.UseVisualStyleBackColor = true;
      this.btnLIMSEdit.Click += new System.EventHandler(this.btnLIMSEdit_Click);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(16, 134);
      this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(168, 13);
      this.label8.TabIndex = 35;
      this.label8.Text = "Standard reference genome:";
      // 
      // txtStandardReference
      // 
      this.txtStandardReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtStandardReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtStandardReference.Location = new System.Drawing.Point(19, 149);
      this.txtStandardReference.Margin = new System.Windows.Forms.Padding(2);
      this.txtStandardReference.Name = "txtStandardReference";
      this.txtStandardReference.ReadOnly = true;
      this.txtStandardReference.Size = new System.Drawing.Size(456, 20);
      this.txtStandardReference.TabIndex = 34;
      // 
      // btnNotifications
      // 
      this.btnNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnNotifications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnNotifications.Location = new System.Drawing.Point(521, 67);
      this.btnNotifications.Margin = new System.Windows.Forms.Padding(2);
      this.btnNotifications.Name = "btnNotifications";
      this.btnNotifications.Size = new System.Drawing.Size(216, 37);
      this.btnNotifications.TabIndex = 33;
      this.btnNotifications.Text = "Pending notifications...";
      this.toolTip1.SetToolTip(this.btnNotifications, "Task notifications");
      this.btnNotifications.UseVisualStyleBackColor = true;
      this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
      // 
      // chkDetailSamples
      // 
      this.chkDetailSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkDetailSamples.AutoSize = true;
      this.chkDetailSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkDetailSamples.Location = new System.Drawing.Point(785, 127);
      this.chkDetailSamples.Margin = new System.Windows.Forms.Padding(2);
      this.chkDetailSamples.Name = "chkDetailSamples";
      this.chkDetailSamples.Size = new System.Drawing.Size(73, 17);
      this.chkDetailSamples.TabIndex = 32;
      this.chkDetailSamples.Text = "Detailed";
      this.chkDetailSamples.UseVisualStyleBackColor = true;
      this.chkDetailSamples.CheckedChanged += new System.EventHandler(this.chkDetailSamples_CheckedChanged);
      // 
      // btnDeleteDB
      // 
      this.btnDeleteDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDeleteDB.Image = global::BioSeqDB.Properties.Resources.DELETE;
      this.btnDeleteDB.Location = new System.Drawing.Point(282, 68);
      this.btnDeleteDB.Margin = new System.Windows.Forms.Padding(2);
      this.btnDeleteDB.Name = "btnDeleteDB";
      this.btnDeleteDB.Size = new System.Drawing.Size(31, 20);
      this.btnDeleteDB.TabIndex = 31;
      this.toolTip1.SetToolTip(this.btnDeleteDB, "Delete this database");
      this.btnDeleteDB.UseVisualStyleBackColor = true;
      this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(16, 91);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(153, 13);
      this.label4.TabIndex = 29;
      this.label4.Text = "Sequence database path:";
      // 
      // lstSampleIDs
      // 
      this.lstSampleIDs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstSampleIDs.FormattingEnabled = true;
      this.lstSampleIDs.Location = new System.Drawing.Point(521, 145);
      this.lstSampleIDs.Margin = new System.Windows.Forms.Padding(2);
      this.lstSampleIDs.Name = "lstSampleIDs";
      this.lstSampleIDs.Size = new System.Drawing.Size(344, 290);
      this.lstSampleIDs.Sorted = true;
      this.lstSampleIDs.TabIndex = 28;
      this.lstSampleIDs.SelectedIndexChanged += new System.EventHandler(this.lstSampleIDs_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(518, 129);
      this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(75, 13);
      this.label7.TabIndex = 27;
      this.label7.Text = "Sample IDs:";
      // 
      // lblKipper
      // 
      this.lblKipper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblKipper.Location = new System.Drawing.Point(16, 406);
      this.lblKipper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblKipper.Name = "lblKipper";
      this.lblKipper.Size = new System.Drawing.Size(297, 40);
      this.lblKipper.TabIndex = 26;
      this.lblKipper.Text = "This backup is stored in";
      this.lblKipper.Visible = false;
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(16, 365);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(321, 41);
      this.label5.TabIndex = 25;
      this.label5.Text = "If the database has been backed up, there could be multiple versions of the backu" +
    "p databases.";
      // 
      // txtVersions
      // 
      this.txtVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtVersions.Location = new System.Drawing.Point(19, 197);
      this.txtVersions.Margin = new System.Windows.Forms.Padding(2);
      this.txtVersions.Multiline = true;
      this.txtVersions.Name = "txtVersions";
      this.txtVersions.ReadOnly = true;
      this.txtVersions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtVersions.Size = new System.Drawing.Size(456, 152);
      this.txtVersions.TabIndex = 24;
      // 
      // txtPath
      // 
      this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPath.Location = new System.Drawing.Point(19, 106);
      this.txtPath.Margin = new System.Windows.Forms.Padding(2);
      this.txtPath.Name = "txtPath";
      this.txtPath.ReadOnly = true;
      this.txtPath.Size = new System.Drawing.Size(456, 20);
      this.txtPath.TabIndex = 23;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(16, 182);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(105, 13);
      this.label3.TabIndex = 22;
      this.label3.Text = "Backup versions:";
      // 
      // lblDB
      // 
      this.lblDB.AutoSize = true;
      this.lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDB.Location = new System.Drawing.Point(16, 53);
      this.lblDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblDB.Name = "lblDB";
      this.lblDB.Size = new System.Drawing.Size(176, 13);
      this.lblDB.TabIndex = 20;
      this.lblDB.Text = "Selected sequence database:";
      // 
      // txtDB
      // 
      this.txtDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtDB.Location = new System.Drawing.Point(19, 68);
      this.txtDB.Margin = new System.Windows.Forms.Padding(2);
      this.txtDB.Name = "txtDB";
      this.txtDB.ReadOnly = true;
      this.txtDB.Size = new System.Drawing.Size(239, 20);
      this.txtDB.TabIndex = 21;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Enabled = false;
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAssemble,
            this.mnuInsert,
            this.mnuExtract,
            this.mnuRemove,
            this.aboutToolStripMenuItem,
            this.cmbAnalysis});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
      this.menuStrip1.ShowItemToolTips = true;
      this.menuStrip1.Size = new System.Drawing.Size(876, 38);
      this.menuStrip1.TabIndex = 11;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // mnuAssemble
      // 
      this.mnuAssemble.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.mnuAssemble.Image = global::BioSeqDB.Properties.Resources._5130___Assembly_Line_5121;
      this.mnuAssemble.Name = "mnuAssemble";
      this.mnuAssemble.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
      this.mnuAssemble.Size = new System.Drawing.Size(113, 36);
      this.mnuAssemble.Text = "&Assemble...";
      this.mnuAssemble.ToolTipText = "Assemble samples using NextFlow";
      this.mnuAssemble.Click += new System.EventHandler(this.mnuAssemble_Click);
      // 
      // mnuInsert
      // 
      this.mnuInsert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.mnuInsert.Image = ((System.Drawing.Image)(resources.GetObject("mnuInsert.Image")));
      this.mnuInsert.Name = "mnuInsert";
      this.mnuInsert.Size = new System.Drawing.Size(93, 36);
      this.mnuInsert.Text = "Insert...";
      this.mnuInsert.ToolTipText = "add a new sequence to database";
      this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
      // 
      // mnuExtract
      // 
      this.mnuExtract.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.mnuExtract.Image = global::BioSeqDB.Properties.Resources.plier;
      this.mnuExtract.Name = "mnuExtract";
      this.mnuExtract.Size = new System.Drawing.Size(100, 36);
      this.mnuExtract.Text = "Extract...";
      this.mnuExtract.ToolTipText = "retrieve a target sequence from database";
      this.mnuExtract.Click += new System.EventHandler(this.mnuExtract_Click);
      // 
      // mnuRemove
      // 
      this.mnuRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.mnuRemove.Image = global::BioSeqDB.Properties.Resources.DELETE;
      this.mnuRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.mnuRemove.Name = "mnuRemove";
      this.mnuRemove.Size = new System.Drawing.Size(91, 36);
      this.mnuRemove.Text = "Remove...";
      this.mnuRemove.ToolTipText = "remove an existing target from database";
      this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.aboutToolStripMenuItem.Image = global::BioSeqDB.Properties.Resources.dna;
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // cmbAnalysis
      // 
      this.cmbAnalysis.BackColor = System.Drawing.Color.PeachPuff;
      this.cmbAnalysis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbAnalysis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.cmbAnalysis.Items.AddRange(new object[] {
            "-- Select analysis --",
            "BBMap...",
            "Build tree...",
            "InfluenzaA...",
            "Kraken2...",
            "Nextstrain...",
            "Quast...",
            "Salmonella Serotyping...",
            "Search...",
            "VFabricate..."});
      this.cmbAnalysis.Name = "cmbAnalysis";
      this.cmbAnalysis.Size = new System.Drawing.Size(200, 36);
      this.cmbAnalysis.Sorted = true;
      this.cmbAnalysis.SelectedIndexChanged += new System.EventHandler(this.cmbAnalysis_SelectedIndexChanged);
      // 
      // ConfirmDBDelete
      // 
      this.ConfirmDBDelete.Buttons.Add(this.btnDeleteDBYes);
      this.ConfirmDBDelete.Buttons.Add(this.btnDeleteDBNo);
      this.ConfirmDBDelete.CenterParent = true;
      this.ConfirmDBDelete.WindowTitle = "Delete selected database";
      // 
      // btnDeleteDBYes
      // 
      this.btnDeleteDBYes.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Yes;
      this.btnDeleteDBYes.Text = "Delete";
      // 
      // btnDeleteDBNo
      // 
      this.btnDeleteDBNo.ButtonType = Ookii.Dialogs.WinForms.ButtonType.No;
      this.btnDeleteDBNo.Text = "No";
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
      // 
      // backgroundWorker_Versions
      // 
      this.backgroundWorker_Versions.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Versions_DoWork);
      this.backgroundWorker_Versions.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Versions_RunWorkerCompleted);
      // 
      // backgroundWorker_SampleIDs
      // 
      this.backgroundWorker_SampleIDs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_SampleIDs_DoWork);
      this.backgroundWorker_SampleIDs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_SampleIDs_RunWorkerCompleted);
      // 
      // BioSeqUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(876, 514);
      this.Controls.Add(this.splitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "BioSeqUI";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "BioSeqDB";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioSeqUI_FormClosing);
      this.Load += new System.EventHandler(this.BioSeqUI_Load);
      this.Shown += new System.EventHandler(this.BioSeqUI_Shown);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuInsert;
    private System.Windows.Forms.ToolStripMenuItem mnuExtract;
    private System.Windows.Forms.ToolStripMenuItem mnuRemove;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbSeqDB;
    private System.Windows.Forms.ListBox lstSampleIDs;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblKipper;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtVersions;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblDB;
    private System.Windows.Forms.TextBox txtDB;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnDeleteDB;
    private System.Windows.Forms.CheckBox chkDetailSamples;
    private Ookii.Dialogs.WinForms.TaskDialog ConfirmDBDelete;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnDeleteDBYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnDeleteDBNo;
    private System.Windows.Forms.ToolStripMenuItem mnuAssemble;
    private System.Windows.Forms.Button btnNotifications;
    private System.Windows.Forms.PictureBox picHelp;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtStandardReference;
    private System.Windows.Forms.Button btnLIMSEdit;
    private System.Windows.Forms.ComboBox cmbUser;
    private System.Windows.Forms.Button btnRestore;
    private System.Windows.Forms.Button btnBackup;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.ComponentModel.BackgroundWorker backgroundWorker_Versions;
    private System.ComponentModel.BackgroundWorker backgroundWorker_SampleIDs;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStripComboBox cmbAnalysis;
  }
}