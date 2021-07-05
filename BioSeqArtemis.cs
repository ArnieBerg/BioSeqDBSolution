using BioSeqDB.ModelClient;
using FSExplorer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqArtemis : Form
  {
    // Perform Artemis analysis of Nanopore data.

    public BioSeqArtemis()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.ArtemisInputPath);
      EnableOK();

      Location = AppConfigHelper.ArtemisLocation();
      if (Location.X == 0 && Location.Y == 0)
      {
        Location = new Point(100, 100);
        Size = new Size(1000, 600);
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtInputPath.Text.Trim().Length > 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      AppConfigHelper.ArtemisInputPath = txtInputPath.Text.Trim();
    }

    private void BioSeqArtemis_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveArtemisUIForm(Location, Size);
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text.Trim()); // We want a file.
      if (path.EndsWith("\\"))
      {
        path = path.Substring(0, path.Length - 1);
      }
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to genomic file to report on",
                                          DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                          string.Empty, null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtInputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;
    }

    private void txtInputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }
  }
}