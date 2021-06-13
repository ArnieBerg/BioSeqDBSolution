using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqFastQC : Form
  {
    // Perform FastQC analysis of Nanopore data.

    public BioSeqFastQC()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.FastQCOutputPath);
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.FastQCInputPath);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.FastQCThreads) ? "4" : AppConfigHelper.FastQCThreads.ToString();
      chkConsolidate.Checked = AppConfigHelper.FastQCConsolidate;
      chkMultiQC.Checked = AppConfigHelper.FastQCMultiQC;
      EnableOK();

      if (Size.Width != 0)
      {
        Location = AppConfigHelper.FastQCLocation();
        if (Location.X <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.FastQCSize();
        if (Size.Height <= 0 || Size.Width <= 0)
        {
          Size = new Size(1000, 1000);
        }
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtInputPath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
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

      AppConfigHelper.FastQCParms(txtOutputPath.Text.Trim(), txtInputPath.Text.Trim(), txtMemo.Text.Trim(), txtThreads.Text, chkConsolidate.Checked, chkMultiQC.Checked);
    }

    private void btnOutputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
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
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Output path";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtOutputPath.Text = ofn.SelectedPath.Trim();
        }
      }

      EnableOK();
    }

    private void txtThreads_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
                      e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void txtThreads_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void BioSeqFastQC_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveFastQCUIForm(Location, Size);
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text + "\\"); // We want a folder.
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder with .fastq files",
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