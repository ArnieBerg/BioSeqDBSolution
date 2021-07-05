namespace BioSeqDB
{
  partial class BioSeqBuildTree
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqBuildTree));
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnFindDBPath = new System.Windows.Forms.Button();
      this.txtOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.chkFastTree = new System.Windows.Forms.CheckBox();
      this.lstQueryGenomes = new System.Windows.Forms.CheckedListBox();
      this.btnGenomePicker = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.chkMakeStandard = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.radDomesticReference = new System.Windows.Forms.RadioButton();
      this.txtDomesticReference = new System.Windows.Forms.TextBox();
      this.radWildReference = new System.Windows.Forms.RadioButton();
      this.btnFindWildReferenceGenome = new System.Windows.Forms.Button();
      this.txtWildReference = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.radCluster = new System.Windows.Forms.RadioButton();
      this.label8 = new System.Windows.Forms.Label();
      this.txtCutoff = new System.Windows.Forms.TextBox();
      this.lblCutoff = new System.Windows.Forms.Label();
      this.radTophits = new System.Windows.Forms.RadioButton();
      this.radThreshold = new System.Windows.Forms.RadioButton();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
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
      this.label4.Size = new System.Drawing.Size(565, 54);
      this.label4.TabIndex = 13;
      this.label4.Text = "Construct a cgSNP tree from closest genomic neighbours in the database.";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(463, 644);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(61, 22);
      this.btnOK.TabIndex = 40;
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
      this.btnCancel.Location = new System.Drawing.Point(583, 644);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 41;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnFindDBPath
      // 
      this.btnFindDBPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindDBPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindDBPath.Location = new System.Drawing.Point(608, 420);
      this.btnFindDBPath.Name = "btnFindDBPath";
      this.btnFindDBPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindDBPath.TabIndex = 11;
      this.btnFindDBPath.Text = "...";
      this.btnFindDBPath.UseVisualStyleBackColor = true;
      this.btnFindDBPath.Click += new System.EventHandler(this.btnFindOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(12, 422);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(595, 20);
      this.txtOutputPath.TabIndex = 10;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 406);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 13);
      this.label1.TabIndex = 20;
      this.label1.Text = "Path to output results:";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(368, 607);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 23;
      this.label6.Text = "Number of threads:";
      // 
      // txtThreads
      // 
      this.txtThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txtThreads.Location = new System.Drawing.Point(489, 604);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 39;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.TextChanged += new System.EventHandler(this.txtThreads_TextChanged);
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreads_KeyPress);
      // 
      // chkFastTree
      // 
      this.chkFastTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkFastTree.AutoSize = true;
      this.chkFastTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkFastTree.Location = new System.Drawing.Point(25, 607);
      this.chkFastTree.Name = "chkFastTree";
      this.chkFastTree.Size = new System.Drawing.Size(195, 17);
      this.chkFastTree.TabIndex = 38;
      this.chkFastTree.Text = "Use FastTree analysis (faster)";
      this.chkFastTree.UseVisualStyleBackColor = true;
      // 
      // lstQueryGenomes
      // 
      this.lstQueryGenomes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstQueryGenomes.FormattingEnabled = true;
      this.lstQueryGenomes.Location = new System.Drawing.Point(12, 256);
      this.lstQueryGenomes.Name = "lstQueryGenomes";
      this.lstQueryGenomes.Size = new System.Drawing.Size(504, 139);
      this.lstQueryGenomes.Sorted = true;
      this.lstQueryGenomes.TabIndex = 7;
      this.lstQueryGenomes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstQueryGenomes_ItemCheck);
      this.lstQueryGenomes.SelectedValueChanged += new System.EventHandler(this.lstQueryGenomes_SelectedValueChanged);
      // 
      // btnGenomePicker
      // 
      this.btnGenomePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGenomePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGenomePicker.Location = new System.Drawing.Point(522, 256);
      this.btnGenomePicker.Name = "btnGenomePicker";
      this.btnGenomePicker.Size = new System.Drawing.Size(122, 23);
      this.btnGenomePicker.TabIndex = 8;
      this.btnGenomePicker.Text = "Genome picker...";
      this.btnGenomePicker.UseVisualStyleBackColor = true;
      this.btnGenomePicker.Click += new System.EventHandler(this.btnGenomePicker_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Location = new System.Drawing.Point(522, 285);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(122, 23);
      this.btnDelete.TabIndex = 9;
      this.btnDelete.Text = "Remove unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.chkMakeStandard);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.radDomesticReference);
      this.panel1.Controls.Add(this.txtDomesticReference);
      this.panel1.Controls.Add(this.radWildReference);
      this.panel1.Controls.Add(this.btnFindWildReferenceGenome);
      this.panel1.Controls.Add(this.txtWildReference);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(12, 76);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(567, 132);
      this.panel1.TabIndex = 34;
      // 
      // chkMakeStandard
      // 
      this.chkMakeStandard.AutoSize = true;
      this.chkMakeStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkMakeStandard.Location = new System.Drawing.Point(259, 50);
      this.chkMakeStandard.Name = "chkMakeStandard";
      this.chkMakeStandard.Size = new System.Drawing.Size(270, 17);
      this.chkMakeStandard.TabIndex = 37;
      this.chkMakeStandard.Text = "Make this the standard database reference";
      this.chkMakeStandard.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(33, 71);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(224, 13);
      this.label7.TabIndex = 41;
      this.label7.Text = "Standard database reference genome:";
      // 
      // radDomesticReference
      // 
      this.radDomesticReference.AutoSize = true;
      this.radDomesticReference.Location = new System.Drawing.Point(12, 90);
      this.radDomesticReference.Name = "radDomesticReference";
      this.radDomesticReference.Size = new System.Drawing.Size(14, 13);
      this.radDomesticReference.TabIndex = 38;
      this.radDomesticReference.UseVisualStyleBackColor = true;
      // 
      // txtDomesticReference
      // 
      this.txtDomesticReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDomesticReference.Location = new System.Drawing.Point(36, 87);
      this.txtDomesticReference.Name = "txtDomesticReference";
      this.txtDomesticReference.Size = new System.Drawing.Size(486, 20);
      this.txtDomesticReference.TabIndex = 39;
      // 
      // radWildReference
      // 
      this.radWildReference.AutoSize = true;
      this.radWildReference.Checked = true;
      this.radWildReference.Location = new System.Drawing.Point(12, 31);
      this.radWildReference.Name = "radWildReference";
      this.radWildReference.Size = new System.Drawing.Size(14, 13);
      this.radWildReference.TabIndex = 34;
      this.radWildReference.TabStop = true;
      this.radWildReference.UseVisualStyleBackColor = true;
      // 
      // btnFindWildReferenceGenome
      // 
      this.btnFindWildReferenceGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindWildReferenceGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindWildReferenceGenome.Location = new System.Drawing.Point(523, 26);
      this.btnFindWildReferenceGenome.Name = "btnFindWildReferenceGenome";
      this.btnFindWildReferenceGenome.Size = new System.Drawing.Size(31, 23);
      this.btnFindWildReferenceGenome.TabIndex = 36;
      this.btnFindWildReferenceGenome.Text = "...";
      this.btnFindWildReferenceGenome.UseVisualStyleBackColor = true;
      this.btnFindWildReferenceGenome.Click += new System.EventHandler(this.btnFindReferencePath_Click);
      // 
      // txtWildReference
      // 
      this.txtWildReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtWildReference.Location = new System.Drawing.Point(36, 28);
      this.txtWildReference.Name = "txtWildReference";
      this.txtWildReference.Size = new System.Drawing.Size(486, 20);
      this.txtWildReference.TabIndex = 35;
      this.txtWildReference.TextChanged += new System.EventHandler(this.txtInputPath_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(33, 12);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(203, 13);
      this.label2.TabIndex = 40;
      this.label2.Text = "Reference genome in fasta format:";
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Location = new System.Drawing.Point(15, 239);
      this.chkAll.Name = "chkAll";
      this.chkAll.Size = new System.Drawing.Size(15, 14);
      this.chkAll.TabIndex = 35;
      this.chkAll.UseVisualStyleBackColor = true;
      this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 220);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(98, 13);
      this.label3.TabIndex = 36;
      this.label3.Text = "Query genomes:";
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.radCluster);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.txtCutoff);
      this.panel2.Controls.Add(this.lblCutoff);
      this.panel2.Controls.Add(this.radTophits);
      this.panel2.Controls.Add(this.radThreshold);
      this.panel2.Location = new System.Drawing.Point(15, 448);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(629, 146);
      this.panel2.TabIndex = 37;
      // 
      // radCluster
      // 
      this.radCluster.AutoSize = true;
      this.radCluster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radCluster.Location = new System.Drawing.Point(12, 79);
      this.radCluster.Name = "radCluster";
      this.radCluster.Size = new System.Drawing.Size(584, 17);
      this.radCluster.TabIndex = 36;
      this.radCluster.Text = "cluster: use multi-dimensional density-based clustering to identify the closest r" +
    "elated subpopulation";
      this.radCluster.UseVisualStyleBackColor = true;
      this.radCluster.CheckedChanged += new System.EventHandler(this.radCluster_CheckedChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(9, 4);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(249, 13);
      this.label8.TabIndex = 41;
      this.label8.Text = "Select method to define molecular linkage:";
      // 
      // txtCutoff
      // 
      this.txtCutoff.Location = new System.Drawing.Point(324, 112);
      this.txtCutoff.Name = "txtCutoff";
      this.txtCutoff.Size = new System.Drawing.Size(45, 20);
      this.txtCutoff.TabIndex = 37;
      this.txtCutoff.Text = "1";
      this.txtCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtCutoff.TextChanged += new System.EventHandler(this.txtCutoff_TextChanged);
      this.txtCutoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCutoff_KeyPress);
      // 
      // lblCutoff
      // 
      this.lblCutoff.AutoSize = true;
      this.lblCutoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCutoff.Location = new System.Drawing.Point(9, 115);
      this.lblCutoff.Name = "lblCutoff";
      this.lblCutoff.Size = new System.Drawing.Size(303, 13);
      this.lblCutoff.TabIndex = 40;
      this.lblCutoff.Text = "Number of top hits to include per query [Default: 25]";
      // 
      // radTophits
      // 
      this.radTophits.AutoSize = true;
      this.radTophits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radTophits.Location = new System.Drawing.Point(12, 55);
      this.radTophits.Name = "radTophits";
      this.radTophits.Size = new System.Drawing.Size(511, 17);
      this.radTophits.TabIndex = 35;
      this.radTophits.Text = "tophits: retrieve the top n number of hits ranked by genetic distances from low t" +
    "o high";
      this.radTophits.UseVisualStyleBackColor = true;
      this.radTophits.CheckedChanged += new System.EventHandler(this.radTophits_CheckedChanged);
      // 
      // radThreshold
      // 
      this.radThreshold.AutoSize = true;
      this.radThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radThreshold.Location = new System.Drawing.Point(12, 31);
      this.radThreshold.Name = "radThreshold";
      this.radThreshold.Size = new System.Drawing.Size(415, 17);
      this.radThreshold.TabIndex = 34;
      this.radThreshold.Text = "threshold: use a universal distance threshold cutoff to define linkage";
      this.radThreshold.UseVisualStyleBackColor = true;
      this.radThreshold.CheckedChanged += new System.EventHandler(this.radThreshold_CheckedChanged);
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(15, 646);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(428, 20);
      this.txtMemo.TabIndex = 42;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(15, 630);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(255, 13);
      this.label5.TabIndex = 43;
      this.label5.Text = "Memo (to help identify task in notifications):";
      // 
      // BioSeqBuildTree
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(683, 672);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnGenomePicker);
      this.Controls.Add(this.lstQueryGenomes);
      this.Controls.Add(this.chkFastTree);
      this.Controls.Add(this.txtThreads);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btnFindDBPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "BioSeqBuildTree";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Build Tree Analysis";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnFindDBPath;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.CheckBox chkFastTree;
    private System.Windows.Forms.CheckedListBox lstQueryGenomes;
    private System.Windows.Forms.Button btnGenomePicker;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox chkMakeStandard;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.RadioButton radDomesticReference;
    private System.Windows.Forms.TextBox txtDomesticReference;
    private System.Windows.Forms.RadioButton radWildReference;
    private System.Windows.Forms.Button btnFindWildReferenceGenome;
    private System.Windows.Forms.TextBox txtWildReference;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtCutoff;
    private System.Windows.Forms.Label lblCutoff;
    private System.Windows.Forms.RadioButton radTophits;
    private System.Windows.Forms.RadioButton radThreshold;
    private System.Windows.Forms.RadioButton radCluster;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label5;
  }
}