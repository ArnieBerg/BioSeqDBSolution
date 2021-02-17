using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqBackup : Form
  {
    // Backup the selected database. Only need to prompt for the archival path.

    public BioSeqBackup()
    {
      InitializeComponent();
      btnOK.Enabled = false;
      txtDBPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CurrentKipperPath());
      txtArchiveFilename.Text = AppConfigHelper.CurrentKipperFilenamePrefix();
      if (txtArchiveFilename.Text.Length == 0)
      {
        txtArchiveFilename.ReadOnly = false;  // Allow filename to be entered if none exists.
        txtDBPath.ReadOnly = false;
        btnFindDBPath.Enabled = true;
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtDBPath.Text.Trim().Length > 0;
    }

    private void txtDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtArchiveFilename_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnFindDBPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtDBPath.Text + "\\");
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Archive database path",
                                            DirectoryHelper.IsServerPath(txtDBPath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtDBPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Archive database path";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtDBPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          //if (!ofn.SelectedPath.Trim().StartsWith(AppConfigHelper.UbuntuPrefix()))
          //{
          //  MessageBox.Show("The backup database path must be in the Linux file system.", "Wrong file system", MessageBoxButtons.OK);
          //  return;
          //}
          txtDBPath.Text = ofn.SelectedPath.Trim();
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // Update config to reflect selection.
      AppConfigHelper.BackupDatabase(txtArchiveFilename.Text, txtDBPath.Text);
    }
  }
}