namespace BioSeqDB
{
  partial class BioSeqNewDB
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqNewDB));
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtDBPath = new System.Windows.Forms.TextBox();
      this.txtInputPath = new System.Windows.Forms.TextBox();
      this.btnFindDBPath = new System.Windows.Forms.Button();
      this.btnFindInputPath = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txtDBName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnStdRefGenome = new System.Windows.Forms.Button();
      this.txtStandardReferenceGenome = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(565, 93);
      this.label4.TabIndex = 13;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 141);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(135, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Path to new database:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 189);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(272, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Path to subfolders containing .fasta input files:";
      // 
      // txtDBPath
      // 
      this.txtDBPath.Location = new System.Drawing.Point(12, 157);
      this.txtDBPath.Name = "txtDBPath";
      this.txtDBPath.Size = new System.Drawing.Size(528, 20);
      this.txtDBPath.TabIndex = 1;
      this.txtDBPath.TextChanged += new System.EventHandler(this.txtDBPath_TextChanged);
      // 
      // txtInputPath
      // 
      this.txtInputPath.Location = new System.Drawing.Point(12, 205);
      this.txtInputPath.Name = "txtInputPath";
      this.txtInputPath.Size = new System.Drawing.Size(528, 20);
      this.txtInputPath.TabIndex = 3;
      this.txtInputPath.TextChanged += new System.EventHandler(this.txtInputPath_TextChanged);
      // 
      // btnFindDBPath
      // 
      this.btnFindDBPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindDBPath.Location = new System.Drawing.Point(540, 155);
      this.btnFindDBPath.Name = "btnFindDBPath";
      this.btnFindDBPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindDBPath.TabIndex = 2;
      this.btnFindDBPath.Text = "...";
      this.btnFindDBPath.UseVisualStyleBackColor = true;
      this.btnFindDBPath.Click += new System.EventHandler(this.btnFindDBPath_Click);
      // 
      // btnFindInputPath
      // 
      this.btnFindInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindInputPath.Location = new System.Drawing.Point(540, 203);
      this.btnFindInputPath.Name = "btnFindInputPath";
      this.btnFindInputPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindInputPath.TabIndex = 4;
      this.btnFindInputPath.Text = "...";
      this.btnFindInputPath.UseVisualStyleBackColor = true;
      this.btnFindInputPath.Click += new System.EventHandler(this.btnFindInputPath_Click);
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(385, 292);
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
      this.btnCancel.Location = new System.Drawing.Point(516, 292);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // txtDBName
      // 
      this.txtDBName.Location = new System.Drawing.Point(295, 110);
      this.txtDBName.Name = "txtDBName";
      this.txtDBName.Size = new System.Drawing.Size(245, 20);
      this.txtDBName.TabIndex = 0;
      this.txtDBName.TextChanged += new System.EventHandler(this.txtDBName_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 113);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(280, 13);
      this.label3.TabIndex = 17;
      this.label3.Text = "New database name (usually name of organism):";
      // 
      // btnStdRefGenome
      // 
      this.btnStdRefGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStdRefGenome.Location = new System.Drawing.Point(540, 251);
      this.btnStdRefGenome.Name = "btnStdRefGenome";
      this.btnStdRefGenome.Size = new System.Drawing.Size(31, 23);
      this.btnStdRefGenome.TabIndex = 6;
      this.btnStdRefGenome.Text = "...";
      this.btnStdRefGenome.UseVisualStyleBackColor = true;
      this.btnStdRefGenome.Click += new System.EventHandler(this.btnStdRefGenome_Click);
      // 
      // txtStandardReferenceGenome
      // 
      this.txtStandardReferenceGenome.Location = new System.Drawing.Point(12, 253);
      this.txtStandardReferenceGenome.Name = "txtStandardReferenceGenome";
      this.txtStandardReferenceGenome.Size = new System.Drawing.Size(528, 20);
      this.txtStandardReferenceGenome.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(9, 237);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(357, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "Path to standard reference genome in .fasta format (optional):";
      // 
      // BioSeqNewDB
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(609, 326);
      this.Controls.Add(this.btnStdRefGenome);
      this.Controls.Add(this.txtStandardReferenceGenome);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtDBName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnFindInputPath);
      this.Controls.Add(this.btnFindDBPath);
      this.Controls.Add(this.txtInputPath);
      this.Controls.Add(this.txtDBPath);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqNewDB";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB New Database";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDBPath;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Button btnFindDBPath;
    private System.Windows.Forms.Button btnFindInputPath;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtDBName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnStdRefGenome;
    private System.Windows.Forms.TextBox txtStandardReferenceGenome;
    private System.Windows.Forms.Label label5;
  }
}