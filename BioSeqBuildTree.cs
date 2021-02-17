using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using BioSeqDB.ModelClient;
using FSExplorer;

namespace BioSeqDB
{
  public partial class BioSeqBuildTree : Form
  {
    // Do a build_tree analysis for the selected database.

    public BioSeqBuildTree()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      // Bring in defaults if they exist.
      txtWildReference.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.BuildTreeWildReference());
      txtDomesticReference.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.BuildTreeDomesticReference);
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.BuildTreeOutputPath());
      //txtCutoff.Text = AppConfigHelper.BuildTreeHits;
      txtThreads.Text = AppConfigHelper.BuildTreeThreads();

      //radWildReference.CheckedChanged -= radWildReference_CheckedChanged;
      //radDomesticReference.CheckedChanged -= radDomesticReference_CheckedChanged;
      radDomesticReference.Checked = AppConfigHelper.BuildTreeChooseDomestic;
      radWildReference.Checked = !AppConfigHelper.BuildTreeChooseDomestic;

      if (txtDomesticReference.Text.Trim().Length > 0 && txtDomesticReference.Text.Trim() == txtWildReference.Text.Trim())
      {
        txtWildReference.Text = string.Empty;
        radDomesticReference.Checked = true;
        radWildReference.Checked = false;
      }

      if (txtDomesticReference.Text.Trim().Length == 0) // The only way to select a domestic reference is if there is one before we came in here.
      {
        txtDomesticReference.Enabled = radDomesticReference.Enabled = false;
      }

      chkFastTree.Checked = AppConfigHelper.BuildTreeFastTree();
      if (AppConfigHelper.BuildTreeQueryList() != null)
      {
        foreach (string item in AppConfigHelper.BuildTreeQueryList())
        {
          int i = lstQueryGenomes.Items.Add(DirectoryHelper.UnCleanPath(item.Substring(1)));
          if (item.StartsWith("1"))
          {
            lstQueryGenomes.SetItemChecked(i, true);
          }
        }
      }

      switch (AppConfigHelper.BuildTreeLinkage)
      {
        case 0:
          radThreshold.Checked = true;
          break;
        case 1:
          radTophits.Checked = true;
          break;
        case 2:
          radCluster.Checked = true;
          break;
      }
      EnableOK();
    }

    private void btnFindOutputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(txtOutputPath.Text + "\\"));
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Output path",
                                            DirectoryHelper.IsServerPath(txtOutputPath.Text), DirectoryHelper.CleanPath(path), 
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtOutputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
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
    }

    private void btnFindReferencePath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(txtWildReference.Text)); // We want an actual file, so don't append "\\".
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to reference genome file",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path), 
                                 "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtWildReference.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
          radWildReference.Checked = true;
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        string path = AppConfigHelper.NormalizePathToWindows(txtWildReference.Text);
        if (File.Exists(path))
        {
          ofn.InitialDirectory = ofn.FileName = AppConfigHelper.FileExists(path);
        }
        ofn.Title = "Input path to reference genome file";
        ofn.CheckFileExists = true;
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtWildReference.Text = ofn.FileName.Trim();
          radWildReference.Checked = true;
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (radTophits.Checked && !float.TryParse(txtCutoff.Text, out float hits))
      {
        MessageBox.Show("Cutoff for number of hits is required.", "Missing number of hits", MessageBoxButtons.OK);
        txtCutoff.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (radThreshold.Checked && !float.TryParse(txtCutoff.Text, out float threshold))
      {
        MessageBox.Show("Threshold distance is required.", "Missing distance", MessageBoxButtons.OK);
        txtCutoff.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (radWildReference.Checked && !DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtWildReference.Text)))
      {
        MessageBox.Show(txtWildReference.Text + " does not exist. Choose a valid reference genome file.", "Invalid reference genome file", MessageBoxButtons.OK);
        txtWildReference.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (radDomesticReference.Checked && !DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtDomesticReference.Text)))
      {
        MessageBox.Show(txtWildReference.Text + " does not exist. Choose a valid standard reference genome file.", "Invalid standard reference genome file", MessageBoxButtons.OK);
        txtWildReference.Focus();
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

      if (chkMakeStandard.Checked && txtDomesticReference.Text.Trim() != txtWildReference.Text.Trim())
      {
        AppConfigHelper.BuildTreeDomesticReference = txtDomesticReference.Text =
                                        AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.CurrentDBPath())) +
                                       "\\" + Path.GetFileName(AppConfigHelper.NormalizePathToWindows(txtWildReference.Text.Trim()));

        // Also copy the wild to the database folder so it can be used in the future.
        DirectoryHelper.FileCopy(txtWildReference.Text.Trim(), AppConfigHelper.BuildTreeDomesticReference, true);
      }

      AppConfigHelper.BuildTreeChooseDomestic = radDomesticReference.Checked;

      // Update config to reflect selection.
      List<string> queryGenomes = new List<string>();
      for (int i = 0; i < lstQueryGenomes.Items.Count; i++)
      {
        // Pass an indicator whether checked or not.
        queryGenomes.Add((lstQueryGenomes.GetItemChecked(i) ? "1" : "0") + lstQueryGenomes.Items[i].ToString());
      }
      AppConfigHelper.BuildTreeSample(txtOutputPath.Text, txtWildReference.Text, txtDomesticReference.Text, radDomesticReference.Checked,
                                                   txtCutoff.Text, txtThreads.Text, queryGenomes, chkFastTree.Checked, txtMemo.Text.Trim());
    }

    private void txtCutoff_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != (Char)Keys.Delete) || (radTophits.Checked ? e.KeyChar == '.' : false);  // Numerics only  isNumeric
    }

    private void txtThreads_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void txtSampleID_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtCutoff_TextChanged(object sender, EventArgs e)
    {
      if (radThreshold.Checked)
      {
        AppConfigHelper.BuildTreeThreshold = txtCutoff.Text.Trim().ToString();
      }
      else if (radTophits.Checked)
      {
        AppConfigHelper.BuildTreeHits = txtCutoff.Text.Trim().ToString();
      }

      EnableOK();
    }

    private void txtThreads_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtOutputPath.Text.Trim().Length > 0 && ((txtWildReference.Text.Trim().Length > 0 && radWildReference.Checked) ||
                              (txtDomesticReference.Text.Trim().Length > 0 && !radWildReference.Checked)) &&
                            lstQueryGenomes.CheckedIndices.Count > 0 && txtThreads.Text.Trim().Length > 0 &&
                            (txtCutoff.Text.Trim().Length > 0 || radCluster.Checked);
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtInputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void lstQueryGenomes_SelectedValueChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnGenomePicker_Click(object sender, EventArgs e)
    {
      // Need to be able to multi-select.
      DialogResult result;
      List<string> filenames = null;

      if (IsServiceClass.IsService)
      {
        string path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.BuildTreeLastQueryFolder));

        List<string> genomeList = new List<string>();
        for (int i = 0; i < lstQueryGenomes.Items.Count; i++)
        {
          genomeList.Add(Path.GetFileName(DirectoryHelper.CleanPath(lstQueryGenomes.Items[i].ToString())));
        }

        // We want an actual file, so don't append "\\".
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to query genome file",
                            DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path), 
                            "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", genomeList, AppConfigHelper.UbuntuPrefix());
        result = Explorer.frmExplorer.ShowDialog();
        if (result != DialogResult.Cancel)
        {
          filenames = Explorer.FileNames;
          AppConfigHelper.BuildTreeLastQueryFolder = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        if (Directory.Exists(AppConfigHelper.BuildTreeLastQueryFolder))
        {
          ofn.InitialDirectory = ofn.FileName = AppConfigHelper.FileExists(AppConfigHelper.BuildTreeLastQueryFolder);
        }
        ofn.Title = "Input path to query genome file(s)";
        ofn.CheckFileExists = true;
        ofn.Multiselect = true;
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*";

        result = ofn.ShowDialog();
        if (result != DialogResult.Cancel)
        {
          filenames = ofn.FileNames.ToList();
          AppConfigHelper.BuildTreeLastQueryFolder = ofn.FileName.Substring(0, ofn.FileName.LastIndexOf("\\"));
        }
      }

      if (result != DialogResult.Cancel)
      {
        if (filenames != null && filenames.Count > 0)
        {
          List<string> queryList = new List<string>();
          for (int i = 0; i < lstQueryGenomes.Items.Count; i++)
          {
            queryList.Add(lstQueryGenomes.Items[i].ToString());
          }

          foreach (string filename in filenames)
          {
            // Combine the filename with the path.
            string fullname = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.BuildTreeLastQueryFolder)) + "\\" + filename;
            if (queryList.Contains(fullname))
            {
              for (int j = 0; j < lstQueryGenomes.Items.Count; j++)
              {
                if (lstQueryGenomes.Items[j].ToString() == fullname)
                {
                  lstQueryGenomes.SetItemChecked(j, true);
                  break;
                }
              }
            }
            else
            {
              lstQueryGenomes.SetItemChecked(lstQueryGenomes.Items.Add(fullname), true);
            }
          }
        }
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      List<string> queryList = new List<string>();
      for (int i = 0; i < lstQueryGenomes.CheckedItems.Count; i++)
      {
        queryList.Add(lstQueryGenomes.Items[i].ToString());
      }
      lstQueryGenomes.Items.Clear();
      lstQueryGenomes.Items.AddRange(queryList.ToArray());

      for (int i = 0; i < lstQueryGenomes.Items.Count; i++)
      {
        lstQueryGenomes.SetItemChecked(i, true);
      }
    }

    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
      for (int i = 0; i < lstQueryGenomes.Items.Count; i++)
      {
        lstQueryGenomes.SetItemChecked(i, chkAll.Checked);
      }
    }

    private void radThreshold_CheckedChanged(object sender, EventArgs e)
    {
      txtCutoff.Enabled = lblCutoff.Enabled = true;
      lblCutoff.Text = "Distance threshold [Default: .001]";
      txtCutoff.Text = AppConfigHelper.BuildTreeThreshold;
      AppConfigHelper.BuildTreeLinkage = 0;
    }

    private void radTophits_CheckedChanged(object sender, EventArgs e)
    {
      txtCutoff.Enabled = lblCutoff.Enabled = true;
      lblCutoff.Text = "Distance threshold [Default: 25]";
      txtCutoff.Text = AppConfigHelper.BuildTreeHits;
      AppConfigHelper.BuildTreeLinkage = 1;
    }

    private void radCluster_CheckedChanged(object sender, EventArgs e)
    {
      txtCutoff.Enabled = lblCutoff.Enabled = false;
      txtCutoff.Text = string.Empty;
      lblCutoff.Text = "(no cutoff)";
      AppConfigHelper.BuildTreeLinkage = 2;
    }
  }
}