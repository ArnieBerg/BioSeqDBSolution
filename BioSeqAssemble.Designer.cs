namespace BioSeqDB
{
  partial class BioSeqAssemble
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqAssemble));
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lstSamples = new System.Windows.Forms.CheckedListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSamplePicker = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.pnlBacterial = new System.Windows.Forms.Panel();
      this.btnGeneXRef = new System.Windows.Forms.Button();
      this.txtGeneXRef = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.lblGeneXRef = new System.Windows.Forms.Label();
      this.chkVFabricate = new System.Windows.Forms.CheckBox();
      this.chkQuast = new System.Windows.Forms.CheckBox();
      this.chkBBmap = new System.Windows.Forms.CheckBox();
      this.chkKraken2 = new System.Windows.Forms.CheckBox();
      this.chkFastPolish = new System.Windows.Forms.CheckBox();
      this.grpViral = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtHostReference = new System.Windows.Forms.TextBox();
      this.btnFindHostReferenceGenome = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.txtVirusReference = new System.Windows.Forms.TextBox();
      this.btnFindVirusReferenceGenome = new System.Windows.Forms.Button();
      this.radTrinity = new System.Windows.Forms.RadioButton();
      this.radFlye = new System.Windows.Forms.RadioButton();
      this.radRA = new System.Windows.Forms.RadioButton();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMaxFastq = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox2.SuspendLayout();
      this.pnlBacterial.SuspendLayout();
      this.grpViral.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(695, 54);
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
      this.btnOK.Location = new System.Drawing.Point(654, 569);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "OK";
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
      this.btnCancel.Location = new System.Drawing.Point(785, 569);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // lstSamples
      // 
      this.lstSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstSamples.FormattingEnabled = true;
      this.lstSamples.Location = new System.Drawing.Point(12, 102);
      this.lstSamples.Name = "lstSamples";
      this.lstSamples.Size = new System.Drawing.Size(695, 154);
      this.lstSamples.Sorted = true;
      this.lstSamples.TabIndex = 25;
      this.lstSamples.SelectedValueChanged += new System.EventHandler(this.lstSamples_SelectedValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(5, 70);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(129, 13);
      this.label3.TabIndex = 26;
      this.label3.Text = "Samples to assemble:";
      // 
      // btnSamplePicker
      // 
      this.btnSamplePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSamplePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSamplePicker.Location = new System.Drawing.Point(713, 102);
      this.btnSamplePicker.Name = "btnSamplePicker";
      this.btnSamplePicker.Size = new System.Drawing.Size(122, 23);
      this.btnSamplePicker.TabIndex = 27;
      this.btnSamplePicker.Text = "Sample picker...";
      this.btnSamplePicker.UseVisualStyleBackColor = true;
      this.btnSamplePicker.Click += new System.EventHandler(this.btnSamplePicker_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Location = new System.Drawing.Point(713, 131);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(122, 23);
      this.btnDelete.TabIndex = 28;
      this.btnDelete.Text = "Delete unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.pnlBacterial);
      this.groupBox2.Controls.Add(this.chkFastPolish);
      this.groupBox2.Controls.Add(this.grpViral);
      this.groupBox2.Controls.Add(this.radTrinity);
      this.groupBox2.Controls.Add(this.radFlye);
      this.groupBox2.Controls.Add(this.radRA);
      this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(12, 263);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(695, 289);
      this.groupBox2.TabIndex = 30;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Select assembler:";
      // 
      // pnlBacterial
      // 
      this.pnlBacterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlBacterial.Controls.Add(this.btnGeneXRef);
      this.pnlBacterial.Controls.Add(this.txtGeneXRef);
      this.pnlBacterial.Controls.Add(this.label5);
      this.pnlBacterial.Controls.Add(this.lblGeneXRef);
      this.pnlBacterial.Controls.Add(this.chkVFabricate);
      this.pnlBacterial.Controls.Add(this.chkQuast);
      this.pnlBacterial.Controls.Add(this.chkBBmap);
      this.pnlBacterial.Controls.Add(this.chkKraken2);
      this.pnlBacterial.Location = new System.Drawing.Point(156, 14);
      this.pnlBacterial.Name = "pnlBacterial";
      this.pnlBacterial.Size = new System.Drawing.Size(519, 93);
      this.pnlBacterial.TabIndex = 34;
      // 
      // btnGeneXRef
      // 
      this.btnGeneXRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGeneXRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGeneXRef.Location = new System.Drawing.Point(480, 66);
      this.btnGeneXRef.Name = "btnGeneXRef";
      this.btnGeneXRef.Size = new System.Drawing.Size(31, 23);
      this.btnGeneXRef.TabIndex = 51;
      this.btnGeneXRef.Text = "...";
      this.btnGeneXRef.UseVisualStyleBackColor = true;
      this.btnGeneXRef.Click += new System.EventHandler(this.btnGeneXRef_Click);
      // 
      // txtGeneXRef
      // 
      this.txtGeneXRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtGeneXRef.Location = new System.Drawing.Point(11, 67);
      this.txtGeneXRef.Name = "txtGeneXRef";
      this.txtGeneXRef.Size = new System.Drawing.Size(468, 20);
      this.txtGeneXRef.TabIndex = 50;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(8, 4);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(122, 13);
      this.label5.TabIndex = 51;
      this.label5.Text = "Analyses to perform:";
      // 
      // lblGeneXRef
      // 
      this.lblGeneXRef.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
      this.lblGeneXRef.AutoSize = true;
      this.lblGeneXRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGeneXRef.Location = new System.Drawing.Point(8, 51);
      this.lblGeneXRef.Name = "lblGeneXRef";
      this.lblGeneXRef.Size = new System.Drawing.Size(335, 13);
      this.lblGeneXRef.TabIndex = 50;
      this.lblGeneXRef.Text = "Gene cross-reference configuration table (for VFabricate):";
      // 
      // chkVFabricate
      // 
      this.chkVFabricate.AutoSize = true;
      this.chkVFabricate.Checked = true;
      this.chkVFabricate.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkVFabricate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkVFabricate.Location = new System.Drawing.Point(226, 25);
      this.chkVFabricate.Name = "chkVFabricate";
      this.chkVFabricate.Size = new System.Drawing.Size(87, 17);
      this.chkVFabricate.TabIndex = 49;
      this.chkVFabricate.Text = "VFabricate";
      this.chkVFabricate.UseVisualStyleBackColor = true;
      this.chkVFabricate.CheckedChanged += new System.EventHandler(this.chkVFabricate_CheckedChanged);
      // 
      // chkQuast
      // 
      this.chkQuast.AutoSize = true;
      this.chkQuast.Checked = true;
      this.chkQuast.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkQuast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkQuast.Location = new System.Drawing.Point(161, 25);
      this.chkQuast.Name = "chkQuast";
      this.chkQuast.Size = new System.Drawing.Size(59, 17);
      this.chkQuast.TabIndex = 48;
      this.chkQuast.Text = "Quast";
      this.chkQuast.UseVisualStyleBackColor = true;
      // 
      // chkBBmap
      // 
      this.chkBBmap.AutoSize = true;
      this.chkBBmap.Checked = true;
      this.chkBBmap.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkBBmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkBBmap.Location = new System.Drawing.Point(90, 25);
      this.chkBBmap.Name = "chkBBmap";
      this.chkBBmap.Size = new System.Drawing.Size(65, 17);
      this.chkBBmap.TabIndex = 47;
      this.chkBBmap.Text = "BBmap";
      this.chkBBmap.UseVisualStyleBackColor = true;
      // 
      // chkKraken2
      // 
      this.chkKraken2.AutoSize = true;
      this.chkKraken2.Checked = true;
      this.chkKraken2.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkKraken2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkKraken2.Location = new System.Drawing.Point(11, 25);
      this.chkKraken2.Name = "chkKraken2";
      this.chkKraken2.Size = new System.Drawing.Size(73, 17);
      this.chkKraken2.TabIndex = 46;
      this.chkKraken2.Text = "Kraken2";
      this.chkKraken2.UseVisualStyleBackColor = true;
      // 
      // chkFastPolish
      // 
      this.chkFastPolish.AutoSize = true;
      this.chkFastPolish.Checked = true;
      this.chkFastPolish.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkFastPolish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkFastPolish.Location = new System.Drawing.Point(167, 113);
      this.chkFastPolish.Name = "chkFastPolish";
      this.chkFastPolish.Size = new System.Drawing.Size(222, 17);
      this.chkFastPolish.TabIndex = 52;
      this.chkFastPolish.Text = "Use fast polish (skip Medaka step)";
      this.chkFastPolish.UseVisualStyleBackColor = true;
      // 
      // grpViral
      // 
      this.grpViral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpViral.Controls.Add(this.label1);
      this.grpViral.Controls.Add(this.txtHostReference);
      this.grpViral.Controls.Add(this.btnFindHostReferenceGenome);
      this.grpViral.Controls.Add(this.label7);
      this.grpViral.Controls.Add(this.txtVirusReference);
      this.grpViral.Controls.Add(this.btnFindVirusReferenceGenome);
      this.grpViral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.grpViral.Location = new System.Drawing.Point(27, 172);
      this.grpViral.Name = "grpViral";
      this.grpViral.Size = new System.Drawing.Size(651, 110);
      this.grpViral.TabIndex = 32;
      this.grpViral.TabStop = false;
      this.grpViral.Text = "Reference genomes:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 59);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(152, 13);
      this.label1.TabIndex = 47;
      this.label1.Text = "Host reference (optional):";
      // 
      // txtHostReference
      // 
      this.txtHostReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtHostReference.Location = new System.Drawing.Point(15, 75);
      this.txtHostReference.Name = "txtHostReference";
      this.txtHostReference.Size = new System.Drawing.Size(601, 20);
      this.txtHostReference.TabIndex = 45;
      // 
      // btnFindHostReferenceGenome
      // 
      this.btnFindHostReferenceGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindHostReferenceGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindHostReferenceGenome.Location = new System.Drawing.Point(617, 73);
      this.btnFindHostReferenceGenome.Name = "btnFindHostReferenceGenome";
      this.btnFindHostReferenceGenome.Size = new System.Drawing.Size(31, 23);
      this.btnFindHostReferenceGenome.TabIndex = 46;
      this.btnFindHostReferenceGenome.Text = "...";
      this.btnFindHostReferenceGenome.UseVisualStyleBackColor = true;
      this.btnFindHostReferenceGenome.Click += new System.EventHandler(this.btnFindHostReferenceGenome_Click);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(12, 21);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(97, 13);
      this.label7.TabIndex = 44;
      this.label7.Text = "Virus reference:";
      // 
      // txtVirusReference
      // 
      this.txtVirusReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtVirusReference.Location = new System.Drawing.Point(15, 37);
      this.txtVirusReference.Name = "txtVirusReference";
      this.txtVirusReference.Size = new System.Drawing.Size(601, 20);
      this.txtVirusReference.TabIndex = 43;
      // 
      // btnFindVirusReferenceGenome
      // 
      this.btnFindVirusReferenceGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindVirusReferenceGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindVirusReferenceGenome.Location = new System.Drawing.Point(617, 35);
      this.btnFindVirusReferenceGenome.Name = "btnFindVirusReferenceGenome";
      this.btnFindVirusReferenceGenome.Size = new System.Drawing.Size(31, 23);
      this.btnFindVirusReferenceGenome.TabIndex = 44;
      this.btnFindVirusReferenceGenome.Text = "...";
      this.btnFindVirusReferenceGenome.UseVisualStyleBackColor = true;
      this.btnFindVirusReferenceGenome.Click += new System.EventHandler(this.btnFindVirusReferenceGenome_Click);
      // 
      // radTrinity
      // 
      this.radTrinity.AutoSize = true;
      this.radTrinity.Location = new System.Drawing.Point(15, 149);
      this.radTrinity.Name = "radTrinity";
      this.radTrinity.Size = new System.Drawing.Size(96, 17);
      this.radTrinity.TabIndex = 31;
      this.radTrinity.Text = "Trinity (viral)";
      this.radTrinity.UseVisualStyleBackColor = true;
      this.radTrinity.CheckedChanged += new System.EventHandler(this.radAssembler_CheckedChanged);
      // 
      // radFlye
      // 
      this.radFlye.AutoSize = true;
      this.radFlye.Location = new System.Drawing.Point(15, 48);
      this.radFlye.Name = "radFlye";
      this.radFlye.Size = new System.Drawing.Size(48, 17);
      this.radFlye.TabIndex = 1;
      this.radFlye.Text = "Flye";
      this.radFlye.UseVisualStyleBackColor = true;
      this.radFlye.CheckedChanged += new System.EventHandler(this.radAssembler_CheckedChanged);
      // 
      // radRA
      // 
      this.radRA.AutoSize = true;
      this.radRA.Location = new System.Drawing.Point(15, 25);
      this.radRA.Name = "radRA";
      this.radRA.Size = new System.Drawing.Size(119, 17);
      this.radRA.TabIndex = 0;
      this.radRA.Text = "Rapid Assembler";
      this.radRA.UseVisualStyleBackColor = true;
      this.radRA.CheckedChanged += new System.EventHandler(this.radAssembler_CheckedChanged);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackgroundImage = global::BioSeqDB.Properties.Resources._5130___Assembly_Line_512;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(720, 173);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(114, 97);
      this.pictureBox1.TabIndex = 31;
      this.pictureBox1.TabStop = false;
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Location = new System.Drawing.Point(15, 85);
      this.chkAll.Name = "chkAll";
      this.chkAll.Size = new System.Drawing.Size(71, 17);
      this.chkAll.TabIndex = 32;
      this.chkAll.Text = "(all/none)";
      this.chkAll.UseVisualStyleBackColor = true;
      this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(12, 571);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(557, 20);
      this.txtMemo.TabIndex = 33;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 555);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(255, 13);
      this.label2.TabIndex = 34;
      this.label2.Text = "Memo (to help identify task in notifications):";
      // 
      // txtMaxFastq
      // 
      this.txtMaxFastq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMaxFastq.Location = new System.Drawing.Point(641, 80);
      this.txtMaxFastq.Name = "txtMaxFastq";
      this.txtMaxFastq.Size = new System.Drawing.Size(66, 20);
      this.txtMaxFastq.TabIndex = 36;
      this.txtMaxFastq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxFastq_KeyPress);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(530, 83);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(105, 13);
      this.label6.TabIndex = 37;
      this.label6.Text = "Max # fastq files:";
      // 
      // BioSeqAssemble
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(874, 600);
      this.Controls.Add(this.txtMaxFastq);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnSamplePicker);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lstSamples);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "BioSeqAssemble";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "BioSeqDB Assemble Samples";
      this.Shown += new System.EventHandler(this.BioSeqAssemble_Shown);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.pnlBacterial.ResumeLayout(false);
      this.pnlBacterial.PerformLayout();
      this.grpViral.ResumeLayout(false);
      this.grpViral.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckedListBox lstSamples;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSamplePicker;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton radFlye;
    private System.Windows.Forms.RadioButton radRA;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.GroupBox grpViral;
    private System.Windows.Forms.RadioButton radTrinity;
    private System.Windows.Forms.CheckBox chkFastPolish;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtHostReference;
    private System.Windows.Forms.Button btnFindHostReferenceGenome;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtVirusReference;
    private System.Windows.Forms.Button btnFindVirusReferenceGenome;
    private System.Windows.Forms.Panel pnlBacterial;
    private System.Windows.Forms.Button btnGeneXRef;
    private System.Windows.Forms.TextBox txtGeneXRef;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblGeneXRef;
    private System.Windows.Forms.CheckBox chkVFabricate;
    private System.Windows.Forms.CheckBox chkQuast;
    private System.Windows.Forms.CheckBox chkBBmap;
    private System.Windows.Forms.CheckBox chkKraken2;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMaxFastq;
    private System.Windows.Forms.Label label6;
  }
}