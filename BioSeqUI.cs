using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using BioSeqDBTransferData;
using FSExplorer;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqUI : Form
  {
    public bool NotificationsIsOpen { get; private set; }
    public BioSeqDBNotifications frmNotifications;
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

      Location = AppConfigHelper.UILocation();
      if (Location.X <= 0 || Location.Y <= 0)
      {
        Location = new Point(100, 100);
        Size = new Size(3000, 1500);
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
        txtStandardReference.Text = AppConfigHelper.StandardReference;
        txtPath.Text = AppConfigHelper.CurrentDBPath();
        backgroundWorker_CleanUserFolder.RunWorkerAsync();

        priorityDataBackupToolStripMenuItem.Visible = AppConfigHelper.BackupManager == AppConfigHelper.LoggedOnUser;

        if (AppConfigHelper.seqdbConfig.TaskToDelete != null)        // Remove any previous delete request at startup so as not to confuse WSLProxy2.
        {
          AppConfigHelper.seqdbConfig.TaskToDelete = null;
          AppConfigHelper.SaveConfig();
        }
      }
      catch (Exception ex)
      {
        Splasher.Close();
        MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK);
        throw; // Rethrow original exception
      }
    }

    private void PopulateUserDropdownAndSelect()
    {
      // Populate the drop down.
      cmbUser.Items.Clear();
      if (AppConfigHelper.seqdbConfigGlobal.Users.Count > 0)
      {
        foreach (User user in AppConfigHelper.seqdbConfigGlobal.Users.Values)
        {
          cmbUser.Items.Add(user.Username);
        }
      }

      if (!string.IsNullOrEmpty(AppConfigHelper.seqdbConfigGlobal.LastUser))
      {
        for (int i = 0; i < cmbUser.Items.Count; i++)
        {
          if (cmbUser.Items[i].ToString() == AppConfigHelper.seqdbConfigGlobal.LastUser)
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

      txtStandardReference.Text = AppConfigHelper.StandardReference; // This may have been updated by the Build tree function.

      OpenNotifications();
    }

    private void OpenNotifications()
    {
      if (btnNotifications.Enabled && !NotificationsIsOpen)
      {
        //btnNotifications_Click(null, null); // Automatically open the notifications dialog if it is not open.
        frmNotifications = new BioSeqDBNotifications();
        frmNotifications.FormClosedEvent += NotificationsClosed;
        frmNotifications.StatusChangeEvent += ModelessDialogEvent;
        frmNotifications.Show(this);
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
      ServiceCallHelper.LoadConfig(string.Empty);
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
          string fastaPath = AppConfigHelper.Build_DBInput();
          if (IsServiceClass.IsService && !string.IsNullOrEmpty(fastaPath))
          {
            if (fastaPath.StartsWith("[L]") || !fastaPath.StartsWith("["))
            {
              ServiceCallHelper.ResetFastaFolder(AppConfigHelper.LoggedOnUser);
              string[] folders = Directory.GetDirectories(DirectoryHelper.CleanPath(fastaPath));
              foreach (string folder in folders)
              {
                string[] files = Directory.GetFiles(folder, "*.fasta", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                  TransferHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastaFiles", true);
                }
                files = Directory.GetFiles(folder, "*.fna", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                  TransferHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastaFiles", true);
                }
                files = Directory.GetFiles(folder, "*.fa", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                  TransferHelper.FileCopy("[L]" + file, "[S]" + AppConfigHelper.UserFolder() + "FastaFiles", true);
                }
              }
            }
          }

          if (!string.IsNullOrEmpty(AppConfigHelper.BuildTreeWildReference())) // This is the standard genome for the new database.
          {
            // Wherever it is, store it temporarily in the UserFolder.
            TransferHelper.FileCopy(AppConfigHelper.BuildTreeWildReference(), "[S]" + AppConfigHelper.UserFolder(), true);
          }

          /////////// Call Build_DB in SeqDB.
          try
          {
            ServiceCallHelper.Build_DB(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
          }
          catch (Exception ex)
          {
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Error: " + ex.ToString(), "ERROR", MessageBoxButtons.OK);
            return;
          }

          if (AppConfigHelper.LastError.Length > 0)
          {
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Error: " + AppConfigHelper.LastError, "ERROR", MessageBoxButtons.OK);
            return;
          }

          //if (string.IsNullOrEmpty(AppConfigHelper.StandardReference))
          //{
          //  AppConfigHelper.StandardReference = AppConfigHelper.BuildTreeDomesticReference;
          //  AppConfigHelper.SaveConfig();
          //}
          //if (string.IsNullOrEmpty(AppConfigHelper.StandardReference))
          //{
          //  AppConfigHelper.StandardReference = AppConfigHelper.BuildTreeWildReference();
          //  AppConfigHelper.SaveConfig();
          //}

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

        txtStandardReference.Text = AppConfigHelper.StandardReference;
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
          TransferHelper.FileCopy(AppConfigHelper.InsertInputPath(), "[S]" + AppConfigHelper.UserFolder(), true);
        }

        WSLProxyResponse WSLResponse;
        if (AppConfigHelper.InsertSampleReplace)
        {
          WSLResponse = ServiceCallHelper.ReplaceSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        }
        else // Go ahead without prompting.
        {
          function = "Insert";
          WSLResponse = ServiceCallHelper.InsertSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        }
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (WSLResponse.ExitCode == 0)
        {
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + function + " completed successfully.", "Success", MessageBoxButtons.OK);
          ReloadSampleIDs(); // Reload list with new sample ID.
        }
        else
        {
          MessageBox.Show(function + " completed with error code " + WSLResponse.ExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
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
        WSLProxyResponse WSLResponse = ServiceCallHelper.Extract(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (WSLResponse.ExitCode == 0)
        {
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Extract completed successfully. Result is in " +
                          AppConfigHelper.ExtractOutputPath() + "\\" + AppConfigHelper.ExtractSampleID() + ".fasta", "Success", MessageBoxButtons.OK);
        }
        else
        {
          MessageBox.Show("Extract completed with error code " + WSLResponse.ExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                             AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void mnuRemove_Click(object sender, EventArgs e)
    {
      // Collect all the samples selected.
      List<string> sampleIDs = new List<string>();
      foreach (string sample in lstSampleIDs.SelectedItems)
      {
        sampleIDs.Add(sample);
      }
      AppConfigHelper.RemoveSampleIDs = sampleIDs;

      BioSeqRemove frm = new BioSeqRemove();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK) // then the config has the specs 
      {
        Cursor.Current = Cursors.WaitCursor;
        //int ret = SeqDBHelper.RemoveSample(); // Parameters are in appsettings.
        WSLProxyResponse WSLResponse = ServiceCallHelper.RemoveSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (WSLResponse.ExitCode == 0)
        {
          MessageBox.Show(AppConfigHelper.RemoveSampleIDs.Count.ToString() + " sample(s) successfully removed.", "Success", MessageBoxButtons.OK);
          ReloadSampleIDs(); // Reload list with sample IDs removed.
        }
        else
        {
          MessageBox.Show("Remove completed with error code " + WSLResponse.ExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
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
        WSLProxyResponse WSLResponse = ServiceCallHelper.BackupDatabase(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (WSLResponse.ExitCode == 0)
        {
          RefreshVersionInformation(AppConfigHelper.seqdbConfig.seqDBs[AppConfigHelper.seqdbConfig.LastDBSelected]);
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Backup successfully completed.", "Success", MessageBoxButtons.OK);
          // Refresh backup version display.
        }
        else
        {
          MessageBox.Show("Backup completed with error code " + WSLResponse.ExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
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
        WSLProxyResponse WSLResponse = ServiceCallHelper.RestoreDatabase(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // Parameters are in appsettings.
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
        Cursor.Current = Cursors.Default;
        if (WSLResponse.ExitCode == 0)
        {
          ReloadSampleIDs(); // Reload list without sample ID.
          MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Restore successfully completed.", "Success", MessageBoxButtons.OK);
        }
        else
        {
          MessageBox.Show("Restore completed with error code " + WSLResponse.ExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
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
        Location = AppConfigHelper.UILocation();
        if (Location.X <= 0 || Location.Y <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.UISize();
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

        CreateNewTask("Assemble", AppConfigHelper.TaskMemo, string.Empty);
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

        CreateNewTask("BuildTree", AppConfigHelper.TaskMemo, string.Empty);
        UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

        backgroundWorker.RunWorkerAsync();
        Cursor.Current = Cursors.Default;
      }
    }

    private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      BioSeqTask task = AppConfigHelper.TaskOfID(AppConfigHelper.LastTaskID);
      WSLProxyResponse WSLResponse = null;

      try
      {
        switch (task.TaskType)
        {
          case "BackupOffsite":
            WSLResponse = BioSeqDBModel.Instance.BackupDatabaseOffsite(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "FastQC":
            WSLResponse = ServiceCallHelper.FastQC(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "MultiQC":
            WSLResponse = ServiceCallHelper.MultiQC(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Centrifuge":
            WSLResponse = ServiceCallHelper.Centrifuge(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "CANS":
            WSLResponse = ServiceCallHelper.CANS(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Salmonella":
            WSLResponse = ServiceCallHelper.Salmonella(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "MetaMaps":
            WSLResponse = ServiceCallHelper.MetaMaps(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "VFabricate":
            WSLResponse = ServiceCallHelper.VFabricate(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Search":
            WSLResponse = ServiceCallHelper.SearchSample(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Kraken2":
            WSLResponse = ServiceCallHelper.Kraken2(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Quast":
            WSLResponse = ServiceCallHelper.Quast(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "BBMap":
            WSLResponse = ServiceCallHelper.BBMap(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "BuildTree":
            WSLResponse = ServiceCallHelper.BuildTree(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Assemble":
            WSLResponse = ServiceCallHelper.Assemble(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), AppConfigHelper.QuerySampleConfig());
            break;

          case "InfluenzaA":
            WSLResponse = ServiceCallHelper.InfluenzaA(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;

          case "Nextstrain":
            WSLResponse = ServiceCallHelper.Nextstrain(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
            break;
        }

        task.LastError = WSLResponse.StandardError;
        task.StandardOutput = WSLResponse.StandardOutput;
        e.Result = new List<object>() { WSLResponse.ExitCode, task };
      }
      catch (Exception ex)
      {
        e.Result = new List<object>() { ex, 0 };
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      // Parse the return from the background task.
      try
      {
        //AppConfigHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // Reload user's config (gets at least the LastCommand)

        List<object> arguments = (List<object>)e.Result;

        if (arguments[0] is Exception)
        {
          Exception ex = (Exception)arguments[0];
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
          return;
        }

        int ret = (int)arguments[0];
        BioSeqTask task = (BioSeqTask)arguments[1];

        if (ret != 0)  // Background task never got off the ground. Activate event in Notifications to report and remove task.
        {
          task.LastExitCode = ret;
          OpenNotifications();
          frmNotifications.TaskCompletion(task, task.TaskType, task.TaskType + " failed to complete");
          return;
        }

        switch (task.TaskType)
        {
          case "Search": // These analyses all use the option to extract a sample from the current sequence database,
          case "Kraken2": // and so need to report when that extraction fails.
          case "Quast":
          case "MetaMaps":
          case "VFabricate":
            ReportExtractError(ret, task.TaskType);
            break;

          case "FastQC":
            if (AppConfigHelper.FastQCMultiQC) // Schedule, but don't start this until we know that the background task is done.
            {
              if (frmNotifications == null)
              {
                frmNotifications = new BioSeqDBNotifications();
              }
              frmNotifications.ScheduleMultiQCEvent += ScheduleMultiQC;
            }
            break;

          case "BBMap":
            ReportExtractError(ret, task.TaskType);
            if (ret == -3)
            {
              MessageBox.Show("There are no .fastq files in " + AppConfigHelper.BBMapFastqPath() + ".", "Error", MessageBoxButtons.OK);
            }
            else if (ret == -2)
            {
              MessageBox.Show(task.LastError, "Error", MessageBoxButtons.OK);
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
          case "Nextstrain":
            break;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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

    private void CreateNewTask(string taskType, string taskMemo, string DB)
    {
      int taskid = AppConfigHelper.MaxTaskID() + 1;
      BioSeqTask task = new BioSeqTask()
      {
        TaskMemo = taskMemo,
        TaskDB = DB, //  AppConfigHelper.CurrentDBName(),
        TaskID = taskid.ToString(),
        TaskStatus = "Pending",
        TaskTime = DateTime.Now,
        TaskComplete = DateTime.MinValue,
        TaskType = taskType,
        TaskUser = AppConfigHelper.LoggedOnUser,
        TaskTimeout = 0,
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
        frmNotifications.Focus();
        return;
      }

      UpdateNotificationStatus();
    }

    private void ScheduleMultiQC(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      if (frmNotifications != null)
      {
        frmNotifications.ScheduleMultiQCEvent -= ScheduleMultiQC; // Deactivate scheduling mechanism.
      }

      SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

      CreateNewTask("MultiQC", AppConfigHelper.TaskMemo, string.Empty);
      UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

      backgroundWorker.RunWorkerAsync();
      Cursor.Current = Cursors.Default;
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
      cmbAnalysis.SelectedIndexChanged -= cmbAnalysis_SelectedIndexChanged; // Prevent double-entry when using keystroke.
      switch (cmbAnalysis.Text)
      {
        case "Search...":
        case "Kraken2...":
        case "Quast...":
        case "BBMap...":
        case "VFabricate...":
          if (lstSampleIDs.Items.Count == 0)
          {
            MessageBox.Show("Try again when sample IDs are loaded.", "Sample IDs not loaded", MessageBoxButtons.OK);
            cmbAnalysis.SelectedIndexChanged += cmbAnalysis_SelectedIndexChanged; // Reestablish hook.
            return;
          }
          break;
      }

      switch (cmbAnalysis.Text)
      {
        case "Centrifuge...":
          BioSeqCentrifuge frmCentrifuge = new BioSeqCentrifuge();
          DialogResult rc = frmCentrifuge.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("Centrifuge", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Artemis...":
          BioSeqArtemis frmArtemis = new BioSeqArtemis();
          rc = frmArtemis.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            // If the file is on the server, copy to local machine first.
            string path = DirectoryHelper.CleanPath(AppConfigHelper.ArtemisInputPath);
            try
            {
              if (AppConfigHelper.ArtemisInputPath.StartsWith("[S"))
              {
                path = @"C:\Temp\";
                TransferHelper.FileCopy(AppConfigHelper.ArtemisInputPath, "[L]" + path, true);
                path = path + Path.GetFileName(DirectoryHelper.CleanPath(AppConfigHelper.ArtemisInputPath));
              }
              InvokeArtemis(path);
              Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
              Cursor.Current = Cursors.Default;
              MessageBox.Show("Failed to read " + AppConfigHelper.ArtemisInputPath + ".\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
          }
          break;

        case "Bandage...":
          BioSeqBandage frmBandage = new BioSeqBandage();
          rc = frmBandage.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            // If the file is on the server, copy to local machine first.
            string path = DirectoryHelper.CleanPath(AppConfigHelper.BandageInputPath);
            try
            {
              if (AppConfigHelper.BandageInputPath.StartsWith("[S"))
              {
                path = @"C:\Temp\";
                TransferHelper.FileCopy(AppConfigHelper.BandageInputPath, "[L]" + path, true);
                path = path + Path.GetFileName(DirectoryHelper.CleanPath(AppConfigHelper.BandageInputPath));
              }
              InvokeBandage(path);
              Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
              Cursor.Current = Cursors.Default;
              MessageBox.Show("Failed to read " + AppConfigHelper.ArtemisInputPath + ".\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
          }
          break;

        case "CANS...":
          BioSeqCANS frmCANS = new BioSeqCANS();
          rc = frmCANS.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("CANS", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "FastQC...":
          BioSeqFastQC frmBioSeqFastQC = new BioSeqFastQC();
          rc = frmBioSeqFastQC.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("FastQC", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "MetaMaps...":
          BioSeqMetaMaps frmBioSeqMetaMaps = new BioSeqMetaMaps();
          rc = frmBioSeqMetaMaps.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("MetaMaps", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "MultiQC...":
          BioSeqMultiQC frmBioSeqMultiQC = new BioSeqMultiQC();
          rc = frmBioSeqMultiQC.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("MultiQC", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Nextstrain...":
          BioSeqNextstrain frmNextstrain = new BioSeqNextstrain();
          rc = frmNextstrain.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("Nextstrain", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Salmonella Serotyping...":
          BioSeqSalmonella frmSalmonella = new BioSeqSalmonella();
          rc = frmSalmonella.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            CreateNewTask("Salmonella", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Search...":
          BioSeqAnalysis frm = new BioSeqAnalysis(cmbAnalysis.Text, SampleList());
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Search for " + (AppConfigHelper.SampleChecked("Search") ? AppConfigHelper.SampleID("Search") : AppConfigHelper.InputPath("Search")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Search", memo, AppConfigHelper.CurrentDBName());
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

            CreateNewTask("InfluenzaA", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Build tree...":
          mnuBuildTree_Click(sender, e);
          break;

        case "Kraken2...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text, SampleList());
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Kraken2 analysis for " + (AppConfigHelper.SampleChecked("Kraken2") ? AppConfigHelper.SampleID("Kraken2") : AppConfigHelper.InputPath("Kraken2")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Kraken2", memo, AppConfigHelper.CurrentDBName());
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "Quast...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text, SampleList());
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "Quast analysis for " + (AppConfigHelper.SampleChecked("Quast") ? AppConfigHelper.SampleID("Quast") : AppConfigHelper.InputPath("Quast")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("Quast", memo, AppConfigHelper.CurrentDBName());
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "BBMap...":
          frm = new BioSeqAnalysis("BBMap", SampleList());
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "BBMap analysis for " + (AppConfigHelper.SampleChecked("BBMap") ? AppConfigHelper.SampleID("BBMap") : AppConfigHelper.InputPath("BBMap")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("BBMap", memo, AppConfigHelper.CurrentDBName());
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;

        case "VFabricate...":
          frm = new BioSeqAnalysis(cmbAnalysis.Text, SampleList());
          rc = frm.ShowDialog();
          if (rc == DialogResult.OK) // then the config has the specs 
          {
            Cursor.Current = Cursors.WaitCursor;
            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete); // Schedule a clean up task.

            string memo = string.IsNullOrEmpty(AppConfigHelper.TaskMemo) ?
                      "VFabricate analysis for " + (AppConfigHelper.SampleChecked("VFabricate") ? AppConfigHelper.SampleID("VFabricate") : AppConfigHelper.InputPath("VFabricate")) + "." :
                      AppConfigHelper.TaskMemo;

            CreateNewTask("VFabricate", memo, AppConfigHelper.CurrentDBName());
            UpdateNotificationStatus();  // Completion will arrive in the Notifications dialog.

            backgroundWorker.RunWorkerAsync();
            Cursor.Current = Cursors.Default;
          }
          break;
      }
      cmbAnalysis.SelectedIndex = 0; // Position back to -- Select analysis --.
      cmbAnalysis.SelectedIndexChanged += cmbAnalysis_SelectedIndexChanged; // Reestablish hook.
    }

    private void InvokeBandage(string dataPath)
    {
      string pathToBandage = AppConfigHelper.BandageInvocation();
      if (DownloadSoftware("Bandage", pathToBandage))
      {
        Process.Start(AppConfigHelper.BandageInvocation(), "load " + dataPath + " --draw");
      }
    }

    private void InvokeArtemis(string dataPath)
    {
      string pathToBandage = AppConfigHelper.ArtemisInvocation();
      if (DownloadSoftware("Artemis", pathToBandage))
      {
        Process.Start(AppConfigHelper.ArtemisInvocation(), dataPath);
      }
    }

    private static bool DownloadSoftware(string software, string pathToSoftware)
    {
      DirData dirData;
      string localPath, serverPath;
      List<DirData> fileNames, fileList, zeroLengthFileList;

      if (!File.Exists(pathToSoftware)) // then put it in place.
      {
        if (!Directory.Exists("C:\\Programs")) // Then this is not a managed computer and we need to create this folder.
        {
          Directory.CreateDirectory("C:\\Programs");
        }

        // Now if we can create a file in C:\Programs, this is unmanaged. Otherwise managed.
        try
        {
          if (!File.Exists(@"C:\Programs\unmanaged.txt"))
          {
            File.Create(@"C:\Programs\unmanaged.txt");
          }
        }
        catch (Exception ex) // Then this is a managed computer and will need support.
        {
          MessageBox.Show("This is a managed computer and will need help to install " + software + ". You will be contacted by Support.",
                                                                              software + " did not get installed.", MessageBoxButtons.OK);
          string s1 = Emailer.SendEmail("agb465@mail.usask.ca", "BioSeqDB User: Attempt to install " + software + ".",
                                                            "Assist " + AppConfigHelper.LoggedOnUser + " to install " + software + ".", null, null);
          if (!string.IsNullOrEmpty(s1))
          {
            Logger.Log.Debug("Email error: " + s1);
            //MessageBox.Show(s1, "ERROR", MessageBoxButtons.OK);
          }
          return false;
        }

        string fileName = "OpenJDK11U-jdk_x86-32_windows_hotspot_11.0.11_9.msi";
        localPath = "C:\\Temp\\"; // Target the C:\Temp folder.
        serverPath = "C:\\PDSFiles\\"; // This is where the <software> folder is stored on the server.

        if (software == "Artemis" && !File.Exists(localPath + fileName)) // Need to install Java runtime as well.
        {
          DialogResult rc = MessageBox.Show("In order to run Artemis on this computer, the Java runtime is required. Please respond to the prompts to install Java runtime.",
                                                                                "Click OK to install Java runtime, else Cancel", MessageBoxButtons.OKCancel);
          if (rc == DialogResult.Cancel)
          {
            return false;
          }

          fileNames = new List<DirData>();
          dirData = new DirData();
          dirData.Name = serverPath + fileName; // Copy this file from C:\PDSFiles\ on the server.
          dirData.FileType = "msi";
          dirData.Size = 155676672;
          fileNames.Add(dirData);

          zeroLengthFileList = new List<DirData>();

          TransferHelper.OpenModal = true;
          TransferHelper.AutoClose = true;
          TransferHelper.TCPCopy(serverPath, localPath, fileNames, zeroLengthFileList, false, software + " needs to be downloaded; please be patient."); // Download <software>
          if (!File.Exists(localPath + fileName)) // then put it in place.
          {
            MessageBox.Show("Cannot start " + software + " from " + pathToSoftware + ".", "Java runtime did not get downloaded.", MessageBoxButtons.OK);
            return false;
          }
          Process P = Process.Start(localPath + fileName);
          P.WaitForExit();
        }

        Cursor.Current = Cursors.WaitCursor;
        fileNames = new List<DirData>();
        dirData = new DirData();
        dirData.Name = software + "\\"; // Copy this folder from C:\PDSFiles\<software> on the server.
        dirData.FileType = "Folder";
        fileNames.Add(dirData);

        localPath = Path.GetDirectoryName(pathToSoftware); // Target the C:\Temp folder.
        localPath = Path.GetDirectoryName(localPath) + "\\"; // Knock off '<software>'
        // For managed computers, we cannot copy directly to c:\Programs, but we can run from there. For unmanaged, we are fine.
        serverPath = "C:\\PDSFiles\\"; // This is where the <software> folder is stored on the server.

        // Handle multi-select here (FileNames) and pass all selected items to fileList.
        fileList = BioSeqDBModel.Instance.FileList(serverPath, fileNames, false); // For download we look to the server for a list of files. 
        zeroLengthFileList = BioSeqDBModel.Instance.FileList(serverPath, fileNames, true); // For download we look to the server for a list of files. 

        TransferHelper.OpenModal = true;
        TransferHelper.AutoClose = true;
        TransferHelper.TCPCopy(serverPath, localPath, fileList, zeroLengthFileList, false, software + " needs to be downloaded; please be patient."); // Download <software>
      }

      Cursor.Current = Cursors.Default;
      if (!File.Exists(pathToSoftware)) // then put it in place.
      {
        MessageBox.Show("Cannot start " + software + " from " + pathToSoftware + ".", software + " did not get installed.", MessageBoxButtons.OK);
        return false;
      }
      return true;
    }

    private List<string> SampleList()
    {
      var list = new List<string>();
      foreach (var item in lstSampleIDs.Items)
      {
        list.Add(item.ToString());
      }

      return list;
    }

    private void backgroundWorker_CleanUserFolder_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      e.Result = ServiceCallHelper.CleanUserFolder(AppConfigHelper.LoggedOnUser);
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
        lblKipper.Text = "This backup is stored at " + AppConfigHelper.NormalizePathToWindows(db.KipperPath);
        if (!lblKipper.Text.EndsWith("\\"))
        {
          lblKipper.Text += "\\";
        }
        lblKipper.Text += db.KipperFilenamePrefix + ".";
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
      string path = AppConfigHelper.LastExplorerServerPath;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Server File Explorer...",
                                          DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path), "All files (*.*)|*.*",
                                                                                          null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.lastPath = LastPathCallback;
      //Explorer.frmExplorer.ReadOnly = true;  // Testing
      Explorer.frmExplorer.ReadOnly = AppConfigHelper.seqdbConfigGlobal.Users[AppConfigHelper.LoggedOnUser].ReadOnly;
      Explorer.frmExplorer.Show(); // Show modeless
    }

    private void LastPathCallback(string serverPath, string localPath)
    {
      AppConfigHelper.LastExplorerServerPath = serverPath;
      AppConfigHelper.LastExplorerLocalPath = localPath;
    }

    private void btnReferenceGenome_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.StandardReference); // We want an actual file, so don't append "\\".
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Path to genome reference file",
                               DirectoryHelper.IsServerPath(path), DirectoryHelper.CleanPath(path),
                               "All files (*.*)|*.*", null, AppConfigHelper.UbuntuPrefix());
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        AppConfigHelper.StandardReference = txtStandardReference.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
    }

    private void priorityDataBackupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BioSeqBackupOffsite frm = new BioSeqBackupOffsite();
      DialogResult rc = frm.ShowDialog();
      if (rc == DialogResult.OK)
      {
        int ct = 0;
        long bytes = 0;
        btnNotifications.Focus();
        Cursor.Current = Cursors.Default;
        Cursor.Current = Cursors.WaitCursor;
        BackupOffsiteParms backupOffsiteParms = BioSeqDBModel.Instance.PriorityBackupFileCount(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
        Cursor.Current = Cursors.WaitCursor;
        foreach (List<DirData> pathData in backupOffsiteParms.FilesToBackup.Values)
        {
          ct += pathData.Count;
          foreach (DirData dd in pathData)
          {
            bytes += dd.Size;
          }
        }

        int removeCt = backupOffsiteParms.FilesToRemoveFromBackup.Count;
        string removeMsg = ", ";
        if (removeCt > 0)
        {
          removeMsg += removeCt.ToString() + " files to remove from backup";
        }

        if (ct == 0 && removeCt == 0)
        {
          MessageBox.Show("Backup is up-to-date.", "No Backup Needed", MessageBoxButtons.OK);
        }
        else if (ct == 0)
        {
          if (MessageBox.Show("No files to back up" + removeMsg + ". Continue anyway?", "No Backup Needed", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            Cursor.Current = Cursors.WaitCursor;

            SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete);

            CreateNewTask("BackupOffsite", AppConfigHelper.TaskMemo, string.Empty);
            UpdateNotificationStatus();
            backgroundWorker.RunWorkerAsync();
          }
        }
        else if (MessageBox.Show(ct.ToString() + " files to back up in " + backupOffsiteParms.FilesToBackup.Count + " folders (" + (bytes / 1024 / 1024).ToString() +
                                                              "Mb)" + removeMsg + ". Ok to continue?", "Ready to backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          Cursor.Current = Cursors.WaitCursor;

          SeqDBHelper.backgroundTaskComplete += new SeqDBHelper.taskCompleteEvent(backupgroundTaskComplete);

          CreateNewTask("BackupOffsite", AppConfigHelper.TaskMemo, string.Empty);
          UpdateNotificationStatus();
          backgroundWorker.RunWorkerAsync();
        }
      }
      Cursor.Current = Cursors.Default;
    }
  }
}