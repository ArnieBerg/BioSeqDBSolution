using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqUI : Form
  {
    public bool NotificationsIsOpen { get; private set; }
    public BioSeqDBNotifications frm;
    //private PleaseWaitDialog pleaseWaitDialog;
    private bool SampleIDsBusyFlag = false;
    private bool VersionsBusyFlag = false;

    public BioSeqUI()
    {
      InitializeComponent();

      Visible = false;
      Splasher.Show(typeof(BioSeqSplash));  // Uncomment!

      cmbAnalysis.SelectedIndex = 0;
    }

    private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
    {
      BioSeqDBLogin frmLogin = new BioSeqDBLogin(cmbUser.Text.Trim().ToUpper(), null);
      if (frmLogin.ShowDialog() != DialogResult.OK)
      {
        cmbUser.SelectedIndexChanged -= cmbUser_SelectedIndexChanged;
        cmbUser.Text = AppConfigHelper.LastUser;
        cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
        return;
      }

      AppConfigHelper.Logout(); // Logout current user (just to record the time of logout).

      AppConfigHelper.LastUser = cmbUser.Text;
      AppConfigHelper.SaveConfigGlobal();
      AppConfigHelper.LoggedOnUser = cmbUser.Text;

      cmbUser.SelectedIndexChanged -= cmbUser_SelectedIndexChanged;

      Initialize();
      Visible = true;
      //AppConfigHelper.StartTimer();
      Cursor.Current = Cursors.Default;
      if (Size.Width != 0)
      {
        Location = AppConfigHelper.Location();
        if (Location.X <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.Size();
        if (Size.Height <= 0 || Size.Width <= 0)
        {
          Size = new Size(3000, 1500);
        }
      }
      cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
    }

    private void Initialize()
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;

        PopulateDBDropdownAndSelect();
        PopulateUserDropdownAndSelect();
        Cursor.Current = Cursors.Default;

        chkDetailSamples.CheckedChanged -= chkDetailSamples_CheckedChanged;
        chkDetailSamples.Checked = AppConfigHelper.ShowDetail;
        chkDetailSamples.CheckedChanged += chkDetailSamples_CheckedChanged;

        cmbUser.Text = AppConfigHelper.LastUser;
        txtDB.Text = AppConfigHelper.CurrentDBName();
        txtStandardReference.Text = AppConfigHelper.BuildTreeDomesticReference;
        txtPath.Text = AppConfigHelper.CurrentDBPath();
      }
      catch (Exception ex)
      {
        Splasher.Close();
        MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK);
        throw ex;
      }
    }

    private void PopulateUserDropdownAndSelect()
    {
      // Populate the drop down.
      cmbUser.Items.Clear();
      if (AppConfigHelper.seqdbConfig.Users.Count > 0)
      {
        foreach (User user in AppConfigHelper.seqdbConfig.Users.Values)
        {
          cmbUser.Items.Add(user.Username);
        }
      }

      if (!string.IsNullOrEmpty(AppConfigHelper.seqdbConfig.LastUser))
      {
        for (int i = 0; i < cmbUser.Items.Count; i++)
        {
          if (cmbUser.Items[i].ToString() == AppConfigHelper.seqdbConfig.LastUser)
          {
            cmbUser.SelectedIndex = i; // Pick the last selected.
            break;
          }
        }
      }
      else
      {
        cmbUser.SelectedIndex = 0;  // Pick the first one.
      }
    }

    private void PopulateDBDropdownAndSelect()
    {
      // Populate the drop down.
      cmbSeqDB.Items.Clear();
      cmbSeqDB.Items.Add(string.Empty);
      cmbSeqDB.Items.Add("<new...>");

      if (AppConfigHelper.seqdbConfig.seqDBs.Count > 0)
      {
        foreach (SeqDB seqdb in AppConfigHelper.seqdbConfig.seqDBs.Values)
        {
          cmbSeqDB.Items.Add(seqdb.DBName);
        }
      }

      if (!string.IsNullOrEmpty(AppConfigHelper.seqdbConfig.LastDBSelected))
      {
        for (int i = 2; i < cmbSeqDB.Items.Count; i++)
        {
          if (cmbSeqDB.Items[i].ToString() == AppConfigHelper.seqdbConfig.LastDBSelected)
          {
            cmbSeqDB.SelectedIndex = i; // Pick the last selected.
            break;
          }
        }
      }
      else if (cmbSeqDB.Items.Count > 2)
      {
        cmbSeqDB.SelectedIndex = cmbSeqDB.Items.Count - 1; // Pick the last one.
      }
      else
      {
        cmbSeqDB.SelectedIndex = 0;  // Pick the empty one.
      }

      UpdateNotificationStatus();
    }

    private void UpdateNotificationStatus()
    {
      // Also update notifications button task count and enabled status.
      int count = AppConfigHelper.TaskCount();
      btnNotifications.Text = "Pending notifications (" + count.ToString() + ")...";
      btnNotifications.Enabled = count > 0;

      // If any of the tasks are status=Ready, turn background color to OrangeRed.
      btnNotifications.BackColor = Color.LightGray;
      foreach (BioSeqTask task in AppConfigHelper.TaskList.Values)
      {
        if (task.TaskStatus == "Ready")
        {
          btnNotifications.BackColor = Color.OrangeRed;
        }
      }

      txtStandardReference.Text = AppConfigHelper.BuildTreeDomesticReference; // This may have been updated by the Build tree function.

      if (btnNotifications.Enabled && !NotificationsIsOpen)
      {
        //btnNotifications_Click(null, null); // Automatically open the notifications dialog if it is not open.
        frm = new BioSeqDBNotifications();
        frm.FormClosedEvent += NotificationsClosed;
        frm.StatusChangeEvent += ModelessDialogEvent;
        frm.Show(this);
        NotificationsIsOpen = true;
      }
    }

    private void btnDeleteDB_Click(object sender, EventArgs e)
    {
      // Delete the currently selected database and associated archive database.
      ConfirmDBDelete.MainInstruction = "You are about to completely delete " + txtDB.Text + " in " + txtPath.Text;
      if (txtVersions.Text.Length > 0)
      {
        ConfirmDBDelete.MainInstruction = ConfirmDBDelete.MainInstruction + ", as well as the associated archival database";
      }
      ConfirmDBDelete.MainInstruction = ConfirmDBDelete.MainInstruction + ". Do you want to continue?";

      TaskDialogButton button = ConfirmDBDelete.ShowDialog(this);
      if (button == btnDeleteDBNo)
      {
        return;
      }

      Cursor.Current = Cursors.WaitCursor;
      int rc = ServiceCallHelper.DeleteDB(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
      if (rc == 0)
      {
        MessageBox.Show("Database successfully deleted.", "Success", MessageBoxButtons.OK);
      }
      else
      {
        MessageBox.Show("Failed to delete database. Error code " + rc.ToString(), "ERROR", MessageBoxButtons.OK);
      }

      cmbUser.SelectedIndexChanged -= cmbUser_SelectedIndexChanged;
      ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser);
      AppConfigHelper.seqdbConfig.LastDBSelected = string.Empty;
      Initialize();
      cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
      Cursor.Current = Cursors.Default;
    }

    private void cmbSeqDB_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cmbSeqDB.SelectedIndex == 0) // empty = none = reset
      {
        menuStrip1.Enabled = false;
        btnDeleteDB.Enabled = false;
        txtDB.Text = txtPath.Text = txtVersions.Text = AppConfigHelper.seqdbConfig.LastDBSelected = string.Empty;
        lblKipper.Visible = false;
        lstSampleIDs.Items.Clear();
        chkDetailSamples.Enabled = false;
        lstSampleIDs.Enabled = false;
        AppConfigHelper.SaveConfig();
      }
      else if (cmbSeqDB.SelectedIndex == 1)  // New
      {
        BioSeqNewDB frmNewDB = new BioSeqNewDB();
        DialogResult rc = frmNewDB.ShowDialog();
        if (rc == DialogResult.OK) // then the config has the specs for the new db to select.
        {
          Cursor.Current = Cursors.WaitCursor;

          // If necessary, copy local files to server.
          if (IsServiceClass.IsService)
          {
            string fastaPath = AppConfigHelper.Build_DBInput();
            if (fastaPath.StartsWith("[L]")) // Not extract sample ID
            {
              ServiceCallHelper.ResetFastaFolder(AppConfigHelper.LoggedOnUser);
              string[] folders = Directory.GetDirectories(DirectoryHelper.CleanPath(fastaPath));
              foreach (string folder in folders)
              {
                string[] files = Directory.GetFiles(folder, "*.fasta", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                  DirectoryHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastaFiles", true);
                }
                files = Directory.GetFiles(folder, "*.fna", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                  DirectoryHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastaFiles", true);
                }
              }
            }

            if (!string.IsNullOrEmpty(AppConfigHelper.BuildTreeWildReference())) // This is the standard genome for the new database.
            {
              // Wherever it is, store it temporarily in the UserFolder.
              DirectoryHelper.FileCopy(AppConfigHelper.BuildTreeWildReference(), "[S]" + AppConfigHelper.UserFolder(), true);
            }
          }

          ServiceCallHelper.Build_DB(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          if (AppConfigHelper.LastError.Length > 0)
          {
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Error: " + AppConfigHelper.LastError, "ERROR", MessageBoxButtons.OK);
            return;
          }

          ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser);
          PopulateDBDropdownAndSelect();
          Cursor.Current = Cursors.Default;
        }
      }
      else // a database is selected.
      {
        Cursor.Current = Cursors.WaitCursor;
        AppConfigHelper.seqdbConfig.LastDBSelected = cmbSeqDB.SelectedItem.ToString();
        AppConfigHelper.SaveConfig();

        menuStrip1.Enabled = true;
        btnDeleteDB.Enabled = true;
        chkDetailSamples.Enabled = true;
        lstSampleIDs.Enabled = true;
        txtVersions.Text = string.Empty;
        lstSampleIDs.Items.Clear();

        SeqDB db = AppConfigHelper.seqdbConfig.seqDBs[AppConfigHelper.seqdbConfig.LastDBSelected];
        txtDB.Text = db.DBName;
        txtPath.Text = db.DBPath;
        AppConfigHelper.LastError = string.Empty;

        if (SampleIDsBusyFlag || VersionsBusyFlag)
        {
          MessageBox.Show("Version information and sample IDs are being loaded for previous database. Please select " +
                  db.DBName + " again.", "Warning", MessageBoxButtons.OK);
          return;
        }

        // Version information comes from the global config.
        RefreshVersionInformation(AppConfigHelper.seqdbConfigGlobal.seqDBs[AppConfigHelper.seqdbConfig.LastDBSelected]);

        // Also get sample IDs into listbox.
        ReloadSampleIDs();
        Cursor.Current = Cursors.Default;
        if (AppConfigHelper.LastError.Length > 0)
        {
          MessageBox.Show("Error: " + AppConfigHelper.LastError, "ERROR", MessageBoxButtons.OK);
        }
      }
    }

    private void RefreshVersionInformation(SeqDB db)
    {
      if (!VersionsBusyFlag)
      {
        VersionsBusyFlag = true;
        backgroundWorker_Versions.RunWorkerAsync(db);
      }
    }

    private void cmbSeqDB_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = true;
    }

    private void mnuInsert_Click(object sender, EventArgs e)
    {
      BioSeqInsert frm = new BioSeqInsert(lstSampleIDs.Items);
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        int ret;
        string function = "Replace";

        // If the InsertInputPath is local, copy it to UserFolder on the server.
        if (AppConfigHelper.InsertInputPath().StartsWith("[L]"))
        {
          DirectoryHelper.FileCopy(AppConfigHelper.InsertInputPath(), "[S]" + AppConfigHelper.UserFolder(), true);
        }

        if (AppConfigHelper.InsertSampleReplace)
        {
          ret = ServiceCallHelper.ReplaceSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        }
        else // Go ahead without prompting.
        {
          function = "Insert";
          ret = ServiceCallHelper.InsertSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        }
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (ret == 0)
        {
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + function + " completed successfully.", "Success", MessageBoxButtons.OK);
          ReloadSampleIDs(); // Reload list with new sample ID.
        }
        else
        {
          MessageBox.Show(function + " completed with error code " + ret.ToString() + "." + Environment.NewLine + Environment.NewLine +
                               AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void mnuExtract_Click(object sender, EventArgs e)
    {
      BioSeqExtract frm = new BioSeqExtract();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        // Parameters are in appsettings.
        int ret = ServiceCallHelper.Extract(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (ret == 0)
        {
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Extract completed successfully. Result is in " +
                          AppConfigHelper.ExtractOutputPath() + "\\" + AppConfigHelper.ExtractSampleID() + ".fasta", "Success", MessageBoxButtons.OK);
        }
        else
        {
          MessageBox.Show("Extract completed with error code " + ret.ToString() + "." + Environment.NewLine + Environment.NewLine +
                             AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void mnuRemove_Click(object sender, EventArgs e)
    {
      BioSeqRemove frm = new BioSeqRemove();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        //int ret = SeqDBHelper.RemoveSample(); // Parameters are in appsettings.
        int ret = ServiceCallHelper.RemoveSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (ret == 0)
        {
          MessageBox.Show(AppConfigHelper.RemoveSampleID() + " successfully removed.", "Success", MessageBoxButtons.OK);
          AppConfigHelper.RemoveSample(string.Empty); // So we don't prompt for it again.
          ReloadSampleIDs(); // Reload list without sample ID.
        }
        else
        {
          MessageBox.Show("Remove completed with error code " + ret.ToString() + "." + Environment.NewLine + Environment.NewLine +
                            AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void mnuBackup_Click(object sender, EventArgs e)
    {
      BioSeqBackup frm = new BioSeqBackup();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        int ret = ServiceCallHelper.BackupDatabase(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (ret == 0)
        {
          RefreshVersionInformation(AppConfigHelper.seqdbConfig.seqDBs[AppConfigHelper.seqdbConfig.LastDBSelected]);
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Backup successfully completed.", "Success", MessageBoxButtons.OK);
          // Refresh backup version display.
        }
        else
        {
          MessageBox.Show("Backup completed with error code " + ret.ToString() + "." + Environment.NewLine + Environment.NewLine +
                              AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void mnuRestore_Click(object sender, EventArgs e)
    {
      BioSeqRestore frm = new BioSeqRestore(txtVersions.Text.Trim());
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        int ret = ServiceCallHelper.RestoreDatabase(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (ret == 0)
        {
          ReloadSampleIDs(); // Reload list without sample ID.
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Restore successfully completed.", "Success", MessageBoxButtons.OK);
        }
        else
        {
          MessageBox.Show("Restore completed with error code " + ret.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                  AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void lstSampleIDs_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lstSampleIDs.SelectedItem != null)
      {
        AppConfigHelper.UpdateSampleSelected(lstSampleIDs.SelectedItem.ToString());
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BioSeqDBAbout frm = new BioSeqDBAbout();
      frm.Show(); // Go modeless so we can continue in the main UI without closing About.
    }

    private void chkDetailSamples_CheckedChanged(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      AppConfigHelper.ShowDetail = chkDetailSamples.Checked;
      ReloadSampleIDs(); // Reload list without sample ID.
      Cursor.Current = Cursors.Default;
    }

    private void BioSeqUI_Shown(object sender, EventArgs e)
    {
      Visible = false;

      cmbUser.SelectedIndexChanged -= cmbUser_SelectedIndexChanged;
      cmbUser.Text = AppConfigHelper.LastUser;

      Initialize();
      //AppConfigHelper.StartTimer();
      Cursor.Current = Cursors.Default;
      if (Size.Width != 0)
      {
        Location = AppConfigHelper.Location();
        if (Location.X <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.Size();
        if (Size.Height <= 0 || Size.Width <= 0)
        {
          Size = new Size(3000, 1500);
        }
      }
      cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
      Splasher.Close();
      Visible = true;
    }

    private void mnuAssemble_Click(object sender, EventArgs e)
    {
      BioSeqAssemble frm = new BioSeqAssemble();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete);

        CreateNewTask("Assemble", AppConfigHelper.TaskMemo);
        UpdateNotificationStatus();
        backgroundWorker.RunWorkerAsync();
        Cursor.Current = Cursors.Default;
      }
    }

    private void mnuBuildTree_Click(object sender, EventArgs e)
    {
      BioSeqBuildTree frm = new BioSeqBuildTree();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

        CreateNewTask("BuildTree", AppConfigHelper.TaskMemo);
        UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

        backgroundWorker.RunWorkerAsync();
        Cursor.Current = Cursors.Default;
      }
    }

    private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      BioSeqTask task = AppConfigHelper.TaskOfID(AppConfigHelper.LastTaskID);
      switch (task.TaskType)
      {
        case "Salmonella":
          int rc = ServiceCallHelper.Salmonella(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "VFabricate":
          rc = ServiceCallHelper.VFabricate(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "Search":
          rc = ServiceCallHelper.SearchSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "Kraken2":
          rc = ServiceCallHelper.Kraken2(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "Quast":
          rc = ServiceCallHelper.Quast(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "BBMap":
          rc = ServiceCallHelper.BBMap(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "BuildTree":
          rc = ServiceCallHelper.BuildTree(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "Assemble":
          rc = ServiceCallHelper.Assemble(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), AppConfigHelper.QuerySampleConfig());
          e.Result = new List<object>() { rc, task };
          break;

        case "InfluenzaA":
          rc = ServiceCallHelper.InfluenzaA(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          e.Result = new List<object>() { rc, task };
          break;
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      // Parse the return from the background task.
      try
      {
        List<object> arguments = (List<object>)e.Result;
        int ret = (int)arguments[0];
        BioSeqTask task = (BioSeqTask)arguments[1];

        switch (task.TaskType)
        {
          case "Search":
          case "Kraken2":
          case "Quast":
          case "VFabricate":
            ReportExtractError(ret, task.TaskType);
            break;

          case "BBMap":
            ReportExtractError(ret, task.TaskType);
            if (ret == -3)
            {
              MessageBox.Show("There are no .fastq files in " + AppConfigHelper.BBMapFastqPath() + ".", "Error", MessageBoxButtons.OK);
            }
            else if (ret == -2)
            {
              MessageBox.Show("Failed to catenate files in BBMap.", "Error", MessageBoxButtons.OK);
            }
            else if (ret == -4)
            {
              MessageBox.Show("The seqtk step failed in BBMap.", "Error", MessageBoxButtons.OK);
            }
            else if (ret != 0)
            {
              MessageBox.Show("BBMap failed with error code " + ret.ToString() + ".", "Error", MessageBoxButtons.OK);
            }
            break;

          case "BuildTree":
          case "Assemble":
          case "InfluenzaA":
          case "Salmonella":
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static void ReportExtractError(int ret, string analysis)
    {
      if (ret == -1)
      {
        MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + analysis + " was unable to extract sample from sequence database." +
                      Environment.NewLine + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
      }
    }

    private void CreateNewTask(string taskType, string taskMemo)
    {
      int taskid = AppConfigHelper.MaxTaskID() + 1;
      BioSeqTask task = new BioSeqTask()
      {
        TaskMemo = taskMemo,
        TaskDB = AppConfigHelper.CurrentDBName(),
        TaskID = taskid.ToString(),
        TaskStatus = "Pending",
        TaskTime = DateTime.Now,
        TaskComplete = DateTime.MinValue,
        TaskType = taskType,
        TaskUser = AppConfigHelper.LoggedOnUser,
        StandardOutput = string.Empty,
        LastError = string.Empty,
        LastExitCode = -999
      };
      AppConfigHelper.AddTask(task);
    }

    private void backupgroundTaskComplete(object sender, TaskEventArgs e)
    {
      // Change status of this task to Ready.
      AppConfigHelper.BackgroundTaskComplete(e.task);
    }

    private void btnNotifications_Click(object sender, EventArgs e)
    {
      if (NotificationsIsOpen)
      {
        frm.Focus();
        return;
      }

      //NotificationsIsOpen = true;
      //frm = new BioSeqDBNotifications();
      //frm.FormClosedEvent += NotificationsClosed;
      //frm.StatusChangeEvent += ModelessDialogEvent; 
      //frm.Show(this);
      UpdateNotificationStatus();
    }

    private void ModelessDialogEvent(object sender, EventArgs e)
    {
      UpdateNotificationStatus();
    }

    private void NotificationsClosed(object sender, EventArgs e)
    {
      NotificationsIsOpen = false;
    }

    private void picHelp_Click(object sender, EventArgs e)
    {
      string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      executablePath = AppConfigHelper.GetDirectoryName(executablePath);
      Process.Start(executablePath + "\\BioSeqDBHelp.pdf");
    }

    private void BioSeqUI_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (Visible)
      {
        AppConfigHelper.Logout();
        AppConfigHelper.SaveUIForm(Location, Size);

      }
    }

    private void btnLIMSEdit_Click(object sender, EventArgs e)
    {
      // Open a dialog where we can maintain LIMS identifiers associated with samples.
      BioSeqLIMSEdit bioSeqLIMSEdit = new BioSeqLIMSEdit();
      bioSeqLIMSEdit.ShowDialog();
    }

    private void BioSeqUI_Load(object sender, EventArgs e)
    {
      Visible = false;
    }

    private void cmbAnalysis_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (cmbAnalysis.Text)
      {
        case "Salmonella Serotyping...":
          BioSeqSalmonella frmSalmonella = new BioSeqSalmonella();
          DialogResult rc = frmSalmonella.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("Salmonella", AppConfigHelper.TaskMemo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Search...":
          BioSeqAnalysis frm = new BioSeqAnalysis(cmbAnalysis.Text);
           rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Search for " + (AppConfigHelper.SampleChecked("Search") ? AppConfigHelper.SampleID("Search") : AppConfigHelper.InputPath("Search")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Search", memo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "InfluenzaA...":
          BioSeqInfluenzaA frmInfluenzaA = new BioSeqInfluenzaA();
          rc = frmInfluenzaA.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("InfluenzaA", AppConfigHelper.TaskMemo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Build tree...":
          mnuBuildTree_Click(sender, e);
          break;

        case "Kraken2...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text);
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Kraken2 analysis for " + (AppConfigHelper.SampleChecked("Kraken2") ? AppConfigHelper.SampleID("Kraken2") : AppConfigHelper.InputPath("Kraken2")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Search", memo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Quast...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text);
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Quast analysis for " + (AppConfigHelper.SampleChecked("Quast") ? AppConfigHelper.SampleID("Quast") : AppConfigHelper.InputPath("Quast")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Quast", memo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "BBMap...":
          frm = new BioSeqAnalysis("BBMap");
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "BBMap analysis for " + (AppConfigHelper.SampleChecked("BBMap") ? AppConfigHelper.SampleID("BBMap") : AppConfigHelper.InputPath("BBMap")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("BBMap", memo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "VFabricate...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text);
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "VFabricate analysis for " + (AppConfigHelper.SampleChecked("VFabricate") ? AppConfigHelper.SampleID("VFabricate") : AppConfigHelper.InputPath("VFabricate")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("VFabricate", memo);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;
      }
      cmbAnalysis.SelectedIndex = 0; // Position back to -- Select analysis --.
    }

    private void backgroundWorker_Versions_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      SeqDB db = (SeqDB)e.Argument;
      e.Result = ServiceCallHelper.GetVersions(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), DirectoryHelper.CleanPath(db.DBPath));
    }

    private void backgroundWorker_Versions_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      // Get version info. Version information comes from the global config.
      Cursor.Current = Cursors.WaitCursor;
      VersionsBusyFlag = false;

      txtVersions.Text = (string)e.Result;
      lblKipper.Visible = false;
      if (txtVersions.Text.Trim().Length > 0)
      {
        SeqDB db = AppConfigHelper.seqdbConfigGlobal.seqDBs[AppConfigHelper.seqdbConfig.LastDBSelected];
        lblKipper.Text = "This backup is stored at " + db.KipperPath + db.KipperFilenamePrefix + ".";
        lblKipper.Visible = true;
      }
      btnRestore.Enabled = txtVersions.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Length > 2; // Must have at least two backups before restore is meaningful.
      Cursor.Current = Cursors.Default;
    }

    private void ReloadSampleIDs()
    {
      if (!SampleIDsBusyFlag)
      {
        SampleIDsBusyFlag = true;
        backgroundWorker_SampleIDs.RunWorkerAsync();
      }
    }

    private void backgroundWorker_SampleIDs_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      e.Result = ServiceCallHelper.SampleIDs(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()).ToArray();
    }

    private void backgroundWorker_SampleIDs_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      SampleIDsBusyFlag = false;

      Cursor.Current = Cursors.WaitCursor;
      lstSampleIDs.Items.Clear();
      lstSampleIDs.Items.AddRange((string[])e.Result);
      AppConfigHelper.UpdateSampleSelected(string.Empty);
      Cursor.Current = Cursors.Default;
    }

    private void panel1_Click(object sender, EventArgs e)
    {
      // Test DirectoryHelper
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Server File Explorer...", false, "C:\\",
                                            "All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ShowDialog();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}