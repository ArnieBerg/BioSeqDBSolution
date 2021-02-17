namespace BioSeqDB
{
  partial class BioSeqLIMSEdit
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
      this.components = new System.ComponentModel.Container();
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnRestore = new System.Windows.Forms.Button();
      this.picLights = new System.Windows.Forms.PictureBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.txtLIMSSampleID = new System.Windows.Forms.TextBox();
      this.txtLIMSTestID = new System.Windows.Forms.TextBox();
      this.txtCaseNumber = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnApply = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.ConfirmApply = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnNo = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.lstSampleIDs = new System.Windows.Forms.CheckedListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLights)).BeginInit();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(565, 31);
      this.label4.TabIndex = 13;
      this.label4.Text = "Use this dialog to maintain LIMS identifiers.";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(441, 409);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "Close";
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
      this.btnCancel.Location = new System.Drawing.Point(510, 409);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(9, 47);
      this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(75, 13);
      this.label7.TabIndex = 29;
      this.label7.Text = "Sample IDs:";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btnRestore);
      this.groupBox1.Controls.Add(this.picLights);
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.txtLIMSSampleID);
      this.groupBox1.Controls.Add(this.txtLIMSTestID);
      this.groupBox1.Controls.Add(this.txtCaseNumber);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(281, 63);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(296, 150);
      this.groupBox1.TabIndex = 31;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "LIMS Identifiers:";
      // 
      // btnRestore
      // 
      this.btnRestore.FlatAppearance.BorderSize = 2;
      this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRestore.Location = new System.Drawing.Point(189, 122);
      this.btnRestore.Name = "btnRestore";
      this.btnRestore.Size = new System.Drawing.Size(63, 22);
      this.btnRestore.TabIndex = 19;
      this.btnRestore.Text = "Restore";
      this.toolTip1.SetToolTip(this.btnRestore, "Restore values to last time changes were applied");
      this.btnRestore.UseVisualStyleBackColor = true;
      this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
      // 
      // picLights
      // 
      this.picLights.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picLights.Location = new System.Drawing.Point(256, 23);
      this.picLights.Name = "picLights";
      this.picLights.Size = new System.Drawing.Size(28, 49);
      this.picLights.TabIndex = 18;
      this.picLights.TabStop = false;
      this.toolTip1.SetToolTip(this.picLights, "When green, values are valid");
      // 
      // btnClear
      // 
      this.btnClear.FlatAppearance.BorderSize = 2;
      this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClear.Location = new System.Drawing.Point(120, 122);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(63, 22);
      this.btnClear.TabIndex = 5;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // txtLIMSSampleID
      // 
      this.txtLIMSSampleID.Location = new System.Drawing.Point(120, 81);
      this.txtLIMSSampleID.Name = "txtLIMSSampleID";
      this.txtLIMSSampleID.Size = new System.Drawing.Size(63, 20);
      this.txtLIMSSampleID.TabIndex = 4;
      this.txtLIMSSampleID.TextChanged += new System.EventHandler(this.txtLIMSSampleID_TextChanged);
      this.txtLIMSSampleID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLIMSSampleID_KeyPress);
      // 
      // txtLIMSTestID
      // 
      this.txtLIMSTestID.Location = new System.Drawing.Point(120, 51);
      this.txtLIMSTestID.Name = "txtLIMSTestID";
      this.txtLIMSTestID.Size = new System.Drawing.Size(63, 20);
      this.txtLIMSTestID.TabIndex = 3;
      this.txtLIMSTestID.TextChanged += new System.EventHandler(this.txtLIMSTestID_TextChanged);
      this.txtLIMSTestID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLIMSTestID_KeyPress);
      // 
      // txtCaseNumber
      // 
      this.txtCaseNumber.Location = new System.Drawing.Point(120, 23);
      this.txtCaseNumber.Name = "txtCaseNumber";
      this.txtCaseNumber.Size = new System.Drawing.Size(114, 20);
      this.txtCaseNumber.TabIndex = 2;
      this.txtCaseNumber.TextChanged += new System.EventHandler(this.txtCaseNumber_TextChanged);
      this.txtCaseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaseNumber_KeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(64, 54);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 17;
      this.label6.Text = "Test ID:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(50, 84);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 16;
      this.label5.Text = "Sample ID:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(34, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(84, 13);
      this.label3.TabIndex = 15;
      this.label3.Text = "Case number:";
      // 
      // btnApply
      // 
      this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnApply.FlatAppearance.BorderSize = 2;
      this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnApply.Location = new System.Drawing.Point(287, 409);
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new System.Drawing.Size(53, 22);
      this.btnApply.TabIndex = 32;
      this.btnApply.Text = "Apply";
      this.toolTip1.SetToolTip(this.btnApply, "Commit all changes so far to the database");
      this.btnApply.UseVisualStyleBackColor = true;
      this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
      // 
      // ConfirmApply
      // 
      this.ConfirmApply.Buttons.Add(this.btnYes);
      this.ConfirmApply.Buttons.Add(this.btnNo);
      this.ConfirmApply.CenterParent = true;
      this.ConfirmApply.WindowTitle = "Apply changes";
      // 
      // btnYes
      // 
      this.btnYes.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Yes;
      this.btnYes.Default = true;
      this.btnYes.Text = "Yes";
      // 
      // btnNo
      // 
      this.btnNo.ButtonType = Ookii.Dialogs.WinForms.ButtonType.No;
      this.btnNo.Text = "No";
      // 
      // lstSampleIDs
      // 
      this.lstSampleIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstSampleIDs.FormattingEnabled = true;
      this.lstSampleIDs.Location = new System.Drawing.Point(12, 63);
      this.lstSampleIDs.Name = "lstSampleIDs";
      this.lstSampleIDs.Size = new System.Drawing.Size(263, 349);
      this.lstSampleIDs.TabIndex = 33;
      this.lstSampleIDs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSampleIDs_ItemCheck);
      this.lstSampleIDs.SelectedIndexChanged += new System.EventHandler(this.lstSampleIDs_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(11, 418);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(254, 12);
      this.label1.TabIndex = 34;
      this.label1.Text = "(Checked samples already have LIMS identifiers)";
      // 
      // BioSeqLIMSEdit
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(589, 445);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lstSampleIDs);
      this.Controls.Add(this.btnApply);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqLIMSEdit";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB LIMS Edit";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLights)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.TextBox txtLIMSSampleID;
    private System.Windows.Forms.TextBox txtLIMSTestID;
    private System.Windows.Forms.TextBox txtCaseNumber;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnRestore;
    private System.Windows.Forms.PictureBox picLights;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.ToolTip toolTip1;
    private Ookii.Dialogs.WinForms.TaskDialog ConfirmApply;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnNo;
    private System.Windows.Forms.CheckedListBox lstSampleIDs;
    private System.Windows.Forms.Label label1;
  }
}