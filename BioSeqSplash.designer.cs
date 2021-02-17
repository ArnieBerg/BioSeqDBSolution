namespace BioSeqDB
{
  partial class BioSeqSplash
  {
    /// <summary>
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// </summary>
    /// <param name="disposing"> true； false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 

    /// <summary>
    /// </summary>
    private void InitializeComponent()
    {
      this.lbStatusInfo = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lbStatusInfo
      // 
      this.lbStatusInfo.AutoSize = true;
      this.lbStatusInfo.BackColor = System.Drawing.Color.White;
      this.lbStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbStatusInfo.Location = new System.Drawing.Point(310, 292);
      this.lbStatusInfo.Name = "lbStatusInfo";
      this.lbStatusInfo.Size = new System.Drawing.Size(88, 20);
      this.lbStatusInfo.TabIndex = 0;
      this.lbStatusInfo.Text = "Loading...";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.White;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(172, 246);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(247, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "BioSeqDB database manager";
      // 
      // BioSeqSplash
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::BioSeqDB.Properties.Resources.dna;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(422, 321);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lbStatusInfo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "BioSeqSplash";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmSplash";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbStatusInfo;
    private System.Windows.Forms.Label label1;
  }
}