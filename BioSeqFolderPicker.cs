using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqFolderPicker : Form
  {
    public Dictionary<string, string> items; // Folders selected in this run.
    public Dictionary<string, string> alreadySelected; // This is a list of those that have already been selected.
    private bool IsSalmonella;
    private bool IsInfluenzaA;
    private bool IsBackup;
    private bool IsCANS;
    private string currentSampleSelection = null;

    // Prompt for a Influenza A fastq sample for pipeline to analyze. Or Salmonella.

    public BioSeqFolderPicker(Dictionary<string, string> itemsSelected, string functionUsage)  // functionUsage is "Salmonella" or "Influenza A". Or "CANS". Or "Priority Backup".
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
      IsInfluenzaA = functionUsage == "Influenza A";
      IsBackup = functionUsage == "Priority Backup";
      IsCANS = functionUsage == "CANS";
      Text = Text.Replace("<analysis>", functionUsage);
      label4.Text = label4.Text.Replace("<analysis>", functionUsage);
      label2.Text = label2.Text.Replace("<analysis>", functionUsage);
      if (alreadySelected.Count > 0)
      {
        foreach (string key in alreadySelected.Keys)
        {
          currentSampleSelection = key; // Choose the last sample in those already selected.
        }
      }
      ReloadFolderList();
    }

    private void ReloadFolderList()
    {
      lvFolders.Items.Clear();
      foreach (string item in alreadySelected.Keys)
      {
        ListViewItem lvItem = new ListViewItem(item);
        lvItem.SubItems.Add(alreadySelected[item].Substring(1));

        lvFolders.Items.Insert(lvFolders.Items.Count, lvItem);
      }

      foreach (string item in items.Keys)
      {
        ListViewItem lvItem = new ListViewItem(item);
        lvItem.SubItems.Add(items[item]);

        lvFolders.Items.Insert(lvFolders.Items.Count, lvItem);
      }
      for (int i = 0; i < lvFolders.Items.Count; i++)
      {
        if (lvFolders.Items[i].Text == currentSampleSelection)
        {
          lvFolders.Items[i].Focused = true;
          lvFolders.Items[i].Selected = true;
          lvFolders.Items[i].EnsureVisible();

          lvFolders.Select();
          break;
        }
      }
      EnableOK();
    }

    private void EnableOK()
    {
      btnOK.Enabled = true;

      foreach (ListViewItem item in lvFolders.Items) // Make sure all the samples have IDs.
      {
        if (string.IsNullOrEmpty(item.Text))
        {
          btnOK.Enabled = false;
          break;
        }
      }
    }

    private void btnFindFolder_Click(object sender, EventArgs e)
    {
      DialogResult result;
      List<string> folderList = new List<string>();
      items = new Dictionary<string, string>(); // Start from square one with items in this batch.

      string title = "Input path to folder containing sample fastq files";
      string extensions = "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*";
      string folderPath = AppConfigHelper.InfluenzaASamplesPath;
      if (IsSalmonella)
      {
        folderPath = AppConfigHelper.SalmonellaSamplesPath;
      }
      if (IsCANS)
      {
        folderPath = AppConfigHelper.CANSSamplesPath;
      }
      if (IsBackup)
      {
        folderPath = AppConfigHelper.BackupFoldersPath;
        title = "Input path to folder containing files to backup";
        extensions = "All files (*.*)|*.*";
      }
      folderPath = AppConfigHelper.NormalizePathToWindows(folderPath);

      // We want an actual file, so don't append "\\".
      // Jan-8-2021 No, we want a folder with fastq files in it.
      if (string.IsNullOrEmpty(folderPath))
      {
        folderPath = "C:";
      }
      if (!folderPath.EndsWith("\\"))
      {
        folderPath += "\\";
      }
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), title, DirectoryHelper.IsServerPath(folderPath), 
                                                     DirectoryHelper.CleanPath(folderPath), extensions, folderList, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ServerOnly = true;
      result = Explorer.frmExplorer.ShowDialog();
      if (result != DialogResult.Cancel)
      {
        folderList = Explorer.FileNames;
        folderPath = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }

      if (result != DialogResult.Cancel)
      {
        folderPath = folderPath.Substring(0, folderPath.LastIndexOf("\\") + 1);

        // If the selection already exists, boot it out.
        string fastqClause = IsBackup ? "" : " or having no .fastq files";
        string msg = "Folders already selected" + fastqClause + " (will be ignored): " + Environment.NewLine;
        bool isSelected = false;
        if (folderList.Count == 0)
        {
          foreach (string key in alreadySelected.Keys)
          {
            if (alreadySelected[key].Substring(1) == folderPath)
            {
              isSelected = true;
              msg += folderPath + Environment.NewLine;
              break;
            }
          }

          if (!isSelected && !IsBackup)
          {
            int fCount = ServiceCallHelper.TraverseTree(DirectoryHelper.CleanPath(folderPath), true, "fastq");
            if (fCount == 0)
            {
              isSelected = true;
              msg += folderPath + Environment.NewLine;
            }
          }

          if (!isSelected)
          {
            string path = folderPath.Substring(0, folderPath.Length - 1);
            path = path.Substring(path.LastIndexOf("\\") + 1);
            //samplePath = samplePath.Substring(0, samplePath.Length - 1 - path.Length); // Chop off last folder name.
            currentSampleSelection = path;
            items.Add(path, folderPath);
          }
        }
        else
        {
          foreach (string folder in folderList)
          {
            isSelected = false;
            foreach (string key in alreadySelected.Keys)
            {
              if (Path.GetDirectoryName(alreadySelected[key].Substring(1)) == Path.GetDirectoryName(folderPath + folder + "\\"))
              {
                isSelected = true;
                msg += folderPath + folder + Environment.NewLine;
                break;
              }
            }

            if (!isSelected && !IsBackup)
            {
              int fCount = ServiceCallHelper.TraverseTree(DirectoryHelper.CleanPath(folderPath + folder), true, "fastq");
              if (fCount == 0)
              {
                isSelected = true;
                msg += folderPath + folder + Environment.NewLine;
              }
            }

            if (!isSelected)
            {
              currentSampleSelection = folder;
              items.Add(folder, folderPath + folder);
            }
          }
        }

        if (msg.Length > 72)
        {
          MessageBox.Show(msg, "WARNING", MessageBoxButtons.OK);
        }
        ReloadFolderList();

        if (IsSalmonella)
        {
          AppConfigHelper.SalmonellaSamplesPath = folderPath;
        }
        else if (IsInfluenzaA)
        {
          AppConfigHelper.InfluenzaASamplesPath = folderPath;
        }
        else if (IsBackup)
        {
          AppConfigHelper.BackupFoldersPath = folderPath;
        }
        else if (IsCANS)
        {
          AppConfigHelper.CANSSamplesPath = folderPath;
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // If the sample ID already exists, prompt to replace.
      foreach (string sample in items.Keys)
      {
        if (alreadySelected.ContainsKey(sample))
        {
          ReplacePrompt.MainInstruction = "A folder for " + sample + " already exists in the database. Do you want to replace it?";
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

    private void BioSeqFolderPicker_Shown(object sender, EventArgs e)
    {
      btnFindFolder_Click(sender, e); // Immediately go into Explorer to find fastq folder(s).
    }

    private void lvSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lvFolders.SelectedItems != null && lvFolders.SelectedItems.Count > 0)
      {
        ListViewItem item = lvFolders.SelectedItems[0];
        btnUpdate.Enabled = btnDelete.Enabled = true;
        if (alreadySelected.ContainsKey(item.Text))
        {
          btnUpdate.Enabled = btnDelete.Enabled = false;
        }
        txtSampleID.Text = item.Text;
        lblPath.Text = item.SubItems[1].Text;
        currentSampleSelection = txtSampleID.Text;
      }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (txtSampleID.Text.Trim().Length > 0 && txtSampleID.Text.Trim() != lvFolders.SelectedItems[0].Text)
      {
        items.Remove(lvFolders.SelectedItems[0].Text);
        currentSampleSelection = txtSampleID.Text;
        items.Add(currentSampleSelection, lblPath.Text);
        ReloadFolderList();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (txtSampleID.Text.Trim().Length > 0 && txtSampleID.Text.Trim() == lvFolders.SelectedItems[0].Text)
      {
        items.Remove(lvFolders.SelectedItems[0].Text);
        txtSampleID.Text = lblPath.Text = currentSampleSelection = string.Empty;
        ReloadFolderList();
      }
    }
  }
}