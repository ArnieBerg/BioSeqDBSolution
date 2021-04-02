namespace BioSeqDB
{
  partial class BioSeqDBLogin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqDBLogin));
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.txt = new System.Windows.Forms.TextBox();
      this.cmb = new System.Windows.Forms.ComboBox();
      this.lblMessage = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btnLogin = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtConfirm = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtNewPassword = new System.Windows.Forms.TextBox();
      this.chkRemember = new System.Windows.Forms.CheckBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkEmailNotifications = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.Transparent;
      this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
      this.panel1.Location = new System.Drawing.Point(328, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(32, 32);
      this.panel1.TabIndex = 6;
      this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(41, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(250, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Enter a user name and password to log on,";
      // 
      // txt
      // 
      this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txt.Location = new System.Drawing.Point(120, 89);
      this.txt.MaxLength = 20;
      this.txt.Name = "txt";
      this.txt.PasswordChar = '*';
      this.txt.Size = new System.Drawing.Size(240, 20);
      this.txt.TabIndex = 1;
      // 
      // cmb
      // 
      this.cmb.Location = new System.Drawing.Point(119, 61);
      this.cmb.Name = "cmb";
      this.cmb.Size = new System.Drawing.Size(241, 21);
      this.cmb.Sorted = true;
      this.cmb.TabIndex = 0;
      // 
      // lblMessage
      // 
      this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMessage.Location = new System.Drawing.Point(41, 257);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(319, 46);
      this.lblMessage.TabIndex = 10;
      this.lblMessage.Text = "The username for BioSeqDB is pre-assigned by the BioSeqDB administrator, and is u" +
    "sed to track activity in the sequence databases.";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(41, 64);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Username:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(41, 91);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Password:";
      // 
      // btnLogin
      // 
      this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLogin.Location = new System.Drawing.Point(285, 306);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(75, 23);
      this.btnLogin.TabIndex = 7;
      this.btnLogin.Text = "OK";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.txtConfirm);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.txtNewPassword);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(12, 170);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(359, 83);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "To change password:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(49, 47);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "Confirm:";
      // 
      // txtConfirm
      // 
      this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtConfirm.Location = new System.Drawing.Point(108, 45);
      this.txtConfirm.MaxLength = 20;
      this.txtConfirm.Name = "txtConfirm";
      this.txtConfirm.PasswordChar = '*';
      this.txtConfirm.Size = new System.Drawing.Size(240, 20);
      this.txtConfirm.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(9, 21);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "New password:";
      // 
      // txtNewPassword
      // 
      this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewPassword.Location = new System.Drawing.Point(108, 19);
      this.txtNewPassword.MaxLength = 20;
      this.txtNewPassword.Name = "txtNewPassword";
      this.txtNewPassword.PasswordChar = '*';
      this.txtNewPassword.Size = new System.Drawing.Size(240, 20);
      this.txtNewPassword.TabIndex = 4;
      // 
      // chkRemember
      // 
      this.chkRemember.AutoSize = true;
      this.chkRemember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkRemember.Location = new System.Drawing.Point(120, 115);
      this.chkRemember.Name = "chkRemember";
      this.chkRemember.Size = new System.Drawing.Size(142, 17);
      this.chkRemember.TabIndex = 2;
      this.chkRemember.Text = "Remember password";
      this.chkRemember.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(159, 306);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Visible = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // chkEmailNotifications
      // 
      this.chkEmailNotifications.AutoSize = true;
      this.chkEmailNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkEmailNotifications.Location = new System.Drawing.Point(120, 134);
      this.chkEmailNotifications.Name = "chkEmailNotifications";
      this.chkEmailNotifications.Size = new System.Drawing.Size(250, 17);
      this.chkEmailNotifications.TabIndex = 3;
      this.chkEmailNotifications.Text = "Email Notifications of Task Completions";
      this.chkEmailNotifications.UseVisualStyleBackColor = true;
      // 
      // BioSeqDBLogin
      // 
      this.AcceptButton = this.btnLogin;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlDark;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(383, 335);
      this.Controls.Add(this.chkEmailNotifications);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.chkRemember);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.txt);
      this.Controls.Add(this.cmb);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BioSeqDBLogin";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Welcome to BioSeqDB";
      this.Shown += new System.EventHandler(this.BioSeqDBLogin_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txt;
    private System.Windows.Forms.ComboBox cmb;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtConfirm;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtNewPassword;
    private System.Windows.Forms.CheckBox chkRemember;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkEmailNotifications;
  }
}