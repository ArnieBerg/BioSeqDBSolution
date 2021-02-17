namespace BioSeqDB
{
  partial class BioSeqDBNotifications
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqDBNotifications));
      this.label4 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.lstTasks = new System.Windows.Forms.ListBox();
      this.btnDeleteTask = new System.Windows.Forms.Button();
      this.btnPushTask = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblTime = new System.Windows.Forms.Label();
      this.lblUser = new System.Windows.Forms.Label();
      this.lblStatus = new System.Windows.Forms.Label();
      this.lblDatabase = new System.Windows.Forms.Label();
      this.lblType = new System.Windows.Forms.Label();
      this.cmbTaskStatusFilter = new System.Windows.Forms.ComboBox();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.label5 = new System.Windows.Forms.Label();
      this.lblCompleted = new System.Windows.Forms.Label();
      this.SuccessDialog = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
      this.btnOK = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
      this.lblMemo = new System.Windows.Forms.Label();
      this.lbl9 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(18, 14);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(983, 88);
      this.label4.TabIndex = 13;
      this.label4.Text = "The listed tasks are pending or have been completed (\'ready\').  Click on \'PUSH\' f" +
    "or \'Ready\' tasks to see their completion status.";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatAppearance.BorderSize = 2;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(906, 678);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(92, 34);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(16, 168);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 20);
      this.label2.TabIndex = 25;
      this.label2.Text = "Tasks:";
      // 
      // lstTasks
      // 
      this.lstTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lstTasks.FormattingEnabled = true;
      this.lstTasks.ItemHeight = 20;
      this.lstTasks.Location = new System.Drawing.Point(16, 197);
      this.lstTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lstTasks.Name = "lstTasks";
      this.lstTasks.Size = new System.Drawing.Size(376, 444);
      this.lstTasks.TabIndex = 0;
      this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.lstTasks_SelectedIndexChanged);
      // 
      // btnDeleteTask
      // 
      this.btnDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDeleteTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDeleteTask.Image = global::BioSeqDB.Properties.Resources.DELETE;
      this.btnDeleteTask.Location = new System.Drawing.Point(417, 529);
      this.btnDeleteTask.Name = "btnDeleteTask";
      this.btnDeleteTask.Size = new System.Drawing.Size(96, 98);
      this.btnDeleteTask.TabIndex = 3;
      this.toolTip1.SetToolTip(this.btnDeleteTask, "Delete selected task");
      this.btnDeleteTask.UseVisualStyleBackColor = true;
      this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
      // 
      // btnPushTask
      // 
      this.btnPushTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPushTask.BackgroundImage = global::BioSeqDB.Properties.Resources.pushdull;
      this.btnPushTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnPushTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPushTask.Location = new System.Drawing.Point(902, 560);
      this.btnPushTask.Name = "btnPushTask";
      this.btnPushTask.Size = new System.Drawing.Size(96, 98);
      this.btnPushTask.TabIndex = 5;
      this.toolTip1.SetToolTip(this.btnPushTask, "Complete selected task");
      this.btnPushTask.UseVisualStyleBackColor = true;
      this.btnPushTask.Click += new System.EventHandler(this.btnPushTask_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(412, 202);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(117, 20);
      this.label1.TabIndex = 34;
      this.label1.Text = "Time issued:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(412, 232);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 20);
      this.label3.TabIndex = 35;
      this.label3.Text = "User:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(412, 325);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(69, 20);
      this.label6.TabIndex = 37;
      this.label6.Text = "Status:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(412, 294);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(95, 20);
      this.label7.TabIndex = 38;
      this.label7.Text = "Database:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(412, 263);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(55, 20);
      this.label8.TabIndex = 39;
      this.label8.Text = "Type:";
      // 
      // lblTime
      // 
      this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTime.Location = new System.Drawing.Point(542, 202);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(456, 24);
      this.lblTime.TabIndex = 40;
      // 
      // lblUser
      // 
      this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUser.Location = new System.Drawing.Point(542, 232);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new System.Drawing.Size(456, 24);
      this.lblUser.TabIndex = 41;
      // 
      // lblStatus
      // 
      this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.Location = new System.Drawing.Point(542, 325);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(456, 24);
      this.lblStatus.TabIndex = 43;
      // 
      // lblDatabase
      // 
      this.lblDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDatabase.Location = new System.Drawing.Point(542, 294);
      this.lblDatabase.Name = "lblDatabase";
      this.lblDatabase.Size = new System.Drawing.Size(456, 24);
      this.lblDatabase.TabIndex = 44;
      // 
      // lblType
      // 
      this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblType.Location = new System.Drawing.Point(542, 263);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(456, 24);
      this.lblType.TabIndex = 45;
      // 
      // cmbTaskStatusFilter
      // 
      this.cmbTaskStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTaskStatusFilter.FormattingEnabled = true;
      this.cmbTaskStatusFilter.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Ready"});
      this.cmbTaskStatusFilter.Location = new System.Drawing.Point(222, 163);
      this.cmbTaskStatusFilter.Name = "cmbTaskStatusFilter";
      this.cmbTaskStatusFilter.Size = new System.Drawing.Size(168, 28);
      this.cmbTaskStatusFilter.Sorted = true;
      this.cmbTaskStatusFilter.TabIndex = 2;
      this.cmbTaskStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTaskStatusFilter_SelectedIndexChanged);
      // 
      // btnRefresh
      // 
      this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
      this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRefresh.Location = new System.Drawing.Point(783, 560);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(96, 98);
      this.btnRefresh.TabIndex = 4;
      this.toolTip1.SetToolTip(this.btnRefresh, "Refresh task list");
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(412, 355);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 20);
      this.label5.TabIndex = 46;
      this.label5.Text = "Completed:";
      // 
      // lblCompleted
      // 
      this.lblCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCompleted.Location = new System.Drawing.Point(542, 355);
      this.lblCompleted.Name = "lblCompleted";
      this.lblCompleted.Size = new System.Drawing.Size(456, 24);
      this.lblCompleted.TabIndex = 47;
      // 
      // SuccessDialog
      // 
      this.SuccessDialog.Buttons.Add(this.btnOK);
      this.SuccessDialog.CenterParent = true;
      this.SuccessDialog.WindowTitle = "Success";
      // 
      // btnOK
      // 
      this.btnOK.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Ok;
      this.btnOK.Default = true;
      this.btnOK.Text = "OK";
      // 
      // lblMemo
      // 
      this.lblMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMemo.Location = new System.Drawing.Point(542, 386);
      this.lblMemo.Name = "lblMemo";
      this.lblMemo.Size = new System.Drawing.Size(456, 147);
      this.lblMemo.TabIndex = 49;
      // 
      // lbl9
      // 
      this.lbl9.AutoSize = true;
      this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl9.Location = new System.Drawing.Point(412, 389);
      this.lbl9.Name = "lbl9";
      this.lbl9.Size = new System.Drawing.Size(65, 20);
      this.lbl9.TabIndex = 48;
      this.lbl9.Text = "Memo:";
      // 
      // BioSeqDBNotifications
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(1047, 718);
      this.Controls.Add(this.lblMemo);
      this.Controls.Add(this.lbl9);
      this.Controls.Add(this.lblCompleted);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.cmbTaskStatusFilter);
      this.Controls.Add(this.lblType);
      this.Controls.Add(this.lblDatabase);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.lblUser);
      this.Controls.Add(this.lblTime);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnPushTask);
      this.Controls.Add(this.btnDeleteTask);
      this.Controls.Add(this.lstTasks);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.label4);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "BioSeqDBNotifications";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "BioSeqDB Pending Notifications";
      this.toolTip1.SetToolTip(this, "Refresh task list");
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioSeqDBNotifications_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lstTasks;
    private System.Windows.Forms.Button btnDeleteTask;
    private System.Windows.Forms.Button btnPushTask;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblUser;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblDatabase;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.ComboBox cmbTaskStatusFilter;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblCompleted;
    private Ookii.Dialogs.WinForms.TaskDialog SuccessDialog;
    private Ookii.Dialogs.WinForms.TaskDialogButton btnOK;
    private System.Windows.Forms.Label lblMemo;
    private System.Windows.Forms.Label lbl9;
  }
}