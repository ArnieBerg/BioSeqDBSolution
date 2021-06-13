namespace BioSeqDB
{
  partial class BioSeqFastQC
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
      this.btnFindInputPath = new System.Windows.Forms.Button();
      this.txtInputPath = new System.Windows.Forms.TextBox();
      this.lblSampleFastq = new System.Windows.Forms.Label();
      this.chkConsolidate = new System.Windows.Forms.CheckBox();
      this.chkMultiQC = new System.Windows.Forms.CheckBox();
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
      this.label4.Text = "Perform basic quality control on a set of fastq sequenced reads using FastQC.";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(500, 345);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(65, 22);
      this.btnOK.TabIndex = 8;
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
      this.btnCancel.Location = new System.Drawing.Point(586, 345);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOutputPath
      // 
      this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputPath.Location = new System.Drawing.Point(586, 224);
      this.btnOutputPath.Name = "btnOutputPath";
      this.btnOutputPath.Size = new System.Drawing.Size(31, 23);
      this.btnOutputPath.TabIndex = 3;
      this.btnOutputPath.Text = "...";
      this.btnOutputPath.UseVisualStyleBackColor = true;
      this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(12, 226);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(574, 20);
      this.txtOutputPath.TabIndex = 2;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 210);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(154, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Path to output result files:";
      // 
      // txtThreads
      // 
      this.txtThreads.Location = new System.Drawing.Point(334, 261);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 4;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.TextChanged += new System.EventHandler(this.txtThreads_TextChanged);
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreads_KeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(204, 264);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 55;
      this.label6.Text = "Number of threads:";
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(9, 345);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(435, 20);
      this.txtMemo.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 329);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(255, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Memo (to help identify task in notifications):";
      // 
      // btnFindInputPath
      // 
      this.btnFindInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindInputPath.Location = new System.Drawing.Point(586, 103);
      this.btnFindInputPath.Name = "btnFindInputPath";
      this.btnFindInputPath.Size = new System.Drawing.Size(31, 23);
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
      this.lblSampleFastq.Size = new System.Drawing.Size(244, 13);
      this.lblSampleFastq.TabIndex = 73;
      this.lblSampleFastq.Text = "Sample folder with fastq reads to analyze:";
      // 
      // chkConsolidate
      // 
      this.chkConsolidate.AutoSize = true;
      this.chkConsolidate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.chkConsolidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkConsolidate.Location = new System.Drawing.Point(207, 287);
      this.chkConsolidate.Name = "chkConsolidate";
      this.chkConsolidate.Size = new System.Drawing.Size(172, 17);
      this.chkConsolidate.TabIndex = 5;
      this.chkConsolidate.Text = "Consolidate all fastq files:";
      this.chkConsolidate.UseVisualStyleBackColor = true;
      // 
      // chkMultiQC
      // 
      this.chkMultiQC.AutoSize = true;
      this.chkMultiQC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.chkMultiQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkMultiQC.Location = new System.Drawing.Point(220, 306);
      this.chkMultiQC.Name = "chkMultiQC";
      this.chkMultiQC.Size = new System.Drawing.Size(159, 17);
      this.chkMultiQC.TabIndex = 6;
      this.chkMultiQC.Text = "Follow up with MultiQC:";
      this.chkMultiQC.UseVisualStyleBackColor = true;
      // 
      // BioSeqFastQC
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(685, 379);
      this.Controls.Add(this.chkMultiQC);
      this.Controls.Add(this.chkConsolidate);
      this.Controls.Add(this.btnFindInputPath);
      this.Controls.Add(this.txtInputPath);
      this.Controls.Add(this.lblSampleFastq);
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
      this.Name = "BioSeqFastQC";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB FastQC Analysis";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioSeqFastQC_FormClosing);
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
    private System.Windows.Forms.Button btnFindInputPath;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Label lblSampleFastq;
    private System.Windows.Forms.CheckBox chkConsolidate;
    private System.Windows.Forms.CheckBox chkMultiQC;
  }
}