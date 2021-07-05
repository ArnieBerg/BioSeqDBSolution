using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqSalmonella : Form
  {
    // Perform Salmonella analysis from Nanopore data using Centrifuge database.

    public BioSeqSalmonella()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.SalmonellaOutputPath);
      txtThreads.Text = string.IsNullOrEmpty(AppConfigHelper.SalmonellaThreads) ? "4" : AppConfigHelper.SalmonellaThreads.ToString();
      chkTrim.Checked = AppConfigHelper.SalmonellaChooseTrim;
      ReloadSampleList();
      EnableOK();
    }

    private void ReloadSampleList()
    {
      lvSamples.Items.Clear();
      if (AppConfigHelper.SalmonellaSamplesList != null)
      {
        foreach (string item in AppConfigHelper.SalmonellaSamplesList.Keys)
        {
          ListViewItem lvItem = new ListViewItem(item);
          lvItem.SubItems.Add(AppConfigHelper.SalmonellaSamplesList[item].Substring(1));
          lvItem.Checked = AppConfigHelper.SalmonellaSamplesList[item].StartsWith("1");

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
        btnOK.Enabled = txtOutputPath.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0;
      }
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

      // Update config to reflect selection.

      foreach (ListViewItem item in lvSamples.Items)
      {
        foreach (string key in AppConfigHelper.SalmonellaSamplesList.Keys)
        {
          if (key == item.Text)
          {
            AppConfigHelper.SalmonellaSamplesList[key] = (item.Checked ? "1" : "0") + AppConfigHelper.SalmonellaSamplesList[key].Substring(1);
            break;
          }
        }
      }

      AppConfigHelper.SalmonellaParms(txtOutputPath.Text.Trim(), txtMemo.Text.Trim(), chkTrim.Checked, txtThreads.Text);
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

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
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

    private void btnFastqPicker_Click(object sender, EventArgs e)
    {
      // Overload the lookup form used for Influenza A.
      BioSeqFolderPicker frm = new BioSeqFolderPicker(AppConfigHelper.SalmonellaSamplesList, "Salmonella");
      if (frm.ShowDialog() == DialogResult.OK)
      {
        AppConfigHelper.SalmonellaSamplesList = frm.alreadySelected;
        ReloadSampleList();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem item in lvSamples.Items)
      {
        if (!item.Checked)
        {
          AppConfigHelper.SalmonellaSamplesList.Remove(item.Text);
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
  }
}
