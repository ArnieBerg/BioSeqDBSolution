namespace BioSeqDB
{
  partial class BioSeqDBAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqDBAbout));
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnChangeLog = new System.Windows.Forms.Button();
      this.labelVersion = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lvThreads = new System.Windows.Forms.ListView();
      this.colThreadIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lvUsers = new System.Windows.Forms.ListView();
      this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colLastActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colLogout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label7 = new System.Windows.Forms.Label();
      this.lblServer = new System.Windows.Forms.Label();
      this.txtCommandHistory = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(26, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(122, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "BioSeqDB 2.0";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackgroundImage = global::BioSeqDB.Properties.Resources.dna;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(436, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(71, 64);
      this.pictureBox1.TabIndex = 21;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(26, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 13);
      this.label2.TabIndex = 22;
      this.label2.Text = "Jimmy Liu, Arnie Berg";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(26, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(160, 13);
      this.label3.TabIndex = 23;
      this.label3.Text = "Prairie Diagnostic Services";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(26, 85);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(96, 13);
      this.label4.TabIndex = 24;
      this.label4.Text = "December 2020";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(27, 124);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(264, 13);
      this.label5.TabIndex = 25;
      this.label5.Text = "Last Windows Subsystem for Linux command:";
      // 
      // panel1
      // 
      this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
      this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.panel1.Location = new System.Drawing.Point(488, 140);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(14, 17);
      this.panel1.TabIndex = 27;
      this.toolTip1.SetToolTip(this.panel1, "Copy command to clipboard");
      this.panel1.Click += new System.EventHandler(this.panel1_Click);
      // 
      // btnChangeLog
      // 
      this.btnChangeLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnChangeLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnChangeLog.Location = new System.Drawing.Point(371, 99);
      this.btnChangeLog.Margin = new System.Windows.Forms.Padding(2);
      this.btnChangeLog.Name = "btnChangeLog";
      this.btnChangeLog.Size = new System.Drawing.Size(111, 22);
      this.btnChangeLog.TabIndex = 0;
      this.btnChangeLog.Text = "Change log...";
      this.toolTip1.SetToolTip(this.btnChangeLog, "Backup database");
      this.btnChangeLog.UseVisualStyleBackColor = true;
      this.btnChangeLog.Click += new System.EventHandler(this.btnChangeLog_Click);
      // 
      // labelVersion
      // 
      this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelVersion.Location = new System.Drawing.Point(30, 104);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(156, 17);
      this.labelVersion.TabIndex = 29;
      this.labelVersion.Text = "version";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(26, 211);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(164, 13);
      this.label6.TabIndex = 69;
      this.label6.Text = "Background thread activity:";
      // 
      // lvThreads
      // 
      this.lvThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colThreadIndex,
            this.colID,
            this.colStartTime,
            this.colUser,
            this.colMemo,
            this.colResult});
      this.lvThreads.FullRowSelect = true;
      this.lvThreads.HideSelection = false;
      this.lvThreads.Location = new System.Drawing.Point(27, 229);
      this.lvThreads.MultiSelect = false;
      this.lvThreads.Name = "lvThreads";
      this.lvThreads.Size = new System.Drawing.Size(480, 245);
      this.lvThreads.TabIndex = 70;
      this.lvThreads.UseCompatibleStateImageBehavior = false;
      this.lvThreads.View = System.Windows.Forms.View.Details;
      // 
      // colThreadIndex
      // 
      this.colThreadIndex.Text = " ";
      this.colThreadIndex.Width = 30;
      // 
      // colID
      // 
      this.colID.Text = "Thread";
      this.colID.Width = 47;
      // 
      // colStartTime
      // 
      this.colStartTime.Text = "Start time";
      this.colStartTime.Width = 110;
      // 
      // colUser
      // 
      this.colUser.Text = "User";
      this.colUser.Width = 80;
      // 
      // colMemo
      // 
      this.colMemo.Text = "Memo";
      this.colMemo.Width = 110;
      // 
      // colResult
      // 
      this.colResult.Text = "Request";
      this.colResult.Width = 1500;
      // 
      // lvUsers
      // 
      this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUsername,
            this.colLogin,
            this.colLastActive,
            this.colLogout});
      this.lvUsers.FullRowSelect = true;
      this.lvUsers.HideSelection = false;
      this.lvUsers.Location = new System.Drawing.Point(27, 499);
      this.lvUsers.MultiSelect = false;
      this.lvUsers.Name = "lvUsers";
      this.lvUsers.Size = new System.Drawing.Size(480, 169);
      this.lvUsers.TabIndex = 71;
      this.lvUsers.UseCompatibleStateImageBehavior = false;
      this.lvUsers.View = System.Windows.Forms.View.Details;
      // 
      // colUsername
      // 
      this.colUsername.Text = "User";
      this.colUsername.Width = 80;
      // 
      // colLogin
      // 
      this.colLogin.Text = "Login Time";
      this.colLogin.Width = 125;
      // 
      // colLastActive
      // 
      this.colLastActive.Text = "Last Active Time";
      this.colLastActive.Width = 125;
      // 
      // colLogout
      // 
      this.colLogout.Text = "Logout Time";
      this.colLogout.Width = 125;
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(27, 483);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(43, 13);
      this.label7.TabIndex = 72;
      this.label7.Text = "Users:";
      // 
      // lblServer
      // 
      this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblServer.Location = new System.Drawing.Point(192, 104);
      this.lblServer.Name = "lblServer";
      this.lblServer.Size = new System.Drawing.Size(156, 17);
      this.lblServer.TabIndex = 73;
      this.lblServer.Text = "server IP address";
      // 
      // txtCommandHistory
      // 
      this.txtCommandHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtCommandHistory.Location = new System.Drawing.Point(33, 141);
      this.txtCommandHistory.Multiline = true;
      this.txtCommandHistory.Name = "txtCommandHistory";
      this.txtCommandHistory.ReadOnly = true;
      this.txtCommandHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtCommandHistory.Size = new System.Drawing.Size(449, 66);
      this.txtCommandHistory.TabIndex = 74;
      // 
      // BioSeqDBAbout
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(519, 680);
      this.Controls.Add(this.txtCommandHistory);
      this.Controls.Add(this.lblServer);
      this.Controls.Add(this.btnChangeLog);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.lvUsers);
      this.Controls.Add(this.lvThreads);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BioSeqDBAbout";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About BioSeqDB...";
      this.Shown += new System.EventHandler(this.BioSeqDBAbout_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ListView lvThreads;
    private System.Windows.Forms.ColumnHeader colThreadIndex;
    private System.Windows.Forms.ColumnHeader colID;
    private System.Windows.Forms.ColumnHeader colStartTime;
    private System.Windows.Forms.ColumnHeader colUser;
    private System.Windows.Forms.ColumnHeader colResult;
    private System.Windows.Forms.ColumnHeader colMemo;
    private System.Windows.Forms.ListView lvUsers;
    private System.Windows.Forms.ColumnHeader colUsername;
    private System.Windows.Forms.ColumnHeader colLogin;
    private System.Windows.Forms.ColumnHeader colLastActive;
    private System.Windows.Forms.ColumnHeader colLogout;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnChangeLog;
    private System.Windows.Forms.Label lblServer;
    private System.Windows.Forms.TextBox txtCommandHistory;
  }
}