namespace BioSeqDB
{
  partial class BioSeqMetaMaps
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
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnCentrifugePath = new System.Windows.Forms.Button();
      this.txtReferencePath = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMinReadLength = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btnFindInputPath = new System.Windows.Forms.Button();
      this.txtInputPath = new System.Windows.Forms.TextBox();
      this.lblSampleFastq = new System.Windows.Forms.Label();
      this.txtMaxReads = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtMaxMemory = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.chkOnlyBestMappings = new System.Windows.Forms.CheckBox();
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
      this.label4.Text = "Create a taxonomic classification for a set of sequence reads using MetaMaps.";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(500, 401);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(65, 22);
      this.btnOK.TabIndex = 12;
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
      this.btnCancel.Location = new System.Drawing.Point(586, 401);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 13;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOutputPath
      // 
      this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputPath.Location = new System.Drawing.Point(585, 327);
      this.btnOutputPath.Name = "btnOutputPath";
      this.btnOutputPath.Size = new System.Drawing.Size(31, 22);
      this.btnOutputPath.TabIndex = 10;
      this.btnOutputPath.Text = "...";
      this.btnOutputPath.UseVisualStyleBackColor = true;
      this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(12, 328);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(574, 20);
      this.txtOutputPath.TabIndex = 9;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 312);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(154, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Path to output result files:";
      // 
      // txtThreads
      // 
      this.txtThreads.Location = new System.Drawing.Point(334, 205);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 4;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.TextChanged += new System.EventHandler(this.txt_TextChanged);
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(217, 208);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 55;
      this.label6.Text = "Number of threads:";
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(9, 403);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(435, 20);
      this.txtMemo.TabIndex = 11;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 387);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(255, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Memo (to help identify task in notifications):";
      // 
      // btnCentrifugePath
      // 
      this.btnCentrifugePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCentrifugePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCentrifugePath.Location = new System.Drawing.Point(585, 163);
      this.btnCentrifugePath.Name = "btnCentrifugePath";
      this.btnCentrifugePath.Size = new System.Drawing.Size(31, 22);
      this.btnCentrifugePath.TabIndex = 3;
      this.btnCentrifugePath.Text = "...";
      this.btnCentrifugePath.UseVisualStyleBackColor = true;
      this.btnCentrifugePath.Click += new System.EventHandler(this.btnReferencePath_Click);
      // 
      // txtReferencePath
      // 
      this.txtReferencePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtReferencePath.Location = new System.Drawing.Point(12, 164);
      this.txtReferencePath.Name = "txtReferencePath";
      this.txtReferencePath.Size = new System.Drawing.Size(574, 20);
      this.txtReferencePath.TabIndex = 2;
      this.txtReferencePath.TextChanged += new System.EventHandler(this.txtReferencePath_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 148);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(341, 13);
      this.label2.TabIndex = 61;
      this.label2.Text = "MetaMaps reference database for taxonomic classification:";
      // 
      // txtMinReadLength
      // 
      this.txtMinReadLength.Location = new System.Drawing.Point(334, 222);
      this.txtMinReadLength.Name = "txtMinReadLength";
      this.txtMinReadLength.Size = new System.Drawing.Size(45, 20);
      this.txtMinReadLength.TabIndex = 5;
      this.txtMinReadLength.Text = "50";
      this.txtMinReadLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMinReadLength.TextChanged += new System.EventHandler(this.txt_TextChanged);
      this.txtMinReadLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(159, 226);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(172, 13);
      this.label7.TabIndex = 70;
      this.label7.Text = "Minimum read length (bases):";
      // 
      // btnFindInputPath
      // 
      this.btnFindInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindInputPath.Location = new System.Drawing.Point(585, 103);
      this.btnFindInputPath.Name = "btnFindInputPath";
      this.btnFindInputPath.Size = new System.Drawing.Size(31, 22);
      this.btnFindInputPath.TabIndex = 1;
      this.btnFindInputPath.Text = "...";
      this.btnFindInputPath.UseVisualStyleBackColor = true;
      this.btnFindInputPath.Click += new System.EventHandler(this.btnFindInputPath_Click);
      // 
      // txtInputPath
      // 
      this.txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInputPath.Location = new System.Drawing.Point(15, 104);
      this.txtInputPath.Name = "txtInputPath";
      this.txtInputPath.Size = new System.Drawing.Size(571, 20);
      this.txtInputPath.TabIndex = 0;
      // 
      // lblSampleFastq
      // 
      this.lblSampleFastq.AutoSize = true;
      this.lblSampleFastq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSampleFastq.Location = new System.Drawing.Point(12, 89);
      this.lblSampleFastq.Name = "lblSampleFastq";
      this.lblSampleFastq.Size = new System.Drawing.Size(229, 13);
      this.lblSampleFastq.TabIndex = 73;
      this.lblSampleFastq.Text = "Sample fastq file with reads to analyze:";
      // 
      // txtMaxReads
      // 
      this.txtMaxReads.Location = new System.Drawing.Point(334, 241);
      this.txtMaxReads.Name = "txtMaxReads";
      this.txtMaxReads.Size = new System.Drawing.Size(45, 20);
      this.txtMaxReads.TabIndex = 6;
      this.txtMaxReads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMaxReads.TextChanged += new System.EventHandler(this.txt_TextChanged);
      this.txtMaxReads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(218, 244);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(113, 13);
      this.label5.TabIndex = 75;
      this.label5.Text = "Max # fastq reads:";
      // 
      // txtMaxMemory
      // 
      this.txtMaxMemory.Location = new System.Drawing.Point(334, 260);
      this.txtMaxMemory.Name = "txtMaxMemory";
      this.txtMaxMemory.Size = new System.Drawing.Size(45, 20);
      this.txtMaxMemory.TabIndex = 7;
      this.txtMaxMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtMaxMemory.TextChanged += new System.EventHandler(this.txt_TextChanged);
      this.txtMaxMemory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(194, 262);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(136, 13);
      this.label8.TabIndex = 77;
      this.label8.Text = "Maximum memory (Gb):";
      // 
      // chkOnlyBestMappings
      // 
      this.chkOnlyBestMappings.AutoSize = true;
      this.chkOnlyBestMappings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.chkOnlyBestMappings.Checked = true;
      this.chkOnlyBestMappings.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOnlyBestMappings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkOnlyBestMappings.Location = new System.Drawing.Point(61, 280);
      this.chkOnlyBestMappings.Name = "chkOnlyBestMappings";
      this.chkOnlyBestMappings.Size = new System.Drawing.Size(288, 17);
      this.chkOnlyBestMappings.TabIndex = 8;
      this.chkOnlyBestMappings.Text = "Report only best mapping locations for a read:";
      this.chkOnlyBestMappings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.chkOnlyBestMappings.UseVisualStyleBackColor = true;
      // 
      // BioSeqMetaMaps
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(685, 435);
      this.Controls.Add(this.chkOnlyBestMappings);
      this.Controls.Add(this.txtMaxMemory);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtMaxReads);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnFindInputPath);
      this.Controls.Add(this.txtInputPath);
      this.Controls.Add(this.lblSampleFastq);
      this.Controls.Add(this.txtMinReadLength);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.btnCentrifugePath);
      this.Controls.Add(this.txtReferencePath);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtThreads);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btnOutputPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqMetaMaps";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB MetaMaps Analysis";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioSeqMetaMaps_FormClosing);
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
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnCentrifugePath;
    private System.Windows.Forms.TextBox txtReferencePath;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMinReadLength;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnFindInputPath;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Label lblSampleFastq;
    private System.Windows.Forms.TextBox txtMaxReads;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtMaxMemory;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.CheckBox chkOnlyBestMappings;
  }
}