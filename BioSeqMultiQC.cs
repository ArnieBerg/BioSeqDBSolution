using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqMultiQC : Form
  {
    // Perform MultiQC analysis of Nanopore data.

    public BioSeqMultiQC()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.MultiQCOutputPath);
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.MultiQCInputPath);
      EnableOK();

      Location = AppConfigHelper.MultiQCLocation();
      if (Location.X == 0 && Location.Y == 0)
      {
        Location = new Point(100, 100);
        Size = new Size(1000, 600);
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtInputPath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!DirectoryHelper.DirectoryExists(AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text)))
      {
        MessageBox.Show(txtOutputPath.Text + " does not exist. Choose a valid output path.", "Invalid output path", MessageBoxButtons.OK);
        txtOutputPath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      AppConfigHelper.MultiQCParms(txtOutputPath.Text.Trim(), txtInputPath.Text.Trim(), txtMemo.Text.Trim());
    }

    private void btnOutputPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text + "\\");
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Output path",
                                          DirectoryHelper.IsServerPath(txtOutputPath.Text), DirectoryHelper.CleanPath(path),
                                          string.Empty, null, AppConfigHelper.UbuntuPrefix());
      Cursor.Current = Cursors.Default;
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtOutputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;

      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void BioSeqMultiQC_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveMultiQCUIForm(Location, Size);
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text + "\\"); // We want a folder.
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder files to report on",
                                          DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                          string.Empty, null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtInputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;
    }
  }
}