using BioSeqDB.ModelClient;
using FSExplorer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqBandage : Form
  {
    // Perform BioSeqBandage analysis of Nanopore data.

    public BioSeqBandage()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.BandageInputPath);
      EnableOK();

      Location = AppConfigHelper.BioSeqBandageLocation();
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
      AppConfigHelper.BandageInputPath = txtInputPath.Text.Trim();
    }

    private void BioSeqBandage_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveBioSeqBandageUIForm(Location, Size);
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
                                          "GFA files (*.gfa)|*.gfa|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
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