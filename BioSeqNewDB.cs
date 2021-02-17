using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqNewDB : Form
  {
    // Build a new database. Treat the new database as the selected database if all goes well and update config.
    // If there is already a database by the specified name, prompt to overwrite.

    public BioSeqNewDB()
    {
      InitializeComponent();
      btnOK.Enabled = false;

      SeqDB db = AppConfigHelper.seqdbConfigGlobal.Current();
      if (db != null) // Default the new database path to the same as the current db.
      {
        txtDBPath.Text = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(DirectoryHelper.UnCleanPath(db.DBPath)));
        txtDBPath.Text = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.GetDirectoryName(txtDBPath.Text)); // DB path much be on the server.
        if (!txtDBPath.Text.StartsWith("["))
        {
          txtDBPath.Text = "[S]" + txtDBPath.Text;
        }
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtDBPath.Text.Trim().Length > 0 && txtInputPath.Text.Trim().Length > 0 && txtDBName.Text.Trim().Length > 0;
    }

    private void txtDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void txtInputPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnFindDBPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        string path = "C:\\"; // Need to indicate we are looking for a folder by ending with "\\".
        if (!string.IsNullOrEmpty(txtDBPath.Text.Trim()))
        {
          path = AppConfigHelper.NormalizePathToWindows(txtDBPath.Text + "\\");
        }
        Cursor.Current = Cursors.WaitCursor;
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Organism database path",
                                            DirectoryHelper.IsServerPath(txtDBPath.Text), DirectoryHelper.CleanPath(path),
                                            string.Empty, null, AppConfigHelper.UbuntuPrefix());
        Explorer.frmExplorer.ServerOnly = true;
        Cursor.Current = Cursors.Default;
        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtDBPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Organism database path";
        ofn.SelectedPath = AppConfigHelper.NormalizePathToWindows(txtDBPath.Text);
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtDBPath.Text = ofn.SelectedPath.Trim();
        }
      }
    }

    private void btnFindInputPath_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        Cursor.Current = Cursors.WaitCursor;
        string path = "C:\\"; // Need to indicate we are looking for a folder by ending with "\\".
        if (!string.IsNullOrEmpty(txtInputPath.Text.Trim()))
        {
          path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(txtInputPath.Text)) + "\\";
        }

        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to sub-folders containing .fasta contig file(s)",
                                  DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                 "Fasta files (*.fasta)|*.fasta|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Cursor.Current = Cursors.Default;

        while (Explorer.frmExplorer.ShowDialog() != DialogResult.Cancel)
        {
          path = AppConfigHelper.GetDirectoryName(Explorer.PresentServerPath + Explorer.PresentLocalPath); // One of these is empty.
          bool ServerPath = string.IsNullOrEmpty(Explorer.PresentLocalPath);

          // Make sure the sub-folders contain .fasta files.
          int fCount = ValidFastaFiles(DirectoryHelper.CleanPath(path), ServerPath);
          if (fCount > 0)
          {
            txtInputPath.Text = path;
            if (MessageBox.Show("There are " + fCount.ToString() + " *.fasta (or *.fna) files in the sub-folders of the " + txtInputPath.Text +
                          " folder. Continue with building the " + txtDBName.Text.Trim() + " database?", "Confirm new " + txtDBName.Text.Trim() +
                                                                                      " database", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              break;
            }
          }

          Cursor.Current = Cursors.WaitCursor;
          Explorer.frmExplorer = null;
          path = "C:\\"; // Need to indicate we are looking for a folder by ending with "\\".
          if (!string.IsNullOrEmpty(txtInputPath.Text.Trim()))
          {
            path = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(txtInputPath.Text)) + "\\";
          }
          Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Input path to sub-folders containing .fasta contig file(s)",
                                   DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                   "Fasta files (*.fasta)|*.fasta|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
          Cursor.Current = Cursors.Default;
        }
      }
      else
      {
        VistaFolderBrowserDialog ofn = new VistaFolderBrowserDialog();
        ofn.Description = "Input path to folders containing .fasta contig file(s)";
        ofn.SelectedPath = txtInputPath.Text;
        ofn.ShowNewFolderButton = true;
        ofn.UseDescriptionForTitle = true;

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          // Make sure the folders contain .fasta files.
          //int fCount = TraverseTree(ofn.SelectedPath.Trim());
          int fCount = ValidFastaFiles(DirectoryHelper.CleanPath(ofn.SelectedPath.Trim()), false);
          if (fCount > 0)
          {
            txtInputPath.Text = ofn.SelectedPath.Trim();
            if (MessageBox.Show("There are " + fCount.ToString() + " *.fasta (or *.fna) files in the subfolders of the " + txtInputPath.Text +
                          " folder. Continue with building the " + txtDBName.Text.Trim() + " database?", "Confirm new " + txtDBName.Text.Trim() +
                                                                                      " database", MessageBoxButtons.YesNo) == DialogResult.No)
            {
              return;
            }
          }

          //int fCount = ServiceCallHelper.TraverseTree(ofn.SelectedPath.Trim(), false, "fasta");
          //if (fCount == 0)
          //{
          //  MessageBox.Show("There are no *.fasta or *.fna files in the subfolders of the " + ofn.SelectedPath.Trim() + " folder.", "Wrong folder", MessageBoxButtons.OK);
          //  return;
          //}
        }
      }
    }

    private int ValidFastaFiles(string root, bool IsServerPath)
    {
      if (!DirectoryHelper.DirectoryExists(root))
      {
        MessageBox.Show("The " + root + " folder does not exist.", "Wrong folder", MessageBoxButtons.OK);
        return 0;
      }

      string[] subDirs = DirectoryHelper.GetDirectories(root);
      int fCount = 0;

      foreach (string subfolderName in subDirs)
      {
        fCount += ServiceCallHelper.TraverseTree(subfolderName, IsServerPath, "fasta");
      }

      if (fCount == 0)
      {
        MessageBox.Show("There are no *.fasta files in the sub-folders of the " + root + " folder.", "Wrong folder", MessageBoxButtons.OK);
        return fCount;
      }

      EnableOK();
      return fCount;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      string dbname = txtDBName.Text.Trim();
      if (AppConfigHelper.seqdbConfig.seqDBs.ContainsKey(dbname)) // This can only be checked after we know the name of the db.
      {
        if (MessageBox.Show("There is already a database named " + dbname + ". Do you want to replace it?",
                                                            "Replace database?", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
          return;
        }

        SeqDB db = AppConfigHelper.seqdbConfig.seqDBs[dbname];
        if (db != null && db.DBPath == txtDBPath.Text + "/" + dbname)
        {
          if (MessageBox.Show("The database path " + db.DBPath + " already exists. Do you want to replace it?",
                                                        "Overwrite database?", MessageBoxButtons.OKCancel) != DialogResult.OK)
          {
            return;
          }
        }
      }

      // Update config to reflect selection.
      AppConfigHelper.NewDatabase(dbname, txtDBPath.Text.Trim(), txtInputPath.Text.Trim(), txtStandardReferenceGenome.Text.Trim());
    }

    private void txtDBName_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnStdRefGenome_Click(object sender, EventArgs e)
    {
      if (IsServiceClass.IsService)
      {
        Cursor.Current = Cursors.WaitCursor;
        string path = AppConfigHelper.NormalizePathToWindows(txtStandardReferenceGenome.Text); // We want an actual file, so don't append "\\".
        Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to standard reference genome file",
                                            DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                                            "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
        Cursor.Current = Cursors.Default;

        Explorer.frmExplorer.ShowDialog();
        if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
        {
          txtStandardReferenceGenome.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
        }
        Explorer.frmExplorer = null;
      }
      else
      {
        VistaOpenFileDialog ofn = new VistaOpenFileDialog();
        string path = AppConfigHelper.NormalizePathToWindows(txtStandardReferenceGenome.Text);
        if (File.Exists(path))
        {
          ofn.InitialDirectory = ofn.FileName = AppConfigHelper.FileExists(txtStandardReferenceGenome.Text.Trim());
        }
        ofn.Title = "Path to standard reference genome file";
        ofn.CheckFileExists = true;
        ofn.Filter = "Fasta files (*.fasta)|*.fasta;*.fna|All files (*.*)|*.*";

        if (ofn.ShowDialog() != DialogResult.Cancel)
        {
          txtStandardReferenceGenome.Text = ofn.FileName.Trim();
        }
      }
    }
  }
}