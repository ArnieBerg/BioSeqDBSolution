using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using BioSeqDBTransferData;
using BioSeqDBUserCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace BioSeqDB
{
  public static class AppConfigHelper
  {
    public static BioSeqDBConfig seqdbConfig { get; set; }
    public static BioSeqDBConfig seqdbConfigGlobal { get; set; }

    public static string localAppDataPath;

    private static string loggedOnUser = string.Empty;

    public static NextstrainProfile GetNextstrainProfile()
    {
      SeqDB db = seqdbConfig.Current();
      NextstrainProfile nextstrainProfile = db.NextstrainProfile == null ? new NextstrainProfile() : db.NextstrainProfile;
      nextstrainProfile.SNPCutoff = nextstrainProfile.SNPCutoff == 0 ? 25 : nextstrainProfile.SNPCutoff;
      nextstrainProfile.MinGenomeLength = nextstrainProfile.MinGenomeLength == 0 ? 27000 : nextstrainProfile.MinGenomeLength;
      nextstrainProfile.MaskFromBeginning = nextstrainProfile.MaskFromBeginning == 0 ? 1 : nextstrainProfile.MaskFromBeginning;
      nextstrainProfile.MaskFromEnd = nextstrainProfile.MaskFromEnd == 0 ? 1 : nextstrainProfile.MaskFromEnd;
      nextstrainProfile.NumberOfThreads = nextstrainProfile.NumberOfThreads == 0 ? 2 : nextstrainProfile.NumberOfThreads;

      return nextstrainProfile;
    }

    internal static void MultiQCParms(string Output, string Input, string Memo)
    {
      seqdbConfig.MultiQCOutputPath = Output;
      seqdbConfig.MultiQCInputPath = Input;
      seqdbConfig.TaskMemo = Memo;
      SaveConfig();
    }

    internal static void FastQCParms(string Output, string Input, string Memo, string Threads, bool Consolidate, bool MultiQC)
    {
      seqdbConfig.FastQCOutputPath = Output;
      seqdbConfig.FastQCInputPath = Input;
      seqdbConfig.FastQCThreads = int.Parse(Threads);
      seqdbConfig.FastQCConsolidate = Consolidate;
      seqdbConfig.FastQCMultiQC = MultiQC;
      seqdbConfig.TaskMemo = Memo;
      SaveConfig();
    }

    public static string LoggedOnUser
    {
      get { return loggedOnUser.Length == 0 ? loggedOnUser : loggedOnUser.Substring(0, loggedOnUser.Length - 1); }

      set
      {
        if (value != string.Empty)
        {
          Debug.Assert(value != string.Empty);
          loggedOnUser = value + "_";
          LoadConfig(loggedOnUser);

          seqdbConfigGlobal.Users[value].LoginTime = seqdbConfigGlobal.Users[value].LastActiveTime = DateTime.Now;          
          SaveConfigGlobal(); // This information will eventually get to the service for permanent recording.

          // Also make sure we have a copy of every database description.
          Dictionary<string, SeqDB> seqDBs = seqdbConfigGlobal.seqDBs; // Make sure we know about all the databases as well.

          foreach (SeqDB seqdb in seqDBs.Values) // These are global values.
          {
            if (!seqdbConfig.seqDBs.ContainsKey(seqdb.DBName))
            {
              seqdbConfig.seqDBs.Add(seqdb.DBName, seqdb); // Add to local values.
            }
          }

          // To be complete, we should also remove any local database description that no longer exists.
          List<string> dbsToRemove = new List<string>();
          foreach (SeqDB seqdb in seqdbConfig.seqDBs.Values)
          {
            if (!seqDBs.ContainsKey(seqdb.DBName)) // No longer in global config.
            {
              dbsToRemove.Add(seqdb.DBName);
            }
          }

          foreach (string dbName in dbsToRemove)
          {
            seqdbConfig.seqDBs.Remove(dbName);
          }
          seqdbConfig.LastDBSelected = CurrentDBName();
        }
      }
    }

    public static void Logout()
    {
      seqdbConfigGlobal.Users[LoggedOnUser].LogoutTime = DateTime.Now; // This information will eventually get to the service for permanent recording.
      SaveConfigGlobal();
    }

    internal static void CANSParms(string ReferencePath, string OutputPath, string Memo, bool Trim, string Threads, string ExpectedLength, 
                                                                      string ReadLengthDeviation, string TargetCoverage, string Model)
    {
      seqdbConfig.CANSReferencePath = ReferencePath; 
      seqdbConfig.CANSChooseTrim = Trim;
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.CANSOutputPath = OutputPath;
      seqdbConfig.CANSThreads = int.Parse(Threads);
      seqdbConfig.CANSModel = Model;
      seqdbConfig.CANSExpectedLength = string.IsNullOrEmpty(ExpectedLength) ? 0 : int.Parse(ExpectedLength);
      seqdbConfig.CANSReadLengthDeviation = string.IsNullOrEmpty(ReadLengthDeviation) ? 0 : int.Parse(ReadLengthDeviation);
      seqdbConfig.CANSTargetCoverage = string.IsNullOrEmpty(TargetCoverage) ? 0 : int.Parse(TargetCoverage);
      SaveConfig();
    }

    //public static void StartTimer()
    //{
    //  Task task = new Task(() =>
    //  {
    //    while (true)
    //    {
    //      Task.Delay(10000).Wait();
    //      UpdateTaskNotifications();
    //    }
    //  });
    //  task.Start();
    //}

    public static int MaxTaskID()
    {
      int maxID = seqdbConfig.LastTaskID;
      foreach (BioSeqTask task in seqdbConfig.Tasks.Values)
      {
        if (int.Parse(task.TaskID) > maxID)
        {
          maxID = int.Parse(task.TaskID);
        }
      }
      return maxID;
    }

    public static bool ShowDetail
    {
      get { return seqdbConfig.ShowDetailedList; }
      set { seqdbConfig.ShowDetailedList = value; SaveConfig(); }
    }

    internal static void NextstrainParms(NextstrainProfile nextstrainProfile, string memo)
    {
      SeqDB db = seqdbConfig.Current();
      db.NextstrainProfile = nextstrainProfile;
      seqdbConfig.TaskMemo = memo;
      SaveConfig();
    }

    internal static string BandageInvocation()
    {
      string path = seqdbConfigGlobal.BandageInvocation ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.BandageInvocation = @"C:\Programs\Bandage\Bandage.exe";
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.BandageInvocation ?? string.Empty;
    }

    internal static string ArtemisInvocation()
    {
      string path = seqdbConfigGlobal.ArtemisInvocation ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.ArtemisInvocation = @"C:\Programs\artemis\artemis.jar";
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.ArtemisInvocation ?? string.Empty;
    }

    public static string LinuxHomeDirectory
    {
      get { return seqdbConfigGlobal.LinuxHomeDirectory ?? "/~"; }
      set { seqdbConfigGlobal.LinuxHomeDirectory = value ?? "/~"; SaveConfigGlobal(); }
    }

    public static string TaskFilter
    {
      get { return seqdbConfig.TaskFilter; }
      set { seqdbConfig.TaskFilter = value; SaveConfig(); }
    }

    public static string LIMSDuplicate(string CaseNumber, string LIMSTestID, string LIMSSampleID)
    {
      // We check to see if we already have a duplicate LIMS identifier, and if so, return the information in msg.
      string msg = string.Empty;

      if ((CaseNumber + LIMSTestID + LIMSSampleID).Length > 0)
      {
        // The structure of the file:
        //    >BRD2017_0001 PDS2020001;3;1
        //    >BRD2017_0002 PDS2020001;3;2
        //    >BRD2017_0003 PDS2020002;1;1

        Dictionary<string, string> LIMSList = ServiceCallHelper.ReadLIMSData(LoggedOnUser, JsonConfig());

        string key = CaseNumber + ";" + LIMSTestID + ";" + LIMSSampleID;
        if (LIMSList.ContainsKey(key))
        {
          msg = "Case number " + CaseNumber + ", Test ID " + LIMSTestID + ", Sample ID " + LIMSSampleID +
                                      " has already been assigned to sample " + LIMSList[key] + ". Do you want to replace it?";
        }
      }
      return msg;
    }

    public static string QuerySampleConfig()
    {
      string config = "SampleName,SamplePath" + Environment.NewLine;
      // Update config to reflect selection.
      List<string> QuerySamples = seqdbConfig.AssembleQueryListRAFlye;
      if (AssembleTrinity())
      {
        QuerySamples = seqdbConfig.AssembleQueryListTrinity;
      }
      if (AssembleTracy())
      {
        QuerySamples = seqdbConfig.AssembleQueryListTracy;
      }

      if (QuerySamples != null)
      {
        foreach (string query in QuerySamples)
        {
          if (query.StartsWith("1"))
          {
            // The last subfolder becomes the sample name.
            string q = query;
            if (q.EndsWith("\\"))
            {
              q = q.Substring(0, q.Length - 1);
            }
            config += q.Substring(q.LastIndexOf("\\") + 1) + "," + NormalizePathToLinux(DirectoryHelper.CleanPath(q.Substring(1))) + Environment.NewLine;
          }
        }
      }
      return config;
    }

    public static Dictionary<string, string> ReadLIMSData()
    {
      Dictionary<string, string> LIMSList = new Dictionary<string, string>(); // Key is LIMS identifiers.

      string path = GetDirectoryName(NormalizePathToWindows(DirectoryHelper.CleanPath(CurrentDBPath())));
      string filename = path + "\\" + CurrentDBName() + "_LIMS.fasta";
      if (!File.Exists(filename))
      {
        File.Create(filename).Close();
      }

      string LIMSIDs = File.ReadAllText(filename).Replace("\r", string.Empty);
      string[] IDs = LIMSIDs.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string ID in IDs)
      {
        LIMSList.Add(ID.Substring(ID.IndexOf(" ") + 1), ID.Substring(1, ID.IndexOf(" ") - 1));
      }

      return LIMSList;
    }

    public static void WriteLIMSData(Dictionary<string, string> LIMSList)
    {
      string path = GetDirectoryName(NormalizePathToWindows(DirectoryHelper.CleanPath(CurrentDBPath())));
      string filename = path + "\\" + CurrentDBName() + "_LIMS.fasta";

      using (StreamWriter sw = new StreamWriter(filename))
      {
        foreach (string key in LIMSList.Keys)
        {
          sw.WriteLine(">" + LIMSList[key] + " " + key);
        }
      }
    }

    public static string LastCommand
    {
      get { return seqdbConfig.LastCommand; }
      set { seqdbConfig.LastCommand = value; SaveConfig(); }
    }

    public static BioSeqTask TaskOfIndex(int selectedIndex)
    {
      foreach (BioSeqTask task in seqdbConfig.Tasks.Values)
      {
        if (task.TaskIndexInList == selectedIndex)
        {
          return task;
        }
      }

      return null;
    }

    public static BioSeqTask TaskOfID(int ID)
    {
      foreach (BioSeqTask task in seqdbConfig.Tasks.Values)
      {
        if (task.TaskID == ID.ToString())
        {
          return task;
        }
      }

      return null;
    }

    public static void DeleteTask(int index, bool kill)
    {
      BioSeqTask task = TaskOfIndex(index); // Task to delete.
      if (kill)
      {
        task.TaskTimeout = 5;
        seqdbConfig.TaskToDelete = task;
        try
        {
          ServiceCallHelper.KillTask(LoggedOnUser, JsonConfig()); // This gets rid of Ubuntu background task, if possible.
        }
        catch (Exception ex)
        {
          // Ignore timeout, couldn't remove Ubuntu process.
        }
      }

      seqdbConfig.Tasks.Remove(task.TaskID);
      SaveConfig();
    }

    public static string LastError
    {
      get { return seqdbConfig.LastError; }
      set { seqdbConfig.LastError = value; SaveConfig(); }
    }

    public static int LastExitCode
    {
      get { return seqdbConfig.LastExitCode; }
      set { seqdbConfig.LastExitCode = value; SaveConfig(); }
    }

    public static string StandardOutput
    {
      get { return seqdbConfig.StandardOutput; }
      set { seqdbConfig.StandardOutput = value; SaveConfig(); }
    }

    public static string LastKipperList
    {
      get { return seqdbConfigGlobal.LastKipperList; }
      set { seqdbConfigGlobal.LastKipperList = value; SaveConfigGlobal(); }
    }

    public static string LastUser
    {
      get { return seqdbConfigGlobal.LastUser; }
      set { seqdbConfigGlobal.LastUser = value; SaveConfigGlobal(); }
    }

    public static int LastTaskID
    {
      get { return seqdbConfig.LastTaskID; }
      set { seqdbConfig.LastTaskID = value; SaveConfig(); }
    }

    public static string AssembleLastQueryFolder
    {
      get
      {
        return seqdbConfig.AssembleLastQueryFolder ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleLastQueryFolder = value;
        SaveConfig();
      }
    }

    public static string AssembleLastQueryFolderTrinity
    {
      get
      {
        return seqdbConfig.AssembleLastQueryFolderTrinity ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleLastQueryFolderTrinity = value;
        SaveConfig();
      }
    }

    public static string AssembleLastQueryFolderTracy
    {
      get
      {
        return seqdbConfig.AssembleLastQueryFolderTracy ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleLastQueryFolderTracy = value;
        SaveConfig();
      }
    }

    public static string AssembleVFGeneXRef
    {
      get
      {
        return seqdbConfig.AssembleVFGeneXRef ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleVFGeneXRef = value;
        SaveConfig();
      }
    }

    public static string AssembleTracyReference
    {
      get
      {
        return seqdbConfig.AssembleTracyReference ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleTracyReference = value;
        SaveConfig();
      }
    }

    public static string AssembleVirusReference
    {
      get
      {
        return seqdbConfig.AssembleVirusReference ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleVirusReference = value;
        SaveConfig();
      }
    }

    internal static void RebuildBackupFolderList(Dictionary<string, BackupFolderDetails>  BackupFolderList, Dictionary<string, string> folderList)
    {
      if (BackupFolderList == null)
      {
        BackupFolderList = new Dictionary<string, BackupFolderDetails>();
      }
      foreach (string folder in folderList.Keys)
      {
        if (!BackupFolderList.ContainsKey(folder))
        {
          BackupFolderDetails backupFolderDetails = new BackupFolderDetails();
          backupFolderDetails.ID = folder;
          backupFolderDetails.Checked = true;
          backupFolderDetails.FolderPath = folderList[folder].Substring(1);
          backupFolderDetails.Compress = false;
          backupFolderDetails.RetentionDate = DateTime.MinValue;
          BackupFolderList.Add(folder, backupFolderDetails);
        }
      }
    }

    public static string AssembleHostReference
    {
      get
      {
        return seqdbConfig.AssembleHostReference ?? string.Empty;
      }
      set
      {
        seqdbConfig.AssembleHostReference = value;
        SaveConfig();
      }
    }

    public static void AddTask(BioSeqTask task)
    {
      seqdbConfig.Tasks.Add(task.TaskID, task);
      seqdbConfig.LastTaskID = int.Parse(task.TaskID);
      seqdbConfig.TaskToDelete = task; // For the benefit of WSLProxy if task is deleted from Notifications.
      SaveConfig();
    }

    public static string BuildTreeLastQueryFolder
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeLastQueryFolder ?? string.Empty;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeLastQueryFolder = value;
        SaveConfig();
      }
    }
    
    //public static string PathToServerAppsettings
    //{
    //  get
    //  {
    //    return seqdbConfig.PathToServerAppsettings;
    //  }
    //  set
    //  {
    //    seqdbConfig.PathToServerAppsettings = value;
    //    if (string.IsNullOrEmpty(value))
    //    {
    //      seqdbConfig.PathToServerAppsettings = @"C:\BioSeqDB\Service";
    //    }
    //    SaveConfig();
    //  }
    //}

    public static bool AssembleFastPolish()
    {
      return seqdbConfig.AssembleFastPolish;
    }

    public static bool AssembleBBmap()
    {
      return seqdbConfig.AssembleBBMap;
    }

    public static string CopyResultFromServer(string outputPath, string[] names, bool isFiles = true, string userSubFolder = "")
    {
      // If the output path is on the server, we need to copy it to the local Temp folder to display the results.
      // If the output path is on the local machine, we need to copy from the user folder on the server to the local destination.
      // If filenames is empty, outputPath is a folder to copy.
      // userSubFolder is the optional name of the folder in the user folder if that is where the source is.
      string destination = @"[L]C:\Temp\"; // Copy from UserFolder() on server to C:\Temp.
      string source = outputPath + "\\";
      if (outputPath.StartsWith("[L]"))  // Copy from user folder on server to OutputPath.
      {
        destination = source;
        source = "[S]" + UserFolder() + userSubFolder;
      }

      if (!isFiles) // Copy folders.
      {
        foreach (string foldername in names)
        {
          Logger.Log.Debug("Copy " + foldername + " from " + source + " to " + destination);
          try
          {
            //DirectoryHelper.FolderCopy(source + foldername, destination);
            TransferHelper.FolderCopy(source + foldername, destination);
          }
          catch (Exception ex) // Fail on unsuccessful folders but continue with the rest.
          {
            Logger.Log.Debug("Failed to copy " + foldername + " from " + source + " to " + destination + ". Error: " + ex.ToString());
            throw;
          }
        }
      }
      else // Copy files.
      {
        foreach (string filename in names)
        {
          Logger.Log.Debug("Copy " + filename + " from " + source + " to " + destination);
          try
          {
            TransferHelper.FileCopy(source + filename, destination, true);
          }
          catch (Exception ex) // Fail on unsuccessful files but continue with the rest.
          {
            Logger.Log.Debug("Failed to copy " + filename + " from " + source + " to " + destination + ". Error: " + ex.ToString());
            throw;
          }
        }
      }
      return destination;
    }

    public static bool AssembleVFabricate()
    {
      return seqdbConfig.AssembleVFabricate;
    }

    public static bool AssembleKraken2()
    {
      return seqdbConfig.AssembleKraken2;
    }

    public static bool AssembleQuast()
    {
      return seqdbConfig.AssembleQuast;
    }

    public static void SampleChecked(string analysis, bool isChecked)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          db.KrakenSampleChecked = isChecked;
          break;
        case "BBMap":
          db.BBMapSampleChecked = isChecked;
          break;
        case "VFabricate":
          db.VFabricateSampleChecked = isChecked;
          break;
        case "Quast":
          db.QuastSampleChecked = isChecked;
          break;
        case "Search":
          db.SearchSampleChecked = isChecked;
          break;
      }

      SaveConfig();
    }

    public static bool SampleChecked(string analysis)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          return db.KrakenSampleChecked;
        case "BBMap":
          return db.BBMapSampleChecked;
        case "VFabricate":
          return db.VFabricateSampleChecked;
        case "Quast":
          return db.QuastSampleChecked;
        case "Search":
          return db.SearchSampleChecked;
      }
      return false;
    }

    public static bool AssembleFlye()
    {
      return seqdbConfig.AssembleFlye;
    }

    public static bool AssembleRA()
    {
      return seqdbConfig.AssembleRA;
    }

    public static bool AssembleTrinity()
    {
      return seqdbConfig.AssembleTrinity;
    }

    public static bool AssembleTracy()
    {
      return seqdbConfig.AssembleTracy;
    }

    public static bool BuildTreeFastTree()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeFastTree;
    }

    public static string Build_DBName()
    {
      SeqDB db = seqdbConfig.Current();
      return db.Build_DBName;
    }

    public static int BuildTreeLinkage // enum: 0-threshold 1-tophits 2-cluster
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeLinkage;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeLinkage = value;
      }
    }

    public static int TaskCount()
    {
      return seqdbConfig.Tasks.Count;
    }

    public static string Build_DBInput()
    {
      SeqDB db = seqdbConfig.Current();
      return db.Build_DBInput;
    }

    public static string SearchSampleID()
    {
      SeqDB db = seqdbConfig.Current();
      // Search never uses the sample ID selected in the listbox, as it is looking for a NEW sample ID.
      return db.SearchSampleID ?? string.Empty;
    }

    public static string SearchOutputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchOutputPath ?? string.Empty;
    }

    public static string SearchOutputSampleName()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchOutputSampleName ?? string.Empty;
    }

    public static string SearchInputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchInputPath ?? string.Empty;
    }

    public static string BBMapFastqPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BBMapFastqPath ?? string.Empty;
    }

    internal static void MetaMapsParms(string ReferencePath, string OutputPath, string InputPath, string Memo, string Threads, 
                                                    string MinReadLength, string MaxMemory, string MaxReads, bool OnlyBestMappings)
    {
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.MetaMapsInputFile = InputPath;
      seqdbConfig.MetaMapsMaxMemory = string.IsNullOrEmpty(MaxMemory) ? 0 : int.Parse(MaxMemory);
      seqdbConfig.MetaMapsMaxReads = string.IsNullOrEmpty(MaxReads) ? 0 : int.Parse(MaxReads);
      seqdbConfig.MetaMapsMinReadLength = string.IsNullOrEmpty(MinReadLength) ? 0 : int.Parse(MinReadLength);
      seqdbConfig.MetaMapsOnlyBestMappings = OnlyBestMappings;
      seqdbConfig.MetaMapsOutputPath = OutputPath;
      seqdbConfig.MetaMapsReferencePath = ReferencePath;
      seqdbConfig.MetaMapsThreads = string.IsNullOrEmpty(Threads) ? 0 : int.Parse(Threads);
      SaveConfig();
    }

    internal static void CentrifugeParms(string CentrifugeReferencePath, string OutputPath, string InputPath, string Memo, string Threads, string MaxAssignments)
    {
      seqdbConfig.CentrifugeReferencePath = CentrifugeReferencePath; // Path to database
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.CentrifugeOutputPath = OutputPath;
      seqdbConfig.CentrifugeFastqPath = InputPath;
      seqdbConfig.CentrifugeThreads = int.Parse(Threads);
      seqdbConfig.CentrifugeMaxAssignments = int.Parse(MaxAssignments);
      SaveConfig();
    }

    public static void InfluenzaAParms(string CentrifugePath, string OutputPath, string Memo, bool Trim, string Threads, string SegmentsToAssemble, string model)
    {
      seqdbConfig.CentrifugeReferencePath = CentrifugePath; // The reference genome is a Centrifuge database.
      seqdbConfig.InfluenzaAChooseTrim = Trim;
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.InfluenzaAOutputPath = OutputPath;
      seqdbConfig.InfluenzaAThreads = int.Parse(Threads);
      seqdbConfig.InfluenzaASegmentsToAssemble = SegmentsToAssemble;
      seqdbConfig.InfluenzaAModel = model;
      SaveConfig();
    }

    public static void InsertSample(string caseNumber, string LIMStestID, string LIMSsampleID, string inputPath, string sampleID, bool replace)
    {
      SeqDB db = seqdbConfig.Current();
      db.InsertInputPath = inputPath;
      db.InsertCaseNumber = caseNumber;
      db.InsertSampleID = sampleID;
      db.InsertSampleReplace = replace;

      // Also update the LIMS file with the LIMS identifiers.
      if (caseNumber.Length > 0) // We are guaranteed to also have values for LIMStestID and LIMSsampleID.
      {
        // Warning: We need to replace duplicates.
        Dictionary<string, string> LIMSList = ServiceCallHelper.ReadLIMSData(LoggedOnUser, JsonConfig());
        string key = caseNumber + ";" + LIMStestID + ";" + LIMSsampleID;
        if (LIMSList.ContainsKey(key))
        {
          LIMSList.Remove(key);
        }
        LIMSList.Add(key, sampleID);
        ServiceCallHelper.WriteLIMSData(LoggedOnUser, JsonConfig(), LIMSList);
      }

      SaveConfig();
    }

    public static bool InsertSampleReplace
    {
      // Gets/sets whether to insert sample or replace existing.
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.InsertSampleReplace;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.InsertSampleReplace = value;
        SaveConfig();
      }
    }

    public static Dictionary<string, BioSeqTask> TaskList
    {
      get { return seqdbConfig.Tasks; }
    }

    public static void SampleID(string analysis, string sampleID)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          db.KrakenSampleID = sampleID;
          break;
        case "BBMap":
          db.BBMapSampleID = sampleID;
          break;
        case "VFabricate":
          db.VFabricateSampleID = sampleID;
          break;
        case "Quast":
          db.QuastSampleID = sampleID;
          break;
        case "Search":
          db.SearchSampleID = sampleID;
          break;
      }
      SaveConfig();
    }

    public static string SampleID(string analysis)
    {
      SeqDB db = seqdbConfig.Current();
      string sample = string.Empty;
      switch (analysis)
      {
        case "Kraken2":
          sample = db.KrakenSampleID ?? string.Empty;
          break;
        case "BBMap":
          sample = db.BBMapSampleID ?? string.Empty;
          break;
        case "VFabricate":
          sample = db.VFabricateSampleID ?? string.Empty;
          break;
        case "Quast":
          sample = db.QuastSampleID ?? string.Empty;
          break;
        case "Search":
          sample = SearchSampleID();
          break;
      }
      return sample;
    }

    public static string InsertSampleID()
    {
      SeqDB db = seqdbConfig.Current();
      string sample = db.InsertSampleID ?? string.Empty;
      if (CurrentSelectedSample().Length > 0 && sample.Length == 0)
      {
        sample = CurrentSelectedSample();
      }

      return sample;
    }

    public static void BBMapFastqPath(string analysis, string path)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "BBMap":
          db.BBMapFastqPath = path;
          break;
      }
      SaveConfig();
    }

    public static void InputPath(string analysis, string path)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          db.KrakenInputPath = path;
          break;
        case "BBMap":
          db.BBMapInputPath = path;
          break;
        case "VFabricate":
          db.VFabricateContigPath = path;
          break;
        case "Quast":
          db.QuastInputPath = path;
          break;
        case "Search":
          db.SearchInputPath = path;
          break;
      }
      SaveConfig();
    }

    public static string InputPath(string analysis)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          return db.KrakenInputPath ?? string.Empty;
        case "BBMap":
          return db.BBMapInputPath ?? string.Empty;
        case "VFabricate":
          return db.VFabricateContigPath ?? string.Empty;
        case "Quast":
          return db.QuastInputPath ?? string.Empty;
        case "Search":
          return SearchInputPath();
      }

      return string.Empty;
    }

    public static void OutputPath(string analysis, string path)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          db.KrakenOutputPath = path;
          break;
        case "BBMap":
          db.BBMapOutputPath = path;
          break;
        case "VFabricate":
          db.VFabricateOutputPath = path;
          break;
        case "Quast":
          db.QuastOutputPath = path;
          break;
        case "Search":
          db.SearchOutputPath = path;
          break;
      }
      SaveConfig();
    }

    public static string OutputPath(string analysis)
    {
      SeqDB db = seqdbConfig.Current();
      switch (analysis)
      {
        case "Kraken2":
          return db.KrakenOutputPath ?? string.Empty;
        case "BBMap":
          return db.BBMapOutputPath ?? string.Empty;
        case "VFabricate":
          return db.VFabricateOutputPath ?? string.Empty;
        case "Quast":
          return db.QuastOutputPath ?? string.Empty;
        case "Search":
          return SearchOutputPath();
      }
      return string.Empty;
    }

    public static string InsertInputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.InsertInputPath ?? string.Empty;
    }

    public static string InsertCaseNumber()
    {
      SeqDB db = seqdbConfig.Current();
      return db.InsertCaseNumber ?? string.Empty;
    }

    //private static string ConvertPathToLinux(string path)
    //{
    //  path = path.Replace("C:\\", LinuxCDrive() + "/");
    //  path = path.Replace("D:\\", LinuxDDrive() + "/");
    //  path = path.Replace("E:\\", LinuxEDrive() + "/");
    //  return path.Replace("\\", "/");
    //}

    private static string ConvertPathToLinux(string path)
    {
      string[] DriveList = Environment.GetLogicalDrives();
      foreach (string drive in DriveList)
      {
        path = path.Replace(drive, LinuxDrivePrefix() + "/" + drive.Substring(0, 1).ToLower() + "/");
      }

      // Also need to replace any remaining drives that are referenced on the server.
      string serverDrives = ServerDriveList;
      while (serverDrives.Length > 0)
      {
        string drive = serverDrives.Substring(0, 1);
        serverDrives = serverDrives.Substring(1);
        path = path.Replace(drive + ":\\", LinuxDrivePrefix() + "/" + drive.ToLower() + "/");
      }
      return path.Replace("\\", "/");
    }

    public static string NormalizePathToLinux(string path)
    {
      string prefix = string.Empty;
      if (path.StartsWith("["))
      {
        prefix = path.Substring(0, 3);
        path = path.Substring(3);
      }
      if (path.IndexOf("\\") > -1)
      {
        path = path.Replace(UbuntuPrefix(), string.Empty).Replace("$", string.Empty);
        path = ConvertPathToLinux(path);
      }
      return prefix + path;
    }

    public static string GetDirectoryName(string path)
    {
      // Path.GetDirectoryName works well as long as path is not an Ubuntu path reference.
      if (string.IsNullOrEmpty(path))
      {
        return string.Empty;
      }

      string prefix = string.Empty;
      if (path.StartsWith("["))
      {
        prefix = path.Substring(0, 3);
        path = path.Substring(3);
      }
      if (path.StartsWith(UbuntuPrefix()))
      {
        prefix += UbuntuPrefix();
        path = path.Substring(UbuntuPrefix().Length);
      }

      path = Path.GetDirectoryName(path);

      return prefix + path;
    }

    public static string NormalizePathToWindows(string path)
    {
      if (path.IndexOf("/") > -1)
      {
        // eg. /mnt/e/data/database/nhl
        path = path.Replace(UbuntuPrefix(), string.Empty); // First eliminate the Ubuntu prefix (eg. \\wsl$\UbuntuWimmer we add it later if needed).
        string[] DriveList = Environment.GetLogicalDrives();
        foreach (string drive in DriveList)
        {
          if (path.IndexOf(LinuxDrivePrefix() + "/" + drive.Substring(0, 1).ToLower() + "/") > -1)
          {
            path = path.Replace("/" + LinuxDrivePrefix() + (LinuxDrivePrefix().Length > 0 ? "/" : string.Empty) + drive.Substring(0, 1).ToLower() , "C:\\");
            return path.Replace("/", "\\");
          }
        }
        path = UbuntuPrefix() + path;
      }

      return path.Replace("/", "\\");
    }

    public static string CondaPrefixAbricate()
    {
      return seqdbConfigGlobal.CondaPrefixAbricate ?? string.Empty;
    }

    public static string CondaPrefix()
    {
      return seqdbConfigGlobal.CondaPrefix ?? string.Empty;
    }

    public static string UbuntuPrefix()
    {
      string prefix = seqdbConfigGlobal.UbuntuPrefix ?? string.Empty;
      if (prefix.Length == 0)
      {
        seqdbConfigGlobal.UbuntuPrefix = @"\\wsl\Ubuntu"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.UbuntuPrefix ?? string.Empty;
    }

    public static string PathToWSL()
    {
      string path = seqdbConfigGlobal.PathToWSL ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.PathToWSL = @"C:\PDSFiles\BioSeqDB\bin\Debug\wsl.exe"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.PathToWSL ?? string.Empty;
    }

    public static string PathToDendroscope()
    {
      string path = seqdbConfig.PathToDendroscope ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfig.PathToDendroscope = "C:\\Program Files\\Dendroscope\\Dendroscope.exe"; // default
        SaveConfig();
      }
      return seqdbConfig.PathToDendroscope ?? string.Empty;
    }

    public static string WSLProxyRoot()
    {
      string path = seqdbConfigGlobal.WSLProxyRoot ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.WSLProxyRoot = "C:\\PDSFiles\\BioSeqDBSolution\\WSLProxyRoot\\"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.WSLProxyRoot ?? string.Empty;
    }

    public static string UserFolder()
    {
      return WSLProxyRoot() + "\\" + LoggedOnUser + "\\";
    }

    public static string LinuxCDrive()
    {
      string path = seqdbConfigGlobal.LinuxCDrive ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.LinuxCDrive = "/mnt/c"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.LinuxCDrive ?? string.Empty;
    }

    //private static string LinuxDDrive()
    //{
    //  string path = seqdbConfigGlobal.LinuxDDrive ?? string.Empty;
    //  if (path.Length == 0)
    //  {
    //    seqdbConfigGlobal.LinuxDDrive = "/mnt/d"; // default
    //    SaveConfigGlobal();
    //  }
    //  return seqdbConfigGlobal.LinuxDDrive ?? string.Empty;
    //}

    //public static string LinuxEDrive()
    //{
    //  string path = seqdbConfigGlobal.LinuxEDrive ?? string.Empty;
    //  if (path.Length == 0)
    //  {
    //    seqdbConfigGlobal.LinuxEDrive = "/mnt/e"; // default
    //    SaveConfigGlobal();
    //  }
    //  return seqdbConfigGlobal.LinuxEDrive ?? string.Empty;
    //}

    public static string LinuxDrivePrefix()
    {
      if (seqdbConfigGlobal.LinuxDrivePrefix == null)
      {
        seqdbConfigGlobal.LinuxDrivePrefix = "/mnt"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.LinuxDrivePrefix ?? string.Empty;
    }

    public static string PathToSeqDB()
    {
      string path = seqdbConfigGlobal.PathToSeqDB ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.PathToSeqDB = @"~/seqdb/seqdb"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.PathToSeqDB ?? string.Empty;
    }

    public static string PathToNextFlowScript()
    {
      string path = seqdbConfigGlobal.PathToNextFlowScript ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.PathToNextFlowScript = @"~/assembleRANF.sh"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.PathToNextFlowScript ?? string.Empty;
    }

    public static string ExtractSampleID()
    {
      SeqDB db = seqdbConfig.Current();
      string sample = db.ExtractSampleID ?? string.Empty;
      if (CurrentSelectedSample().Length > 0)
      {
        sample = CurrentSelectedSample();
      }

      return sample;
    }

    public static string ExtractOutputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.ExtractOutputPath ?? string.Empty;
    }

    public static string SearchThreads()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchThreads ?? "1";
    }

    public static string SearchCutoff()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchCutoff ?? "1.0";
    }

    public static void LoadConfig(string user) // This loads the local appsettings.
    {
      string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      string userFilePath = Path.Combine(localAppData, "PDS");

      if (!Directory.Exists(userFilePath))
      {
        Directory.CreateDirectory(userFilePath);
      }

      //if it's not already there, copy the file from the server to the folder
      string filename = Path.Combine(userFilePath, user + "appsettings.json");
      string sourceFilePath = Application.StartupPath + "\\bin\\debug\\" + user + "appsettings.json";
      if (!File.Exists(filename))
      {
        string cfgServer = BioSeqDBModel.Instance.AppSettings(loggedOnUser);
        File.WriteAllText(sourceFilePath, cfgServer);
        File.Copy(sourceFilePath, filename);
      }

      if (!string.IsNullOrEmpty(user) && !File.Exists(filename)) // assume this is because the user version of appsettings.json does not yet exist, so take a copy of the global appsettings.
      {
        // Then make a copy of appsettings.json for this user.
        File.Copy(Application.StartupPath + "\\bin\\debug\\appsettings.json", filename);
      }

      // If we are running in the dev environment, and the server in Remember.json is different from the 
      // last server we referenced, swap appSettings files for the other server.
      if (Debugger.IsAttached)
      {
        string requestedServer = UserProfileHelper.userProfile.ServerIPAddress; // From Remember.json.
        if (requestedServer != Properties.Settings.Default.LastServer) // localhost != WIMMER
        {
          // Save current appSettings 
          File.Copy(filename, Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "_" + 
                                                                      Properties.Settings.Default.LastServer + ".json", true);
          // Load requested appSettings
          File.Copy(Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "_" + requestedServer + ".json", 
                                                                                                               filename, true);
          Properties.Settings.Default.LastServer = requestedServer;
          Properties.Settings.Default.Save();
        }
      }

      string cfg = File.ReadAllText(filename);
      seqdbConfig = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
      if (seqdbConfig.Tasks == null)
      {
        seqdbConfig.Tasks = new Dictionary<string, BioSeqTask>();
      }
      if (seqdbConfig.seqDBs == null)
      {
        seqdbConfig.seqDBs = new Dictionary<string, SeqDB>();
      }

      // Apr-14-2021 Set the PathToWSL in the user config to whatever is in the global config. The reason is that it is the
      // user config that gets passed to WSLProxy, and for when this runs on the dev machine, it passes the wrong path.
      seqdbConfig.PathToWSL = PathToWSL();
      SaveConfig();
    }

    //public static void LoadConfig() // This loads the global config.
    //{
    //  string filename = executablePath + "\\" + loggedOnUser + "appsettings.json";
    //  if (!string.IsNullOrEmpty(loggedOnUser) && !File.Exists(filename)) // assume this is because the user version of appsettings.json does not yet exist.
    //  {
    //    // Then make a copy of appsettings.json for this user.
    //    File.Copy(executablePath + "\\appsettings.json", executablePath + "\\" + loggedOnUser + "appsettings.json");
    //  }

    //  string cfg = File.ReadAllText(filename);
    //  if (string.IsNullOrEmpty(loggedOnUser))
    //  {
    //    seqdbConfigGlobal = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
    //    if (seqdbConfigGlobal.seqDBs == null)
    //    {
    //      seqdbConfigGlobal.seqDBs = new Dictionary<string, SeqDB>();
    //    }
    //    if (seqdbConfigGlobal.MappedDrives == null)
    //    {
    //      seqdbConfigGlobal.MappedDrives = new List<MappedDrive>();
    //    }
    //    if (seqdbConfigGlobal.Users == null)
    //    {
    //      seqdbConfigGlobal.Users = new Dictionary<string, User>();
    //      //seqdbConfigGlobal.Users.Add("superuser", new User() { Username = "superuser", Password = "anything" });
    //    }
    //  }
    //  else
    //  {
    //    seqdbConfig = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
    //    if (seqdbConfig.Tasks == null)
    //    {
    //      seqdbConfig.Tasks = new Dictionary<string, BioSeqTask>();
    //    }
    //    if (seqdbConfig.seqDBs == null)
    //    {
    //      seqdbConfig.seqDBs = new Dictionary<string, SeqDB>();
    //    }
    //  }
    //}

    public static string JsonConfig()
    {
      return JsonSerializer.Serialize(seqdbConfig, new JsonSerializerOptions
      {
        WriteIndented = true
      });
    }

    public static void SaveConfig()
    {
      ServiceCallHelper.SaveConfig();
    }

    public static void SaveConfigGlobal()
    {
      ServiceCallHelper.SaveConfigGlobal();
    }

    private static void PostNewDatabaseToGlobalConfig(SeqDB db)
    {
      if (seqdbConfigGlobal.seqDBs.ContainsKey(db.DBName))
      {
        seqdbConfigGlobal.seqDBs.Remove(db.DBName);
      }
      seqdbConfigGlobal.seqDBs.Add(db.DBName, db);
      SaveConfigGlobal();
    }

    public static void NewDatabase(string dbname, string dbpath, bool IsFastaInput, string inputPath, string standardReferenceGenomePath)
    {
      seqdbConfig.LastDBSelected = dbname;
      if (seqdbConfig.seqDBs.ContainsKey(dbname))
      {
        seqdbConfig.seqDBs.Remove(dbname);
      }

      NewDBPath = dbpath;
      NewDBName = dbname;
      NewDBImportFasta = IsFastaInput;
      NewDBInputPath = inputPath;
      NewDBReference = standardReferenceGenomePath;

      SeqDB db = new SeqDB();
      db.Build_DBName = dbname;
      db.Build_DBInput = inputPath;
      db.BuildTreeDomesticReference = string.Empty;
      db.BuildTreeChooseDomestic = standardReferenceGenomePath.Length > 0;
      db.BuildTreeWildReference = standardReferenceGenomePath; // Temporarily overload BuildTreeWildReference so we can complete this file copy logic in the service.
      db.DBName = dbname;
      string thePath = NormalizePathToWindows(DirectoryHelper.CleanPath(dbpath)) + "\\" + dbname + "\\";
      db.DBPath = "[S]" + thePath + dbname + ".fasta";
      seqdbConfig.seqDBs.Add(dbname, db);
      SaveConfig();
      PostNewDatabaseToGlobalConfig(db);
    }

    public static string CurrentDBName()
    {
      SeqDB db = seqdbConfig.Current();
      return db.DBName ?? string.Empty;
    }

    public static List<string> BuildTreeQueryList()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeQueryList ?? null;
    }

    public static List<string> AssembleQueryListRAFlye()
    {
      return seqdbConfig.AssembleQueryListRAFlye ?? null;
    }

    internal static List<string> AssembleQueryListTracy()
    {
      return seqdbConfig.AssembleQueryListTracy ?? null;
    }

    public static List<string> AssembleQueryListTrinity()
    {
      return seqdbConfig.AssembleQueryListTrinity ?? null;
    }

    public static string BuildTreeThreads()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeThreads ?? "1";
    }

    public static string BuildTreeWildReference()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeWildReference ?? string.Empty;
    }

    public static void SaveUIForm(Point location, Size size)
    {
      seqdbConfig.X = location.X;
      seqdbConfig.Y = location.Y;
      seqdbConfig.W = size.Width;
      seqdbConfig.H = size.Height;
      SaveConfig();
    }

    public static void SaveNotificationUIForm(Point location, Size size)
    {
      seqdbConfig.NotificationX = location.X;
      seqdbConfig.NotificationY = location.Y;
      seqdbConfig.NotificationW = size.Width;
      seqdbConfig.NotificationH = size.Height;
      SaveConfig();
    }

    internal static void SaveBioSeqBandageUIForm(Point location, Size size)
    {
      seqdbConfig.BandageX = location.X;
      seqdbConfig.BandageY = location.Y;
      seqdbConfig.BandageW = size.Width;
      seqdbConfig.BandageH = size.Height;
      SaveConfig();
    }

    internal static void SaveArtemisUIForm(Point location, Size size)
    {
      seqdbConfig.ArtemisX = location.X;
      seqdbConfig.ArtemisY = location.Y;
      seqdbConfig.ArtemisW = size.Width;
      seqdbConfig.ArtemisH = size.Height;
      SaveConfig();
    }

    internal static void SaveCANSUIForm(Point location, Size size)
    {
      seqdbConfig.CANSX = location.X;
      seqdbConfig.CANSY = location.Y;
      seqdbConfig.CANSW = size.Width;
      seqdbConfig.CANSH = size.Height;
      SaveConfig();
    }

    public static void SaveInfluenzaAUIForm(Point location, Size size)
    {
      seqdbConfig.InfluenzaAX = location.X;
      seqdbConfig.InfluenzaAY = location.Y;
      seqdbConfig.InfluenzaAW = size.Width;
      seqdbConfig.InfluenzaAH = size.Height;
      SaveConfig();
    }

    internal static void SaveMultiQCUIForm(Point location, Size size)
    {
      seqdbConfig.MultiQCX = location.X;
      seqdbConfig.MultiQCY = location.Y;
      seqdbConfig.MultiQCW = size.Width;
      seqdbConfig.MultiQCH = size.Height;
      SaveConfig();
    }

    internal static void SaveFastQCUIForm(Point location, Size size)
    {
      seqdbConfig.FastQCX = location.X;
      seqdbConfig.FastQCY = location.Y;
      seqdbConfig.FastQCW = size.Width;
      seqdbConfig.FastQCH = size.Height;
      SaveConfig();
    }

    internal static void SaveCentrifugeUIForm(Point location, Size size)
    {
      seqdbConfig.CentrifugeX = location.X;
      seqdbConfig.CentrifugeY = location.Y;
      seqdbConfig.CentrifugeW = size.Width;
      seqdbConfig.CentrifugeH = size.Height;
      SaveConfig();
    }

    internal static void SaveMetaMapsUIForm(Point location, Size size)
    {
      seqdbConfig.MetaMapsX = location.X;
      seqdbConfig.MetaMapsY = location.Y;
      seqdbConfig.MetaMapsW = size.Width;
      seqdbConfig.MetaMapsH = size.Height;
      SaveConfig();
    }

    public static Point UILocation()
    {
      return new Point(seqdbConfig.X, seqdbConfig.Y);
    }

    public static Size UISize()
    {
      return new Size(seqdbConfig.W, seqdbConfig.H);
    }

    public static Point NotificationLocation()
    {
      return new Point(seqdbConfig.NotificationX, seqdbConfig.NotificationY);
    }

    public static Size NotificationSize()
    {
      return new Size(seqdbConfig.NotificationW, seqdbConfig.NotificationH);
    }

    internal static Size CANSSize()
    {
      return new Size(seqdbConfig.CANSW, seqdbConfig.CANSH);
    }

    internal static Point BioSeqBandageLocation()
    {
      return new Point(seqdbConfig.BandageX, seqdbConfig.BandageY);
    }

    internal static Point ArtemisLocation()
    {
      return new Point(seqdbConfig.ArtemisX, seqdbConfig.ArtemisY);
    }

    internal static Point CANSLocation()
    {
      return new Point(seqdbConfig.CANSX, seqdbConfig.CANSY);
    }

    public static Point InfluenzaALocation()
    {
      return new Point(seqdbConfig.InfluenzaAX, seqdbConfig.InfluenzaAY);
    }

    public static Size InfluenzaASize()
    {
      return new Size(seqdbConfig.InfluenzaAW, seqdbConfig.InfluenzaAH);
    }

    internal static Size CentrifugeSize()
    {
      return new Size(seqdbConfig.CentrifugeW, seqdbConfig.CentrifugeH);
    }

    internal static Point CentrifugeLocation()
    {
      return new Point(seqdbConfig.CentrifugeX, seqdbConfig.CentrifugeY);
    }

    internal static Size BioSeqBandageSize()
    {
      return new Size(seqdbConfig.BandageW, seqdbConfig.BandageH);
    }

    internal static Size ArtemisSize()
    {
      return new Size(seqdbConfig.ArtemisW, seqdbConfig.ArtemisH);
    }

    internal static Size FastQCSize()
    {
      return new Size(seqdbConfig.FastQCW, seqdbConfig.FastQCH);
    }

    internal static Point FastQCLocation()
    {
      return new Point(seqdbConfig.FastQCX, seqdbConfig.FastQCY);
    }

    internal static Size MultiQCSize()
    {
      return new Size(seqdbConfig.MultiQCW, seqdbConfig.MultiQCH);
    }

    internal static Point MultiQCLocation()
    {
      return new Point(seqdbConfig.MultiQCX, seqdbConfig.MultiQCY);
    }

    internal static Size MetaMapsSize()
    {
      return new Size(seqdbConfig.MetaMapsW, seqdbConfig.MetaMapsH);
    }

    internal static Point MetaMapsLocation()
    {
      return new Point(seqdbConfig.MetaMapsX, seqdbConfig.MetaMapsY);
    }

    public static string VFabricateGeneXref
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.VFabricateGeneXref;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.VFabricateGeneXref = value;
      }
    }

    public static bool BuildTreeChooseDomestic
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeChooseDomestic;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeChooseDomestic = value;
      }
    }

    public static string BuildTreeDomesticReference
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeDomesticReference;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeDomesticReference = value ?? string.Empty;
      }
    }

    public static string BuildTreeHits
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeHits ?? "25";
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeHits = value;
        SaveConfig();
      }
    }

    public static string TaskMemo
    {
      get
      {
        return seqdbConfig.TaskMemo ?? string.Empty;
      }
      set
      {
        seqdbConfig.TaskMemo = value;
        SaveConfig();
      }
    }

    public static string BuildTreeThreshold
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.BuildTreeThreshold ?? ".001";
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.BuildTreeThreshold = value;
        SaveConfig();
      }
    }

    public static string ServerDriveList
    {
      get { return seqdbConfigGlobal.ServerDriveList; }
    }

    public static Dictionary<string, string> SalmonellaSamplesList
    {
      get
      {
        return seqdbConfig.SalmonellaSamplesList;
      }
      set
      {
        seqdbConfig.SalmonellaSamplesList = value;
        SaveConfig();
      }
    }

    public static string SalmonellaOutputPath
    {
      get
      {
        return seqdbConfig.SalmonellaOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.SalmonellaOutputPath = value;
        SaveConfig();
      }
    }

    public static string NewDBPath
    {
      get
      {
        return seqdbConfig.NewDBPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.NewDBPath = value;
        SaveConfig();
      }
    }

    public static string NewDBReference
    {
      get
      {
        return seqdbConfig.NewDBReference ?? string.Empty;
      }
      set
      {
        seqdbConfig.NewDBReference = value;
        SaveConfig();
      }
    }

    public static string NewDBName
    {
      get
      {
        return seqdbConfig.NewDBName ?? string.Empty;
      }
      set
      {
        seqdbConfig.NewDBName = value;
        SaveConfig();
      }
    }

    public static string NewDBInputPath
    {
      get
      {
        return seqdbConfig.NewDBInputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.NewDBInputPath = value;
        SaveConfig();
      }
    }

    public static bool NewDBImportFasta
    {
      get
      {
        return seqdbConfig.NewDBImportFasta;
      }
      set
      {
        seqdbConfig.NewDBImportFasta = value;
        SaveConfig();
      }
    }

    public static void SalmonellaParms(string OutputPath, string Memo, bool Trim, string Threads)
    {
      seqdbConfig.SalmonellaChooseTrim = Trim;
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.SalmonellaOutputPath = OutputPath;
      seqdbConfig.SalmonellaThreads = int.Parse(Threads);
      SaveConfig();
    }

    public static bool SalmonellaChooseTrim
    {
      get
      {
        return seqdbConfig.SalmonellaChooseTrim;
      }
      set
      {
        seqdbConfig.SalmonellaChooseTrim = value;
        SaveConfig();
      }
    }

    public static string CANSSamplesPath
    {
      get
      {
        return seqdbConfig.CANSSamplesPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CANSSamplesPath = value;
        SaveConfig();
      }
    }

    public static string SalmonellaSamplesPath
    {
      get
      {
        return seqdbConfig.SalmonellaSamplesPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.SalmonellaSamplesPath = value;
        SaveConfig();
      }
    }

    public static bool CANSChooseTrim
    {
      get
      {
        return seqdbConfig.CANSChooseTrim;
      }
      set
      {
        seqdbConfig.CANSChooseTrim = value;
        SaveConfig();
      }
    }

    public static bool InfluenzaAChooseTrim
    {
      get
      {
        return seqdbConfig.InfluenzaAChooseTrim;
      }
      set
      {
        seqdbConfig.InfluenzaAChooseTrim = value;
        SaveConfig();
      }
    }

    public static string CANSModel
    {
      get
      {
        return seqdbConfig.CANSModel ?? "r9";
      }
      set
      {
        seqdbConfig.CANSModel = value;
        SaveConfig();
      }
    }

    public static string InfluenzaAModel
    {
      get
      {
        return seqdbConfig.InfluenzaAModel ?? "r9";
      }
      set
      {
        seqdbConfig.InfluenzaAModel = value;
        SaveConfig();
      }
    }

    public static string CANSReadLengthDeviation
    {
      get
      {
        return seqdbConfig.CANSReadLengthDeviation == 0 ? string.Empty : seqdbConfig.CANSReadLengthDeviation.ToString();
      }
      set
      {
        seqdbConfig.CANSReadLengthDeviation = int.Parse(value);
        SaveConfig();
      }
    }

    public static string CANSExpectedLength
    {
      get
      {
        return seqdbConfig.CANSExpectedLength == 0 ? string.Empty : seqdbConfig.CANSExpectedLength.ToString();
      }
      set
      {
        seqdbConfig.CANSExpectedLength = int.Parse(value);
        SaveConfig();
      }
    }

    public static string CANSTargetCoverage
    {
      get
      {
        return seqdbConfig.CANSTargetCoverage == 0 ? string.Empty : seqdbConfig.CANSTargetCoverage.ToString();
      }
      set
      {
        seqdbConfig.CANSTargetCoverage = int.Parse(value);
        SaveConfig();
      }
    }

    public static string CANSThreads
    {
      get
      {
        return seqdbConfig.CANSThreads == 0 ? string.Empty : seqdbConfig.CANSThreads.ToString();
      }
      set
      {
        seqdbConfig.CANSThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string InfluenzaAThreads
    {
      get
      {
        return seqdbConfig.InfluenzaAThreads == 0 ? string.Empty : seqdbConfig.InfluenzaAThreads.ToString();
      }
      set
      {
        seqdbConfig.InfluenzaAThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string MultiQCOutputPath
    {
      get
      {
        return seqdbConfig.MultiQCOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.MultiQCOutputPath = value;
        SaveConfig();
      }
    }
    public static string MultiQCInputPath
    {
      get
      {
        return seqdbConfig.MultiQCInputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.MultiQCInputPath = value;
        SaveConfig();
      }
    }

    public static string FastQCOutputPath
    {
      get
      {
        return seqdbConfig.FastQCOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.FastQCOutputPath = value;
        SaveConfig();
      }
    }

    public static string CentrifugeOutputPath
    {
      get
      {
        return seqdbConfig.CentrifugeOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CentrifugeOutputPath = value;
        SaveConfig();
      }
    }

    public static string FastQCInputPath
    {
      get
      {
        return seqdbConfig.FastQCInputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.FastQCInputPath = value;
        SaveConfig();
      }
    }

    public static string CentrifugeFastqPath
    {
      get
      {
        return seqdbConfig.CentrifugeFastqPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CentrifugeFastqPath = value;
        SaveConfig();
      }
    }

    public static string FastQCThreads
    {
      get
      {
        return seqdbConfig.FastQCThreads == 0 ? string.Empty : seqdbConfig.FastQCThreads.ToString();
      }
      set
      {
        seqdbConfig.FastQCThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string CentrifugeThreads
    {
      get
      {
        return seqdbConfig.CentrifugeThreads == 0 ? string.Empty : seqdbConfig.CentrifugeThreads.ToString();
      }
      set
      {
        seqdbConfig.CentrifugeThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string CentrifugeMaxAssignments
    {
      get
      {
        return seqdbConfig.CentrifugeMaxAssignments == 0 ? string.Empty : seqdbConfig.CentrifugeMaxAssignments.ToString();
      }
      set
      {
        seqdbConfig.CentrifugeMaxAssignments = int.Parse(value);
        SaveConfig();
      }
    }

    public static string MetaMapsThreads
    {
      get
      {
        return seqdbConfig.MetaMapsThreads == 0 ? string.Empty : seqdbConfig.MetaMapsThreads.ToString();
      }
      set
      {
        seqdbConfig.MetaMapsThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string MetaMapsMinReadLength
    {
      get
      {
        return seqdbConfig.MetaMapsMinReadLength == 0 ? string.Empty : seqdbConfig.MetaMapsMinReadLength.ToString();
      }
      set
      {
        seqdbConfig.MetaMapsMinReadLength = int.Parse(value);
        SaveConfig();
      }
    }

    public static string MetaMapsMaxMemory
    {
      get
      {
        return seqdbConfig.MetaMapsMaxMemory == 0 ? string.Empty : seqdbConfig.MetaMapsMaxMemory.ToString();
      }
      set
      {
        seqdbConfig.MetaMapsMaxMemory = int.Parse(value);
        SaveConfig();
      }
    }

    public static string MetaMapsMaxReads
    {
      get
      {
        return seqdbConfig.MetaMapsMaxReads == 0 ? string.Empty : seqdbConfig.MetaMapsMaxReads.ToString();
      }
      set
      {
        seqdbConfig.MetaMapsMaxReads = int.Parse(value);
        SaveConfig();
      }
    }

    public static bool MetaMapsOnlyBestMappings
    {
      get
      {
        return seqdbConfig.MetaMapsOnlyBestMappings;
      }
      set
      {
        seqdbConfig.MetaMapsOnlyBestMappings = value;
        SaveConfig();
      }
    }

    public static string CANSOutputPath
    {
      get
      {
        return seqdbConfig.CANSOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CANSOutputPath = value;
        SaveConfig();
      }
    }

    public static string InfluenzaAOutputPath
    {
      get
      {
        return seqdbConfig.InfluenzaAOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.InfluenzaAOutputPath = value;
        SaveConfig();
      }
    }

    public static string InfluenzaASamplesPath
    {
      get
      {
        return seqdbConfig.InfluenzaASamplesPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.InfluenzaASamplesPath = value;
        SaveConfig();
      }
    }

    public static string CentrifugeReferencePath
    {
      get
      {
        return seqdbConfig.CentrifugeReferencePath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CentrifugeReferencePath = value;
        SaveConfig();
      }
    }

    public static string MetaMapsReferencePath
    {
      get
      {
        return seqdbConfig.MetaMapsReferencePath ?? string.Empty;
      }
      set
      {
        seqdbConfig.MetaMapsReferencePath = value;
        SaveConfig();
      }
    }

    public static string MetaMapsOutputPath
    {
      get
      {
        return seqdbConfig.MetaMapsOutputPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.MetaMapsOutputPath = value;
        SaveConfig();
      }
    }

    public static string MetaMapsInputFile
    {
      get
      {
        return seqdbConfig.MetaMapsInputFile ?? string.Empty;
      }
      set
      {
        seqdbConfig.MetaMapsInputFile = value;
        SaveConfig();
      }
    }

    public static string CANSReferencePath
    {
      get
      {
        return seqdbConfig.CANSReferencePath ?? string.Empty;
      }
      set
      {
        seqdbConfig.CANSReferencePath = value;
        SaveConfig();
      }
    }

    public static string InfluenzaACentrifugePath
    {
      get
      {
        return seqdbConfig.InfluenzaACentrifugePath ?? string.Empty;
      }
      set
      {
        seqdbConfig.InfluenzaACentrifugePath = value;
        SaveConfig();
      }
    }

    public static string BackupFoldersPath
    {
      get
      {
        return seqdbConfig.BackupFoldersPath ?? string.Empty;
      }
      set
      {
        seqdbConfig.BackupFoldersPath = value;
        SaveConfig();
      }
    }

    //public static Dictionary<string, BackupFolderDetails> BackupFolderList
    //{
    //  get
    //  {
    //    return seqdbConfig.BackupOffsite == null ? null : seqdbConfig.BackupOffsite.BackupFolderList;
    //  }

    //  set
    //  {
    //    if (seqdbConfig.BackupOffsite == null)
    //    {
    //      seqdbConfig.BackupOffsite = new BioSeqDBConfigModel.BackupOffsiteParms();
    //    }
    //    seqdbConfig.BackupOffsite.BackupFolderList = value;
    //    SaveConfig();
    //  }
    //}

    //public static string BackupOffsiteTargetPath
    //{
    //  get => seqdbConfig.BackupOffsite.TargetPath;
    //  set
    //  {
    //    seqdbConfig.BackupOffsite.TargetPath = value;
    //    SaveConfig();
    //  }
    //}

    public static Dictionary<string, string> CANSSampleList
    {
      get
      {
        return seqdbConfig.CANSSampleList;
      }
      set
      {
        seqdbConfig.CANSSampleList = value;
        SaveConfig();
      }
    }

    public static Dictionary<string, string> InfluenzaASampleList
    {
      get
      {
        return seqdbConfig.InfluenzaASampleList;
      }
      set
      {
        seqdbConfig.InfluenzaASampleList = value;
        SaveConfig();
      }
    }

    public static string SalmonellaThreads
    {
      get
      {
        return seqdbConfig.SalmonellaThreads == 0 ? string.Empty : seqdbConfig.SalmonellaThreads.ToString();
      }
      set
      {
        seqdbConfig.SalmonellaThreads = int.Parse(value);
        SaveConfig();
      }
    }

    public static string Kraken2FastqPath
    {
      get
      {
        return seqdbConfig.Kraken2FastqPath == null ? string.Empty : seqdbConfig.Kraken2FastqPath;
      }
      set
      {
        seqdbConfig.Kraken2FastqPath = value;
        SaveConfig();
      }
    }

    public static bool Kraken2UseFastq
    {
      get
      {
        return seqdbConfig.Kraken2UseFastq;
      }
      set
      {
        seqdbConfig.Kraken2UseFastq = value;
        SaveConfig();
      }
    }

    public static string BandageInputPath
    {
      get
      {
        return seqdbConfig.BandageInputPath == null ? string.Empty : seqdbConfig.BandageInputPath;
      }
      set
      {
        seqdbConfig.BandageInputPath = value;
        SaveConfig();
      }
    }

    public static string ArtemisInputPath
    {
      get
      {
        return seqdbConfig.ArtemisInputPath == null ? string.Empty : seqdbConfig.ArtemisInputPath;
      }
      set
      {
        seqdbConfig.ArtemisInputPath = value;
        SaveConfig();
      }
    }

    public static string LastExplorerServerPath
    {
      get
      {
        return seqdbConfig.LastExplorerServerPath == null ? "[S]C:\\" : seqdbConfig.LastExplorerServerPath;
      }
      set
      {
        seqdbConfig.LastExplorerServerPath = value;
        SaveConfig();
      }
    }

    public static string LastExplorerLocalPath
    {
      get
      {
        return seqdbConfig.LastExplorerLocalPath == null ? "[S]C:\\" : seqdbConfig.LastExplorerLocalPath;
      }
      set
      {
        seqdbConfig.LastExplorerLocalPath = value;
        SaveConfig();
      }
    }

    public static bool FastQCConsolidate
    {
      get { return seqdbConfig.FastQCConsolidate; }
      set { seqdbConfig.FastQCConsolidate = value; SaveConfig(); }
    }

    public static bool FastQCMultiQC
    {
      get { return seqdbConfig.FastQCMultiQC; }
      set { seqdbConfig.FastQCMultiQC = value; SaveConfig(); }
    }

    public static string BuildTreeOutputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeOutputPath ?? string.Empty;
    }

    public static string CurrentDBPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.DBPath ?? string.Empty;
    }

    public static string CurrentSelectedSample()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SampleSelected ?? string.Empty;
    }

    public static string StandardReference
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        if (string.IsNullOrEmpty(db.StandardReference))
        {
          db.StandardReference = db.BuildTreeDomesticReference;
          SaveConfig();
        }
        if (string.IsNullOrEmpty(db.StandardReference))
        {
          db.StandardReference = db.BuildTreeWildReference;
          SaveConfig();
        }

        return db.StandardReference ?? string.Empty;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.StandardReference = value;
        SaveConfig();
      }
    }

    public static string CurrentKipperPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.KipperPath ?? string.Empty;
    }

    public static string CurrentKipperFilenamePrefix()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.KipperFilenamePrefix ?? string.Empty;
    }

    public static void UpdateKipperPath(string dbFilenamePrefix, string dbPath)
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      db.KipperPath = dbPath;
      db.KipperFilenamePrefix = dbFilenamePrefix;
      SaveConfigGlobal();
    }

    public static void BackupDatabase(string backupFilenamePrefix, string backupPath)
    {
      UpdateKipperPath(backupFilenamePrefix, backupPath);
    }

    public static void RestoreDatabase(string ArchiveFilename, string ArchiveDBPath, string Version, string OutputDBPath)
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      db.RestoreArchiveDBPath = ArchiveDBPath;
      db.RestoreArchiveDBFilenamePrefix = ArchiveFilename;
      db.RestoreArchiveDBOutputPath = OutputDBPath;
      db.RestoreArchiveDBVersion = Version;
      SaveConfigGlobal();
    }

    public static void BackgroundTaskComplete(BioSeqTask task)
    {
      task.TaskStatus = "Ready";
      task.TaskComplete = DateTime.Now;
      SaveConfig();
    }

    public static string RestoreOutputPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBOutputPath ?? db.DBPath; // If the restore output path has not been used before, use the current DB path.
    }

    public static string RestoreKipperFilenamePrefix()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBFilenamePrefix ?? db.KipperFilenamePrefix; // If the restore prefix has not been used before, use the current prefix.
    }

    public static string RestoreVersion()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBVersion.Substring(0, db.RestoreArchiveDBVersion.IndexOf(":")) ?? string.Empty;
    }

    public static string RestoreKipperPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBPath ?? db.KipperPath; // If the restore DB path has not been used before, use the current path.
    }

    public static void UpdateSampleSelected(string sample)
    {
      SeqDB db = seqdbConfig.Current();
      if (ShowDetail && sample.Length > 0)
      {
        sample = sample.Substring(0, sample.IndexOf("|"));
      }
      db.SampleSelected = sample;
      SaveConfig();
    }

    public static void AssembleSample(List<string> QuerySamples, bool FastPolish, bool RA, bool Flye, int tabSelected,
                                                  bool Kraken2, bool BBmap, bool Quast, bool VFabricate, string GeneXRef, 
                                                                                           string memo, string maxFastq)
    {
      if (tabSelected == 0 && (RA || Flye))
      {
        seqdbConfig.AssembleQueryListRAFlye = QuerySamples;
      }
      if (tabSelected == 1)
      {
        seqdbConfig.AssembleQueryListTrinity = QuerySamples;
      }
      if (tabSelected == 2)
      {
        seqdbConfig.AssembleQueryListTracy = QuerySamples;
      }
      seqdbConfig.AssembleFastPolish = FastPolish;
      seqdbConfig.AssembleRA = seqdbConfig.AssembleFlye = seqdbConfig.AssembleTrinity = seqdbConfig.AssembleTracy = false;
      if (tabSelected == 1)
      {
        seqdbConfig.AssembleTrinity = true;
      }
      else if (tabSelected == 2)
      {
        seqdbConfig.AssembleTracy = true;
      }
      else
      {
        seqdbConfig.AssembleRA = RA;
        seqdbConfig.AssembleFlye = Flye;
      }

      seqdbConfig.AssembleKraken2 = Kraken2;
      seqdbConfig.AssembleBBMap = BBmap;
      seqdbConfig.AssembleQuast = Quast;
      seqdbConfig.AssembleVFabricate = VFabricate;
      seqdbConfig.AssembleVFGeneXRef = GeneXRef;
      seqdbConfig.TaskMemo = memo;
      seqdbConfig.AssembleMaxFastq = maxFastq.Length > 0 ? int.Parse(maxFastq) : 0;
      SaveConfig();
    }

    public static void BuildTreeSample(string OutputPath, string ReferenceGenome, string StandardReference, bool ReferenceChoice,
                                                                      string Hits, string Threads, List<string> QueryList, bool FastTree, string memo)
    {
      SeqDB db = seqdbConfig.Current();
      db.BuildTreeOutputPath = OutputPath;
      db.BuildTreeWildReference = ReferenceGenome;
      db.BuildTreeHits = Hits;
      db.BuildTreeThreads = Threads;
      db.BuildTreeQueryList = QueryList;
      db.BuildTreeFastTree = FastTree;
      db.BuildTreeDomesticReference = StandardReference;
      db.BuildTreeChooseDomestic = ReferenceChoice;
      seqdbConfig.TaskMemo = memo;
      SaveConfig();
    }

    public static void SearchSample(string OutputSampleName, string OutputPath, string InputPath, string Cutoff, string Threads)
    {
      SeqDB db = seqdbConfig.Current();
      db.SearchOutputPath = OutputPath;
      db.SearchInputPath = InputPath;
      db.SearchCutoff = Cutoff;
      db.SearchThreads = Threads;
      db.SearchOutputSampleName = OutputSampleName;
      SaveConfig();
    }

    public static void ExtractSample(string outputPath, string sampleID)
    {
      SeqDB db = seqdbConfig.Current();
      db.ExtractOutputPath = outputPath;
      db.ExtractSampleID = sampleID;
      SaveConfig();
    }

    //public static void RemoveSample(List<string> sampleIDs)
    //{
    //  // This removes the samples from the settings
    //  SeqDB db = seqdbConfig.Current();
    //  db.RemoveSampleIDs = sampleIDs;
    //  SaveConfig();

    //  // Also remove from LIMS file if present (i.e. duplicate).
    //  Dictionary<string, string> LIMSList = ServiceCallHelper.ReadLIMSData(LoggedOnUser, JsonConfig());
    //  foreach (string key in LIMSList.Keys)
    //  {
    //    if (sampleIDs.Contains(LIMSList[key]))
    //    {
    //      LIMSList.Remove(key);
    //      ServiceCallHelper.WriteLIMSData(LoggedOnUser, JsonConfig(), LIMSList);
    //      return;
    //    }
    //  }
    //}

    //public static List<string> RemoveSampleIDs()
    //{
    //  // This returns the list of sample IDs to remove.
    //  SeqDB db = seqdbConfig.Current();
    //  return db.RemoveSampleIDs;
    //}

    public static List<string> RemoveSampleIDs
    {
      get
      {
        SeqDB db = seqdbConfig.Current();
        return db.RemoveSampleIDs;
      }
      set
      {
        SeqDB db = seqdbConfig.Current();
        db.RemoveSampleIDs = value;
        SaveConfig();
      }
    }

    public static string BackupManager
    {
      get
      {
        if (seqdbConfigGlobal.BackupManager == null)
        {
          seqdbConfigGlobal.BackupManager = "AGB465";
          SaveConfigGlobal();
        }
        return seqdbConfigGlobal.BackupManager;
      }
      set
      {
        seqdbConfigGlobal.BackupManager = value;
        SaveConfigGlobal();
      }
    }

    public static string Password(string username)
    {
      User user = seqdbConfigGlobal.Users[username];
      return Utility.DecryptSupports(user.Password, username);
    }

    public static void ChangePassword(string username, string newPassword)
    {
      User user = seqdbConfigGlobal.Users[username];
      user.Password = Utility.DecryptSupports(newPassword, username);
      SaveConfigGlobal();
    }

    public static bool ValidPassword(string Username, string Password)
    {
      foreach (string key in seqdbConfigGlobal.Users.Keys)
      {
        User user = seqdbConfigGlobal.Users[key];
        if (user.Username.ToUpper() == Username.ToUpper())
        {
          return Utility.DecryptSupports(user.Password, Username) == Password;
        }
      }

      return false;
    }

    public static bool IsNumeric(char KeyChar)
    {
      return (!Char.IsNumber(KeyChar) && KeyChar != (Char)Keys.Back && KeyChar != (Char)Keys.Delete) || KeyChar == '.';  // Numerics only
    }

    public static string FileExists(string path)
    {
      if (!File.Exists(path))
      {
        return string.Empty;
      }

      return path;
    }
  }
}
