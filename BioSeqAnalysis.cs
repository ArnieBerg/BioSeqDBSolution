using BioSeqDB.ModelClient;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqAnalysis : Form
  {
    private string analysis;

    public BioSeqAnalysis(string Analysis, List<string> sampleIDs)
    {
      InitializeComponent();

      analysis = Analysis.Replace(".", string.Empty);
      btnOK.Enabled = false;

      Text = "BioSeqDB " + analysis + " analysis";
      lblDescription.Text = "Use this dialog to run the " + analysis + " analysis function.";
      lblDescription.Text += "  Choose either a sample from the database list, or an external contig sample file to analyze.";
      Cursor.Current = Cursors.WaitCursor;

      lstSampleIDs.Items.Clear();
      //lstSampleIDs.Items.AddRange(ServiceCallHelper.SampleIDs(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()).ToArray());
      lstSampleIDs.Items.AddRange(sampleIDs.ToArray());

      // Set some defaults.
      radSample.Checked = AppConfigHelper.SampleChecked(analysis);
      lblSampleFasta.Enabled = txtInputPath.Enabled = btnFindInputPath.Enabled = !radSample.Checked;
      radContig.Checked = !radSample.Checked;
      lblSampleID.Enabled = lstSampleIDs.Enabled = !radContig.Checked;
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.InputPath(analysis));
      txtOutputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.OutputPath(analysis));

      if (AppConfigHelper.SampleID(analysis).Length > 0)
      {
        for (int i = 0; i < lstSampleIDs.Items.Count; i++)
        {
          if (lstSampleIDs.Items[i].ToString() == AppConfigHelper.SampleID(analysis))
          {
            lstSampleIDs.SelectedIndex = i;
            break;
          }
        }
      }

      switch (analysis)
      {
        case "Kraken2":
          // Hide the fastq folder path controls.
          lblFastqPath.Visible = txtFastqPath.Visible = btnFastqPath.Visible = false;
          if (AppConfigHelper.Kraken2UseFastq)
          {
            txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.Kraken2FastqPath);
          }
          pnlKraken.Visible = true;
          radUseFastq.Checked = AppConfigHelper.Kraken2UseFastq;
          radUseFasta.Checked = !radUseFastq.Checked;
          break;
        case "Quast":
          // Hide the fastq folder path controls.
          lblFastqPath.Visible = txtFastqPath.Visible = btnFastqPath.Visible = false;
          break;
        case "BBMap":
          txtFastqPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.BBMapFastqPath());
          lblSampleFasta.Text = "Sample .fasta reference file (often this is the contig file assembled from the fastq reads):";
          break;
        case "VFabricate":
          txtFastqPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.VFabricateGeneXref);
          lblSampleFasta.Text = "Sample .fasta contig file:";
          btnGeneXref.Location = new System.Drawing.Point(lblFastqPath.Location.X + 2, lblFastqPath.Location.Y - 7);
          lblFastqPath.Visible = false;
          btnGeneXref.Visible = true;
          break;
        case "Search":
          pnlSearch.Visible = true;
          pnlSearch.Location = new System.Drawing.Point(lblFastqPath.Location.X + 3, lblFastqPath.Location.Y - 40);
          txtOutputSampleName.Text = AppConfigHelper.SearchOutputSampleName();
          break;
      }
      EnableOK();
      Cursor.Current = Cursors.Default;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // TODO: Should check the validity of the paths here.
      AppConfigHelper.OutputPath(analysis, txtOutputPath.Text.Trim());
      AppConfigHelper.SampleChecked(analysis, radSample.Checked);
      AppConfigHelper.TaskMemo = txtMemo.Text.Trim();

      if (analysis == "Kraken2")
      {
        AppConfigHelper.Kraken2UseFastq = radUseFastq.Checked;
        if (radUseFastq.Checked)
        {
          AppConfigHelper.Kraken2FastqPath = txtInputPath.Text.Trim();
        }
      }

      if (analysis == "BBMap")
      {
        AppConfigHelper.BBMapFastqPath(analysis, txtFastqPath.Text.Trim());
        string fastqPath = txtFastqPath.Text.Trim();
        if (IsServiceClass.IsService)
        {
          if (fastqPath.StartsWith("[L]")) // Not extract sample ID
          {
            ServiceCallHelper.ResetFastqFolder(AppConfigHelper.LoggedOnUser);
            string[] files = Directory.GetFiles(DirectoryHelper.CleanPath(fastqPath), "*.fastq", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
              DirectoryHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastqFiles", true);
            }
          }
        }
      }

      if (analysis == "VFabricate")
      {
        AppConfigHelper.VFabricateGeneXref = txtFastqPath.Text.Trim();
      }

      if (analysis == "Search")
      {
        if (!float.TryParse(txtCutoff.Text, out float cutoff))
        {
          MessageBox.Show("A cutoff number between 0 and 1 is required.", "Missing cutoff", MessageBoxButtons.OK);
          txtCutoff.Focus();
          DialogResult = DialogResult.None;
          return;
        }

        if (cutoff < 0.0 || cutoff > 1.0)
        {
          MessageBox.Show("A cutoff number between 0 and 1 is required.", "Invalid cutoff", MessageBoxButtons.OK);
          txtCutoff.Focus();
          DialogResult = DialogResult.None;
          return;
        }

        if (radContig.Checked && !DirectoryHelper.FileExists(AppConfigHelper.NormalizePathToWindows(txtInputPath.Text)))
        {
          MessageBox.Show(txtInputPath.Text + " does not exist. Choose a valid input file.", "Invalid input file", MessageBoxButtons.OK);
          txtInputPath.Focus();
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
        AppConfigHelper.SearchSample(txtOutputSampleName.Text, txtOutputPath.Text, txtInputPath.Text.Trim(), txtCutoff.Text, txtThreads.Text);
      }

      if (radSample.Checked)
      {
        if (lstSampleIDs.SelectedIndex == -1)
        {
          MessageBox.Show("Select a sample from the sample list", "ERROR", MessageBoxButtons.OK);
          return;
        }

        AppConfigHelper.SampleID(analysis, lstSampleIDs.SelectedItem.ToString().Trim());
      }
      else   // If the txtInputPath is local, send it to the UserFolder() on the server.
      {
        string inputPath = txtInputPath.Text.Trim();
        if (!radSample.Checked && IsServiceClass.IsService)
        {
          if (inputPath.StartsWith("[L]")) // Not extract sample ID
          {
            DirectoryHelper.FileCopy(inputPath, AppConfigHelper.UserFolder(), true);
          }
        }

        AppConfigHelper.InputPath(analysis, inputPath);
      }
    }

    private void lstSampleIDs_SelectedIndexChanged(object sender, EventArgs e)
    {
      AppConfigHelper.SampleID(lstSampleIDs.SelectedItem.ToString());
      EnableOK();
    }

    private void radContig_CheckedChanged(object sender, EventArgs e)
    {
      lblSampleFasta.Enabled = txtInputPath.Enabled = btnFindInputPath.Enabled = pnlKraken.Enabled = radContig.Checked;
      lblSampleID.Enabled = lstSampleIDs.Enabled = !radContig.Checked;
      AppConfigHelper.SampleChecked(analysis, false);
      EnableOK();
    }

    private void radSample_CheckedChanged(object sender, EventArgs e)
    {
      lblSampleID.Enabled = lstSampleIDs.Enabled = radSample.Checked;
      lblSampleFasta.Enabled = txtInputPath.Enabled = btnFindInputPath.Enabled = pnlKraken.Enabled = !radSample.Checked;
      AppConfigHelper.SampleChecked(analysis, true);
      EnableOK();
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        if (txtInputPath.Text.EndsWith("\\"))
        {
          txtInputPath.Text = txtInputPath.Text.Substring(0, txtInputPath.Text.LastIndexOf("\\"));
        }
        string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text); // We want an actual file, so don't append "\\".

        if (analysis == "Kraken2" && radUseFastq.Checked)
        {
          path = AppConfigHelper.NormalizePathToWindows(path + "\\");
          Cursor.Current = Cursors.WaitCursor;
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder with .fastq files",
                                              DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                              string.Empty, null, AppConfigHelper.UbuntuPrefix());
        }
        else
        {
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to folder with .fasta contig file",
                                              DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                              "Fasta files (*.fasta)|*.fasta;*.fna;*.fa|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        }
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtInputPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        string path = AppConfigHelper.NormalizePathToWindows(txtInputPath.Text);
        ofn.InitialDirectory = path;
        ofn.Title = "Input path to folder with .fasta contig file";
        ofn.CheckFileExists = true;
        ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(path);
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna;*.fa|All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtInputPath.Text = ofn.FileName.Trim();
        }
      }
      EnableOK();
    }

    private void btnFindOutputPath_Click(object sender, EventArgs e)
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

    private void btnFastqPath_Click(object sender, EventArgs e)
    {
      if (analysis == "BBMap")
      {
        if (IsServiceClass.IsService)
        {
          string path = AppConfigHelper.NormalizePathToWindows(txtFastqPath.Text + "\\");
          Cursor.Current = Cursors.WaitCursor;
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "BBMap output path",
                                              DirectoryHelper.IsServerPath(txtOutputPath.Text), DirectoryHelper.CleanPath(path),
                                              string.Empty, null, AppConfigHelper.UbuntuPrefix());
          Cursor.Current = Cursors.Default;
          Explorer.frmExplorer.ShowDialog();
          if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
          {
            txtFastqPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
          }
          Explorer.frmExplorer = null;
        }
        else
        {
          VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
          ofn.Description = "BBMap";

          ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtFastqPath.Text);
          ofn.UseDescriptionForTitle = true;
          if (ofn.ShowDialog() != DialogResult.Cancel)
          {
            txtFastqPath.Text = ofn.SelectedPath.Trim();
          }
        }
      }
      else if (analysis == "VFabricate") // overload these controls.
      {
        if (IsServiceClass.IsService)
        {
          string path = AppConfigHelper.NormalizePathToWindows(txtFastqPath.Text); // We want an actual file, so don't append "\\".
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Gene Xref file",
                                              DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                              "CSV files (*.csv)|*.csv;|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
          Explorer.frmExplorer.ShowDialog();
          if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
          {
            txtFastqPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
          }
          Explorer.frmExplorer = null;
        }
        else
        {
          {
            VistaOpenFileDialog ofn = new VistaOpenFileDialog();
            string path = AppConfigHelper.NormalizePathToWindows(txtFastqPath.Text);
            ofn.InitialDirectory = path;
            ofn.Title = "Gene Xref file";
            ofn.CheckFileExists = true;
            ofn.FileName = ofn.InitialDirectory = AppConfigHelper.FileExists(path);
            ofn.Filter = "CSV files (*.csv)|*.csv;|All files (*.*)|*.*";

            if (ofn.ShowDialog() != DialogResult.Cancel)
            {
              txtFastqPath.Text = ofn.FileName.Trim();
            }
          }
        }
      }
      EnableOK();
    }

    private void EnableOK()
    {
      bool isOK = true;
      if (radContig.Checked && txtInputPath.Text.Trim().Length == 0)
      {
        isOK = false;
      }
      else if (radSample.Checked && lstSampleIDs.SelectedIndex < 0)
      {
        isOK = false;
      }

      if (txtOutputPath.Text.Trim().Length == 0)
      {
        isOK = false;
      }

      if ((analysis == "BBMap" || analysis == "VFabricate") && isOK && txtFastqPath.Text.Trim().Length == 0)
      {
        isOK = false;
      }

      if (isOK && analysis == "Search" && !(txtOutputPath.Text.Trim().Length > 0 && txtOutputSampleName.Text.Trim().Length > 0 &&
                                                               txtCutoff.Text.Trim().Length > 0 && txtThreads.Text.Trim().Length > 0))
      {
        isOK = false;
      }
      else if ((txtInputPath.Text.Trim().Length == 0 && radContig.Checked) || (radSample.Checked && lstSampleIDs.SelectedIndex == -1))
      {
        isOK = false;
      }

      btnOK.Enabled = isOK;
    }

    private void txtInputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnGeneXref_Click(object sender, EventArgs e)
    {
      string filename = txtFastqPath.Text.Trim();
      if (filename.Length == 0)
      {
        btnFastqPath_Click(sender, e);
        return;
      }

      if (!DirectoryHelper.FileExists(filename))
      {
        MessageBox.Show(txtFastqPath.Text.Trim() + " not found.", "ERROR", MessageBoxButtons.OK);
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

      Process p = Process.Start("excel.exe", DirectoryHelper.CleanPath(filename));
      p.WaitForExit();
      p.Close();

      if (IsServiceClass.IsService && filename.StartsWith("[S]")) // Copy back to server.
      {
        string nameOnly = Path.GetFileName(filename);
        DirectoryHelper.FileCopy("[L]C:\\Temp\\" + nameOnly, filename.Replace(nameOnly, string.Empty), true);
      }
    }

    private void txtSampleID_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtCutoff_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
                    e.KeyChar != (Char)Keys.Delete);  // Numerics only  isNumeric
      EnableOK();
    }

    private void txtCutoff_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtThreads_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
                      e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
      EnableOK();
    }

    private void txtThreads_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void BioSeqAnalysis_Shown(object sender, EventArgs e)
    {
      pnlSearch.Visible = analysis == "Search";
    }

    private void radUseFasta_CheckedChanged(object sender, EventArgs e)
    {
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.InputPath(analysis));
      lblSampleFasta.Text = "Sample .fasta file to analyze:";
    }

    private void radUseFastq_CheckedChanged(object sender, EventArgs e)
    {
      lblSampleFasta.Text = "Sample .fastq folder to analyze:";
      txtInputPath.Text = DirectoryHelper.UnCleanPath(AppConfigHelper.Kraken2FastqPath);
    }

    private void lblSampleFasta_Click(object sender, EventArgs e)
    {

    }
  }
}