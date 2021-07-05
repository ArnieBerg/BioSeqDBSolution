namespace BioSeqDB
{
  partial class BioSeqInfluenzaA
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqInfluenzaA));
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOutputPath = new System.Windows.Forms.Button();
      this.txtOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.chkTrim = new System.Windows.Forms.CheckBox();
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnCentrifugePath = new System.Windows.Forms.Button();
      this.txtCentrifugePath = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnFastqPicker = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lvSamples = new System.Windows.Forms.ListView();
      this.colSampleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lblCentrifugeDBName = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.chkSeg1 = new System.Windows.Forms.CheckBox();
      this.chkSeg7 = new System.Windows.Forms.CheckBox();
      this.chkSeg6 = new System.Windows.Forms.CheckBox();
      this.chkSeg5 = new System.Windows.Forms.CheckBox();
      this.chkSeg4 = new System.Windows.Forms.CheckBox();
      this.chkSeg3 = new System.Windows.Forms.CheckBox();
      this.chkSeg2 = new System.Windows.Forms.CheckBox();
      this.chkAllSegments = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.chkSeg8 = new System.Windows.Forms.CheckBox();
      this.label8 = new System.Windows.Forms.Label();
      this.cmbModel = new System.Windows.Forms.ComboBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(656, 61);
      this.label4.TabIndex = 13;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(500, 456);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(65, 22);
      this.btnOK.TabIndex = 19;
      this.btnOK.Text = "Run";
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
      this.btnCancel.Location = new System.Drawing.Point(586, 456);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 20;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOutputPath
      // 
      this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputPath.Location = new System.Drawing.Point(586, 335);
      this.btnOutputPath.Name = "btnOutputPath";
      this.btnOutputPath.Size = new System.Drawing.Size(31, 23);
      this.btnOutputPath.TabIndex = 6;
      this.btnOutputPath.Text = "...";
      this.btnOutputPath.UseVisualStyleBackColor = true;
      this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(12, 337);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(574, 20);
      this.txtOutputPath.TabIndex = 5;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 321);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(578, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Path to output result files, including final consensus sequence in subfolder <Sam" +
    "pleID>\\consensus\\:";
      // 
      // chkTrim
      // 
      this.chkTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkTrim.AutoSize = true;
      this.chkTrim.Checked = true;
      this.chkTrim.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkTrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkTrim.Location = new System.Drawing.Point(12, 375);
      this.chkTrim.Name = "chkTrim";
      this.chkTrim.Size = new System.Drawing.Size(194, 17);
      this.chkTrim.TabIndex = 7;
      this.chkTrim.Text = "Adaptor trimming by porechop";
      this.chkTrim.UseVisualStyleBackColor = true;
      // 
      // txtThreads
      // 
      this.txtThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtThreads.Location = new System.Drawing.Point(334, 372);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 8;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.TextChanged += new System.EventHandler(this.txtThreads_TextChanged);
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreads_KeyPress);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(213, 375);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 55;
      this.label6.Text = "Number of threads:";
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(9, 456);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(435, 20);
      this.txtMemo.TabIndex = 18;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 440);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(255, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Memo (to help identify task in notifications):";
      // 
      // btnCentrifugePath
      // 
      this.btnCentrifugePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCentrifugePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCentrifugePath.Location = new System.Drawing.Point(586, 273);
      this.btnCentrifugePath.Name = "btnCentrifugePath";
      this.btnCentrifugePath.Size = new System.Drawing.Size(31, 23);
      this.btnCentrifugePath.TabIndex = 4;
      this.btnCentrifugePath.Text = "...";
      this.btnCentrifugePath.UseVisualStyleBackColor = true;
      this.btnCentrifugePath.Click += new System.EventHandler(this.btnCentrifugePath_Click);
      // 
      // txtCentrifugePath
      // 
      this.txtCentrifugePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtCentrifugePath.Location = new System.Drawing.Point(12, 275);
      this.txtCentrifugePath.Name = "txtCentrifugePath";
      this.txtCentrifugePath.Size = new System.Drawing.Size(574, 20);
      this.txtCentrifugePath.TabIndex = 3;
      this.txtCentrifugePath.TextChanged += new System.EventHandler(this.txtCentrifugePath_TextChanged);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 259);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(404, 13);
      this.label2.TabIndex = 61;
      this.label2.Text = "Path to Centrifuge database for taxonomic and segment classification:";
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Location = new System.Drawing.Point(15, 100);
      this.chkAll.Name = "chkAll";
      this.chkAll.Size = new System.Drawing.Size(71, 17);
      this.chkAll.TabIndex = 65;
      this.chkAll.Text = "(all/none)";
      this.chkAll.UseVisualStyleBackColor = true;
      this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Location = new System.Drawing.Point(522, 146);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(122, 23);
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Remove unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnFastqPicker
      // 
      this.btnFastqPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFastqPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFastqPicker.Location = new System.Drawing.Point(522, 117);
      this.btnFastqPicker.Name = "btnFastqPicker";
      this.btnFastqPicker.Size = new System.Drawing.Size(122, 23);
      this.btnFastqPicker.TabIndex = 1;
      this.btnFastqPicker.Text = "Fastq file picker...";
      this.btnFastqPicker.UseVisualStyleBackColor = true;
      this.btnFastqPicker.Click += new System.EventHandler(this.btnFastqPicker_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 84);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(260, 13);
      this.label5.TabIndex = 66;
      this.label5.Text = "Fastq files representing Influenza A samples:";
      // 
      // lvSamples
      // 
      this.lvSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvSamples.CheckBoxes = true;
      this.lvSamples.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSampleID,
            this.colPath});
      this.lvSamples.FullRowSelect = true;
      this.lvSamples.HideSelection = false;
      this.lvSamples.Location = new System.Drawing.Point(12, 118);
      this.lvSamples.MultiSelect = false;
      this.lvSamples.Name = "lvSamples";
      this.lvSamples.Size = new System.Drawing.Size(504, 122);
      this.lvSamples.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.lvSamples.TabIndex = 0;
      this.lvSamples.UseCompatibleStateImageBehavior = false;
      this.lvSamples.View = System.Windows.Forms.View.Details;
      // 
      // colSampleID
      // 
      this.colSampleID.Text = "Sample ID";
      this.colSampleID.Width = 100;
      // 
      // colPath
      // 
      this.colPath.Text = "Path";
      this.colPath.Width = 1200;
      // 
      // lblCentrifugeDBName
      // 
      this.lblCentrifugeDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblCentrifugeDBName.AutoSize = true;
      this.lblCentrifugeDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCentrifugeDBName.Location = new System.Drawing.Point(28, 298);
      this.lblCentrifugeDBName.Name = "lblCentrifugeDBName";
      this.lblCentrifugeDBName.Size = new System.Drawing.Size(159, 13);
      this.lblCentrifugeDBName.TabIndex = 68;
      this.lblCentrifugeDBName.Text = "Centrifuge database name:";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(12, 404);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(137, 13);
      this.label7.TabIndex = 69;
      this.label7.Text = "Segments to assemble:";
      // 
      // chkSeg1
      // 
      this.chkSeg1.AutoSize = true;
      this.chkSeg1.Checked = true;
      this.chkSeg1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg1.Location = new System.Drawing.Point(3, 5);
      this.chkSeg1.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg1.Name = "chkSeg1";
      this.chkSeg1.Size = new System.Drawing.Size(33, 17);
      this.chkSeg1.TabIndex = 10;
      this.chkSeg1.Text = "1";
      this.chkSeg1.UseVisualStyleBackColor = true;
      // 
      // chkSeg7
      // 
      this.chkSeg7.AutoSize = true;
      this.chkSeg7.Checked = true;
      this.chkSeg7.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg7.Location = new System.Drawing.Point(213, 5);
      this.chkSeg7.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg7.Name = "chkSeg7";
      this.chkSeg7.Size = new System.Drawing.Size(33, 17);
      this.chkSeg7.TabIndex = 16;
      this.chkSeg7.Text = "7";
      this.chkSeg7.UseVisualStyleBackColor = true;
      // 
      // chkSeg6
      // 
      this.chkSeg6.AutoSize = true;
      this.chkSeg6.Checked = true;
      this.chkSeg6.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg6.Location = new System.Drawing.Point(178, 5);
      this.chkSeg6.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg6.Name = "chkSeg6";
      this.chkSeg6.Size = new System.Drawing.Size(33, 17);
      this.chkSeg6.TabIndex = 15;
      this.chkSeg6.Text = "6";
      this.chkSeg6.UseVisualStyleBackColor = true;
      // 
      // chkSeg5
      // 
      this.chkSeg5.AutoSize = true;
      this.chkSeg5.Checked = true;
      this.chkSeg5.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg5.Location = new System.Drawing.Point(143, 5);
      this.chkSeg5.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg5.Name = "chkSeg5";
      this.chkSeg5.Size = new System.Drawing.Size(33, 17);
      this.chkSeg5.TabIndex = 14;
      this.chkSeg5.Text = "5";
      this.chkSeg5.UseVisualStyleBackColor = true;
      // 
      // chkSeg4
      // 
      this.chkSeg4.AutoSize = true;
      this.chkSeg4.Checked = true;
      this.chkSeg4.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg4.Location = new System.Drawing.Point(108, 5);
      this.chkSeg4.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg4.Name = "chkSeg4";
      this.chkSeg4.Size = new System.Drawing.Size(33, 17);
      this.chkSeg4.TabIndex = 13;
      this.chkSeg4.Text = "4";
      this.chkSeg4.UseVisualStyleBackColor = true;
      // 
      // chkSeg3
      // 
      this.chkSeg3.AutoSize = true;
      this.chkSeg3.Checked = true;
      this.chkSeg3.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg3.Location = new System.Drawing.Point(73, 5);
      this.chkSeg3.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg3.Name = "chkSeg3";
      this.chkSeg3.Size = new System.Drawing.Size(33, 17);
      this.chkSeg3.TabIndex = 12;
      this.chkSeg3.Text = "3";
      this.chkSeg3.UseVisualStyleBackColor = true;
      // 
      // chkSeg2
      // 
      this.chkSeg2.AutoSize = true;
      this.chkSeg2.Checked = true;
      this.chkSeg2.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg2.Location = new System.Drawing.Point(38, 5);
      this.chkSeg2.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg2.Name = "chkSeg2";
      this.chkSeg2.Size = new System.Drawing.Size(33, 17);
      this.chkSeg2.TabIndex = 11;
      this.chkSeg2.Text = "2";
      this.chkSeg2.UseVisualStyleBackColor = true;
      // 
      // chkAllSegments
      // 
      this.chkAllSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkAllSegments.AutoSize = true;
      this.chkAllSegments.Checked = true;
      this.chkAllSegments.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAllSegments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkAllSegments.Location = new System.Drawing.Point(155, 403);
      this.chkAllSegments.Name = "chkAllSegments";
      this.chkAllSegments.Size = new System.Drawing.Size(40, 17);
      this.chkAllSegments.TabIndex = 9;
      this.chkAllSegments.Text = "All";
      this.chkAllSegments.UseVisualStyleBackColor = true;
      this.chkAllSegments.CheckedChanged += new System.EventHandler(this.chkAllSegments_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.chkSeg8);
      this.panel1.Controls.Add(this.chkSeg1);
      this.panel1.Controls.Add(this.chkSeg2);
      this.panel1.Controls.Add(this.chkSeg7);
      this.panel1.Controls.Add(this.chkSeg6);
      this.panel1.Controls.Add(this.chkSeg5);
      this.panel1.Controls.Add(this.chkSeg4);
      this.panel1.Controls.Add(this.chkSeg3);
      this.panel1.Location = new System.Drawing.Point(201, 398);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(286, 25);
      this.panel1.TabIndex = 78;
      // 
      // chkSeg8
      // 
      this.chkSeg8.AutoSize = true;
      this.chkSeg8.Checked = true;
      this.chkSeg8.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSeg8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSeg8.Location = new System.Drawing.Point(248, 5);
      this.chkSeg8.Margin = new System.Windows.Forms.Padding(0);
      this.chkSeg8.Name = "chkSeg8";
      this.chkSeg8.Size = new System.Drawing.Size(33, 17);
      this.chkSeg8.TabIndex = 17;
      this.chkSeg8.Text = "8";
      this.chkSeg8.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(408, 376);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(151, 13);
      this.label8.TabIndex = 79;
      this.label8.Text = "Flowcell chemistry model:";
      // 
      // cmbModel
      // 
      this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModel.FormattingEnabled = true;
      this.cmbModel.Items.AddRange(new object[] {
            "r9",
            "r10"});
      this.cmbModel.Location = new System.Drawing.Point(565, 371);
      this.cmbModel.Name = "cmbModel";
      this.cmbModel.Size = new System.Drawing.Size(51, 21);
      this.cmbModel.TabIndex = 9;
      // 
      // BioSeqInfluenzaA
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(685, 490);
      this.Controls.Add(this.cmbModel);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.chkAllSegments);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.lblCentrifugeDBName);
      this.Controls.Add(this.lvSamples);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnFastqPicker);
      this.Controls.Add(this.btnCentrifugePath);
      this.Controls.Add(this.txtCentrifugePath);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtThreads);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.chkTrim);
      this.Controls.Add(this.btnOutputPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqInfluenzaA";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Influenza A (Nanopore)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioSeqInfluenzaA_FormClosing);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOutputPath;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkTrim;
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnCentrifugePath;
    private System.Windows.Forms.TextBox txtCentrifugePath;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnFastqPicker;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListView lvSamples;
    private System.Windows.Forms.ColumnHeader colSampleID;
    private System.Windows.Forms.ColumnHeader colPath;
    private System.Windows.Forms.Label lblCentrifugeDBName;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.CheckBox chkSeg1;
    private System.Windows.Forms.CheckBox chkSeg7;
    private System.Windows.Forms.CheckBox chkSeg6;
    private System.Windows.Forms.CheckBox chkSeg5;
    private System.Windows.Forms.CheckBox chkSeg4;
    private System.Windows.Forms.CheckBox chkSeg3;
    private System.Windows.Forms.CheckBox chkSeg2;
    private System.Windows.Forms.CheckBox chkAllSegments;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox chkSeg8;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cmbModel;
  }
}