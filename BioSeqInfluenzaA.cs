using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqInfluenzaA : Form
  {
    // Perform Influenza A analysis from Nanopore data using Centrifuge database.

    public BioSeqInfluenzaA()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtCentrifugePath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.InfluenzaACentrifugePath);
      lblCentrifugeDBName.Text = GetCentrifugeDBName();
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.InfluenzaAOutputPath);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.InfluenzaAThreads) ? "4" : AppConfigHelper.InfluenzaAThreads.ToString();
      chkTrim.Checked = AppConfigHelper.InfluenzaAChooseTrim;
      ReloadSampleList();
      EnableOK();
    }

    private void ReloadSampleList()
    {
      lvSamples.Items.Clear();
      if (AppConfigHelper.InfluenzaASamplesList != null)
      {
        foreach (string item in AppConfigHelper.InfluenzaASamplesList.Keys)
        {
          ListViewItem lvItem = new ListViewItem(item);
          lvItem.SubItems.Add(AppConfigHelper.InfluenzaASamplesList[item].Substring(1));
          lvItem.Checked = AppConfigHelper.InfluenzaASamplesList[item].StartsWith("1");

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
        btnOK.Enabled = txtCentrifugePath.Text.Trim().Length > 0 && txtOutputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
      }
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

      // Update config to reflect selection.
      foreach (ListViewItem item in lvSamples.Items)
      {
        foreach (string key in AppConfigHelper.InfluenzaASamplesList.Keys)
        {
          if (key == item.Text)
          {
            AppConfigHelper.InfluenzaASamplesList[key] = (item.Checked ? "1" : "0") + AppConfigHelper.InfluenzaASamplesList[key].Substring(1);
            break;
          }
        }
      }

      AppConfigHelper.InfluenzaAParms(txtCentrifugePath.Text.Trim(), txtOutputPath.Text.Trim(), txtMemo.Text.Trim(), chkTrim.Checked, txtThreads.Text);
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

    private void btnFastqPicker_Click(object sender, EventArgs e)
    {
      BioSeqInfluenzaAFastq frm = new BioSeqInfluenzaAFastq(AppConfigHelper.InfluenzaASamplesList, "Influenza A");
      if (frm.ShowDialog() == DialogResult.OK)
      {
        AppConfigHelper.InfluenzaASamplesList = frm.alreadySelected;
        ReloadSampleList();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem item in lvSamples.Items)
      {
        if (!item.Checked)
        {
          AppConfigHelper.InfluenzaASamplesList.Remove(item.Text);
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

    private void txtCentrifugePath_TextChanged(object sender, EventArgs e)
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
  }
}
