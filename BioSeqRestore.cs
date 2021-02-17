using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqRestore : Form
  {
    // Restore the selected database. 

    public BioSeqRestore(string versionText)
    {
      InitializeComponent();
      btnOK.Enabled = false;
      txtArchiveDBPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.RestoreKipperPath());
      txtArchiveFilename.Text = AppConfigHelper.RestoreKipperFilenamePrefix();
      txtOutputDBPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.RestoreOutputPath());
      string[] versions = versionText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string version in versions)
      {
        lstVersions.Items.Add(version);
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtArchiveDBPath.Text.Trim().Length > 0 && txtArchiveFilename.Text.Trim().Length > 0 &&
                                       txtOutputDBPath.Text.Trim().Length > 0 && lstVersions.SelectedIndex > 0;
    }

    private void txtArchiveDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtArchiveFilename_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnArchiveDBPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtArchiveDBPath.Text + "\\");
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Archive database path",
                                            DirectoryHelper.IsServerPath(txtArchiveDBPath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtArchiveDBPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Archive database path";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtArchiveDBPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          //if (!ofn.SelectedPath.Trim().StartsWith(AppConfigHelper.UbuntuPrefix()))
          //{
          //  MessageBox.Show("The backup database path must be in the Linux file system.", "Wrong file system", MessageBoxButtons.OK);
          //  return;
          //}
          txtArchiveDBPath.Text = txtArchiveDBPath.Text.Replace(AppConfigHelper.UbuntuPrefix(), string.Empty).Replace("\\", "/");
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // Update config to reflect selection.
      AppConfigHelper.RestoreDatabase(txtArchiveFilename.Text, txtArchiveDBPath.Text, lstVersions.SelectedItem.ToString(), txtOutputDBPath.Text);
    }

    private void lstVersions_SelectedValueChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnOutputDBPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtOutputDBPath.Text + "\\");
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Output database path",
                                            DirectoryHelper.IsServerPath(txtOutputDBPath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtOutputDBPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Output database path";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtOutputDBPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtOutputDBPath.Text = txtArchiveDBPath.Text.Replace(AppConfigHelper.UbuntuPrefix(), string.Empty).Replace("\\", "/");
        }
      }
    }
  }
}