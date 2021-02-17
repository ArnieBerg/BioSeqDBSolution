using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqAssemble : Form
  {
    // Prompt for parameters to do an assemble using NextFlow.

    public BioSeqAssemble()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      // Bring in defaults if they exist.

      chkFastPolish.Checked = AppConfigHelper.AssembleFastPolish();
      chkBBmap.Checked = AppConfigHelper.AssembleBBmap();
      chkKraken2.Checked = AppConfigHelper.AssembleKraken2();
      chkVFabricate.Checked = AppConfigHelper.AssembleVFabricate();
      chkQuast.Checked = AppConfigHelper.AssembleQuast();
      radFlye.Checked = AppConfigHelper.AssembleFlye();
      radRA.Checked = AppConfigHelper.AssembleRA();
      radTrinity.Checked = AppConfigHelper.AssembleTrinity();
      txtHostReference.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.AssembleHostReference);
      txtVirusReference.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.AssembleVirusReference);
      txtGeneXRef.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.AssembleVFGeneXRef);

      ReloadSampleList();
      EnableOK();
    }

    private void ReloadSampleList()
    {
      lstSamples.Items.Clear();
      List<string> list = (radFlye.Checked || radRA.Checked ? AppConfigHelper.AssembleQueryListRAFlye() : AppConfigHelper.AssembleQueryListTrinity());
      if (list != null)
      {
        foreach (string item in list)
        {
          int i = lstSamples.Items.Add(item.Substring(1));
          if (item.StartsWith("1"))
          {
            lstSamples.SetItemChecked(i, true);
          }
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (radTrinity.Checked && txtVirusReference.Text.Trim().Length == 0)
      {
        MessageBox.Show("A virus reference genome is required.", "Missing virus reference genome", MessageBoxButtons.OK);
        txtVirusReference.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      if (chkVFabricate.Checked && txtGeneXRef.Text.Trim().Length == 0)
      {
        MessageBox.Show("A gene cross-reference file is required.", "Missing gene cross-reference file", MessageBoxButtons.OK);
        txtGeneXRef.Focus();
        DialogResult = DialogResult.None;
        return;
      }

      // Build the configuration file to feed to the assembleRANF command.
      // Update config to reflect selection.
      List<string> querySamples = new List<string>();
      for (int i = 0; i < lstSamples.Items.Count; i++)
      {
        // Pass an indicator whether checked or not.
        querySamples.Add((lstSamples.GetItemChecked(i) ? "1" : "0") + lstSamples.Items[i].ToString());
      }

      string config = AppConfigHelper.QuerySampleConfig();
      if (lstSamples.Items.Count == 0 || config == "SampleName,SamplePath" + Environment.NewLine)
      {
        MessageBox.Show("No samples selected.", "ERROR", MessageBoxButtons.OK);
        DialogResult = DialogResult.None;
        return;
      }

      AppConfigHelper.AssembleHostReference = txtHostReference.Text.Trim();
      AppConfigHelper.AssembleVirusReference = txtVirusReference.Text.Trim();

      AppConfigHelper.AssembleSample(querySamples, chkFastPolish.Checked, radRA.Checked, radFlye.Checked, radTrinity.Checked,
                                     chkKraken2.Checked, chkBBmap.Checked, chkQuast.Checked, chkVFabricate.Checked, txtGeneXRef.Text.Trim(), txtMemo.Text.Trim());
    }

    private void EnableOK()
    {
      for (int i = 0; i < lstSamples.Items.Count; i++)
      {
        // Pass an indicator whether checked or not.
        if (lstSamples.GetItemChecked(i))
        {
          btnOK.Enabled = true;
          return;
        }
      }

      btnOK.Enabled = false;
    }

    private void lstSamples_SelectedValueChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnSamplePicker_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(radTrinity.Checked ? AppConfigHelper.AssembleLastQueryFolderTrinity : AppConfigHelper.AssembleLastQueryFolder);
      if (IsServiceClass.IsService)
      {
        path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(path)) + "\\"; // We want an actual file, so don't append "\\". No, we want folder.
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folders containing .fastq contig file(s)",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        while (Explorer.frmExplorer.ShowDialog() != DialogResult.Cancel)
        {
          path = AppConfigHelper.GetDirectoryName(Explorer.PresentServerPath + Explorer.PresentLocalPath + "\\"); // One of these is empty.
          bool ServerPath = string.IsNullOrEmpty(Explorer.PresentLocalPath);

          // Make sure the folders contain .fastq files.
          if (ValidFastqFiles(DirectoryHelper.CleanPath(path), ServerPath))
          {
            if (radTrinity.Checked)
            {
              AppConfigHelper.AssembleLastQueryFolderTrinity = path;
            }
            else
            {
              AppConfigHelper.AssembleLastQueryFolder = path;
            }
            break;
          }

          Explorer.frmExplorer = null;
          path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.NormalizePathToWindows(radTrinity.Checked ? 
                                    AppConfigHelper.AssembleLastQueryFolderTrinity : AppConfigHelper.AssembleLastQueryFolder))) + "\\"; // We want folder, so append "\\".
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folders containing .fastq contig file(s)",
                             DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                             "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        ofn.Title = "Input path to folders containing .fastq contig file(s)";
        ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(path);
        ofn.Filter = "Fastq files (*.fastq)|*.fastq|All files (*.*)|*.*";

        while (ofn.ShowDialog() != DialogResult.Cancel)
        {
          path = Path.GetDirectoryName(ofn.FileName.Trim());
          if (radTrinity.Checked)
          {
            AppConfigHelper.AssembleLastQueryFolderTrinity = path;
          }
          else
          {
            AppConfigHelper.AssembleLastQueryFolder = path;
          }

          // Make sure the folders contain .fastq files.
          if (ValidFastqFiles(path, false))
          {
            break;
          }
        }
      }
    }

    private bool ValidFastqFiles(string path, bool IsServerPath)
    {
      int fCount = ServiceCallHelper.TraverseTree(path, IsServerPath, "fastq");
      if (fCount == 0)
      {
        MessageBox.Show("There are no *.fastq files in the " + path + " folder.", "Wrong folder", MessageBoxButtons.OK);
        return false;
      }

      // Make sure it is not already in the list.
      List<string> querySamples = new List<string>();
      for (int i = 0; i < lstSamples.Items.Count; i++)
      {
        querySamples.Add(lstSamples.Items[i].ToString());
      }
      if (querySamples.Contains(path))
      {
        MessageBox.Show(path + " has already been selected.", "Duplicate selection", MessageBoxButtons.OK);
        return false;
      }

      lstSamples.SetItemChecked(lstSamples.Items.Add(path), true);
      EnableOK();
      return true;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      List<string> queryList = new List<string>();
      for (int i = 0; i < lstSamples.CheckedItems.Count; i++)
      {
        queryList.Add(lstSamples.Items[i].ToString());
      }
      lstSamples.Items.Clear();
      lstSamples.Items.AddRange(queryList.ToArray());

      for (int i = 0; i < lstSamples.Items.Count; i++)
      {
        lstSamples.SetItemChecked(i, true);
      }
    }

    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
      for (int i = 0; i < lstSamples.Items.Count; i++)
      {
        lstSamples.SetItemChecked(i, chkAll.Checked);
      }
    }

    private void radAssembler_CheckedChanged(object sender, EventArgs e)
    {
      ReloadSampleList();

      pnlBacterial.Enabled = grpViral.Enabled = chkFastPolish.Enabled = false;
      RadioButton rad = (RadioButton)sender;
      if (rad.Checked)
      {
        switch (rad.Name)
        {
          case "radRA":
          case "radFlye":
            pnlBacterial.Enabled = chkFastPolish.Enabled = true;
            break;

          case "radTrinity":
            grpViral.Enabled = true;
            break;
        }
      }
    }

    private void btnFindVirusReferenceGenome_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = string.Empty;
        if (DirectoryHelper.FileExists(AppConfigHelper.AssembleVirusReference))
        {
          path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.AssembleVirusReference)); // We want an actual file, so don't append "\\".
        }
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to virus reference genome file",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          AppConfigHelper.AssembleVirusReference = txtVirusReference.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        if (Directory.Exists(AppConfigHelper.AssembleVirusReference))
        {
          ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(AppConfigHelper.AssembleVirusReference);
        }
        ofn.Title = "Input path to virus reference genome file";
        ofn.CheckFileExists = true;
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          AppConfigHelper.AssembleVirusReference = txtVirusReference.Text = ofn.FileName;
        }
      }
    }

    private void btnFindHostReferenceGenome_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = string.Empty;
        if (!string.IsNullOrEmpty(AppConfigHelper.FileExists(AppConfigHelper.AssembleHostReference)))
        {
          path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.AssembleHostReference)); // We want an actual file, so don't append "\\".
        }
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to host reference genome file",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          AppConfigHelper.AssembleHostReference = txtHostReference.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        if (Directory.Exists(AppConfigHelper.AssembleHostReference))
        {
          ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(AppConfigHelper.AssembleHostReference);
        }
        ofn.Title = "Input path to host reference genome file";
        ofn.CheckFileExists = true;
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          AppConfigHelper.AssembleHostReference = txtHostReference.Text = ofn.FileName;
        }
      }
    }

    private void chkVFabricate_CheckedChanged(object sender, EventArgs e)
    {
      lblGeneXRef.Enabled = txtGeneXRef.Enabled = btnGeneXRef.Enabled = chkVFabricate.Checked;
    }

    private void btnGeneXRef_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = string.Empty;
        if (!string.IsNullOrEmpty(AppConfigHelper.FileExists(AppConfigHelper.AssembleVFGeneXRef)))
        {
          path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(AppConfigHelper.AssembleVFGeneXRef)); // We want an actual file, so don't append "\\".
        }
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to gene cross-reference file",
                                 DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          AppConfigHelper.AssembleVFGeneXRef = txtHostReference.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        if (Directory.Exists(AppConfigHelper.AssembleVFGeneXRef))
        {
          ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(AppConfigHelper.AssembleVFGeneXRef);
        }
        ofn.Title = "Input path to gene cross-reference file";
        ofn.CheckFileExists = true;
        ofn.Filter = "All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          AppConfigHelper.AssembleVFGeneXRef = txtGeneXRef.Text = ofn.FileName;
        }
      }
    }
  }
}