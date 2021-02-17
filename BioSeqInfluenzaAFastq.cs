using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqInfluenzaAFastq : Form
  {
    public Dictionary<string, string> items; // Folders selected in this run.
    public Dictionary<string, string> alreadySelected; // This is a list of those that have already been selected.
    private bool IsSalmonella;

    // Prompt for a Influenza A fastq sample for pipeline to analyze. Or Salmonella.

    public BioSeqInfluenzaAFastq(Dictionary<string, string> itemsSelected, string functionUsage)  // functionUsage is "Salmonella" or "Influenza A".
    {
      InitializeComponent();

      alreadySelected = itemsSelected;
      if (alreadySelected == null)
      {
        alreadySelected = new Dictionary<string, string>();
      }

      items = new Dictionary<string, string>();

      btnOK.Enabled = false;
      IsSalmonella = functionUsage == "Salmonella";
      Text = Text.Replace("<analysis>", functionUsage);
      label4.Text = label4.Text.Replace("<analysis>", functionUsage);
      label2.Text = label2.Text.Replace("<analysis>", functionUsage);
    }

    private void ReloadSampleList()
    {
      lvSamples.Items.Clear();
      foreach (string item in items.Keys)
      {
        ListViewItem lvItem = new ListViewItem(item);
        lvItem.SubItems.Add(items[item]);

        lvSamples.Items.Insert(lvSamples.Items.Count, lvItem);
      }
      EnableOK();
    }

    private void EnableOK()
    {
      btnOK.Enabled = true;

      foreach (ListViewItem item in lvSamples.Items) // Make sure all the samples have IDs.
      {
        if (string.IsNullOrEmpty(item.Text))
        {
          btnOK.Enabled = false;
          break;
        }
      }
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      DialogResult result;
      string samplePath = string.Empty;
      List<string> folderList = new List<string>();
      items = new Dictionary<string, string>(); // Start from square one with items in this batch.

      if (IsServiceClass.IsService)
      {
        string path = IsSalmonella ? AppConfigHelper.NormalizePathToWindows(AppConfigHelper.SalmonellaSamplesPath) :
                                     AppConfigHelper.NormalizePathToWindows(AppConfigHelper.InfluenzaASamplesPath);

        // We want an actual file, so don't append "\\".
        // Jan-8-2021 No, we want a folder with fastq files in it.
        path += "\\";
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder containing sample fastq files",
                            DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                            "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*", folderList, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ServerOnly = true;
        result = Explorer.frmExplorer.ShowDialog();
        if (result != DialogResult.Cancel)
        {
          folderList = Explorer.FileNames;
          samplePath = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        if (IsSalmonella ? Directory.Exists(AppConfigHelper.SalmonellaSamplesPath) : Directory.Exists(AppConfigHelper.InfluenzaASamplesPath))
        {
          ofn.InitialDirectory = ofn.FileName = IsSalmonella ? AppConfigHelper.FileExists(AppConfigHelper.SalmonellaSamplesPath) :
                                                               AppConfigHelper.FileExists(AppConfigHelper.InfluenzaASamplesPath);
        }
        ofn.Title = "Input path to folder containing sample fastq files";
        ofn.CheckFileExists = true;
        ofn.Multiselect = false;
        ofn.Filter = "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*";

        result = ofn.ShowDialog();
        samplePath = ofn.FileName;
      }

      if (result != DialogResult.Cancel)
      {
        samplePath = samplePath.Substring(0, samplePath.LastIndexOf("\\") + 1); // Chop off last folder name.

        // If the selection already exists, boot it out.
        string msg = "Folders already selected or having no .fastq files (will be ignored): " + Environment.NewLine;
        bool isSelected = false;
        if (folderList.Count == 0)
        {
          foreach (string key in alreadySelected.Keys)
          {
            if (alreadySelected[key].Substring(1) == samplePath)
            {
              isSelected = true;
              msg += samplePath + Environment.NewLine;
              break;
            }
          }

          if (!isSelected)
          {
            int fCount = ServiceCallHelper.TraverseTree(DirectoryHelper.CleanPath(samplePath), true, "fastq");
            if (fCount == 0)
            {
              isSelected = true;
              msg += samplePath + Environment.NewLine;
            }
          }

          if (!isSelected)
          {
            string path = samplePath.Substring(0, samplePath.Length - 1);
            path = path.Substring(path.LastIndexOf("\\") + 1);
            samplePath = samplePath.Substring(0, samplePath.Length - 2 + path.Length); // Chop off last folder name.
            items.Add(path, samplePath);
          }
        }
        else
        {
          foreach (string folder in folderList)
          {
            isSelected = false;
            foreach (string key in alreadySelected.Keys)
            {
              if (Path.GetDirectoryName(alreadySelected[key].Substring(1)) == Path.GetDirectoryName(samplePath + folder + "\\"))
              {
                isSelected = true;
                msg += samplePath + folder + Environment.NewLine;
                break;
              }
            }

            if (!isSelected)
            {
              int fCount = ServiceCallHelper.TraverseTree(DirectoryHelper.CleanPath(samplePath + folder), true, "fastq");
              if (fCount == 0)
              {
                isSelected = true;
                msg += samplePath + folder + Environment.NewLine;
              }
            }

            if (!isSelected)
            {
              items.Add(folder, samplePath + folder);
            }
          }
        }

        if (msg.Length > 72)
        {
          MessageBox.Show(msg, "WARNING", MessageBoxButtons.OK);
        }
        ReloadSampleList();

        if (IsSalmonella)
        {
          AppConfigHelper.SalmonellaSamplesPath = samplePath;
        }
        else
        {
          AppConfigHelper.InfluenzaASamplesPath = samplePath;
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // If the sample ID is already exists, prompt to replace.
      foreach (string sample in items.Keys)
      {
        if (alreadySelected.ContainsKey(sample))
        {
          ReplacePrompt.MainInstruction = "A sample for " + sample + " already exists in the database. Do you want to replace it?";
          TaskDialogButton button = ReplacePrompt.ShowDialog(this);
          if (button == btnReplaceCancel)
          {
            DialogResult = DialogResult.None;
            return;
          }

          alreadySelected[sample] = "1" + items[sample];
        }
        else
        {
          alreadySelected.Add(sample, "1" + items[sample]);
        }
      }
    }

    private void BioSeqInfluenzaAFastq_Shown(object sender, EventArgs e)
    {
      btnFindInputPath_Click(sender, e); // Immediately go into Explorer to find fastq folder(s).
    }

    private void lvSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lvSamples.SelectedItems != null && lvSamples.SelectedItems.Count > 0)
      {
        txtSampleID.Text = lvSamples.SelectedItems[0].Text;
        lblPath.Text = lvSamples.SelectedItems[0].SubItems[1].Text;
      }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (txtSampleID.Text.Trim().Length > 0 && txtSampleID.Text.Trim() != lvSamples.SelectedItems[0].Text)
      {
        items.Remove(lvSamples.SelectedItems[0].Text);
        items.Add(txtSampleID.Text, lblPath.Text);
        ReloadSampleList();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (txtSampleID.Text.Trim().Length > 0 && txtSampleID.Text.Trim() == lvSamples.SelectedItems[0].Text)
      {
        items.Remove(lvSamples.SelectedItems[0].Text);
        txtSampleID.Text = lblPath.Text = string.Empty;
        ReloadSampleList();
      }
    }
  }
}