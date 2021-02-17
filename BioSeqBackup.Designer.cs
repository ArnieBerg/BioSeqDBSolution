namespace BioSeqDB
{
  partial class BioSeqBackup
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqBackup));
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtDBPath = new System.Windows.Forms.TextBox();
      this.btnFindDBPath = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txtArchiveFilename = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(565, 58);
      this.label4.TabIndex = 13;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 132);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(139, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Archive database path:";
      // 
      // txtDBPath
      // 
      this.txtDBPath.Location = new System.Drawing.Point(12, 148);
      this.txtDBPath.Name = "txtDBPath";
      this.txtDBPath.ReadOnly = true;
      this.txtDBPath.Size = new System.Drawing.Size(528, 20);
      this.txtDBPath.TabIndex = 1;
      this.txtDBPath.TextChanged += new System.EventHandler(this.txtDBPath_TextChanged);
      // 
      // btnFindDBPath
      // 
      this.btnFindDBPath.Enabled = false;
      this.btnFindDBPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindDBPath.Location = new System.Drawing.Point(540, 147);
      this.btnFindDBPath.Name = "btnFindDBPath";
      this.btnFindDBPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindDBPath.TabIndex = 2;
      this.btnFindDBPath.Text = "...";
      this.btnFindDBPath.UseVisualStyleBackColor = true;
      this.btnFindDBPath.Click += new System.EventHandler(this.btnFindDBPath_Click);
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(385, 214);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatAppearance.BorderSize = 2;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(516, 214);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // txtArchiveFilename
      // 
      this.txtArchiveFilename.Location = new System.Drawing.Point(12, 101);
      this.txtArchiveFilename.Name = "txtArchiveFilename";
      this.txtArchiveFilename.ReadOnly = true;
      this.txtArchiveFilename.Size = new System.Drawing.Size(528, 20);
      this.txtArchiveFilename.TabIndex = 0;
      this.txtArchiveFilename.TextChanged += new System.EventHandler(this.txtArchiveFilename_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(9, 85);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(105, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Archive filename:";
      // 
      // BioSeqBackup
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(609, 251);
      this.Controls.Add(this.txtArchiveFilename);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnFindDBPath);
      this.Controls.Add(this.txtDBPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqBackup";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Backup Database";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDBPath;
    private System.Windows.Forms.Button btnFindDBPath;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtArchiveFilename;
    private System.Windows.Forms.Label label3;
  }
}