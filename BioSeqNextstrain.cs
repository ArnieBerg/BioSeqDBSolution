using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using FSExplorer;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqNextstrain : Form
  {
    // Perform Nextstrain analysis of current database.
    private NextstrainProfile nextstrainProfile;

    public BioSeqNextstrain()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      nextstrainProfile = AppConfigHelper.GetNextstrainProfile(); // for current database.

      txtReferencePath.Text = DirectoryHelper.UnCleanPath(nextstrainProfile.ReferencePath);
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(nextstrainProfile.OuputPath);
      txtThreads.Text = nextstrainProfile.NumberOfThreads.ToString();
      txtClusterCutoff.Text = nextstrainProfile.ClusterCutoff.ToString();
      txtMaskFromBeginning.Text = nextstrainProfile.MaskFromBeginning.ToString();
      txtMaskFromEnd.Text = nextstrainProfile.MaskFromEnd.ToString();
      txtMaskSites.Text = nextstrainProfile.MaskSites;
      txtMetadataPath.Text = DirectoryHelper.UnCleanPath(nextstrainProfile.MetadataPath);
      txtMinLengthFilter.Text = nextstrainProfile.MinGenomeLength.ToString();
      txtSNPCutoff.Text = nextstrainProfile.SNPCutoff.ToString();
      txtRootNode.Text = nextstrainProfile.RootNode;
      dtpMinDate.Value = nextstrainProfile.MinDate == DateTime.MinValue ? new DateTime(1950, 1, 1) : nextstrainProfile.MinDate;
      dtpMinDateFilter.Value = nextstrainProfile.MinDateFilter == DateTime.MinValue ? new DateTime(1950, 1, 1) : nextstrainProfile.MinDateFilter;
      EnableOK();
    }

    private void EnableOK()
    {
      btnOK.Enabled = true; // Validate values of numeric fields and date fields

      if (btnOK.Enabled)
      {
        btnOK.Enabled = txtReferencePath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0 && 
                              txtMetadataPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text)))
      {
        MessageBox.Show(txtReferencePath.Text + " does not exist. Choose a valid reference file.", "Invalid reference file", MessageBoxButtons.OK);
        txtReferencePath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (!DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtMetadataPath.Text)))
      {
        MessageBox.Show(txtMetadataPath.Text + " does not exist. Choose a valid metadata file.", "Invalid metadata file", MessageBoxButtons.OK);
        txtMetadataPath.Focus();
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

      nextstrainProfile.MetadataPath = txtMetadataPath.Text.Trim();
      nextstrainProfile.ReferencePath = txtReferencePath.Text.Trim();
      nextstrainProfile.OuputPath = txtOutputPath.Text.Trim();
      nextstrainProfile.MaskSites = txtMaskSites.Text.Trim();
      nextstrainProfile.RootNode = txtRootNode.Text.Trim();
      nextstrainProfile.ClusterCutoff = int.Parse(txtClusterCutoff.Text.Trim());
      nextstrainProfile.MaskFromBeginning = int.Parse(txtMaskFromBeginning.Text.Trim());
      nextstrainProfile.MaskFromEnd = int.Parse(txtMaskFromEnd.Text.Trim());
      nextstrainProfile.NumberOfThreads = int.Parse(txtThreads.Text.Trim());
      nextstrainProfile.MinGenomeLength = int.Parse(txtMinLengthFilter.Text.Trim());
      nextstrainProfile.MinDate = dtpMinDate.Value;
      nextstrainProfile.MinDateFilter = dtpMinDateFilter.Value;

      AppConfigHelper.NextstrainParms(nextstrainProfile, txtMemo.Text.Trim());
    }

    private void btnMetadataPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtMetadataPath.Text);
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to TSV metadata file",
                                          DirectoryHelper.IsServerPath(txtMetadataPath.Text), DirectoryHelper.CleanPath(path),
                                          "TSV files (*.tsv)|*.tsv|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ServerOnly = true;
      Cursor.Current = Cursors.Default;
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtMetadataPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;
    }

    private void btnReferencePath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text);
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to Genbank reference file",
                                          DirectoryHelper.IsServerPath(txtReferencePath.Text), DirectoryHelper.CleanPath(path),
                                          "Genbank files (*.gb)|*.gb|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ServerOnly = true;
      Cursor.Current = Cursors.Default;
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtReferencePath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;

      EnableOK();
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

    private void txtThreads_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private void txtSNPCutoff_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private static void IsNumeric(KeyPressEventArgs e)
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

    private void txtReferencePath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtMetadataPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtSNPCutoff_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtClusterCutoff_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtMinLengthFilter_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtMaskFromBeginning_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtMaskFromEnd_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtMaskSites_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtRootNode_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtClusterCutoff_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private void txtMinLengthFilter_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private void txtMaskFromBeginning_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private void txtMaskFromEnd_KeyPress(object sender, KeyPressEventArgs e)
    {
      IsNumeric(e);
    }

    private void btnMetadata_Click(object sender, EventArgs e)
    {
      string filename = txtMetadataPath.Text.Trim();
      if (filename.Length == 0)
      {
        btnMetadata_Click(sender, e);
        return;
      }

      if (!DirectoryHelper.FileExists(filename))
      {
        MessageBox.Show(txtMetadataPath.Text.Trim() + " not found.", "ERROR", MessageBoxButtons.OK);
        return;
      }

      // If this file is on the server, copy it locally first.
      if (IsServiceClass.IsService && !filename.StartsWith("[L]"))
      {
        if (!filename.StartsWith("[S]"))
        {
          filename = "[S]" + filename;
        }
        DirectoryHelper.FileCopy(filename, "[L]C:\\Temp", true);
      }

      //Process p = Process.Start("excel.exe", DirectoryHelper.CleanPath(filename));
      Process p = Process.Start(DirectoryHelper.CleanPath(filename));
      p.WaitForExit();
      p.Close();

      if (IsServiceClass.IsService && filename.StartsWith("[S]")) // Copy back to server.
      {
        string nameOnly = Path.GetFileName(filename);
        DirectoryHelper.FileCopy("[L]C:\\Temp\\" + nameOnly, filename.Replace(nameOnly, string.Empty), true);
      }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      WSLProxyResponse WSLResponse = BioSeqDBModel.Instance.NextstrainReset(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
      Cursor.Current = Cursors.Default;

      if (WSLResponse.ExitCode == 0)
      {
        MessageBox.Show("Nextstrain reset complete.", "COMPLETE", MessageBoxButtons.OK);
      }
      else
      {
        MessageBox.Show("Nextstrain reset error " + WSLResponse.ExitCode.ToString() + Environment.NewLine +
                                              WSLResponse.StandardError + ".", "ERROR", MessageBoxButtons.OK);
      }
    }
  }
}