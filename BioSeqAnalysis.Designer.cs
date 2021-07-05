namespace BioSeqDB
{
  partial class BioSeqAnalysis
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
      this.lblDescription = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnFindOutputPath = new System.Windows.Forms.Button();
      this.txtOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnFastqPath = new System.Windows.Forms.Button();
      this.txtFastqPath = new System.Windows.Forms.TextBox();
      this.lblFastqPath = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pnlKraken = new System.Windows.Forms.Panel();
      this.radUseFastq = new System.Windows.Forms.RadioButton();
      this.radUseFasta = new System.Windows.Forms.RadioButton();
      this.radSample = new System.Windows.Forms.RadioButton();
      this.radContig = new System.Windows.Forms.RadioButton();
      this.btnFindInputPath = new System.Windows.Forms.Button();
      this.txtInputPath = new System.Windows.Forms.TextBox();
      this.lblSampleFasta = new System.Windows.Forms.Label();
      this.lstSampleIDs = new System.Windows.Forms.ListBox();
      this.lblSampleID = new System.Windows.Forms.Label();
      this.btnGeneXref = new System.Windows.Forms.Button();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlSearch = new System.Windows.Forms.Panel();
      this.txtOutputSampleName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtCutoff = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.pnlKraken.SuspendLayout();
      this.pnlSearch.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblDescription
      // 
      this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDescription.Location = new System.Drawing.Point(12, 9);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(565, 31);
      this.lblDescription.TabIndex = 13;
      this.lblDescription.Text = "Use this dialog to run analysis functions.";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(507, 539);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 9;
      this.btnOK.Text = "Run...";
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
      this.btnCancel.Location = new System.Drawing.Point(576, 539);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 10;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnFindOutputPath
      // 
      this.btnFindOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindOutputPath.Location = new System.Drawing.Point(605, 493);
      this.btnFindOutputPath.Name = "btnFindOutputPath";
      this.btnFindOutputPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindOutputPath.TabIndex = 8;
      this.btnFindOutputPath.Text = "...";
      this.btnFindOutputPath.UseVisualStyleBackColor = true;
      this.btnFindOutputPath.Click += new System.EventHandler(this.btnFindOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(35, 495);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(571, 20);
      this.txtOutputPath.TabIndex = 7;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(32, 479);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(119, 13);
      this.label1.TabIndex = 38;
      this.label1.Text = "Path to output files:";
      // 
      // btnFastqPath
      // 
      this.btnFastqPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFastqPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFastqPath.Location = new System.Drawing.Point(605, 454);
      this.btnFastqPath.Name = "btnFastqPath";
      this.btnFastqPath.Size = new System.Drawing.Size(31, 23);
      this.btnFastqPath.TabIndex = 6;
      this.btnFastqPath.Text = "...";
      this.btnFastqPath.UseVisualStyleBackColor = true;
      this.btnFastqPath.Click += new System.EventHandler(this.btnFastqPath_Click);
      // 
      // txtFastqPath
      // 
      this.txtFastqPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFastqPath.Location = new System.Drawing.Point(35, 456);
      this.txtFastqPath.Name = "txtFastqPath";
      this.txtFastqPath.Size = new System.Drawing.Size(571, 20);
      this.txtFastqPath.TabIndex = 5;
      // 
      // lblFastqPath
      // 
      this.lblFastqPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblFastqPath.AutoSize = true;
      this.lblFastqPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFastqPath.Location = new System.Drawing.Point(32, 440);
      this.lblFastqPath.Name = "lblFastqPath";
      this.lblFastqPath.Size = new System.Drawing.Size(140, 13);
      this.lblFastqPath.TabIndex = 41;
      this.lblFastqPath.Text = "Path to read fastq files:";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.pnlKraken);
      this.panel1.Controls.Add(this.radSample);
      this.panel1.Controls.Add(this.radContig);
      this.panel1.Controls.Add(this.btnFindInputPath);
      this.panel1.Controls.Add(this.txtInputPath);
      this.panel1.Controls.Add(this.lblSampleFasta);
      this.panel1.Controls.Add(this.lstSampleIDs);
      this.panel1.Controls.Add(this.lblSampleID);
      this.panel1.Location = new System.Drawing.Point(12, 52);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(629, 340);
      this.panel1.TabIndex = 42;
      // 
      // pnlKraken
      // 
      this.pnlKraken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlKraken.Controls.Add(this.radUseFastq);
      this.pnlKraken.Controls.Add(this.radUseFasta);
      this.pnlKraken.Location = new System.Drawing.Point(473, 60);
      this.pnlKraken.Name = "pnlKraken";
      this.pnlKraken.Size = new System.Drawing.Size(149, 66);
      this.pnlKraken.TabIndex = 41;
      this.pnlKraken.Visible = false;
      // 
      // radUseFastq
      // 
      this.radUseFastq.AutoSize = true;
      this.radUseFastq.Location = new System.Drawing.Point(14, 34);
      this.radUseFastq.Name = "radUseFastq";
      this.radUseFastq.Size = new System.Drawing.Size(125, 17);
      this.radUseFastq.TabIndex = 2;
      this.radUseFastq.Text = "Use fastq folder input";
      this.radUseFastq.UseVisualStyleBackColor = true;
      this.radUseFastq.CheckedChanged += new System.EventHandler(this.radUseFastq_CheckedChanged);
      // 
      // radUseFasta
      // 
      this.radUseFasta.AutoSize = true;
      this.radUseFasta.Location = new System.Drawing.Point(14, 11);
      this.radUseFasta.Name = "radUseFasta";
      this.radUseFasta.Size = new System.Drawing.Size(112, 17);
      this.radUseFasta.TabIndex = 1;
      this.radUseFasta.Text = "Use fasta file input";
      this.radUseFasta.UseVisualStyleBackColor = true;
      this.radUseFasta.CheckedChanged += new System.EventHandler(this.radUseFasta_CheckedChanged);
      // 
      // radSample
      // 
      this.radSample.AutoSize = true;
      this.radSample.Location = new System.Drawing.Point(9, 56);
      this.radSample.Name = "radSample";
      this.radSample.Size = new System.Drawing.Size(14, 13);
      this.radSample.TabIndex = 1;
      this.radSample.UseVisualStyleBackColor = true;
      this.radSample.CheckedChanged += new System.EventHandler(this.radSample_CheckedChanged);
      // 
      // radContig
      // 
      this.radContig.AutoSize = true;
      this.radContig.Location = new System.Drawing.Point(9, 31);
      this.radContig.Name = "radContig";
      this.radContig.Size = new System.Drawing.Size(14, 13);
      this.radContig.TabIndex = 0;
      this.radContig.UseVisualStyleBackColor = true;
      // 
      // btnFindInputPath
      // 
      this.btnFindInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindInputPath.Location = new System.Drawing.Point(593, 27);
      this.btnFindInputPath.Name = "btnFindInputPath";
      this.btnFindInputPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindInputPath.TabIndex = 3;
      this.btnFindInputPath.Text = "...";
      this.btnFindInputPath.UseVisualStyleBackColor = true;
      this.btnFindInputPath.Click += new System.EventHandler(this.btnFindInputPath_Click);
      // 
      // txtInputPath
      // 
      this.txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInputPath.Location = new System.Drawing.Point(32, 28);
      this.txtInputPath.Name = "txtInputPath";
      this.txtInputPath.Size = new System.Drawing.Size(561, 20);
      this.txtInputPath.TabIndex = 2;
      this.txtInputPath.TextChanged += new System.EventHandler(this.txtInputPath_TextChanged);
      // 
      // lblSampleFasta
      // 
      this.lblSampleFasta.AutoSize = true;
      this.lblSampleFasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSampleFasta.Location = new System.Drawing.Point(29, 13);
      this.lblSampleFasta.Name = "lblSampleFasta";
      this.lblSampleFasta.Size = new System.Drawing.Size(171, 13);
      this.lblSampleFasta.TabIndex = 40;
      this.lblSampleFasta.Text = "Sample .fasta file to analyze:";
      this.lblSampleFasta.Click += new System.EventHandler(this.lblSampleFasta_Click);
      // 
      // lstSampleIDs
      // 
      this.lstSampleIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstSampleIDs.FormattingEnabled = true;
      this.lstSampleIDs.Location = new System.Drawing.Point(32, 71);
      this.lstSampleIDs.Margin = new System.Windows.Forms.Padding(2);
      this.lstSampleIDs.Name = "lstSampleIDs";
      this.lstSampleIDs.Size = new System.Drawing.Size(388, 251);
      this.lstSampleIDs.Sorted = true;
      this.lstSampleIDs.TabIndex = 4;
      this.lstSampleIDs.SelectedIndexChanged += new System.EventHandler(this.lstSampleIDs_SelectedIndexChanged);
      // 
      // lblSampleID
      // 
      this.lblSampleID.AutoSize = true;
      this.lblSampleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSampleID.Location = new System.Drawing.Point(29, 56);
      this.lblSampleID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblSampleID.Name = "lblSampleID";
      this.lblSampleID.Size = new System.Drawing.Size(75, 13);
      this.lblSampleID.TabIndex = 36;
      this.lblSampleID.Text = "Sample IDs:";
      // 
      // btnGeneXref
      // 
      this.btnGeneXref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnGeneXref.FlatAppearance.BorderSize = 2;
      this.btnGeneXref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnGeneXref.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGeneXref.Location = new System.Drawing.Point(442, 435);
      this.btnGeneXref.Name = "btnGeneXref";
      this.btnGeneXref.Size = new System.Drawing.Size(195, 22);
      this.btnGeneXref.TabIndex = 43;
      this.btnGeneXref.Text = "Edit Gene XRef File...";
      this.btnGeneXref.UseVisualStyleBackColor = true;
      this.btnGeneXref.Visible = false;
      this.btnGeneXref.Click += new System.EventHandler(this.btnGeneXref_Click);
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(35, 541);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(435, 20);
      this.txtMemo.TabIndex = 59;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(32, 525);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(255, 13);
      this.label2.TabIndex = 60;
      this.label2.Text = "Memo (to help identify task in notifications):";
      // 
      // pnlSearch
      // 
      this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlSearch.Controls.Add(this.txtOutputSampleName);
      this.pnlSearch.Controls.Add(this.label3);
      this.pnlSearch.Controls.Add(this.txtThreads);
      this.pnlSearch.Controls.Add(this.label6);
      this.pnlSearch.Controls.Add(this.txtCutoff);
      this.pnlSearch.Controls.Add(this.label5);
      this.pnlSearch.Location = new System.Drawing.Point(30, 401);
      this.pnlSearch.Name = "pnlSearch";
      this.pnlSearch.Size = new System.Drawing.Size(606, 76);
      this.pnlSearch.TabIndex = 62;
      // 
      // txtOutputSampleName
      // 
      this.txtOutputSampleName.Location = new System.Drawing.Point(342, 4);
      this.txtOutputSampleName.Name = "txtOutputSampleName";
      this.txtOutputSampleName.Size = new System.Drawing.Size(172, 20);
      this.txtOutputSampleName.TabIndex = 34;
      this.txtOutputSampleName.TextChanged += new System.EventHandler(this.txtSampleID_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(24, 7);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(300, 13);
      this.label3.TabIndex = 35;
      this.label3.Text = "Output sample ID? (used to name output result file):";
      // 
      // txtThreads
      // 
      this.txtThreads.Location = new System.Drawing.Point(469, 50);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 31;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreads_KeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(348, 53);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 33;
      this.label6.Text = "Number of threads:";
      // 
      // txtCutoff
      // 
      this.txtCutoff.Location = new System.Drawing.Point(469, 26);
      this.txtCutoff.Name = "txtCutoff";
      this.txtCutoff.Size = new System.Drawing.Size(45, 20);
      this.txtCutoff.TabIndex = 30;
      this.txtCutoff.Text = "1";
      this.txtCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtCutoff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCutoff_KeyPress);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(24, 29);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(439, 13);
      this.label5.TabIndex = 32;
      this.label5.Text = "Filter results by a maximum distance cutoff [Default: 1] (Ranges from 0 to 1):";
      // 
      // BioSeqAnalysis
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(653, 567);
      this.Controls.Add(this.pnlSearch);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnGeneXref);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.btnFastqPath);
      this.Controls.Add(this.txtFastqPath);
      this.Controls.Add(this.lblFastqPath);
      this.Controls.Add(this.btnFindOutputPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lblDescription);
      this.Name = "BioSeqAnalysis";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Analysis";
      this.Shown += new System.EventHandler(this.BioSeqAnalysis_Shown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.pnlKraken.ResumeLayout(false);
      this.pnlKraken.PerformLayout();
      this.pnlSearch.ResumeLayout(false);
      this.pnlSearch.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnFindOutputPath;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnFastqPath;
    private System.Windows.Forms.TextBox txtFastqPath;
    private System.Windows.Forms.Label lblFastqPath;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton radSample;
    private System.Windows.Forms.RadioButton radContig;
    private System.Windows.Forms.Button btnFindInputPath;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Label lblSampleFasta;
    private System.Windows.Forms.ListBox lstSampleIDs;
    private System.Windows.Forms.Label lblSampleID;
    private System.Windows.Forms.Button btnGeneXref;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.TextBox txtOutputSampleName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtCutoff;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Panel pnlKraken;
    private System.Windows.Forms.RadioButton radUseFastq;
    private System.Windows.Forms.RadioButton radUseFasta;
  }
}