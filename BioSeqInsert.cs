using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqInsert : Form
  {
    private ListBox.ObjectCollection items;

    // Insert a sample into the selected database.

    public BioSeqInsert(ListBox.ObjectCollection items)
    {
      this.items = items;
      InitializeComponent();
      btnOK.Enabled = false;
      txtSampleID.Text = AppConfigHelper.InsertSampleID();
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.InsertInputPath());
      txtCaseNumber.Text = AppConfigHelper.InsertCaseNumber();
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtSampleID.Text.Trim().Length > 0 && txtInputPath.Text.Trim().Length > 0;
    }

    private void txtDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtInputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = txtInputPath.Text;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder with .fasta contig file",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtInputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text);
        ofn.InitialDirectory = path;
        ofn.Title = "Input path to folder with .fasta contig file";
        ofn.CheckFileExists = true;
        ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(path);
        ofn.Filter = "Fasta files (*.fasta)|*.fasta";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtInputPath.Text = ofn.FileName.Trim();
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      bool replace = true;

      // Make sure if any LIMS field is set that all are set.
      if (!((txtCaseNumber.Text.Trim().Length > 0 && txtLIMSTestID.Text.Trim().Length > 0 && txtLIMSSampleID.Text.Trim().Length > 0) ||
          (txtCaseNumber.Text.Trim().Length == 0 && txtLIMSTestID.Text.Trim().Length == 0 && txtLIMSSampleID.Text.Trim().Length == 0)))
      {
        LIMSDialog.ShowDialog(this);
        DialogResult = DialogResult.None;
        return;
      }

      // Does case sample already exist? For what sample ID?
      string duplicateMsg = AppConfigHelper.LIMSDuplicate(txtCaseNumber.Text.Trim(), txtLIMSTestID.Text.Trim(), txtLIMSSampleID.Text.Trim());
      // If no duplicate, duplicateMsg comes back blank. Otherwise it has the warning message.

      if (duplicateMsg.Length > 0)
      {
        LIMSDuplicatePrompt.MainInstruction = duplicateMsg;
        TaskDialogButton button = LIMSDuplicatePrompt.ShowDialog(this);
        if (button == btnReplaceCancel)
        {
          DialogResult = DialogResult.None;
          return;
        }
      }

      // If the sample ID is already exists, prompt to replace.
      if (SampleListContains(txtSampleID.Text.Trim()))
      {
        ReplacePrompt.MainInstruction = "At least one contig for " + txtSampleID.Text.Trim() + " already exists in the database. Do you want to replace it?";
        TaskDialogButton button = ReplacePrompt.ShowDialog(this);
        if (button == btnReplaceCancel)
        {
          DialogResult = DialogResult.None;
          return;
        }
      }
      else // Go ahead without prompting.
      {
        replace = false;
      }

      AppConfigHelper.InsertSample(txtCaseNumber.Text.Trim(), txtLIMSTestID.Text.Trim(), txtLIMSSampleID.Text.Trim(), 
                                                            txtInputPath.Text.Trim(), txtSampleID.Text.Trim(), replace);
    }

    private bool SampleListContains(string sampleID)
    {
      for (int i = 0; i < items.Count; i++)
      {
        string item = items[i].ToString() + "|";
        item = item.Substring(0, item.IndexOf("|"));
        if (sampleID == item)
        {
          return true;
        }
      }
      return false;
    }

    private void txtCaseNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.KeyChar = (e.KeyChar.ToString().ToUpper())[0];
    }

    private void txtLIMSTestID_KeyPress(object sender, KeyPressEventArgs e)
    {
      OnlyNumeric(e);
    }

    private void txtLIMSSampleID_KeyPress(object sender, KeyPressEventArgs e)
    {
      OnlyNumeric(e);
    }

    private static void OnlyNumeric(KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
         e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtCaseNumber.Text = txtLIMSSampleID.Text = txtLIMSTestID.Text = string.Empty;
    }
  }
}