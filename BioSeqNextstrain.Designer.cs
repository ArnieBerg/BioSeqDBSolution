namespace BioSeqDB
{
  partial class BioSeqNextstrain
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
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOutputPath = new System.Windows.Forms.Button();
      this.txtOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnReferencePath = new System.Windows.Forms.Button();
      this.txtReferencePath = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnMetadata = new System.Windows.Forms.Button();
      this.btnMetadataPath = new System.Windows.Forms.Button();
      this.txtMetadataPath = new System.Windows.Forms.TextBox();
      this.lblFastqPath = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.dtpMinDate = new System.Windows.Forms.DateTimePicker();
      this.dtpMinDateFilter = new System.Windows.Forms.DateTimePicker();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.txtRootNode = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.txtMaskSites = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.txtMaskFromEnd = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtMaskFromBeginning = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txtMinLengthFilter = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.txtClusterCutoff = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txtSNPCutoff = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.btnReset = new System.Windows.Forms.Button();
      this.panel3.SuspendLayout();
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
      this.label4.Size = new System.Drawing.Size(659, 61);
      this.label4.TabIndex = 13;
      this.label4.Text = "Create a phylogenetic tree from the current database using Neststrain. The result" +
    "ing Json file can be submitted to auspice.us for visualization.   **** THIS FUNC" +
    "TION IS NOT YET OPERATIONAL ****";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(512, 449);
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
      this.btnCancel.Location = new System.Drawing.Point(598, 449);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 20;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOutputPath
      // 
      this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputPath.Location = new System.Drawing.Point(592, 399);
      this.btnOutputPath.Name = "btnOutputPath";
      this.btnOutputPath.Size = new System.Drawing.Size(31, 23);
      this.btnOutputPath.TabIndex = 6;
      this.btnOutputPath.Text = "...";
      this.btnOutputPath.UseVisualStyleBackColor = true;
      this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(17, 401);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(577, 20);
      this.txtOutputPath.TabIndex = 5;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(17, 385);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(154, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Path to output result files:";
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(17, 451);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(438, 20);
      this.txtMemo.TabIndex = 18;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(17, 435);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(255, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Memo (to help identify task in notifications):";
      // 
      // btnReferencePath
      // 
      this.btnReferencePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnReferencePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnReferencePath.Location = new System.Drawing.Point(593, 172);
      this.btnReferencePath.Name = "btnReferencePath";
      this.btnReferencePath.Size = new System.Drawing.Size(31, 23);
      this.btnReferencePath.TabIndex = 4;
      this.btnReferencePath.Text = "...";
      this.btnReferencePath.UseVisualStyleBackColor = true;
      this.btnReferencePath.Click += new System.EventHandler(this.btnReferencePath_Click);
      // 
      // txtReferencePath
      // 
      this.txtReferencePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtReferencePath.Location = new System.Drawing.Point(17, 174);
      this.txtReferencePath.Name = "txtReferencePath";
      this.txtReferencePath.Size = new System.Drawing.Size(577, 20);
      this.txtReferencePath.TabIndex = 3;
      this.txtReferencePath.TextChanged += new System.EventHandler(this.txtReferencePath_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(17, 158);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(255, 13);
      this.label2.TabIndex = 61;
      this.label2.Text = "Path to reference .gb (Genbank format) file:";
      // 
      // btnMetadata
      // 
      this.btnMetadata.FlatAppearance.BorderSize = 2;
      this.btnMetadata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnMetadata.Location = new System.Drawing.Point(427, 100);
      this.btnMetadata.Name = "btnMetadata";
      this.btnMetadata.Size = new System.Drawing.Size(195, 22);
      this.btnMetadata.TabIndex = 65;
      this.btnMetadata.Text = "Edit metadata file...";
      this.btnMetadata.UseVisualStyleBackColor = true;
      this.btnMetadata.Click += new System.EventHandler(this.btnMetadata_Click);
      // 
      // btnMetadataPath
      // 
      this.btnMetadataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMetadataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnMetadataPath.Location = new System.Drawing.Point(591, 119);
      this.btnMetadataPath.Name = "btnMetadataPath";
      this.btnMetadataPath.Size = new System.Drawing.Size(31, 23);
      this.btnMetadataPath.TabIndex = 63;
      this.btnMetadataPath.Text = "...";
      this.btnMetadataPath.UseVisualStyleBackColor = true;
      this.btnMetadataPath.Click += new System.EventHandler(this.btnMetadataPath_Click);
      // 
      // txtMetadataPath
      // 
      this.txtMetadataPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMetadataPath.Location = new System.Drawing.Point(17, 121);
      this.txtMetadataPath.Name = "txtMetadataPath";
      this.txtMetadataPath.Size = new System.Drawing.Size(577, 20);
      this.txtMetadataPath.TabIndex = 62;
      this.txtMetadataPath.TextChanged += new System.EventHandler(this.txtMetadataPath_TextChanged);
      // 
      // lblFastqPath
      // 
      this.lblFastqPath.AutoSize = true;
      this.lblFastqPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFastqPath.Location = new System.Drawing.Point(17, 105);
      this.lblFastqPath.Name = "lblFastqPath";
      this.lblFastqPath.Size = new System.Drawing.Size(154, 13);
      this.lblFastqPath.TabIndex = 64;
      this.lblFastqPath.Text = "Path to metadata .tsv file:";
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.txtThreads);
      this.panel3.Controls.Add(this.dtpMinDate);
      this.panel3.Controls.Add(this.dtpMinDateFilter);
      this.panel3.Controls.Add(this.label16);
      this.panel3.Controls.Add(this.label15);
      this.panel3.Controls.Add(this.txtRootNode);
      this.panel3.Controls.Add(this.label14);
      this.panel3.Controls.Add(this.txtMaskSites);
      this.panel3.Controls.Add(this.label13);
      this.panel3.Controls.Add(this.txtMaskFromEnd);
      this.panel3.Controls.Add(this.label12);
      this.panel3.Controls.Add(this.txtMaskFromBeginning);
      this.panel3.Controls.Add(this.label11);
      this.panel3.Controls.Add(this.txtMinLengthFilter);
      this.panel3.Controls.Add(this.label10);
      this.panel3.Controls.Add(this.txtClusterCutoff);
      this.panel3.Controls.Add(this.label9);
      this.panel3.Controls.Add(this.txtSNPCutoff);
      this.panel3.Controls.Add(this.label8);
      this.panel3.Controls.Add(this.label7);
      this.panel3.Location = new System.Drawing.Point(17, 213);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(605, 157);
      this.panel3.TabIndex = 67;
      // 
      // txtThreads
      // 
      this.txtThreads.Location = new System.Drawing.Point(168, 120);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 78;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // dtpMinDate
      // 
      this.dtpMinDate.Location = new System.Drawing.Point(371, 63);
      this.dtpMinDate.Name = "dtpMinDate";
      this.dtpMinDate.Size = new System.Drawing.Size(173, 20);
      this.dtpMinDate.TabIndex = 77;
      // 
      // dtpMinDateFilter
      // 
      this.dtpMinDateFilter.Location = new System.Drawing.Point(371, 44);
      this.dtpMinDateFilter.Name = "dtpMinDateFilter";
      this.dtpMinDateFilter.Size = new System.Drawing.Size(173, 20);
      this.dtpMinDateFilter.TabIndex = 76;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(268, 66);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(60, 13);
      this.label16.TabIndex = 75;
      this.label16.Text = "Min date:";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(268, 47);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(97, 13);
      this.label15.TabIndex = 73;
      this.label15.Text = "Min date (filter):";
      // 
      // txtRootNode
      // 
      this.txtRootNode.Location = new System.Drawing.Point(340, 25);
      this.txtRootNode.Name = "txtRootNode";
      this.txtRootNode.Size = new System.Drawing.Size(204, 20);
      this.txtRootNode.TabIndex = 70;
      this.txtRootNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtRootNode.TextChanged += new System.EventHandler(this.txtRootNode_TextChanged);
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(268, 28);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(72, 13);
      this.label14.TabIndex = 71;
      this.label14.Text = "Root Node:";
      // 
      // txtMaskSites
      // 
      this.txtMaskSites.Location = new System.Drawing.Point(168, 101);
      this.txtMaskSites.Name = "txtMaskSites";
      this.txtMaskSites.Size = new System.Drawing.Size(432, 20);
      this.txtMaskSites.TabIndex = 68;
      this.txtMaskSites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMaskSites.TextChanged += new System.EventHandler(this.txtMaskSites_TextChanged);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(14, 104);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(71, 13);
      this.label13.TabIndex = 69;
      this.label13.Text = "Mask sites:";
      // 
      // txtMaskFromEnd
      // 
      this.txtMaskFromEnd.Location = new System.Drawing.Point(168, 82);
      this.txtMaskFromEnd.Name = "txtMaskFromEnd";
      this.txtMaskFromEnd.Size = new System.Drawing.Size(45, 20);
      this.txtMaskFromEnd.TabIndex = 66;
      this.txtMaskFromEnd.Text = "1";
      this.txtMaskFromEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMaskFromEnd.TextChanged += new System.EventHandler(this.txtMaskFromEnd_TextChanged);
      this.txtMaskFromEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaskFromEnd_KeyPress);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(14, 85);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(94, 13);
      this.label12.TabIndex = 67;
      this.label12.Text = "Mask from end:";
      // 
      // txtMaskFromBeginning
      // 
      this.txtMaskFromBeginning.Location = new System.Drawing.Point(168, 63);
      this.txtMaskFromBeginning.Name = "txtMaskFromBeginning";
      this.txtMaskFromBeginning.Size = new System.Drawing.Size(45, 20);
      this.txtMaskFromBeginning.TabIndex = 64;
      this.txtMaskFromBeginning.Text = "1";
      this.txtMaskFromBeginning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMaskFromBeginning.TextChanged += new System.EventHandler(this.txtMaskFromBeginning_TextChanged);
      this.txtMaskFromBeginning.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaskFromBeginning_KeyPress);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(14, 66);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(128, 13);
      this.label11.TabIndex = 65;
      this.label11.Text = "Mask from beginning:";
      // 
      // txtMinLengthFilter
      // 
      this.txtMinLengthFilter.Location = new System.Drawing.Point(168, 44);
      this.txtMinLengthFilter.Name = "txtMinLengthFilter";
      this.txtMinLengthFilter.Size = new System.Drawing.Size(45, 20);
      this.txtMinLengthFilter.TabIndex = 62;
      this.txtMinLengthFilter.Text = "1";
      this.txtMinLengthFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMinLengthFilter.TextChanged += new System.EventHandler(this.txtMinLengthFilter_TextChanged);
      this.txtMinLengthFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinLengthFilter_KeyPress);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(14, 47);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(155, 13);
      this.label10.TabIndex = 63;
      this.label10.Text = "Min genome length (filter):";
      // 
      // txtClusterCutoff
      // 
      this.txtClusterCutoff.Location = new System.Drawing.Point(168, 25);
      this.txtClusterCutoff.Name = "txtClusterCutoff";
      this.txtClusterCutoff.Size = new System.Drawing.Size(45, 20);
      this.txtClusterCutoff.TabIndex = 60;
      this.txtClusterCutoff.Text = "1";
      this.txtClusterCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtClusterCutoff.TextChanged += new System.EventHandler(this.txtClusterCutoff_TextChanged);
      this.txtClusterCutoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClusterCutoff_KeyPress);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(14, 28);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(87, 13);
      this.label9.TabIndex = 61;
      this.label9.Text = "Cluster cutoff:";
      // 
      // txtSNPCutoff
      // 
      this.txtSNPCutoff.Location = new System.Drawing.Point(168, 6);
      this.txtSNPCutoff.Name = "txtSNPCutoff";
      this.txtSNPCutoff.Size = new System.Drawing.Size(45, 20);
      this.txtSNPCutoff.TabIndex = 58;
      this.txtSNPCutoff.Text = "1";
      this.txtSNPCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtSNPCutoff.TextChanged += new System.EventHandler(this.txtSNPCutoff_TextChanged);
      this.txtSNPCutoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSNPCutoff_KeyPress);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(14, 9);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(73, 13);
      this.label8.TabIndex = 59;
      this.label8.Text = "SNP cutoff:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(14, 123);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(115, 13);
      this.label7.TabIndex = 57;
      this.label7.Text = "Number of threads:";
      // 
      // btnReset
      // 
      this.btnReset.FlatAppearance.BorderSize = 2;
      this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnReset.Location = new System.Drawing.Point(12, 73);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(219, 22);
      this.btnReset.TabIndex = 68;
      this.btnReset.Text = "Reset Nextstrain before new run...";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // BioSeqNextstrain
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(688, 483);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.btnMetadata);
      this.Controls.Add(this.btnMetadataPath);
      this.Controls.Add(this.txtMetadataPath);
      this.Controls.Add(this.lblFastqPath);
      this.Controls.Add(this.btnReferencePath);
      this.Controls.Add(this.txtReferencePath);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnOutputPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqNextstrain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Nextstrain phylogenetic analysis";
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
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
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnReferencePath;
    private System.Windows.Forms.TextBox txtReferencePath;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnMetadata;
    private System.Windows.Forms.Button btnMetadataPath;
    private System.Windows.Forms.TextBox txtMetadataPath;
    private System.Windows.Forms.Label lblFastqPath;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox txtRootNode;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtMaskSites;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtMaskFromEnd;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtMaskFromBeginning;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtMinLengthFilter;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtClusterCutoff;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txtSNPCutoff;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DateTimePicker dtpMinDate;
    private System.Windows.Forms.DateTimePicker dtpMinDateFilter;
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.Button btnReset;
  }
}