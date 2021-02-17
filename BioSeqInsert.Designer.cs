namespace BioSeqDB
{
  partial class BioSeqInsert
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtSampleID = new System.Windows.Forms.TextBox();
      this.txtInputPath = new System.Windows.Forms.TextBox();
      this.btnFindInputPath = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.ReplacePrompt = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnReplaceYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnReplaceCancel = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.txtLIMSSampleID = new System.Windows.Forms.TextBox();
      this.txtLIMSTestID = new System.Windows.Forms.TextBox();
      this.txtCaseNumber = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.LIMSDialog = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnLIMSDialogOK = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.LIMSDuplicatePrompt = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnNo = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.groupBox1.SuspendLayout();
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
      this.label4.Text = "Insert a new sample into the selected database.  Optionally, supply identifiers t" +
    "o associate this sample with the LIMS.";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "New sample ID:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 231);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(159, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Sample .fasta file to insert.";
      // 
      // txtSampleID
      // 
      this.txtSampleID.Location = new System.Drawing.Point(12, 86);
      this.txtSampleID.Name = "txtSampleID";
      this.txtSampleID.Size = new System.Drawing.Size(528, 20);
      this.txtSampleID.TabIndex = 0;
      this.txtSampleID.TextChanged += new System.EventHandler(this.txtDBPath_TextChanged);
      // 
      // txtInputPath
      // 
      this.txtInputPath.Location = new System.Drawing.Point(12, 247);
      this.txtInputPath.Name = "txtInputPath";
      this.txtInputPath.Size = new System.Drawing.Size(528, 20);
      this.txtInputPath.TabIndex = 6;
      this.txtInputPath.TextChanged += new System.EventHandler(this.txtInputPath_TextChanged);
      // 
      // btnFindInputPath
      // 
      this.btnFindInputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindInputPath.Location = new System.Drawing.Point(539, 246);
      this.btnFindInputPath.Name = "btnFindInputPath";
      this.btnFindInputPath.Size = new System.Drawing.Size(31, 23);
      this.btnFindInputPath.TabIndex = 7;
      this.btnFindInputPath.Text = "...";
      this.btnFindInputPath.UseVisualStyleBackColor = true;
      this.btnFindInputPath.Click += new System.EventHandler(this.btnFindInputPath_Click);
      // 
      // btnOK
      // 
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(385, 286);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 8;
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
      this.btnCancel.Location = new System.Drawing.Point(516, 286);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // ReplacePrompt
      // 
      this.ReplacePrompt.Buttons.Add(this.btnReplaceYes);
      this.ReplacePrompt.Buttons.Add(this.btnReplaceCancel);
      this.ReplacePrompt.CenterParent = true;
      this.ReplacePrompt.MainInstruction = "taskDialog1";
      this.ReplacePrompt.WindowTitle = "Potential Duplicate Sample";
      // 
      // btnReplaceYes
      // 
      this.btnReplaceYes.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Yes;
      this.btnReplaceYes.Default = true;
      this.btnReplaceYes.Text = "Yes";
      // 
      // btnReplaceCancel
      // 
      this.btnReplaceCancel.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Cancel;
      this.btnReplaceCancel.Text = "Cancel";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.txtLIMSSampleID);
      this.groupBox1.Controls.Add(this.txtLIMSTestID);
      this.groupBox1.Controls.Add(this.txtCaseNumber);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(12, 122);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(528, 87);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "LIMS Identifiers:";
      // 
      // btnClear
      // 
      this.btnClear.FlatAppearance.BorderSize = 2;
      this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClear.Location = new System.Drawing.Point(445, 49);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(63, 22);
      this.btnClear.TabIndex = 5;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // txtLIMSSampleID
      // 
      this.txtLIMSSampleID.Location = new System.Drawing.Point(445, 23);
      this.txtLIMSSampleID.Name = "txtLIMSSampleID";
      this.txtLIMSSampleID.Size = new System.Drawing.Size(63, 20);
      this.txtLIMSSampleID.TabIndex = 4;
      this.txtLIMSSampleID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLIMSSampleID_KeyPress);
      // 
      // txtLIMSTestID
      // 
      this.txtLIMSTestID.Location = new System.Drawing.Point(299, 23);
      this.txtLIMSTestID.Name = "txtLIMSTestID";
      this.txtLIMSTestID.Size = new System.Drawing.Size(63, 20);
      this.txtLIMSTestID.TabIndex = 3;
      this.txtLIMSTestID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLIMSTestID_KeyPress);
      // 
      // txtCaseNumber
      // 
      this.txtCaseNumber.Location = new System.Drawing.Point(120, 23);
      this.txtCaseNumber.Name = "txtCaseNumber";
      this.txtCaseNumber.Size = new System.Drawing.Size(114, 20);
      this.txtCaseNumber.TabIndex = 2;
      this.txtCaseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaseNumber_KeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(243, 26);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 17;
      this.label6.Text = "Test ID:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(375, 26);
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
      // LIMSDialog
      // 
      this.LIMSDialog.Buttons.Add(this.btnLIMSDialogOK);
      this.LIMSDialog.CenterParent = true;
      this.LIMSDialog.MainInstruction = "Must specity either all LIMS identifier fields or none.";
      this.LIMSDialog.WindowTitle = "LIMS Identifier error";
      // 
      // btnLIMSDialogOK
      // 
      this.btnLIMSDialogOK.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Ok;
      this.btnLIMSDialogOK.Text = "OK";
      // 
      // LIMSDuplicatePrompt
      // 
      this.LIMSDuplicatePrompt.Buttons.Add(this.btnYes);
      this.LIMSDuplicatePrompt.Buttons.Add(this.btnNo);
      this.LIMSDuplicatePrompt.CenterParent = true;
      this.LIMSDuplicatePrompt.WindowTitle = "LIMS Duplicate Identifier";
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
      // BioSeqInsert
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(589, 319);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnFindInputPath);
      this.Controls.Add(this.txtInputPath);
      this.Controls.Add(this.txtSampleID);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqInsert";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Insert Sample";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtSampleID;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Button btnFindInputPath;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private Ookii.Dialogs.WinForms.TaskDialog ReplacePrompt;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnReplaceYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnReplaceCancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.TextBox txtLIMSSampleID;
    private System.Windows.Forms.TextBox txtLIMSTestID;
    private System.Windows.Forms.TextBox txtCaseNumber;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private Ookii.Dialogs.WinForms.TaskDialog LIMSDialog;
    private Ookii.Dialogs.WinForms.TaskDialog LIMSDuplicatePrompt;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnLIMSDialogOK;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnNo;
  }
}