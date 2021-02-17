using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqExtract : Form
  {
    // Extract a sample from the selected database.

    public BioSeqExtract()
    {
      InitializeComponent();
      btnOK.Enabled = false;
      txtSampleID.Text = AppConfigHelper.ExtractSampleID();
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.ExtractOutputPath());
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtSampleID.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0;
    }

    private void txtDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnFindOutputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        Cursor.Current = Cursors.WaitCursor;
        string path = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text + "\\");
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
      }
      else
      {
        // Could be in either the Windows or Linux file system.
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Output path to folder for .fasta contig files";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtOutputPath.Text = ofn.SelectedPath.Trim();
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // Update config to reflect selection.
      AppConfigHelper.ExtractSample(txtOutputPath.Text.Trim(), txtSampleID.Text.Trim());
    }
  }
}