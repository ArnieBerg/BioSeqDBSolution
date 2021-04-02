using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace BioSeqDB
{
  public static class AppConfigHelper
  {
    public static BioSeqDBConfig seqdbConfig { get; set; }
    public static BioSeqDBConfig seqdbConfigGlobal { get; set; }

    public static string executablePath;

    private static string loggedOnUser = string.Empty;

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

    internal static void Logout()
    {
      seqdbConfigGlobal.Users[LoggedOnUser].LogoutTime = DateTime.Now; // This information will eventually get to the service for permanent recording.
      SaveConfigGlobal();
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

    internal static int MaxTaskID()
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

    public static string LinuxHomeDirectory
    {
      get { return seqdbConfigGlobal.LinuxHomeDirectory ?? "/home/arnie"; }
      set { seqdbConfigGlobal.LinuxHomeDirectory = value ?? "/home/arnie"; SaveConfigGlobal(); }
    }

    public static string TaskFilter
    {
      get { return seqdbConfig.TaskFilter; }
      set { seqdbConfig.TaskFilter = value; SaveConfig(); }
    }

    internal static string LIMSDuplicate(string CaseNumber, string LIMSTestID, string LIMSSampleID)
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

    internal static BioSeqTask TaskOfIndex(int selectedIndex)
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

    internal static BioSeqTask TaskOfID(int ID)
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

    internal static void DeleteTask(int index, bool kill)
    {
      BioSeqTask task = TaskOfIndex(index); // Task to delete.
      if (kill)
      {
        seqdbConfig.TaskToDelete = task;
        ServiceCallHelper.KillTask(LoggedOnUser, JsonConfig());
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
    
    public static string PathToServerAppsettings
    {
      get
      {
        return seqdbConfig.PathToServerAppsettings;
      }
      set
      {
        seqdbConfig.PathToServerAppsettings = value;
        if (string.IsNullOrEmpty(value))
        {
          seqdbConfig.PathToServerAppsettings = @"C:\BioSeqDB\Service";
        }
        SaveConfig();
      }
    }

    internal static bool AssembleFastPolish()
    {
      return seqdbConfig.AssembleFastPolish;
    }

    internal static bool AssembleBBmap()
    {
      return seqdbConfig.AssembleBBMap;
    }

    public static string CopyResultFromServer(string outputPath, string[] filenames)
    {
      // If the output path is on the server, we need to copy it to the local Temp folder to display the results.
      // If the output path is on the local machine, we need to copy from the user folder on the server to the local destination.
      string destination = @"[L]C:\Temp\"; // Copy from UserFolder() on server to C:\Temp.
      string source = outputPath + "\\";
      if (outputPath.StartsWith("[L]"))  // Copy from user folder on server to OutputPath.
      {
        destination = source;
        source = "[S]" + UserFolder();
      }

      foreach (string filename in filenames)
      {
        Logger.Log.Debug("Copy " + filename + " from " + source + " to " + destination);
        DirectoryHelper.FileCopy(source + filename, destination, true);
      }
      return destination;
    }

    internal static bool AssembleVFabricate()
    {
      return seqdbConfig.AssembleVFabricate;
    }

    internal static bool AssembleKraken2()
    {
      return seqdbConfig.AssembleKraken2;
    }

    internal static bool AssembleQuast()
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

    internal static bool SampleChecked(string analysis)
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

    internal static bool AssembleFlye()
    {
      return seqdbConfig.AssembleFlye;
    }

    internal static bool AssembleRA()
    {
      return seqdbConfig.AssembleRA;
    }

    internal static bool AssembleTrinity()
    {
      return seqdbConfig.AssembleTrinity;
    }

    internal static bool BuildTreeFastTree()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeFastTree;
    }

    internal static string Build_DBName()
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

    internal static int TaskCount()
    {
      return seqdbConfig.Tasks.Count;
    }

    internal static string Build_DBInput()
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

    internal static string SearchInputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchInputPath ?? string.Empty;
    }

    internal static string BBMapFastqPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BBMapFastqPath ?? string.Empty;
    }

    internal static void InfluenzaAParms(string CentrifugePath, string OutputPath, string Memo, bool Trim, string Threads, 
                                                                                    string SegmentsToAssemble, string model)
    {
      seqdbConfig.InfluenzaACentrifugePath = CentrifugePath;
      seqdbConfig.InfluenzaAChooseTrim = Trim;
      seqdbConfig.TaskMemo = Memo;
      seqdbConfig.InfluenzaAOutputPath = OutputPath;
      seqdbConfig.InfluenzaAThreads = int.Parse(Threads);
      seqdbConfig.InfluenzaASegmentsToAssemble = SegmentsToAssemble;
      seqdbConfig.InfluenzaAModel = model;
      SaveConfig();
    }

    internal static void InsertSample(string caseNumber, string LIMStestID, string LIMSsampleID, string inputPath, string sampleID, bool replace)
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

    internal static string SampleID(string analysis)
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

    internal static string InsertSampleID()
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

    internal static string InputPath(string analysis)
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

    internal static string OutputPath(string analysis)
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

    internal static string InsertInputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.InsertInputPath ?? string.Empty;
    }

    internal static string InsertCaseNumber()
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

    internal static string GetDirectoryName(string path)
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

    internal static string NormalizePathToWindows(string path)
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
            path = path.Replace("/" + LinuxDrivePrefix() + "/" + drive.Substring(0, 1).ToLower() , "C:\\");
            return path.Replace("/", "\\");
          }
        }
        path = UbuntuPrefix() + path;
      }

      return path.Replace("/", "\\");
    }

    internal static string CondaPrefixAbricate()
    {
      return seqdbConfigGlobal.CondaPrefixAbricate ?? string.Empty;
    }

    internal static string CondaPrefix()
    {
      return seqdbConfigGlobal.CondaPrefix ?? string.Empty;
    }

    internal static string UbuntuPrefix()
    {
      string prefix = seqdbConfigGlobal.UbuntuPrefix ?? string.Empty;
      if (prefix.Length == 0)
      {
        seqdbConfigGlobal.UbuntuPrefix = @"\\wsl\Ubuntu"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.UbuntuPrefix ?? string.Empty;
    }

    internal static string PathToWSL()
    {
      string path = seqdbConfigGlobal.PathToWSL ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.PathToWSL = @"C:\PDSFiles\BioSeqDB\bin\Debug\wsl.exe"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.PathToWSL ?? string.Empty;
    }

    internal static string PathToDendroscope()
    {
      string path = seqdbConfig.PathToDendroscope ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfig.PathToDendroscope = "C:\\Program Files\\Dendroscope\\Dendroscope.exe"; // default
        SaveConfig();
      }
      return seqdbConfig.PathToDendroscope ?? string.Empty;
    }

    internal static string WSLProxyRoot()
    {
      string path = seqdbConfigGlobal.WSLProxyRoot ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.WSLProxyRoot = "C:\\PDSFiles\\BioSeqDBSolution\\WSLProxyRoot\\"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.WSLProxyRoot ?? string.Empty;
    }

    internal static string UserFolder()
    {
      return WSLProxyRoot() + "\\" + LoggedOnUser + "\\";
    }

    internal static string LinuxCDrive()
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

    //internal static string LinuxEDrive()
    //{
    //  string path = seqdbConfigGlobal.LinuxEDrive ?? string.Empty;
    //  if (path.Length == 0)
    //  {
    //    seqdbConfigGlobal.LinuxEDrive = "/mnt/e"; // default
    //    SaveConfigGlobal();
    //  }
    //  return seqdbConfigGlobal.LinuxEDrive ?? string.Empty;
    //}

    internal static string LinuxDrivePrefix()
    {
      if (seqdbConfigGlobal.LinuxDrivePrefix == null)
      {
        seqdbConfigGlobal.LinuxDrivePrefix = "/mnt"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.LinuxDrivePrefix ?? string.Empty;
    }

    internal static string PathToSeqDB()
    {
      string path = seqdbConfigGlobal.PathToSeqDB ?? string.Empty;
      if (path.Length == 0)
      {
        seqdbConfigGlobal.PathToSeqDB = @"~/seqdb/seqdb"; // default
        SaveConfigGlobal();
      }
      return seqdbConfigGlobal.PathToSeqDB ?? string.Empty;
    }

    internal static string PathToNextFlowScript()
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

    internal static string SearchThreads()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchThreads ?? "1";
    }

    internal static string SearchCutoff()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SearchCutoff ?? "1.0";
    }

    internal static void LoadConfig(string user) // This loads the local appsettings.
    {
      //MessageBox.Show("Looking for appsettings.json in " + executablePath);
      string filename = executablePath + "\\" + user + "appsettings.json";
      if (!string.IsNullOrEmpty(user) && !File.Exists(filename)) // assume this is because the user version of appsettings.json does not yet exist, so take a copy of the global appsettings.
      {
        // Then make a copy of appsettings.json for this user.
        File.Copy(executablePath + "\\appsettings.json", executablePath + "\\" + user + "appsettings.json");
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
    }

    internal static void LoadConfig()
    {
      //MessageBox.Show("Looking for appsettings.json in " + executablePath);
      string filename = executablePath + "\\" + loggedOnUser + "appsettings.json";
      if (!string.IsNullOrEmpty(loggedOnUser) && !File.Exists(filename)) // assume this is because the user version of appsettings.json does not yet exist.
      {
        // Then make a copy of appsettings.json for this user.
        File.Copy(executablePath + "\\appsettings.json", executablePath + "\\" + loggedOnUser + "appsettings.json");
      }

      string cfg = File.ReadAllText(filename);
      if (string.IsNullOrEmpty(loggedOnUser))
      {
        seqdbConfigGlobal = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
        if (seqdbConfigGlobal.seqDBs == null)
        {
          seqdbConfigGlobal.seqDBs = new Dictionary<string, SeqDB>();
        }
        if (seqdbConfigGlobal.MappedDrives == null)
        {
          seqdbConfigGlobal.MappedDrives = new List<MappedDrive>();
        }
        if (seqdbConfigGlobal.Users == null)
        {
          seqdbConfigGlobal.Users = new Dictionary<string, User>();
          //seqdbConfigGlobal.Users.Add("superuser", new User() { Username = "superuser", Password = "anything" });
        }
      }
      else
      {
        seqdbConfig = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
        if (seqdbConfig.Tasks == null)
        {
          seqdbConfig.Tasks = new Dictionary<string, BioSeqTask>();
        }
        if (seqdbConfig.seqDBs == null)
        {
          seqdbConfig.seqDBs = new Dictionary<string, SeqDB>();
        }
      }
    }

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

    public static void NewDatabase(string dbname, string dbpath, string inputPath, string standardReferenceGenomePath)
    {
      seqdbConfig.LastDBSelected = dbname;
      if (seqdbConfig.seqDBs.ContainsKey(dbname))
      {
        seqdbConfig.seqDBs.Remove(dbname);
      }

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

    internal static string CurrentDBName()
    {
      SeqDB db = seqdbConfig.Current();
      return db.DBName ?? string.Empty;
    }

    internal static List<string> BuildTreeQueryList()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeQueryList ?? null;
    }

    internal static List<string> AssembleQueryListRAFlye()
    {
      return seqdbConfig.AssembleQueryListRAFlye ?? null;
    }

    internal static List<string> AssembleQueryListTrinity()
    {
      return seqdbConfig.AssembleQueryListTrinity ?? null;
    }

    internal static string BuildTreeThreads()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeThreads ?? "1";
    }

    internal static string BuildTreeWildReference()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeWildReference ?? string.Empty;
    }

    internal static void SaveUIForm(Point location, Size size)
    {
      seqdbConfig.X = location.X;
      seqdbConfig.Y = location.Y;
      seqdbConfig.W = size.Width;
      seqdbConfig.H = size.Height;
      SaveConfig();
    }

    internal static void SaveNotificationUIForm(Point location, Size size)
    {
      seqdbConfig.NotificationX = location.X;
      seqdbConfig.NotificationY = location.Y;
      seqdbConfig.NotificationW = size.Width;
      seqdbConfig.NotificationH = size.Height;
      SaveConfig();
    }

    internal static Point UILocation()
    {
      return new Point(seqdbConfig.X, seqdbConfig.Y);
    }

    internal static Size UISize()
    {
      return new Size(seqdbConfig.W, seqdbConfig.H);
    }

    internal static Point NotificationLocation()
    {
      return new Point(seqdbConfig.NotificationX, seqdbConfig.NotificationY);
    }

    internal static Size NotificationSize()
    {
      return new Size(seqdbConfig.NotificationW, seqdbConfig.NotificationH);
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

    internal static void SalmonellaParms(string OutputPath, string Memo, bool Trim, string Threads)
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

    public static Dictionary<string, string> InfluenzaASamplesList
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

    internal static string BuildTreeOutputPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.BuildTreeOutputPath ?? string.Empty;
    }

    internal static string CurrentDBPath()
    {
      SeqDB db = seqdbConfig.Current();
      return db.DBPath ?? string.Empty;
    }

    internal static string CurrentSelectedSample()
    {
      SeqDB db = seqdbConfig.Current();
      return db.SampleSelected ?? string.Empty;
    }

    internal static string CurrentKipperPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.KipperPath ?? string.Empty;
    }

    internal static string CurrentKipperFilenamePrefix()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.KipperFilenamePrefix ?? string.Empty;
    }

    internal static void UpdateKipperPath(string dbFilenamePrefix, string dbPath)
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      db.KipperPath = dbPath;
      db.KipperFilenamePrefix = dbFilenamePrefix;
      SaveConfigGlobal();
    }

    internal static void BackupDatabase(string backupFilenamePrefix, string backupPath)
    {
      UpdateKipperPath(backupFilenamePrefix, backupPath);
    }

    internal static void RestoreDatabase(string ArchiveFilename, string ArchiveDBPath, string Version, string OutputDBPath)
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
    }

    internal static string RestoreOutputPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBOutputPath ?? db.DBPath; // If the restore output path has not been used before, use the current DB path.
    }

    internal static string RestoreKipperFilenamePrefix()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBFilenamePrefix ?? db.KipperFilenamePrefix; // If the restore prefix has not been used before, use the current prefix.
    }

    internal static string RestoreVersion()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBVersion.Substring(0, db.RestoreArchiveDBVersion.IndexOf(":")) ?? string.Empty;
    }

    internal static string RestoreKipperPath()
    {
      SeqDB db = seqdbConfigGlobal.seqDBs[seqdbConfig.LastDBSelected];
      return db.RestoreArchiveDBPath ?? db.KipperPath; // If the restore DB path has not been used before, use the current path.
    }

    internal static void UpdateSampleSelected(string sample)
    {
      SeqDB db = seqdbConfig.Current();
      if (ShowDetail && sample.Length > 0)
      {
        sample = sample.Substring(0, sample.IndexOf("|"));
      }
      db.SampleSelected = sample;
      SaveConfig();
    }

    internal static void AssembleSample(List<string> QuerySamples, bool FastPolish, bool RA, bool Flye, bool Trinity,
                                                  bool Kraken2, bool BBmap, bool Quast, bool VFabricate, string GeneXRef, 
                                                                                           string memo, string maxFastq)
    {
      if (RA || Flye)
      {
        seqdbConfig.AssembleQueryListRAFlye = QuerySamples;
      }
      if (Trinity)
      {
        seqdbConfig.AssembleQueryListTrinity = QuerySamples;
      }
      seqdbConfig.AssembleFastPolish = FastPolish;
      seqdbConfig.AssembleRA = RA;
      seqdbConfig.AssembleFlye = Flye;
      seqdbConfig.AssembleTrinity = Trinity;
      seqdbConfig.AssembleKraken2 = Kraken2;
      seqdbConfig.AssembleBBMap = BBmap;
      seqdbConfig.AssembleQuast = Quast;
      seqdbConfig.AssembleVFabricate = VFabricate;
      seqdbConfig.AssembleVFGeneXRef = GeneXRef;
      seqdbConfig.TaskMemo = memo;
      seqdbConfig.AssembleMaxFastq = maxFastq.Length > 0 ? int.Parse(maxFastq) : 0;
      SaveConfig();
    }

    internal static void BuildTreeSample(string OutputPath, string ReferenceGenome, string StandardReference, bool ReferenceChoice,
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

    internal static void SearchSample(string OutputSampleName, string OutputPath, string InputPath, string Cutoff, string Threads)
    {
      SeqDB db = seqdbConfig.Current();
      db.SearchOutputPath = OutputPath;
      db.SearchInputPath = InputPath;
      db.SearchCutoff = Cutoff;
      db.SearchThreads = Threads;
      db.SearchOutputSampleName = OutputSampleName;
      SaveConfig();
    }

    internal static void ExtractSample(string outputPath, string sampleID)
    {
      SeqDB db = seqdbConfig.Current();
      db.ExtractOutputPath = outputPath;
      db.ExtractSampleID = sampleID;
      SaveConfig();
    }

    internal static void RemoveSample(string sampleID)
    {
      SeqDB db = seqdbConfig.Current();
      db.RemoveSampleID = sampleID;
      SaveConfig();

      if (sampleID.Length == 0)
      {
        return;
      }

      // Also remove from LIMS file if present (i.e. duplicate).
      Dictionary<string, string> LIMSList = ServiceCallHelper.ReadLIMSData(LoggedOnUser, JsonConfig());
      foreach (string key in LIMSList.Keys)
      {
        if (LIMSList[key] == sampleID)
        {
          LIMSList.Remove(key);
          ServiceCallHelper.WriteLIMSData(LoggedOnUser, JsonConfig(), LIMSList);
          return;
        }
      }
    }

    public static string RemoveSampleID()
    {
      SeqDB db = seqdbConfig.Current();
      string sample = db.RemoveSampleID ?? string.Empty;
      if (CurrentSelectedSample().Length > 0)
      {
        sample = CurrentSelectedSample();
      }
      return sample;
    }

    internal static string Password(string username)
    {
      User user = seqdbConfigGlobal.Users[username];
      return Utility.DecryptSupports(user.Password, username);
    }

    internal static void ChangePassword(string username, string newPassword)
    {
      User user = seqdbConfigGlobal.Users[username];
      user.Password = Utility.DecryptSupports(newPassword, username);
      SaveConfigGlobal();
    }

    internal static bool ValidPassword(string Username, string Password)
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

    internal static string FileExists(string path)
    {
      if (!File.Exists(path))
      {
        return string.Empty;
      }

      return path;
    }
  }
}
