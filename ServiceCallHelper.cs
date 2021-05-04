using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BioSeqDB
{
  public static class ServiceCallHelper
  {
    public static void InitConfig()
    {
      if (!IsServiceClass.IsService)
      {
        AppConfigHelper.LoadConfig();
      }
      else
      {
        AppConfigHelper.executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location; // To be able to store config files locally. 
                                                                                                     // May not be necessary once service implementation is complete, but may still be a good idea to keep a local copy.
        AppConfigHelper.executablePath = AppConfigHelper.GetDirectoryName(AppConfigHelper.executablePath);

        string cfg = BioSeqDBModel.Instance.AppSettings(string.Empty);  // Uncomment
        AppConfigHelper.seqdbConfigGlobal = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
        if (AppConfigHelper.seqdbConfigGlobal.seqDBs == null)
        {
          AppConfigHelper.seqdbConfigGlobal.seqDBs = new Dictionary<string, SeqDB>();
        }
        if (AppConfigHelper.seqdbConfigGlobal.Users == null)
        {
          AppConfigHelper.seqdbConfigGlobal.Users = new Dictionary<string, User>();
        }
      }
    }

    internal static void LoadConfig(string loggedOnUser)
    {
      AppConfigHelper.executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      AppConfigHelper.executablePath = Path.GetDirectoryName(AppConfigHelper.executablePath);

      if (!IsServiceClass.IsService)
      {
        AppConfigHelper.LoadConfig(); // Load the user specific config.
      }
      else // Is service call.
      {
        string cfg = BioSeqDBModel.Instance.AppSettings(loggedOnUser);

        if (string.IsNullOrEmpty(loggedOnUser)) // global
        {
          AppConfigHelper.seqdbConfigGlobal = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
          if (AppConfigHelper.seqdbConfigGlobal.seqDBs == null)
          {
            AppConfigHelper.seqdbConfigGlobal.seqDBs = new Dictionary<string, SeqDB>();
          }
          if (AppConfigHelper.seqdbConfigGlobal.Users == null)
          {
            AppConfigHelper.seqdbConfigGlobal.Users = new Dictionary<string, User>();
          }
        }
        else // local
        {
          AppConfigHelper.seqdbConfig = JsonSerializer.Deserialize<BioSeqDBConfig>(cfg);
          if (AppConfigHelper.seqdbConfig.seqDBs == null)
          {
            AppConfigHelper.seqdbConfig.seqDBs = new Dictionary<string, SeqDB>();
          }
          if (AppConfigHelper.seqdbConfig.Users == null)
          {
            AppConfigHelper.seqdbConfig.Users = new Dictionary<string, User>();
          }
        }
      }
    }

    public static string HelloBioSeqDBService()
    {
      if (IsServiceClass.IsService)
      {
        // This will generate a catchable exception if service is not available.
        string ModelServer = Properties.Settings.Default.ModelServer;
        string DestinationURL = Properties.Settings.Default.DestinationURL;

        BioSeqDBModel.Initialize(ModelServer, DestinationURL);
        return BioSeqDBModel.Instance.Echo();
      }
    }

    public static string DriveList()
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.DriveList();
      }
    }

    public static void SaveConfigGlobal()
    {
      // Do this regardless. Need to save a local copy anyways.
      string jsonString = JsonSerializer.Serialize(AppConfigHelper.seqdbConfigGlobal, new JsonSerializerOptions
      {
        WriteIndented = true
      });
      File.WriteAllText(AppConfigHelper.executablePath + "\\appsettings.json", jsonString);

      if (IsServiceClass.IsService)
      {
        BioSeqDBModel.Instance.AppSettings(string.Empty, jsonString);
      }
    }

    internal static void ResetFastaFolder(string loggedOnUser)
    {
      BioSeqDBModel.Instance.ResetFastaFolder(loggedOnUser);
    }

    internal static void ResetFastqFolder(string loggedOnUser)
    {
      BioSeqDBModel.Instance.ResetFastqFolder(loggedOnUser);
    }

    internal static void SaveConfig()
    {
      // Do this regardless. Need to save a local copy anyways.
      string jsonString = JsonSerializer.Serialize(AppConfigHelper.seqdbConfig, new JsonSerializerOptions
      {
        WriteIndented = true
      });
      try
      {
        File.WriteAllText(AppConfigHelper.executablePath + "\\" + AppConfigHelper.LoggedOnUser + "_appsettings.json", jsonString);
      }
      catch (Exception ex)
      {
        try
        {
          File.WriteAllText(AppConfigHelper.executablePath + "\\" + AppConfigHelper.LoggedOnUser + "_appsettings.json", jsonString);
        }
        catch (Exception ex2)
        {
          File.WriteAllText(AppConfigHelper.executablePath + "\\" + AppConfigHelper.LoggedOnUser + "_appsettings.json", jsonString);
        }
      }

      if (IsServiceClass.IsService)
      {
        BioSeqDBModel.Instance.AppSettings(AppConfigHelper.LoggedOnUser, jsonString);
      }
    }

    internal static string CentrifugeDatabaseName(string centrifugeDBPath)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.CentrifugeDatabaseName(centrifugeDBPath);
      }

      return SeqDBHelper.CentrifugeDatabaseName(centrifugeDBPath);
    }

    public static string GetVersions(string loggedOnUser, string cfg, string dBPath)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.GetVersions(loggedOnUser, cfg, dBPath);
      }

      return SeqDBHelper.GetVersions(dBPath);
    }

    public static List<string> SampleIDs(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.SampleIDs(loggedOnUser, cfg);
      }

      return SeqDBHelper.SampleIDs();
    }

    public static WSLProxyResponse BuildTree(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.BuildTree(loggedOnUser, cfg);
      }

      return SeqDBHelper.BuildTree();
    }

    public static WSLProxyResponse Assemble(string loggedOnUser, string cfg, string config)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.Assemble(loggedOnUser, cfg, config);
      }

      return SeqDBHelper.AssembleSamples(config);
    }

    internal static WSLProxyResponse Nextstrain(string loggedOnUser, string config)
    {
      return BioSeqDBModel.Instance.Nextstrain(loggedOnUser, config);
    }

    internal static WSLProxyResponse Salmonella(string loggedOnUser, string config)
    {
      if (IsServiceClass.IsService)
      {
        //if (AppConfigHelper.SalmonellaSamplesPath.StartsWith("[L]"))
        //{
        //  DirectoryHelper.FileCopy(AppConfigHelper.SalmonellaSamplesPath, "[S]" + AppConfigHelper.UserFolder(), true);
        //}
        return BioSeqDBModel.Instance.Salmonella(loggedOnUser, config);
      }

      return SeqDBHelper.InfluenzaA();
    }

    internal static WSLProxyResponse InfluenzaA(string loggedOnUser, string config)
    {
      if (IsServiceClass.IsService)
      {
        if (AppConfigHelper.InfluenzaASamplesPath.StartsWith("[L]"))
        {
          DirectoryHelper.FileCopy(AppConfigHelper.InfluenzaASamplesPath, "[S]" + AppConfigHelper.UserFolder(), true);
        }
        return BioSeqDBModel.Instance.InfluenzaA(loggedOnUser, config);
      }

      return SeqDBHelper.InfluenzaA();
    }

    internal static void KillTask(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        BioSeqDBModel.Instance.KillTask(loggedOnUser, cfg);
      }
    }

    public static WSLProxyResponse Kraken2(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.Kraken2(loggedOnUser, cfg);
      }

      return SeqDBHelper.Kraken2();
    }

    public static WSLProxyResponse Extract(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.Extract(loggedOnUser, cfg);
      }

      return SeqDBHelper.ExtractSample(AppConfigHelper.ExtractSampleID(), AppConfigHelper.NormalizePathToLinux(AppConfigHelper.ExtractOutputPath()));
    }

    public static WSLProxyResponse SearchSample(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.SearchSample(loggedOnUser, cfg);
      }

      return SeqDBHelper.SearchSample();
    }

    internal static WSLProxyResponse Build_DB(string loggedOnUser, string cfg)
    {     
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.Build_DB(loggedOnUser, cfg);
      }

      return SeqDBHelper.Build_DB(AppConfigHelper.seqdbConfigGlobal.Current());
    }

    internal static int DeleteDB(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.DeleteDB(loggedOnUser, cfg);
      }

      return SeqDBHelper.DeleteDB();
    }

    public static int TraverseTree(string path, bool IsServerPath, string extension)
    {
      Logger.Log.Debug("TraverseTree: Reading " + path + " on " + (IsServerPath ? "server." : "local."));

      if (IsServerPath)
      {
        return BioSeqDBModel.Instance.TraverseTree("[S]" + path, extension);
      }

      // Look for a count of .fastq files in the root folder.
      int fCount = 0;
      if (!Directory.Exists(path))
      {
        return 0;
      }

      string[] files;
      try
      {
        files = Directory.GetFiles(path + "\\");
      }
      catch (UnauthorizedAccessException e)
      {
        Console.WriteLine(e.Message);
        return 0;
      }
      catch (DirectoryNotFoundException e)
      {
        Console.WriteLine(e.Message);
        return 0;
      }

      // Perform the required action on each file here.
      foreach (string file in files)
      {
        try
        {
          FileInfo fi = new FileInfo(file);
          fCount += fi.Name.ToLower().EndsWith("." + extension) ? 1 : 0;
          if (extension == "fasta") // also count .fna
          {
            fCount += fi.Name.ToLower().EndsWith(".fna") ? 1 : 0;
          }
        }
        catch (FileNotFoundException e)
        {
          // If file was deleted by a separate application or thread since the call to TraverseTree() then just continue.
          Console.WriteLine(e.Message);
          continue;
        }
      }
      Logger.Log.Debug("TraverseTree: Found " + fCount.ToString() + " files.");
      return fCount;
    }

    internal static WSLProxyResponse Quast(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.Quast(loggedOnUser, cfg);
      }

      return SeqDBHelper.Quast();
    }

    internal static WSLProxyResponse BBMap(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.BBMap(loggedOnUser, cfg);
      }

      return SeqDBHelper.BBMap();
    }

    internal static WSLProxyResponse VFabricate(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.VFabricate(loggedOnUser, cfg);
      }

      return SeqDBHelper.VFabricate();
    }

    internal static WSLProxyResponse BackupDatabase(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.BackupDatabase(loggedOnUser, cfg);
      }

      return SeqDBHelper.BackupDatabase();
    }

    internal static WSLProxyResponse RestoreDatabase(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.RestoreDatabase(loggedOnUser, cfg);
      }

      return SeqDBHelper.RestoreDatabase();
    }

    internal static WSLProxyResponse ReplaceSample(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.ReplaceSample(loggedOnUser, cfg);
      }

      return SeqDBHelper.ReplaceSample();
    }

    internal static WSLProxyResponse InsertSample(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.InsertSample(loggedOnUser, cfg);
      }

      return SeqDBHelper.InsertSample();
    }

    internal static WSLProxyResponse RemoveSample(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.RemoveSample(loggedOnUser, cfg);
      }

      return SeqDBHelper.RemoveSample();
    }

    internal static Dictionary<string, string> ReadLIMSData(string loggedOnUser, string cfg)
    {
      if (IsServiceClass.IsService)
      {
        return BioSeqDBModel.Instance.ReadLIMSData(loggedOnUser, cfg);
      }

      return AppConfigHelper.ReadLIMSData();
    }

    internal static void WriteLIMSData(string loggedOnUser, string cfg, Dictionary<string, string> LIMSList)
    {
      if (IsServiceClass.IsService)
      {
        BioSeqDBModel.Instance.WriteLIMSData(loggedOnUser, cfg, LIMSList);
        return;
      }

      AppConfigHelper.WriteLIMSData(LIMSList);
    }
  }
}