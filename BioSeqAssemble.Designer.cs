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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMaxFastq = new System.Windows.Forms.TextBox();
      this.lblMaxFiles = new System.Windows.Forms.Label();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabBacterial = new System.Windows.Forms.TabPage();
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
      this.radFlye = new System.Windows.Forms.RadioButton();
      this.radRA = new System.Windows.Forms.RadioButton();
      this.tabViral = new System.Windows.Forms.TabPage();
      this.label8 = new System.Windows.Forms.Label();
      this.grpViral = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtHostReference = new System.Windows.Forms.TextBox();
      this.btnFindHostReferenceGenome = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.txtVirusReference = new System.Windows.Forms.TextBox();
      this.btnFindVirusReferenceGenome = new System.Windows.Forms.Button();
      this.tabSanger = new System.Windows.Forms.TabPage();
      this.label9 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txtTracyReference = new System.Windows.Forms.TextBox();
      this.btnTracyReference = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabBacterial.SuspendLayout();
      this.pnlBacterial.SuspendLayout();
      this.tabViral.SuspendLayout();
      this.grpViral.SuspendLayout();
      this.tabSanger.SuspendLayout();
      this.groupBox1.SuspendLayout();
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
      this.btnOK.Location = new System.Drawing.Point(654, 521);
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
      this.btnCancel.Location = new System.Drawing.Point(785, 521);
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
      this.lstSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstSamples.FormattingEnabled = true;
      this.lstSamples.Location = new System.Drawing.Point(12, 102);
      this.lstSamples.Name = "lstSamples";
      this.lstSamples.Size = new System.Drawing.Size(695, 109);
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
      this.btnDelete.Text = "Remove unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackgroundImage = global::BioSeqDB.Properties.Resources._5130___Assembly_Line_512;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(799, 7);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(66, 56);
      this.pictureBox1.TabIndex = 31;
      this.pictureBox1.TabStop = false;
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
      this.txtMemo.Location = new System.Drawing.Point(12, 523);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(557, 20);
      this.txtMemo.TabIndex = 33;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 507);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(255, 13);
      this.label2.TabIndex = 34;
      this.label2.Text = "Memo (to help identify task in notifications):";
      // 
      // txtMaxFastq
      // 
      this.txtMaxFastq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMaxFastq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMaxFastq.Location = new System.Drawing.Point(641, 80);
      this.txtMaxFastq.Name = "txtMaxFastq";
      this.txtMaxFastq.Size = new System.Drawing.Size(66, 20);
      this.txtMaxFastq.TabIndex = 36;
      this.txtMaxFastq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxFastq_KeyPress);
      // 
      // lblMaxFiles
      // 
      this.lblMaxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMaxFiles.AutoSize = true;
      this.lblMaxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMaxFiles.Location = new System.Drawing.Point(530, 83);
      this.lblMaxFiles.Name = "lblMaxFiles";
      this.lblMaxFiles.Size = new System.Drawing.Size(105, 13);
      this.lblMaxFiles.TabIndex = 37;
      this.lblMaxFiles.Text = "Max # fastq files:";
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabBacterial);
      this.tabControl1.Controls.Add(this.tabViral);
      this.tabControl1.Controls.Add(this.tabSanger);
      this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabControl1.Location = new System.Drawing.Point(15, 223);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(692, 260);
      this.tabControl1.TabIndex = 38;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabBacterial
      // 
      this.tabBacterial.Controls.Add(this.pnlBacterial);
      this.tabBacterial.Controls.Add(this.chkFastPolish);
      this.tabBacterial.Controls.Add(this.radFlye);
      this.tabBacterial.Controls.Add(this.radRA);
      this.tabBacterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabBacterial.Location = new System.Drawing.Point(4, 22);
      this.tabBacterial.Name = "tabBacterial";
      this.tabBacterial.Padding = new System.Windows.Forms.Padding(3);
      this.tabBacterial.Size = new System.Drawing.Size(684, 234);
      this.tabBacterial.TabIndex = 0;
      this.tabBacterial.Text = "Bacterial";
      this.tabBacterial.UseVisualStyleBackColor = true;
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
      this.pnlBacterial.Location = new System.Drawing.Point(136, 15);
      this.pnlBacterial.Name = "pnlBacterial";
      this.pnlBacterial.Size = new System.Drawing.Size(543, 93);
      this.pnlBacterial.TabIndex = 55;
      // 
      // btnGeneXRef
      // 
      this.btnGeneXRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGeneXRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGeneXRef.Location = new System.Drawing.Point(497, 66);
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
      this.txtGeneXRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtGeneXRef.Location = new System.Drawing.Point(11, 67);
      this.txtGeneXRef.Name = "txtGeneXRef";
      this.txtGeneXRef.Size = new System.Drawing.Size(487, 20);
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
      this.chkFastPolish.Location = new System.Drawing.Point(139, 114);
      this.chkFastPolish.Name = "chkFastPolish";
      this.chkFastPolish.Size = new System.Drawing.Size(222, 17);
      this.chkFastPolish.TabIndex = 56;
      this.chkFastPolish.Text = "Use fast polish (skip Medaka step)";
      this.chkFastPolish.UseVisualStyleBackColor = true;
      // 
      // radFlye
      // 
      this.radFlye.AutoSize = true;
      this.radFlye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radFlye.Location = new System.Drawing.Point(11, 41);
      this.radFlye.Name = "radFlye";
      this.radFlye.Size = new System.Drawing.Size(48, 17);
      this.radFlye.TabIndex = 54;
      this.radFlye.Text = "Flye";
      this.radFlye.UseVisualStyleBackColor = true;
      // 
      // radRA
      // 
      this.radRA.AutoSize = true;
      this.radRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radRA.Location = new System.Drawing.Point(11, 18);
      this.radRA.Name = "radRA";
      this.radRA.Size = new System.Drawing.Size(119, 17);
      this.radRA.TabIndex = 53;
      this.radRA.Text = "Rapid Assembler";
      this.radRA.UseVisualStyleBackColor = true;
      // 
      // tabViral
      // 
      this.tabViral.Controls.Add(this.label8);
      this.tabViral.Controls.Add(this.grpViral);
      this.tabViral.Location = new System.Drawing.Point(4, 22);
      this.tabViral.Name = "tabViral";
      this.tabViral.Padding = new System.Windows.Forms.Padding(3);
      this.tabViral.Size = new System.Drawing.Size(684, 234);
      this.tabViral.TabIndex = 1;
      this.tabViral.Text = "Viral";
      this.tabViral.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(36, 19);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(102, 13);
      this.label8.TabIndex = 45;
      this.label8.Text = "Trinity assembler";
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
      this.grpViral.Location = new System.Drawing.Point(24, 70);
      this.grpViral.Name = "grpViral";
      this.grpViral.Size = new System.Drawing.Size(648, 110);
      this.grpViral.TabIndex = 34;
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
      this.txtHostReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtHostReference.Location = new System.Drawing.Point(15, 75);
      this.txtHostReference.Name = "txtHostReference";
      this.txtHostReference.Size = new System.Drawing.Size(598, 20);
      this.txtHostReference.TabIndex = 45;
      // 
      // btnFindHostReferenceGenome
      // 
      this.btnFindHostReferenceGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindHostReferenceGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindHostReferenceGenome.Location = new System.Drawing.Point(611, 74);
      this.btnFindHostReferenceGenome.Name = "btnFindHostReferenceGenome";
      this.btnFindHostReferenceGenome.Size = new System.Drawing.Size(31, 22);
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
      this.txtVirusReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtVirusReference.Location = new System.Drawing.Point(15, 37);
      this.txtVirusReference.Name = "txtVirusReference";
      this.txtVirusReference.Size = new System.Drawing.Size(598, 20);
      this.txtVirusReference.TabIndex = 43;
      // 
      // btnFindVirusReferenceGenome
      // 
      this.btnFindVirusReferenceGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindVirusReferenceGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindVirusReferenceGenome.Location = new System.Drawing.Point(611, 36);
      this.btnFindVirusReferenceGenome.Name = "btnFindVirusReferenceGenome";
      this.btnFindVirusReferenceGenome.Size = new System.Drawing.Size(31, 22);
      this.btnFindVirusReferenceGenome.TabIndex = 44;
      this.btnFindVirusReferenceGenome.Text = "...";
      this.btnFindVirusReferenceGenome.UseVisualStyleBackColor = true;
      this.btnFindVirusReferenceGenome.Click += new System.EventHandler(this.btnFindVirusReferenceGenome_Click);
      // 
      // tabSanger
      // 
      this.tabSanger.Controls.Add(this.label9);
      this.tabSanger.Controls.Add(this.groupBox1);
      this.tabSanger.Location = new System.Drawing.Point(4, 22);
      this.tabSanger.Name = "tabSanger";
      this.tabSanger.Size = new System.Drawing.Size(684, 234);
      this.tabSanger.TabIndex = 2;
      this.tabSanger.Text = "Sanger";
      this.tabSanger.UseVisualStyleBackColor = true;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(36, 19);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(99, 13);
      this.label9.TabIndex = 47;
      this.label9.Text = "Tracy assembler";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label11);
      this.groupBox1.Controls.Add(this.txtTracyReference);
      this.groupBox1.Controls.Add(this.btnTracyReference);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(24, 70);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(638, 82);
      this.groupBox1.TabIndex = 46;
      this.groupBox1.TabStop = false;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(12, 21);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(127, 13);
      this.label11.TabIndex = 44;
      this.label11.Text = "Reference (optional):";
      // 
      // txtTracyReference
      // 
      this.txtTracyReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTracyReference.Location = new System.Drawing.Point(15, 37);
      this.txtTracyReference.Name = "txtTracyReference";
      this.txtTracyReference.Size = new System.Drawing.Size(588, 20);
      this.txtTracyReference.TabIndex = 43;
      // 
      // btnTracyReference
      // 
      this.btnTracyReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTracyReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTracyReference.Location = new System.Drawing.Point(601, 36);
      this.btnTracyReference.Name = "btnTracyReference";
      this.btnTracyReference.Size = new System.Drawing.Size(31, 22);
      this.btnTracyReference.TabIndex = 44;
      this.btnTracyReference.Text = "...";
      this.btnTracyReference.UseVisualStyleBackColor = true;
      this.btnTracyReference.Click += new System.EventHandler(this.btnTracyReference_Click);
      // 
      // BioSeqAssemble
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(874, 561);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.txtMaxFastq);
      this.Controls.Add(this.lblMaxFiles);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.pictureBox1);
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
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabBacterial.ResumeLayout(false);
      this.tabBacterial.PerformLayout();
      this.pnlBacterial.ResumeLayout(false);
      this.pnlBacterial.PerformLayout();
      this.tabViral.ResumeLayout(false);
      this.tabViral.PerformLayout();
      this.grpViral.ResumeLayout(false);
      this.grpViral.PerformLayout();
      this.tabSanger.ResumeLayout(false);
      this.tabSanger.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
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
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMaxFastq;
    private System.Windows.Forms.Label lblMaxFiles;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabBacterial;
    private System.Windows.Forms.Panel pnlBacterial;
    private System.Windows.Forms.Button btnGeneXRef;
    private System.Windows.Forms.TextBox txtGeneXRef;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblGeneXRef;
    private System.Windows.Forms.CheckBox chkVFabricate;
    private System.Windows.Forms.CheckBox chkQuast;
    private System.Windows.Forms.CheckBox chkBBmap;
    private System.Windows.Forms.CheckBox chkKraken2;
    private System.Windows.Forms.CheckBox chkFastPolish;
    private System.Windows.Forms.RadioButton radFlye;
    private System.Windows.Forms.RadioButton radRA;
    private System.Windows.Forms.TabPage tabViral;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.GroupBox grpViral;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtHostReference;
    private System.Windows.Forms.Button btnFindHostReferenceGenome;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtVirusReference;
    private System.Windows.Forms.Button btnFindVirusReferenceGenome;
    private System.Windows.Forms.TabPage tabSanger;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtTracyReference;
    private System.Windows.Forms.Button btnTracyReference;
  }
}