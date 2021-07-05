using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqMetaMaps : Form
  {
    // Perform MetaMaps analysis from Nanopore data using MetaMaps database.

    public BioSeqMetaMaps()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtReferencePath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.MetaMapsReferencePath);
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.MetaMapsOutputPath);
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.MetaMapsInputFile);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.MetaMapsThreads) ? "4" : AppConfigHelper.MetaMapsThreads.ToString();
      txtMinReadLength.Text = string.IsNullOrEmpty(AppConfigHelper.MetaMapsMinReadLength) ? "2000" : AppConfigHelper.MetaMapsMinReadLength.ToString();
      txtMaxMemory.Text = string.IsNullOrEmpty(AppConfigHelper.MetaMapsMaxMemory) ? "40" : AppConfigHelper.MetaMapsMaxMemory.ToString();
      txtMaxReads.Text = string.IsNullOrEmpty(AppConfigHelper.MetaMapsMaxReads) ? "40" : AppConfigHelper.MetaMapsMaxReads.ToString();
      chkOnlyBestMappings.Checked = AppConfigHelper.MetaMapsOnlyBestMappings;

      EnableOK();

      Location = AppConfigHelper.MetaMapsLocation();
      if (Location.X == 0 && Location.Y == 0)
      {
        Location = new Point(100, 100);
        Size = new Size(1000, 600);
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtReferencePath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0 && txtInputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text)))
      {
        MessageBox.Show(txtReferencePath.Text + " does not exist. Choose a valid MetaMaps database file.", "Invalid MetaMaps database file", MessageBoxButtons.OK);
        txtReferencePath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (!DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtInputPath.Text.Trim())))
      {
        MessageBox.Show(txtInputPath.Text.Trim() + " does not exist. Choose a valid fastq read file.", "Invalid fastq read file", MessageBoxButtons.OK);
        txtInputPath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (!DirectoryHelper.DirectoryExists(AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text)))
      {
        MessageBox.Show(txtOutputPath.Text + " does not exist. Choose a valid output path.", "Invalid output path", MessageBoxButtons.OK);
        txtOutputPath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      AppConfigHelper.MetaMapsParms(txtReferencePath.Text.Trim(), txtOutputPath.Text.Trim(), txtInputPath.Text.Trim(),
                                              txtMemo.Text.Trim(), txtThreads.Text.Trim(), txtMinReadLength.Text.Trim(),
                                              txtMaxMemory.Text.Trim(), txtMaxReads.Text.Trim(), chkOnlyBestMappings.Checked);
    }

    private void btnReferencePath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text);
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to MetaMaps reference database",
                                            DirectoryHelper.IsServerPath(txtReferencePath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ServerOnly = true;
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtReferencePath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Path to MetaMaps reference database";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtReferencePath.Text = ofn.SelectedPath.Trim();
        }
      }

      EnableOK();
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

    private void txt_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
                      e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void txt_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtSamplesPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtReferencePath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void BioSeqMetaMaps_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveMetaMapsUIForm(Location, Size);
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text); // We want a file.
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to .fastq file with reads",
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