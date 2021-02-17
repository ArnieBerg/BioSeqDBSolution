namespace BioSeqDB
{
  partial class BioSeqRestore
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtArchiveDBPath = new System.Windows.Forms.TextBox();
      this.btnArchiveDBPath = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txtArchiveFilename = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOutputDBPath = new System.Windows.Forms.Button();
      this.txtOutputDBPath = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.lstVersions = new System.Windows.Forms.ListBox();
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
      this.label4.Text = "The current sequence database is restored to the specified version number.";
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
      // txtArchiveDBPath
      // 
      this.txtArchiveDBPath.Location = new System.Drawing.Point(12, 148);
      this.txtArchiveDBPath.Name = "txtArchiveDBPath";
      this.txtArchiveDBPath.Size = new System.Drawing.Size(528, 20);
      this.txtArchiveDBPath.TabIndex = 1;
      this.txtArchiveDBPath.TextChanged += new System.EventHandler(this.txtArchiveDBPath_TextChanged);
      // 
      // btnArchiveDBPath
      // 
      this.btnArchiveDBPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnArchiveDBPath.Location = new System.Drawing.Point(540, 147);
      this.btnArchiveDBPath.Name = "btnArchiveDBPath";
      this.btnArchiveDBPath.Size = new System.Drawing.Size(31, 23);
      this.btnArchiveDBPath.TabIndex = 2;
      this.btnArchiveDBPath.Text = "...";
      this.btnArchiveDBPath.UseVisualStyleBackColor = true;
      this.btnArchiveDBPath.Click += new System.EventHandler(this.btnArchiveDBPath_Click);
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(385, 411);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 6;
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
      this.btnCancel.Location = new System.Drawing.Point(516, 411);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // txtArchiveFilename
      // 
      this.txtArchiveFilename.Location = new System.Drawing.Point(12, 101);
      this.txtArchiveFilename.Name = "txtArchiveFilename";
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 177);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(234, 13);
      this.label2.TabIndex = 25;
      this.label2.Text = "Backup versions (select one to restore):";
      // 
      // btnOutputDBPath
      // 
      this.btnOutputDBPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputDBPath.Location = new System.Drawing.Point(540, 367);
      this.btnOutputDBPath.Name = "btnOutputDBPath";
      this.btnOutputDBPath.Size = new System.Drawing.Size(31, 23);
      this.btnOutputDBPath.TabIndex = 5;
      this.btnOutputDBPath.Text = "...";
      this.btnOutputDBPath.UseVisualStyleBackColor = true;
      this.btnOutputDBPath.Click += new System.EventHandler(this.btnOutputDBPath_Click);
      // 
      // txtOutputDBPath
      // 
      this.txtOutputDBPath.Location = new System.Drawing.Point(12, 368);
      this.txtOutputDBPath.Name = "txtOutputDBPath";
      this.txtOutputDBPath.Size = new System.Drawing.Size(528, 20);
      this.txtOutputDBPath.TabIndex = 4;
      this.txtOutputDBPath.TextChanged += new System.EventHandler(this.txtOutputDBPath_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(9, 352);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(207, 13);
      this.label5.TabIndex = 29;
      this.label5.Text = "Path to output sequence database:";
      // 
      // lstVersions
      // 
      this.lstVersions.FormattingEnabled = true;
      this.lstVersions.Location = new System.Drawing.Point(12, 193);
      this.lstVersions.Name = "lstVersions";
      this.lstVersions.Size = new System.Drawing.Size(254, 147);
      this.lstVersions.TabIndex = 30;
      this.lstVersions.SelectedValueChanged += new System.EventHandler(this.lstVersions_SelectedValueChanged);
      // 
      // BioSeqRestore
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(609, 445);
      this.Controls.Add(this.lstVersions);
      this.Controls.Add(this.btnOutputDBPath);
      this.Controls.Add(this.txtOutputDBPath);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtArchiveFilename);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnArchiveDBPath);
      this.Controls.Add(this.txtArchiveDBPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqRestore";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Restore Database";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtArchiveDBPath;
    private System.Windows.Forms.Button btnArchiveDBPath;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtArchiveFilename;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOutputDBPath;
    private System.Windows.Forms.TextBox txtOutputDBPath;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListBox lstVersions;
  }
}