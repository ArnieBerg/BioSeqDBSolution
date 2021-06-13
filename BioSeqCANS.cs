using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqCANS : Form
  {
    // Perform CANS: Consensus calling for Amplicon Nanopore Sequencing from Nanopore data.

    public BioSeqCANS()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtReferencePath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CANSReferencePath);
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.CANSOutputPath);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.CANSThreads) ? "4" : AppConfigHelper.CANSThreads.ToString();
      chkTrim.Checked = AppConfigHelper.CANSChooseTrim;
      cmbModel.SelectedIndex = AppConfigHelper.CANSModel == "r10" ? 1 : 0;
      txtExpectedLength.Text = string.IsNullOrEmpty(AppConfigHelper.CANSExpectedLength) ? string.Empty : AppConfigHelper.CANSExpectedLength.ToString();
      txtTargetCoverage.Text = string.IsNullOrEmpty(AppConfigHelper.CANSTargetCoverage) ? string.Empty : AppConfigHelper.CANSTargetCoverage.ToString();
      txtReadLengthDeviation.Text = string.IsNullOrEmpty(AppConfigHelper.CANSReadLengthDeviation) ? string.Empty : AppConfigHelper.CANSReadLengthDeviation.ToString();

      ReloadSampleList();
      EnableOK();

      if (Size.Width != 0)
      {
        Location = AppConfigHelper.CANSLocation();
        if (Location.X <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.CANSSize();
        if (Size.Height <= 0 || Size.Width <= 0)
        {
          Size = new Size(1000, 1000);
        }
      }
    }

    private void ReloadSampleList()
    {
      lvSamples.Items.Clear();
      if (AppConfigHelper.CANSSampleList != null)
      {
        foreach (string item in AppConfigHelper.CANSSampleList.Keys)
        {
          ListViewItem lvItem = new ListViewItem(item);
          lvItem.SubItems.Add(AppConfigHelper.CANSSampleList[item].Substring(1));
          lvItem.Checked = AppConfigHelper.CANSSampleList[item].StartsWith("1");

          lvSamples.Items.Insert(lvSamples.Items.Count, lvItem);
        }
      }
      EnableOK();
    }

    private void EnableOK()
    {
      btnOK.Enabled = false;
      foreach (ListViewItem item in lvSamples.Items)
      {
        if (item.Checked)
        {
          btnOK.Enabled = true;
          break;
        }
      }

      if (btnOK.Enabled)
      {
        btnOK.Enabled = (txtExpectedLength.Text.Trim().Length > 0 && int.Parse(txtExpectedLength.Text.Trim()) > 0) && 
                            txtOutputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtReferencePath.Text.Trim()) && !DirectoryHelper.FileExists(txtReferencePath.Text.Trim()))
      {
        MessageBox.Show(txtReferencePath.Text + " does not exist. Choose a valid reference database path.", "Invalid reference database path", MessageBoxButtons.OK);
        txtReferencePath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (!DirectoryHelper.DirectoryExists(txtOutputPath.Text.Trim()))
      {
        MessageBox.Show(txtOutputPath.Text + " does not exist. Choose a valid output path.", "Invalid output path", MessageBoxButtons.OK);
        txtOutputPath.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      // Update config to reflect selection.
      foreach (ListViewItem item in lvSamples.Items)
      {
        foreach (string key in AppConfigHelper.CANSSampleList.Keys)
        {
          if (key == item.Text)
          {
            AppConfigHelper.CANSSampleList[key] = (item.Checked ? "1" : "0") + AppConfigHelper.CANSSampleList[key].Substring(1);
            break;
          }
        }
      }

      AppConfigHelper.CANSParms(txtReferencePath.Text.Trim(), txtOutputPath.Text.Trim(), txtMemo.Text.Trim(), chkTrim.Checked, txtThreads.Text.Trim(),
                                txtExpectedLength.Text.Trim(), txtReadLengthDeviation.Text.Trim(), txtTargetCoverage.Text.Trim(),
                                                                    cmbModel.SelectedIndex == 0 ? "r9" : "r10");
    }

    private void btnReferencePath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text); // We want the filename.
        if (path.EndsWith("\\"))
        {
          path = path.Substring(0, path.Length - 1);
        }

        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to reference database file",
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
        ofn.Description = "Path to reference database";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtReferencePath.Text);
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

    private void btnFastqPicker_Click(object sender, EventArgs e)
    {
      BioSeqInfluenzaAFastq frm = new BioSeqInfluenzaAFastq(AppConfigHelper.CANSSampleList, "CANS");
      if (frm.ShowDialog() == DialogResult.OK)
      {
        AppConfigHelper.CANSSampleList = frm.alreadySelected;
        ReloadSampleList();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem item in lvSamples.Items)
      {
        if (!item.Checked)
        {
          AppConfigHelper.CANSSampleList.Remove(item.Text);
        }
      }

      ReloadSampleList();
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

    private void txtReferencePath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
      foreach (ListViewItem item in lvSamples.Items)
      {
        item.Checked = chkAll.Checked;
      }
    }

    private void BioSeqCANS_FormClosing(object sender, FormClosingEventArgs e)
    {
      AppConfigHelper.SaveCANSUIForm(Location, Size);
    }
  }
}