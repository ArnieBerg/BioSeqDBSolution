//using aejw.Network;
using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using BioSeqDBUserCore;
using FSExplorer;
using System;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqDBLogin : Form
  {
    private string UserName;

    public BioSeqDBLogin(string username, string fiClientOnServer) // This is called from the main dialog when switching users. Username is the newly selected user.
    {
      InitializeComponent();
      InitConfig();
      Login(username, fiClientOnServer);
    }

    public BioSeqDBLogin(string fiClientOnServer) // This is called on initial login.
    {
      InitializeComponent();
      InitConfig();
      Login(AppConfigHelper.LastUser, fiClientOnServer);
    }

    private void Login(string user, string fiClientOnServer)
    {
      UserName = user;

      CheckIfClientIsCurrent(fiClientOnServer);
    }

    private void CheckIfClientIsCurrent(string fiClientOnServer)
    {
      PopulateUserDropdown();

      chkRemember.Checked = CheckForRemember();
      chkRemember.CheckedChanged += chkRemember_CheckedChanged;

      chkEmailNotifications.Checked = CheckForEmailNotifications();

      if (fiClientOnServer == null)
      {
        return;
      }

      // Jan-21-2021 This is now being handled by ClickOnce.
      //string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      //FileInfo fi = new FileInfo(executablePath);
      //if (fiClientOnServer != fi.LastWriteTime.ToString("MMM d, yyyy h:mm tt"))
      //{
      //  lblMessage.Text = "This version of BioSeqDB was installed on " + fi.LastWriteTime.ToString("MMM d, yyyy h:mm tt") +
      //                                                        ". A newer version is available (" + fiClientOnServer + ").";
      //  lblMessage.BackColor = Color.Pink;
      //}
    }

    private bool CheckForEmailNotifications()
    {
      User user = AppConfigHelper.seqdbConfigGlobal.Users[cmb.Text.ToUpper()];
      return user.EmailNotifications;
    }

    private bool CheckForRemember()
    {
      if (UserProfileHelper.userProfile.Remember == UserName)
      {
        txt.Text = AppConfigHelper.Password(UserName);
        return true;
      }
      return false;
    }

    private static void InitConfig()
    {
      ServiceCallHelper.LoadConfig(string.Empty); // Loads the global appsettings.json.

      //// Start by copying the local copy of <loggedOnUser>_appsettings.json to the server.
      //DirectoryHelper.FileCopy("[L]" + AppConfigHelper.executablePath + "\\" + AppConfigHelper.LoggedOnUser + "_appsettings.json",
      //                                                                      "[S]" + AppConfigHelper.PathToServerAppsettings, true);
      if (!IsServiceClass.IsService)
      {
        if (!File.Exists(DirectoryHelper.CleanPath(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.PathToWSL()))))
        {
          // Learned that wsl.exe cannot run from \Windows\System32 (file not found).
          MessageBox.Show(DirectoryHelper.CleanPath(AppConfigHelper.PathToWSL()) + " (" +
                          DirectoryHelper.CleanPath(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.PathToWSL())) +
                          ") does not exist. Correct PathToWSL in appsettings.json before continuing.", "ERROR", MessageBoxButtons.OK);
        }

        string path = DirectoryHelper.CleanPath(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.PathToSeqDB()));
        if (!File.Exists(path))
        {
          // Learned that although Ubuntu prefix is \\wsl on my machine, it is \\wsl$ on WIMMER.
          MessageBox.Show(DirectoryHelper.CleanPath(AppConfigHelper.PathToSeqDB()) + " (" +
                        DirectoryHelper.CleanPath(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.PathToSeqDB())) +
                      ") does not exist. " + Environment.NewLine + "Correct PathToSeqDB in appsettings.json before continuing, or" +
                       Environment.NewLine + "issue 'wsl --shutdown' in PowerShell.", "ERROR", MessageBoxButtons.OK);
        }
      }
      else // IsService
      {
        try
        {
          AppConfigHelper.seqdbConfigGlobal.ServerDriveList = ServiceCallHelper.DriveList();
          ServiceCallHelper.SaveConfigGlobal();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Unable to obtain the drive list from the server." + Environment.NewLine + ex.ToString(), "ERROR", MessageBoxButtons.OK);
        }
      }
    }

    private void PopulateUserDropdown()
    {
      foreach (string key in AppConfigHelper.seqdbConfigGlobal.Users.Keys)
      {
        User user = AppConfigHelper.seqdbConfigGlobal.Users[key];
        cmb.Items.Add(user.Username);
      }
      for (int i = 0; i < cmb.Items.Count; i++)
      {
        if (UserName == cmb.Items[i].ToString())
        {
          cmb.SelectedIndex = i;
          break;
        }
      }
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      //NetworkDrive oNetDrive = new NetworkDrive();
      //oNetDrive.Force = false;
      //oNetDrive.Persistent = true;
      //oNetDrive.LocalDrive = "P:";
      //oNetDrive.PromptForCredentials = false;
      //oNetDrive.ShareName = @"\\Datastore\PDSeq";
      //oNetDrive.SaveCredentials = false;
      //string[] DriveListBefore = Environment.GetLogicalDrives();
      //oNetDrive.MapDrive("usask\\agb465", "????BGH4499");

      //string[] DriveListAfter = Environment.GetLogicalDrives();
      //MessageBox.Show("GetDrives: Got " + DriveListBefore.Length.ToString() + " drives before, " + DriveListAfter.Length.ToString() + " drives after.");
      //var dirs = Directory.GetDirectories("P:\\"); // got many nice directories...
      //MessageBox.Show("GetDrives: Got " + dirs.Length.ToString() + " directories in P:");

      if (!AppConfigHelper.ValidPassword(cmb.Text.Trim(), txt.Text.Trim()))
      {
        DialogResult = DialogResult.None;
        MessageBox.Show("Username or password is invalid.", "Invalid", MessageBoxButtons.OK);
        txt.Focus();
        txt.SelectAll();
        return;
      }

      // If this is an attempt to change the password, validate.
      if (txtNewPassword.Text.Trim().Length + txtConfirm.Text.Trim().Length > 0)
      {
        if (txtNewPassword.Text.Trim() != txtConfirm.Text.Trim())
        {
          DialogResult = DialogResult.None;
          MessageBox.Show("New password does not match confirmation.", "Invalid", MessageBoxButtons.OK);
          txtNewPassword.Focus();
          txtNewPassword.SelectAll();
          return;
        }

        AppConfigHelper.ChangePassword(cmb.Text.ToString().ToUpper().Trim(), txtNewPassword.Text.Trim());
      }

      DialogResult = DialogResult.OK;
      AppConfigHelper.LastUser = cmb.Text.ToString().ToUpper().Trim();

      // Only update email notifications on valid login, otherwise one user can change the preference of another.
      User user = AppConfigHelper.seqdbConfigGlobal.Users[AppConfigHelper.LastUser];
      user.EmailNotifications = chkEmailNotifications.Checked;
      AppConfigHelper.SaveConfigGlobal();

      //// Start by copying the local copy of <loggedOnUser>_appsettings.json to the server.      
      //DirectoryHelper.FileCopy("[L]" + AppConfigHelper.executablePath + "\\" + AppConfigHelper.LoggedOnUser + "_appsettings.json",
      //                                                                      "[S]" + AppConfigHelper.PathToServerAppsettings, true);
      AppConfigHelper.LoggedOnUser = AppConfigHelper.LastUser; 
    }

    private void BioSeqDBLogin_Shown(object sender, EventArgs e)
    {
      if (cmb.SelectedIndex > -1)
      {
        txt.Focus(); // Start in password field if last user is defined.
        txt.SelectAll();
      }
    }

    private void panel1_DoubleClick(object sender, EventArgs e)
    {
      // Test DirectoryHelper
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Server File Explorer...", false, string.Empty, 
                                            "Fasta files (*.fasta)|*.fasta;*.fna;*.fa|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {        
        MessageBox.Show(Explorer.PresentLocalPath + Explorer.PresentServerPath, "Selected path", MessageBoxButtons.OK);
      }
    }

    private void chkRemember_CheckedChanged(object sender, EventArgs e)
    {
      if (chkRemember.Checked) // Record username in C:\Temp\remember.json (should really encrypt it).
      {
        UserProfileHelper.userProfile.Remember = UserName;
        UserProfileHelper.SaveUserProfile();
        txt.Text = AppConfigHelper.Password(UserName);
      }
      else // Unchecked
      {
        try
        {
          UserProfileHelper.userProfile.Remember = string.Empty;
          UserProfileHelper.SaveUserProfile();
          txt.Text = string.Empty;
        }
        catch (Exception)
        { }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
