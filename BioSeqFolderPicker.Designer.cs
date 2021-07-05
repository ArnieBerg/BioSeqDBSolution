namespace BioSeqDB
{
  partial class BioSeqFolderPicker
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
      this.label2 = new System.Windows.Forms.Label();
      this.btnFindFolder = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.ReplacePrompt = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnReplaceYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnReplaceCancel = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.LIMSDialog = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnLIMSDialogOK = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.LIMSDuplicatePrompt = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnYes = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.btnNo = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.lvFolders = new System.Windows.Forms.ListView();
      this.colSampleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.lblPath = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtSampleID = new System.Windows.Forms.TextBox();
      this.lblSampleID = new System.Windows.Forms.Label();
      this.btnDelete = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
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
      this.label4.Size = new System.Drawing.Size(565, 48);
      this.label4.TabIndex = 13;
      this.label4.Text = "Select <analysis> data folder(s), and provide an for each folder used to identify" +
    " the selection. By default, the ID comes from the name of the last sub-folder na" +
    "me of the selected path.";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 61);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(202, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "<analysis> data folder(s) to select:";
      // 
      // btnFindFolder
      // 
      this.btnFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFindFolder.Location = new System.Drawing.Point(558, 76);
      this.btnFindFolder.Name = "btnFindFolder";
      this.btnFindFolder.Size = new System.Drawing.Size(31, 23);
      this.btnFindFolder.TabIndex = 1;
      this.btnFindFolder.Text = "...";
      this.btnFindFolder.UseVisualStyleBackColor = true;
      this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(397, 420);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(53, 22);
      this.btnOK.TabIndex = 3;
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
      this.btnCancel.Location = new System.Drawing.Point(498, 420);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 4;
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
      // lvFolders
      // 
      this.lvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSampleID,
            this.colPath});
      this.lvFolders.FullRowSelect = true;
      this.lvFolders.HideSelection = false;
      this.lvFolders.Location = new System.Drawing.Point(12, 77);
      this.lvFolders.MultiSelect = false;
      this.lvFolders.Name = "lvFolders";
      this.lvFolders.Scrollable = false;
      this.lvFolders.Size = new System.Drawing.Size(547, 243);
      this.lvFolders.TabIndex = 68;
      this.lvFolders.UseCompatibleStateImageBehavior = false;
      this.lvFolders.View = System.Windows.Forms.View.Details;
      this.lvFolders.SelectedIndexChanged += new System.EventHandler(this.lvSamples_SelectedIndexChanged);
      // 
      // colSampleID
      // 
      this.colSampleID.Text = "ID";
      this.colSampleID.Width = 100;
      // 
      // colPath
      // 
      this.colPath.Text = "Path";
      this.colPath.Width = 1200;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.btnUpdate);
      this.panel1.Controls.Add(this.lblPath);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.txtSampleID);
      this.panel1.Controls.Add(this.lblSampleID);
      this.panel1.Controls.Add(this.btnDelete);
      this.panel1.Location = new System.Drawing.Point(12, 326);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(547, 88);
      this.panel1.TabIndex = 69;
      // 
      // btnUpdate
      // 
      this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnUpdate.Location = new System.Drawing.Point(442, 9);
      this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new System.Drawing.Size(86, 20);
      this.btnUpdate.TabIndex = 41;
      this.btnUpdate.Text = "Update";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // lblPath
      // 
      this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPath.Location = new System.Drawing.Point(93, 32);
      this.lblPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblPath.Name = "lblPath";
      this.lblPath.Size = new System.Drawing.Size(435, 20);
      this.lblPath.TabIndex = 40;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(15, 32);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 39;
      this.label1.Text = "Path:";
      // 
      // txtSampleID
      // 
      this.txtSampleID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSampleID.Location = new System.Drawing.Point(93, 9);
      this.txtSampleID.Name = "txtSampleID";
      this.txtSampleID.Size = new System.Drawing.Size(345, 20);
      this.txtSampleID.TabIndex = 38;
      // 
      // lblSampleID
      // 
      this.lblSampleID.AutoSize = true;
      this.lblSampleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSampleID.Location = new System.Drawing.Point(15, 13);
      this.lblSampleID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblSampleID.Name = "lblSampleID";
      this.lblSampleID.Size = new System.Drawing.Size(24, 13);
      this.lblSampleID.TabIndex = 37;
      this.lblSampleID.Text = "ID:";
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Image = global::BioSeqDB.Properties.Resources.DELETE;
      this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDelete.Location = new System.Drawing.Point(93, 61);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(136, 20);
      this.btnDelete.TabIndex = 32;
      this.btnDelete.Text = "Delete Folder";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // BioSeqFolderPicker
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(601, 456);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.lvFolders);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnFindFolder);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqFolderPicker";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB folder picker for <analysis> ";
      this.Shown += new System.EventHandler(this.BioSeqFolderPicker_Shown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnFindFolder;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private Ookii.Dialogs.WinForms.TaskDialog ReplacePrompt;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnReplaceYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnReplaceCancel;
    private Ookii.Dialogs.WinForms.TaskDialog LIMSDialog;
    private Ookii.Dialogs.WinForms.TaskDialog LIMSDuplicatePrompt;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnLIMSDialogOK;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnYes;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnNo;
    private System.Windows.Forms.ListView lvFolders;
    private System.Windows.Forms.ColumnHeader colSampleID;
    private System.Windows.Forms.ColumnHeader colPath;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Label lblPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtSampleID;
    private System.Windows.Forms.Label lblSampleID;
    private System.Windows.Forms.Button btnUpdate;
  }
}