using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using System;
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
        ServiceCallHelper.LoadConfig(AppConfigHelper.LoggedOnUser); // Get any changes made by the service.
      }

      BioSeqTask task = AppConfigHelper.TaskOfIndex(lstTasks.SelectedIndex);
      Cursor.Current = Cursors.Default;

      if (task == null)
      {
        MessageBox.Show("Task output is no longer available.", "Warning", MessageBoxButtons.OK);
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
            MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "VFabricate completed successfully. Result is in " +
                            destination + "\\" + sampleName + ".VFList.tsv", "Success", MessageBoxButtons.OK);

            destination = DirectoryHelper.CleanPath(destination);
            Process.Start(destination + "\\" + sampleName + ".VFList.tsv");
          }
          else
          {
            MessageBox.Show("VFabricate completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
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

            MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Quast completed successfully. Result is in the " +
                            AppConfigHelper.OutputPath("Quast") + "\\Quast" + sampleName + " folder.", "Success", MessageBoxButtons.OK);
          }
          else
          {
            MessageBox.Show("Quast completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
          }
          break;

        case "Kraken2":
          TaskCompletion(task, "Kraken2", "Kraken2 completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            // /usr/local/kraken2/kraken2 --db /data/referenceDB/minikraken2_v1_8GB/ --threads 64 --report kraken.aggregates.txt --use-names --output kraken.txt $contig
            // conda run -n refseq_masher-0.1.1 refseq_masher matches --output-type tab -o RefseqIdent.txt $contig
            string sampleName = string.Empty;
            if (AppConfigHelper.SampleChecked("Kraken2"))
            {
              sampleName = AppConfigHelper.SampleID("Kraken2");
            }
            string destination = AppConfigHelper.CopyResultFromServer(AppConfigHelper.OutputPath("Kraken2"), new string[] { "kraken.aggregates.txt" });

            destination = DirectoryHelper.CleanPath(destination);
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Kraken2 completed successfully. Result is in " +
                                                                             destination + ".", "Success", MessageBoxButtons.OK);
            if (File.Exists(destination + "kraken.aggregates.txt")) Process.Start(destination + "kraken.aggregates.txt");
          }
          else
          {
            MessageBox.Show("Kraken2 completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
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
          else
          {
            MessageBox.Show("BBMap completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 task.StandardOutput + Environment.NewLine + task.LastError, "Error", MessageBoxButtons.OK);
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
          else
          {
            MessageBox.Show(task.StandardOutput + Environment.NewLine + "Search completed with error code " + task.LastExitCode.ToString() + "." +
                          Environment.NewLine + Environment.NewLine + task.LastError, "Error", MessageBoxButtons.OK);
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
            MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "InfluenzaA completed successfully. Result is in the " +
                            AppConfigHelper.InfluenzaAOutputPath + " folder.", "Success", MessageBoxButtons.OK);
            if (IsServiceClass.IsService)
            {
              int filesCopied = 0;
              if (AppConfigHelper.InfluenzaAOutputPath.StartsWith("[L]")) // Output was created on server, to be stored on client.  [L]
              {
                // For each sample that was processed, there is a subfolder in the UserFolder on the server named after the sample name. 
                // That subfolder needs to be copied to the local output folder.
                foreach (string sampleName in AppConfigHelper.InfluenzaASamplesList.Keys)
                {
                  if (AppConfigHelper.InfluenzaASamplesList[sampleName].Substring(0, 1) == "1")
                  {
                    string sourceFolderName = "[S]" + AppConfigHelper.UserFolder() + sampleName + "\\";
                    //MessageBox.Show("Copy from " + sourceFolderName + " to " + AppConfigHelper.InfluenzaAOutputPath + "\\" + sampleName + "\\", "COPY", MessageBoxButtons.OK);
                    filesCopied += DirectoryHelper.FolderCopy(sourceFolderName, AppConfigHelper.InfluenzaAOutputPath + "\\" + sampleName + "\\");
                  }
                }
              }
              MessageBox.Show("Files copied: " + filesCopied.ToString(), "Files copied", MessageBoxButtons.OK);
            }
          }
          else
          {
            MessageBox.Show("InfluenzaA completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
          }
          break;

        case "Salmonella":
          TaskCompletion(task, "Salmonella", "Salmonella serotyping completed.");

          Cursor.Current = Cursors.Default;
          if (task.LastExitCode == 0)
          {
            MessageBox.Show(AppConfigHelper.StandardOutput + Environment.NewLine + "Salmonella serotyping completed successfully. Result is in " +
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
          else
          {
            MessageBox.Show("Salmonella completed with error code " + task.LastExitCode.ToString() + "." + Environment.NewLine + Environment.NewLine +
                                 AppConfigHelper.StandardOutput + Environment.NewLine + AppConfigHelper.LastError, "Error", MessageBoxButtons.OK);
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
    }

    private void TaskCompletion(BioSeqTask task, string taskName, string successMsg)
    {
      // Called by the user from the Push button when task status is Ready.
      string output = task.StandardOutput + Environment.NewLine + task.LastError;

      // Read and delete the output file from the command.
      string linuxCapture = string.Empty;
      string filename = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.LinuxHomeDirectory + "/output" + task.TaskID);
      if (File.Exists(filename))
      {
        linuxCapture = File.ReadAllText(filename);
        int residual = 6000;
        if (linuxCapture.Length > residual)
        {
          // Write the whole thing to a log file that can be opened separately.
          string tasklog = "C:\\Temp\\TaskLog.txt";
          File.WriteAllText(tasklog, linuxCapture);
          linuxCapture = "[Full text truncated; see saved log file " + tasklog + "]" + Environment.NewLine + Environment.NewLine +
                                          linuxCapture.Substring(linuxCapture.Length - residual);  // Display the last residual chars.
          Process.Start(tasklog);
        }
        File.Delete(filename);
      }

      SuccessDialog.MainInstruction = successMsg;
      SuccessDialog.Content = output;
      if (linuxCapture.Length > 0 && output.IndexOf(linuxCapture) == -1)
      {
        SuccessDialog.Content += (output.Length > 0 ? Environment.NewLine : string.Empty) + linuxCapture;
      }

      if (task.LastExitCode != 0)
      {
        SuccessDialog.WindowTitle = "ERROR";
        SuccessDialog.MainInstruction = taskName + " completed with error code " + task.LastExitCode.ToString() + ".";
      }
      SuccessDialog.ShowDialog(this);

      RemoveTask(false);
      StatusChangeEvent?.Invoke(this, null); // Notify parent we have a potential status change.
    }

    private void cmbTaskStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
      ClearFields();
      TaskFilter = cmbTaskStatusFilter.SelectedItem.ToString();
      RefreshTaskList(lstTasks.SelectedIndex);
    }
  }
}