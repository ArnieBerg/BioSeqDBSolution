using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqCentrifuge : Form
  {
    // Perform Influenza A analysis from Nanopore data using Centrifuge database.

    public BioSeqCentrifuge()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtCentrifugePath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CentrifugeReferencePath);
      lblCentrifugeDBName.Text = GetCentrifugeDBName();
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CentrifugeOutputPath);
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CentrifugeFastqPath);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.CentrifugeThreads) ? "4" : AppConfigHelper.CentrifugeThreads.ToString();
      txtMaxAssignments.Text = string.IsNullOrEmpty(AppConfigHelper.CentrifugeMaxAssignments) ? "50" : AppConfigHelper.CentrifugeMaxAssignments.ToString();

      EnableOK();

      Location = AppConfigHelper.CentrifugeLocation();
      if (Location.X == 0 && Location.Y == 0)
      {
        Location = new Point(100, 100);
        Size = new Size(1000, 600);
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtCentrifugePath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0 && txtInputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!DirectoryHelper.DirectoryExists(AppConfigHelper.NormalizePathToWindows(txtCentrifugePath.Text)))
      {
        MessageBox.Show(txtCentrifugePath.Text + " does not exist. Choose a valid Centrifuge database path.", "Invalid Centrifuge database path", MessageBoxButtons.OK);
        txtCentrifugePath.Focus();
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

      AppConfigHelper.CentrifugeParms(txtCentrifugePath.Text.Trim(), txtOutputPath.Text.Trim(), txtInputPath.Text.Trim(),
                                              txtMemo.Text.Trim(), txtThreads.Text, txtMaxAssignments.Text.Trim());
    }

    private void btnCentrifugePath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtCentrifugePath.Text + "\\");
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to Centrifuge reference database",
                                            DirectoryHelper.IsServerPath(txtCentrifugePath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ServerOnly = true;
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtCentrifugePath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Path to Centrifuge reference database";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtCentrifugePath.Text = ofn.SelectedPath.Trim();
        }
      }

      lblCentrifugeDBName.Text = GetCentrifugeDBName();

      EnableOK();
    }

    private string GetCentrifugeDBName()
    {
      string lblCentrifugeDBName = "Centrifuge database name: ";

      if (!string.IsNullOrEmpty(txtCentrifugePath.Text.Trim()))
      {
        string centrifugeDBName = ServiceCallHelper.CentrifugeDatabaseName(txtCentrifugePath.Text);
        if (!string.IsNullOrEmpty(centrifugeDBName))
        {
          lblCentrifugeDBName += centrifugeDBName;
        }
        else
        {
          lblCentrifugeDBName = txtCentrifugePath.Text + " is not a valid Centrifuge database path.";
        }
      }
      return lblCentrifugeDBName;
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

    private void txtSamplesPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtCentrifugePath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void BioSeqCentrifuge_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveCentrifugeUIForm(Location, Size);
    }

    private void txtMaxAssignments_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
                e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void txtMaxAssignments_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
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