using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqDBNotifications : Form
  {
    // Display outstanding notifications of tasks. 
    public delegate void infoevent(object sender, EventArgs e);
    public event infoevent StatusChangeEvent;
    public event infoevent FormClosedEvent;
    private Timer timer1;

    private string TaskFilter;

    public BioSeqDBNotifications()
    {
      InitializeComponent();

      TaskFilter = AppConfigHelper.TaskFilter;
      RefreshTaskList(0);
      InitTimer();
      cmbTaskStatusFilter.SelectedIndex = 0;

      if (Size.Width != 0)
      {
        Location = AppConfigHelper.NotificationLocation();
        if (Location.X <= 0)
        {
          Location = new Point(100, 100);
        }
        Size = AppConfigHelper.NotificationSize();
        if (Size.Height <= 0 || Size.Width <= 0)
        {
          Size = new Size(1000, 1000);
        }
      }
    }

    private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
    {
      // Show the details of the selected task and set enable status of push button.
      BioSeqTask task = AppConfigHelper.TaskOfIndex(lstTasks.SelectedIndex);
      //lblData.Text = task.TaskData;
      lblDatabase.Text = task.TaskDB;
      lblStatus.Text = task.TaskStatus;
      lblTime.Text = task.TaskTime.ToString("MMM d, yyyy H:mm");
      lblType.Text = task.TaskType;
      lblUser.Text = task.TaskUser;
      lblMemo.Text = task.TaskMemo;
      if (task.TaskComplete != DateTime.MinValue)
      {
        lblCompleted.Text = task.TaskComplete.ToString("MMM d, yyyy H:mm");
      }

      btnPushTask.Enabled = task.TaskStatus == "Ready";
      btnPushTask.BackgroundImage = btnPushTask.Enabled ? Properties.Resources.push : Properties.Resources.pushdull;
      lblStatus.BackColor = btnPushTask.Enabled ? Color.OrangeRed : lblType.BackColor;
    }

    private void ClearFields()
    {
      lblMemo.Text = lblDatabase.Text = lblStatus.Text = lblTime.Text = lblType.Text = lblUser.Text = lblCompleted.Text = string.Empty;
      lblStatus.BackColor = lblTime.BackColor;
      btnPushTask.Enabled = false;
      btnPushTask.BackgroundImage = Properties.Resources.pushdull;
    }

    private void btnDeleteTask_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("OK to delete the selected task?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        RemoveTask(true);
      }
    }

    private void RemoveTask(bool kill)
    {
      int index = lstTasks.SelectedIndex;
      lstTasks.SelectedIndexChanged -= new EventHandler(lstTasks_SelectedIndexChanged);
      lstTasks.Items.RemoveAt(index);

      AppConfigHelper.DeleteTask(index, kill);
      ClearFields();

      lstTasks.SelectedIndexChanged += new EventHandler(lstTasks_SelectedIndexChanged);
      if (lstTasks.Items.Count > 0)
      {
        if (index == lstTasks.Items.Count)
        {
          RefreshTaskList(index - 1);
        }
        else
        {
          RefreshTaskList(index);
        }
        btnDeleteTask.Enabled = true;
      }
      else
      {
        btnDeleteTask.Enabled = false;
      }
      StatusChangeEvent?.Invoke(this, null); // Notify parent we have a potential status change.
    }

    public void InitTimer()
    {
      timer1 = new Timer();
      timer1.Tick += new EventHandler(timer1_Tick);
      timer1.Interval = 20000; // in milliseconds
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      UIThreadRefresh(sender, e);
    }

    private void UIThreadRefresh(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      Application.DoEvents();
      RefreshTaskList(lstTasks.SelectedIndex);
      Cursor.Current = Cursors.Default;
    }

    private void BioSeqDBNotifications_FormClosing(object sender, FormClosingEventArgs e)
    {
      timer1.Stop();
      timer1 = null;

      AppConfigHelper.SaveNotificationUIForm(Location, Size);

      FormClosedEvent?.Invoke(this, null); // Notify parent we have closed shop (ModelessDialogEvent).
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      UIThreadRefresh(sender, e);
    }

    private void RefreshTaskList(int index)
    {
      lstTasks.Items.Clear();
      btnDeleteTask.Enabled = false;

      if (AppConfigHelper.TaskList.Count == 0)
      {
        return;
      }

      Cursor.Current = Cursors.WaitCursor;
      foreach (BioSeqTask task in AppConfigHelper.TaskList.Values)
      {
        if (string.IsNullOrEmpty(TaskFilter) || TaskFilter == "All" || TaskFilter == task.TaskStatus)
        {
          if (IsServiceClass.IsService)
          {
            string taskCompleted = BioSeqDBModel.Instance.TaskComplete(AppConfigHelper.LoggedOnUser, task.TaskID);
            if (!string.IsNullOrEmpty(taskCompleted))
            {
              BioSeqTask taskFromService = JsonSerializer.Deserialize<BioSeqTask>(taskCompleted);
              task.LastError = taskFromService.LastError;
              task.LastExitCode = taskFromService.LastExitCode;
              task.StandardOutput = taskFromService.StandardOutput;
              task.TaskComplete = taskFromService.TaskComplete;
              AppConfigHelper.BackgroundTaskComplete(task); // Mark task Ready and save config.
            }
          }
          task.TaskIndexInList = lstTasks.Items.Add(task.TaskType + ": " + task.TaskStatus + " " + task.TaskDB + " " + task.TaskUser);
        }
      }
      if (index < 0)
      {
        index = 0;
      }
      if (index >= lstTasks.Items.Count)
      {
        index = lstTasks.Items.Count - 1;
      }
      lstTasks.SelectedIndex = index;
      btnDeleteTask.Enabled = lstTasks.Items.Count > 0;

      StatusChangeEvent?.Invoke(this, null); // Notify parent we have a potential status change.
      Cursor.Current = Cursors.Default;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnPushTask_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      if (IsServiceClass.IsService)
      {
        //ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // Get any changes made by the service.
        AppConfigHelper.LastCommand = (string)BioSeqDBModel.Instance.UserConfigAttributeValue("LastCommand", AppConfigHelper.LoggedOnUser);
      }

      BioSeqTask task = AppConfigHelper.TaskOfIndex(lstTasks.SelectedIndex);
      Cursor.Current = Cursors.Default;

      if (task == null || task.LastExitCode == -999)
      {
        MessageBox.Show("Task output is no longer available but may have completed.", "Warning", MessageBoxButtons.OK);
        return;
      }

      switch (task.TaskType)
      {
        case "VFabricate":
          TaskCompletion(task, "VFabricate", "VFabricate completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            string sampleName = string.Empty;
            if (AppConfigHelper.SampleChecked("VFabricate"))
            {
              sampleName = AppConfigHelper.SampleID("VFabricate");
            }

            string destination = AppConfigHelper.CopyResultFromServer(AppConfigHelper.OutputPath("VFabricate"),
                                                     new string[] { sampleName + ".VFList.tsv" });
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "VFabricate completed successfully. Result is in " +
                            destination + "\\" + sampleName + ".VFList.tsv", "Success", MessageBoxButtons.OK);

            destination = DirectoryHelper.CleanPath(destination);
            Process.Start(destination + "\\" + sampleName + ".VFList.tsv");
          }
          break;

        case "Quast":
          TaskCompletion(task, "Quast", "Quast completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            string sampleName = string.Empty;
            if (AppConfigHelper.SampleChecked("Quast"))
            {
              sampleName = AppConfigHelper.SampleID("Quast");
            }

            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Quast completed successfully. Result is in the " +
                            AppConfigHelper.OutputPath("Quast") + "\\Quast" + sampleName + " folder.", "Success", MessageBoxButtons.OK);
          }
          break;

        case "Kraken2":
          TaskCompletion(task, "Kraken2", "Kraken2 completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            // /usr/local/kraken2/kraken2 --db /data/referenceDB/minikraken2_v1_8GB/ --threads 64 --report kraken.aggregates.txt --use-names --output kraken.txt $contig
            // conda run -n refseq_masher-0.1.1 refseq_masher matches --output-type tab -o RefseqIdent.txt $contig
            //string sampleName = string.Empty;
            //if (AppConfigHelper.SampleChecked("Kraken2"))
            //{
            //  sampleName = AppConfigHelper.SampleID("Kraken2");
            //}
            string destination = AppConfigHelper.CopyResultFromServer(AppConfigHelper.OutputPath("Kraken2"), new string[] { "kraken.aggregates.txt" });

            destination = DirectoryHelper.CleanPath(destination);
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Kraken2 completed successfully. Result is in " +
                                                                             destination + ".", "Success", MessageBoxButtons.OK);
            if (File.Exists(destination + "kraken.aggregates.txt")) Process.Start(destination + "kraken.aggregates.txt");
          }
          break;

        case "BBMap":
          TaskCompletion(task, "BBMap", "BBMap completed.");

          if (task.LastExitCode == 0)
          {
            string destination = AppConfigHelper.CopyResultFromServer(AppConfigHelper.OutputPath("BBMap"), 
                                          new string[] { "covhist.txt", "covstats.txt", "bincov.txt", "basecov.txt", "RefseqIdent.txt" });

            destination = DirectoryHelper.CleanPath(destination);
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "BBMap completed successfully. Result is in " +
                                                                             destination + ".", "Success", MessageBoxButtons.OK);
            if (File.Exists(destination + "covhist.txt")) Process.Start(destination + "covhist.txt");
            if (File.Exists(destination + "covstats.txt")) Process.Start(destination + "covstats.txt");
            if (File.Exists(destination + "bincov.txt")) Process.Start(destination + "bincov.txt");
            if (File.Exists(destination + "basecov.txt")) Process.Start(destination + "basecov.txt");
            if (File.Exists(destination + "RefseqIdent.txt")) Process.Start(destination + "RefseqIdent.txt");
          }
          break;

        case "Search":
          TaskCompletion(task, "Search", "Search completed.");

          Cursor.Current = Cursors.WaitCursor;
          ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // To retrieve StandardOutput and LastError.
          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            string filename = AppConfigHelper.OutputPath("Search") + "\\" + AppConfigHelper.SearchOutputSampleName() + ".txt";
            MessageBox.Show(task.StandardOutput + Environment.NewLine +
                    "Search completed successfully. Close this dialog to open the result file in " + filename + ".", "Success", MessageBoxButtons.OK);

            // If the output path is on the server, we need to copy it to the local Temp folder to display the results.
            // If the output path is on the local machine, we need to copy from the user folder on the server to the local destination.

            string destination = AppConfigHelper.CopyResultFromServer(AppConfigHelper.OutputPath("Search"), new string[] { AppConfigHelper.SearchOutputSampleName() + ".txt" });

            Process.Start(DirectoryHelper.CleanPath(destination) + AppConfigHelper.SearchOutputSampleName() + ".txt");
          }
          break;

        case "Assemble":
          TaskCompletion(task, "Assembly", "Assembly completed. If there are no errors, the results including the contig files are in the E:/data/staging folder on the server.");
          break;

        case "InfluenzaA":
          TaskCompletion(task, "InfluenzaA", "InfluenzaA completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            //MessageBox.Show(task.StandardOutput + Environment.NewLine + "InfluenzaA completed successfully. Result is in the " +
            //                AppConfigHelper.InfluenzaAOutputPath + " folder.", "Success", MessageBoxButtons.OK);
            if (IsServiceClass.IsService)
            {
              if (AppConfigHelper.InfluenzaAOutputPath.StartsWith("[L]")) // Output was created on server, to be stored on client.  [L]
              {
                // For each sample that was processed, there is a subfolder in the UserFolder on the server named after the sample name. 
                // That subfolder needs to be copied to the local output folder. Note that we only copy the <sample>\consensus contents.
                foreach (string sampleName in AppConfigHelper.InfluenzaASamplesList.Keys)
                {
                  if (AppConfigHelper.InfluenzaASamplesList[sampleName].Substring(0, 1) == "1")
                  {
                    string sourceFolderName = "[S]" + AppConfigHelper.UserFolder() + sampleName + "\\consensus\\";
                    Directory.CreateDirectory(DirectoryHelper.CleanPath(AppConfigHelper.InfluenzaAOutputPath) + "\\" + sampleName + "\\");
                    //Logger.Log.Debug("Copy from " + sourceFolderName + " to " + AppConfigHelper.InfluenzaAOutputPath + "\\");
                    DirectoryHelper.FolderCopy(sourceFolderName, AppConfigHelper.InfluenzaAOutputPath + "\\" + sampleName + "\\");
                  }
                }
              }
              MessageBox.Show(task.StandardOutput + Environment.NewLine + "Influenza A pipeline completed successfully. Results copied to " + 
                              AppConfigHelper.InfluenzaAOutputPath + "\\, including consensus fasta files in sample name subfolder[s].", 
                                                                                              "Files copied", MessageBoxButtons.OK);
            }
          }
          break;

        case "Salmonella":
          TaskCompletion(task, "Salmonella", "Salmonella serotyping completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Salmonella serotyping completed successfully. Result is in " +
                                                               AppConfigHelper.SalmonellaOutputPath, "Success", MessageBoxButtons.OK);
            if (IsServiceClass.IsService)
            {
              if (AppConfigHelper.SalmonellaOutputPath.StartsWith("[L]")) // Output was created on server, to be stored on client.  [L]
              {
                string sourceFolderName = "[S]" + AppConfigHelper.UserFolder() + "\\sistr_res_aggregate.csv";
                string destinationFolderName = AppConfigHelper.SalmonellaOutputPath;
                DirectoryHelper.FileCopy(sourceFolderName, destinationFolderName, true);
                File.Move(DirectoryHelper.CleanPath(destinationFolderName) + "\\sistr_res_aggregate.csv",
                          DirectoryHelper.CleanPath(destinationFolderName) + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");  // Rename
                Process.Start(DirectoryHelper.CleanPath(destinationFolderName) + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");
              }
              else // Rename on server.
              {
                DirectoryHelper.FileMove(AppConfigHelper.SalmonellaOutputPath + "\\sistr_res_aggregate.csv",
                                         AppConfigHelper.SalmonellaOutputPath + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");
              }
            }
          }
          break;

        case "Nextstrain":
          TaskCompletion(task, "Nextstrain", "Nextstrain phylogenetic processing completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            NextstrainProfile nextstrainProfile = AppConfigHelper.GetNextstrainProfile(); // for current database.
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Nextstrain completed successfully. Result is in " + 
                                                                 nextstrainProfile.OuputPath, "Success", MessageBoxButtons.OK);
            if (IsServiceClass.IsService)
            {
              //string browser = string.Empty;
              //RegistryKey key = null;
              //try
              //{
              //  key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command");
              //  if (key != null)
              //  {
              //    // Get default Browser
              //    browser = key.GetValue(null).ToString().ToLower().Trim(new[] { '"' });
              //  }
              //  if (!browser.EndsWith("exe"))
              //  {
              //    //Remove all after the ".exe"
              //    browser = browser.Substring(0, browser.LastIndexOf(".exe", StringComparison.InvariantCultureIgnoreCase) + 4);
              //  }
              //}
              //finally
              //{
              //  if (key != null)
              //  {
              //    key.Close();
              //  }
              //}

              // Open the browser.
              Process proc = Process.Start("http://localhost:4000/ncov/global");

              //if (nextstrainProfile.OuputPath.StartsWith("[L]")) // Output was created on server, to be stored on client.  [L]
              //{
              //  string sourceFolderName = "[S]" + AppConfigHelper.UserFolder() + "\\ncov_global.json";
              //  string destinationFolderName = nextstrainProfile.OuputPath;
              //  DirectoryHelper.FileCopy(sourceFolderName, destinationFolderName, true);
              //  File.Move(DirectoryHelper.CleanPath(destinationFolderName) + "\\ncov_global.json",
              //            DirectoryHelper.CleanPath(destinationFolderName) + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");  // Rename
              //  Process.Start(DirectoryHelper.CleanPath(destinationFolderName) + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");
              //}
              //else // Rename on server.
              //{
              //  DirectoryHelper.FileMove(nextstrainProfile.OuputPath + "\\sistr_res_aggregate.csv",
              //                           nextstrainProfile.OuputPath + "\\sistr_res_aggregate" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv");
              //}
            }
          }
          break;

        case "BuildTree":
          TaskCompletion(task, "BuildTree", "BuildTree completed. Close this dialog to open the result file.");

          //Logger.Log.Debug("ExitCode=" + task.LastExitCode.ToString() + @" Write to c:\temp\commandline.txt: open file='" + 
          //                                    AppConfigHelper.BuildTreeOutputPath() + "\\tree.nwk';" + Environment.NewLine);
          if (!Directory.Exists("C:\\Temp"))
          {
            Directory.CreateDirectory("C:\\Temp");
          }

          string dendroscopePath = @"C:\Temp\";
          if (IsServiceClass.IsService)
          {
            // For service, copy the tree.nwk from wherever it was stored to C:\Temp. If it is on the server, call the service to copy it.
            // If it is on the local machine, do a File.Copy.    
            string sourceFolderName = "[S]" + AppConfigHelper.UserFolder();
            string destinationFolderName = AppConfigHelper.BuildTreeOutputPath() + "\\";

            Logger.Log.Debug("btnPushTask: FileCopy " + sourceFolderName + "tree.nwk to " + destinationFolderName);
            Logger.Log.Debug("btnPushTask: DirectoryHelper destination: " +
                  AppConfigHelper.GetDirectoryName(DirectoryHelper.CleanPath(destinationFolderName + "\\")) + "\\" +
                  Path.GetFileName(DirectoryHelper.CleanPath(sourceFolderName)) + "tree.nwk");

            if (destinationFolderName.StartsWith("[L]")) // Buildtree output was created on server, to be stored on client.  [L]
            {
              DirectoryHelper.FileCopy(sourceFolderName + "tree.nwk", destinationFolderName, true);
              DirectoryHelper.FileCopy(sourceFolderName + "metadata_microreact.csv", destinationFolderName, true);
              dendroscopePath = DirectoryHelper.CleanPath(destinationFolderName);
              Logger.Log.Debug("btnPushTask: dendroscopePath: " + dendroscopePath);
            }
            else  // Buildtree output was created on server, to be stored on server.  [S]
            {
              DirectoryHelper.FileCopy(sourceFolderName + "tree.nwk", destinationFolderName, true);
              DirectoryHelper.FileCopy(sourceFolderName + "metadata_microreact.csv", destinationFolderName, true);

              // Also copy to local Temp folder for Dendroscope to pick up.
              DirectoryHelper.FileCopy(sourceFolderName + "tree.nwk", @"[L]C:\Temp\", true);
              DirectoryHelper.FileCopy(sourceFolderName + "metadata_microreact.csv", @"[L]C:\Temp\", true);
            }
          }
          else
          {
            if (DirectoryHelper.CleanPath(AppConfigHelper.BuildTreeOutputPath()) != @"C:\Temp")
            {
              if (File.Exists(@"C:\Temp\tree.nwk"))
              {
                File.Delete(@"C:\Temp\tree.nwk");
              }
              File.Copy(DirectoryHelper.CleanPath(AppConfigHelper.BuildTreeOutputPath() + "\\tree.nwk"), @"C:\Temp\tree.nwk", true);
            }
            if (File.Exists(@"C:\Temp\metadata_microreact.csv"))
            {
              File.Delete(@"C:\Temp\metadata_microreact.csv");
            }
            File.Copy(DirectoryHelper.CleanPath(AppConfigHelper.BuildTreeOutputPath() + "\\metadata_microreact.csv"), @"C:\Temp\metadata_microreact.csv", true);
          }

          File.WriteAllText("C:\\Temp\\commandline.txt", @"open file='" + dendroscopePath + "tree.nwk';" + Environment.NewLine);

          if (task.LastExitCode == 0)
          {
            // Invoke Dendroscope to visualize tree.  c:\\Temp\\commandine.txt contains the line:
            // open file='C:\Temp\Save\tree.nwk';
            try
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(AppConfigHelper.PathToDendroscope(), "-g -c c:\\Temp\\commandline.txt");
              Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
              MessageBox.Show("Dendroscope needs to be installed to view the result. Check path " + AppConfigHelper.PathToDendroscope() + 
                                  Environment.NewLine + Environment.NewLine + ex.ToString(), "INSTALL DENDROSCOPE", MessageBoxButtons.OK);
            }
          }
          break;
      }
      UIThreadRefresh(sender, e);
    }

    private void TaskCompletion(BioSeqTask task, string taskName, string successMsg)
    {
      // Called by the user from the Push button when task status is Ready.
      Cursor.Current = Cursors.WaitCursor;

      TimeSpan duration = task.TaskComplete - task.TaskTime;

      string db = string.IsNullOrEmpty(task.TaskDB) ? string.Empty : "Sequence database: " + task.TaskDB;
      string memo = string.IsNullOrEmpty(task.TaskMemo) ? string.Empty : "Memo: " + task.TaskMemo;
      string subject = "Task completed: " + taskName + " at " + task.TaskComplete.ToString("MMM d, yyyy HH:mm") + " after " + 
                        duration.TotalMinutes.ToString("#.0") + " minutes." + Environment.NewLine + (db + " " + Environment.NewLine + memo).Trim();
      string message = subject + Environment.NewLine + AppConfigHelper.LastCommand + Environment.NewLine;
      subject = subject.Replace(Environment.NewLine, "  ");
      List<string> attachments = new List<string>();
      string output = task.StandardOutput + Environment.NewLine + task.LastError;
      message += "Standard output: " + output + Environment.NewLine;

      // Read and delete the output file from the command.
      string linuxCapture = string.Empty;
      string filename = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.LinuxHomeDirectory + "/output" + task.TaskID);
      if (DirectoryHelper.FileExists("[S]" + filename))
      {
        linuxCapture = BioSeqDBModel.Instance.ReadAllText(filename, AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()); // We know it is on the server.
        int residual = 6000;
        if (linuxCapture.Length > residual)
        {
          // Write the whole thing to a log file that can be opened separately.
          string tasklog = "C:\\Temp\\TaskLog.txt";
          File.WriteAllText(tasklog, linuxCapture);
          linuxCapture = "[Full text truncated; see saved log file " + tasklog + "]" + Environment.NewLine + Environment.NewLine +
                                          linuxCapture.Substring(linuxCapture.Length - residual);  // Display the last residual chars.
          Process.Start(tasklog);
          attachments.Add(tasklog);
        }
      }

      SuccessDialog.MainInstruction = successMsg;
      SuccessDialog.Content = output;
      if (linuxCapture.Length > 0 && output.IndexOf(linuxCapture) == -1)
      {
        SuccessDialog.Content += (output.Length > 0 ? Environment.NewLine : string.Empty) + linuxCapture;
      }

      if (task.LastExitCode != 0 && task.LastExitCode != -999)  // We handle -999 elsewhere (lost task status after completion, likely because BioSeqDB was restarted).
      {
        SuccessDialog.WindowTitle = "ERROR";
        SuccessDialog.MainInstruction = taskName + " completed with error code " + task.LastExitCode.ToString() + ".";
        message += SuccessDialog.MainInstruction + Environment.NewLine;
      }
      SuccessDialog.ShowDialog(this);

      RemoveTask(false); // Do this as soon as possible to reflect the user's closing of the dialog.
      StatusChangeEvent?.Invoke(this, null); // Notify parent we have a potential status change.

      message += linuxCapture;
      User user = AppConfigHelper.seqdbConfigGlobal.Users[AppConfigHelper.LoggedOnUser];
      if (user.EmailNotifications)
      {
        string s1 = Emailer.SendEmail(AppConfigHelper.LoggedOnUser + "@mail.usask.ca", "BioSeqDB User: " + task.TaskUser + " " + subject, message, attachments, null);
        if (!string.IsNullOrEmpty(s1))
        {
          Logger.Log.Debug("Email error: " + s1);
          //MessageBox.Show(s1, "ERROR", MessageBoxButtons.OK);
        }
      }

      if (File.Exists(filename)) // Must do after email since it might be attached.
      {
        File.Delete(filename);
      }
      Cursor.Current = Cursors.Default;
    }

    private void cmbTaskStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
      ClearFields();
      TaskFilter = cmbTaskStatusFilter.SelectedItem.ToString();
      RefreshTaskList(lstTasks.SelectedIndex);
    }
  }
}