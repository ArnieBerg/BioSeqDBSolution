using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace BioSeqDB
{
  public static class SeqDBHelper
  {
    private static BackgroundWorker backgroundWorker;

    public delegate void taskCompleteEvent(object sender, TaskEventArgs e);
    public static event taskCompleteEvent backgroundTaskComplete;

    //private static string TaskID; // For buildTree with fast_tree option, using FileSystemWatcher.

    public static WSLProxyResponse bashcmd(string cmd)
    {
      AppConfigHelper.LastCommand = cmd;
      //if (Environment.Is64BitProcess)
      //{
      //  // this works on x64
      //  ExecuteCommandLine(@"bash -c ""cd /mnt/c/projects/Test/jekyll/help; bundle exec jekyll serve;"" ");
      //}
      //else
      //{
      //  // this works on x86
      //  ExecuteCommandLine(Environment.GetEnvironmentVariable("WinDir") +
      //            "\\SysNative\\bash.exe -c \"" + cmd + "\" ");
      //}
      return StandardCallToWSL();
    }

    public static WSLProxyResponse AssembleSamples(string config)
    {
      // eg. ./assembleRANF.sh --fast_polish --flye –-bbmap skip|normal –-quast skip|normal –-kraken skip|normal --complete_signal /mnt/c/Temp/assemble000003.txt /mnt/c/Temp/samples.txt  

      File.WriteAllText("C:\\Temp\\samples.txt", config);

      AppConfigHelper.StandardOutput = string.Empty;
      AppConfigHelper.LastError = string.Empty;
      AppConfigHelper.LastExitCode = 0;

      //int taskid = AppConfigHelper.MaxTaskID() + 1;
      //BioSeqTask task = new BioSeqTask()
      //{
      //  //TaskData = @"C:\Temp\Assemble" + taskid.ToString("000000") + ".txt",
      //  TaskDB = string.Empty, // No database involved in context of this call.
      //  TaskID = taskid.ToString(),
      //  TaskStatus = "Pending",
      //  TaskTime = DateTime.Now,
      //  TaskComplete = DateTime.MinValue,
      //  TaskType = "Assemble",
      //  TaskUser = AppConfigHelper.LastUser,
      //  StandardOutput = string.Empty,
      //  LastError = string.Empty,
      //  LastExitCode = -999
      //};
      //AppConfigHelper.AddTask(task);

      // Return contents of the TaskData file:
      // Line 1: return code
      // Line 2-n: standard output plus error output.
      if (AppConfigHelper.AssembleTrinity())
      {
        string hostref = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.AssembleHostReference);
        AppConfigHelper.LastCommand = AppConfigHelper.PathToNextFlowScript() + " --Trinity --virusRef " + 
                                      AppConfigHelper.NormalizePathToLinux(AppConfigHelper.AssembleVirusReference) + " " +
                                      (hostref.Length > 0 ? " --hostRef " + hostref : string.Empty) + " " + AppConfigHelper.LinuxCDrive() + "/Temp/samples.txt";
      }
      else
      {
        string VFabricate = " --VFabricate ";
        if (AppConfigHelper.AssembleVFabricate())
        {
          VFabricate += AppConfigHelper.NormalizePathToLinux(AppConfigHelper.AssembleVFGeneXRef);
        }
        else
        {
          VFabricate += "skip";
        }
        AppConfigHelper.LastCommand = AppConfigHelper.PathToNextFlowScript() + " " + (AppConfigHelper.AssembleFastPolish() ? "--fast_polish" : string.Empty) + " " +
                                                                    (AppConfigHelper.AssembleFlye() ? "--flye" : string.Empty) + " --bbmap " +
                                                                    (AppConfigHelper.AssembleBBmap() ? "normal" : "skip") + " --quast " +
                                                                    (AppConfigHelper.AssembleQuast() ? "normal" : "skip") + VFabricate + " --kraken " +
                                                                    (AppConfigHelper.AssembleKraken2() ? "normal" : "skip") + " " +
                                                                    AppConfigHelper.LinuxCDrive() + "/Temp/samples.txt";
      }
      // DEBUG HELPER:
      //AppConfigHelper.LastCommand = "~/makeassemble.sh " + AppConfigHelper.NormalizePathToLinux(task.TaskData);
      //AppConfigHelper.LastCommand = "~/assembleRA.sh PDS2021318subset /mnt/e/data/Crick/PDS_Diagnostics_2020/PDS2021318subset";

      Logger.Log.Debug("AssembleSamples: " + AppConfigHelper.LastUser + " CMD: " + AppConfigHelper.LastCommand);

      RunInBackground(AppConfigHelper.LastCommand, AppConfigHelper.LastTaskID);

      WSLProxyResponse WSLResponse = new WSLProxyResponse();
      WSLResponse.ExitCode = 0;
      return WSLResponse;
    }

    public static WSLProxyResponse Printenv()
    {
      AppConfigHelper.LastCommand = "printenv > printenv.wsl"; // For WSL this file ends up in the executable folder, not in the /home/arnie folder.
      return StandardCallToWSL();
    }

    public static WSLProxyResponse BuildTree()
    {
      //string prefix = "cd;export PATH=/home/arnie/.local/bin:/home/arnie/bin:/snap/bin:/home/arnie/.dotnet/tools:$PATH;conda run -n phame "; // Prepend to each invocation of wsl.
      //prefix = "conda run -n phame ";

      // eg. seqdb build_tree -n 50 -t 1 –fast_tree  -l query.list -r reference.fasta -o path/to/output_dir -d path/to/seqdb_database.
      // First we need to build a file containing the contents of the query list.
      List<string> checkedQueries = new List<string>();
      string[] queryList = AppConfigHelper.BuildTreeQueryList().ToArray();
      for (int i = 0; i < queryList.Length; i++)
      {
        string s1 = queryList[i];
        if (s1.StartsWith("1"))
        {
          checkedQueries.Add(AppConfigHelper.NormalizePathToLinux(s1.Substring(1))); // Remove 'selected' indicator.
        }
      }

      queryList = checkedQueries.ToArray();
      Array.Resize(ref queryList, queryList.Length + 1); // Add an empty line to give us a final LF.
      queryList[queryList.Length - 1] = string.Empty;

      File.WriteAllText(@"C:\Temp\queryList.txt", string.Join("\n", queryList));

      if (File.Exists(AppConfigHelper.BuildTreeOutputPath() + "\\tree.nwk"))
      {
        File.Delete(AppConfigHelper.BuildTreeOutputPath() + "\\tree.nwk");
      }

      //int taskid = AppConfigHelper.MaxTaskID() + 1;
      //BioSeqTask task = new BioSeqTask()
      //{
      //  //TaskData = AppConfigHelper.BuildTreeOutputPath() + "\\tree.nwk",
      //  TaskDB = AppConfigHelper.CurrentDBName(),
      //  TaskID = taskid.ToString(),
      //  TaskStatus = "Pending",
      //  TaskTime = DateTime.Now,
      //  TaskComplete = DateTime.MinValue,
      //  TaskType = "BuildTree",
      //  TaskUser = AppConfigHelper.LastUser,
      //  StandardOutput = string.Empty,
      //  LastError = string.Empty,
      //  LastExitCode = -999
      //};
      //AppConfigHelper.AddTask(task);
      //TaskID = task.TaskID;

      string referenceToUse = AppConfigHelper.BuildTreeChooseDomestic ? AppConfigHelper.BuildTreeDomesticReference : AppConfigHelper.BuildTreeWildReference();

      string linkage = string.Empty;
      string cutoff = string.Empty;
      switch (AppConfigHelper.BuildTreeLinkage)
      {
        case 0:
          linkage = "threshold";
          cutoff = " -c " + AppConfigHelper.BuildTreeThreshold;
          break;
        case 1:
          linkage = "tophits";
          cutoff = " -c " + AppConfigHelper.BuildTreeHits;
          break;
        case 2:
          linkage = "cluster";
          break;
      }

      WSLProxyResponse WSLResponse = new WSLProxyResponse();
      WSLResponse.ExitCode = 0;
      AppConfigHelper.LastCommand = AppConfigHelper.CondaPrefix() + " " + AppConfigHelper.PathToSeqDB() +
                              " build_tree " + (AppConfigHelper.BuildTreeFastTree() ? "--fast_tree " : string.Empty) +
                                         "--linkage " + linkage + cutoff +
                                         " -l " + AppConfigHelper.NormalizePathToLinux("C:\\Temp\\queryList.txt") +
                                         " -r " + AppConfigHelper.NormalizePathToLinux(referenceToUse) +
                                         " -t " + AppConfigHelper.BuildTreeThreads() +
                                         " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath()) +
                                         " -o " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.BuildTreeOutputPath());
      if (AppConfigHelper.BuildTreeFastTree())  // Submit and look for tree.nwk.
      {
        FileSystemWatcher _watcher = new FileSystemWatcher(AppConfigHelper.BuildTreeOutputPath());
        _watcher.Created += _watcher_Created;
        _watcher.Filter = "tree.nwk";
        _watcher.EnableRaisingEvents = true;

        AppConfigHelper.StandardOutput = string.Empty;
        AppConfigHelper.LastError = string.Empty;
        AppConfigHelper.LastExitCode = 0;

        Logger.Log.Debug("BuildTree: " + AppConfigHelper.LastUser + " CMD: " + AppConfigHelper.LastCommand);

        var info = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic '" + AppConfigHelper.CondaPrefix() + " " + AppConfigHelper.LastCommand +" &> " +
                                                            AppConfigHelper.LinuxHomeDirectory + "/output" + AppConfigHelper.LastTaskID.ToString() + "'")
        {
          WorkingDirectory = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.LinuxHomeDirectory),
          UseShellExecute = false,
          CreateNoWindow = true,
          RedirectStandardInput = true,
          RedirectStandardOutput = true,
          RedirectStandardError = true
        };

        Process P = Process.Start(info);
        WSLResponse.StandardError = P.StandardError.ReadToEnd();
        WSLResponse.StandardOutput = P.StandardOutput.ReadToEnd();
      }
      else
      {
        RunInBackground(AppConfigHelper.LastCommand, AppConfigHelper.LastTaskID);
      }
      return WSLResponse;
    }

    internal static WSLProxyResponse MetaMaps()
    {
      throw new NotImplementedException();
    }

    internal static string CentrifugeDatabaseName(string centrifugeDBPath)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(centrifugeDBPath.Trim());
      FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
      FileInfo fiInfo = files[0];
      string filename = fiInfo.Name.Substring(0, fiInfo.Name.Length - fiInfo.Extension.Length);
      if (filename.IndexOf(".") < 0)
      {
        return string.Empty;
      }

      return filename.Substring(0, filename.LastIndexOf("."));
    }

    internal static WSLProxyResponse InfluenzaA() // This assumes InfluenzaA will run locally.
    {
      throw new NotImplementedException();
    }

    internal static WSLProxyResponse Centrifuge() // This assumes Centrifuge will run locally.
    {
      throw new NotImplementedException();
    }

    private static void _watcher_Created(object sender, FileSystemEventArgs e)
    {
      TaskEventArgs taskEventArgs = new TaskEventArgs();
      taskEventArgs.task = AppConfigHelper.TaskOfID(AppConfigHelper.LastTaskID);

      taskEventArgs.task.StandardOutput = AppConfigHelper.StandardOutput;
      taskEventArgs.task.LastError = AppConfigHelper.LastError;
      taskEventArgs.task.LastExitCode = AppConfigHelper.LastExitCode;

      Logger.Log.Debug(string.Format("_watcher_Created: exitcode={0} output={1} error={2}",
                                             taskEventArgs.task.LastExitCode, taskEventArgs.task.StandardOutput, taskEventArgs.task.LastError));
      //System.Windows.MessageBox.Show("Assembly completed.", "Completed", (MessageBoxButton)MessageBoxButtons.OK);

      backgroundTaskComplete?.Invoke(sender, taskEventArgs); // Notify parent we have finished this task.
    }

    private static void RunInBackground(string command, int taskID)
    {
      backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
      backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

      List<object> arguments = new List<object>
          {
            command,
            taskID
          };
      backgroundWorker.RunWorkerAsync(arguments);
    }

    private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      List<object> arguments = (List<object>)e.Argument;
      string LastCommand = (string)arguments[0];
      int taskID = (int)arguments[1];

      Logger.Log.Debug("backgroundWorker_DoWork: task=" + taskID.ToString() + " " + LastCommand);

      try
      {
        var info = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic '" + AppConfigHelper.LastCommand + " &> " + 
                                           AppConfigHelper.LinuxHomeDirectory + "/output" + taskID.ToString() + "'")
        {
          WorkingDirectory = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.LinuxHomeDirectory),
          UseShellExecute = false,
          CreateNoWindow = true,
          RedirectStandardInput = true,
          RedirectStandardOutput = true,
          RedirectStandardError = true
        };

        //using (var p = Process.Start(info))
        //{
        //  p.WaitForExit();
        //  Logger.Log.Debug(string.Format("backgroundWorker_DoWork: exitcode={0}", p.ExitCode));
        //  RecordStandardOutput(p); // This has to be done here; does not recognize StandardOut in RunWorkerCompleted.

        //  e.Result = arguments;  // Error 127 usually means 'command not found'.
        //}

        Process p = Process.Start(info);
        p.WaitForExit();
        Logger.Log.Debug("backgroundWorker_DoWork: completed WaitForExit");
        RecordStandardOutput(p); // This has to be done here; does not recognize StandardOut in RunWorkerCompleted.
        Logger.Log.Debug(string.Format("backgroundWorker_DoWork: exitcode={0}", p.ExitCode));
        p.Close();

        e.Result = arguments;  // Error 127 usually means 'command not found'.
      }
      catch (Exception ex)
      {
        Logger.Log.Debug("backgroundWorker_DoWork: error: " + ex.ToString());
        e.Result = ex;
      }
    }

    private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result != null && e.Result is Exception)
      {
        Logger.Log.Debug("backgroundWorker_RunWorkerCompleted: There was a problem running in the background (" + ((Exception)e.Result).ToString() + ").");
        System.Windows.MessageBox.Show("There was a problem running in the background (" + ((Exception)e.Result).ToString() + 
                                                                                                ").", "Error", (MessageBoxButton)MessageBoxButtons.OK);
        return;
      }

      List<object> arguments = (List<object>)e.Result;

      TaskEventArgs taskEventArgs = new TaskEventArgs();
      taskEventArgs.task = AppConfigHelper.TaskOfID((int)arguments[1]);

      if (taskEventArgs.task != null)
      {
        taskEventArgs.task.StandardOutput = AppConfigHelper.StandardOutput;
        taskEventArgs.task.LastError = AppConfigHelper.LastError;
        taskEventArgs.task.LastExitCode = AppConfigHelper.LastExitCode;

        Logger.Log.Debug(string.Format("backgroundWorker_RunWorkerCompleted: exitcode={0} output={1} error={2}",
                                               taskEventArgs.task.LastExitCode, taskEventArgs.task.StandardOutput, taskEventArgs.task.LastError));
        //System.Windows.MessageBox.Show("Assembly completed.", "Completed", (MessageBoxButton)MessageBoxButtons.OK);

        backgroundTaskComplete?.Invoke(sender, taskEventArgs); // Notify parent we have finished this task.
      }
      else
      {
        Logger.Log.Debug("backgroundWorker_RunWorkerCompleted: task " + arguments[1] + " completed but had already been deleted.");
      }
    }

    public static WSLProxyResponse Build_DB(SeqDB db)
    {
      // eg. ~/seqdb/seqdb build_db -i /data/amrDBinput/organism -o /data/amrDB/hpsuis/hpsuis.fasta
      if (db.BuildTreeWildReference.Length > 0)
      {
        // Also copy the wild to the database folder so it can be used in the future.
        if (File.Exists(db.BuildTreeWildReference))
        {
          db.BuildTreeDomesticReference = AppConfigHelper.GetDirectoryName(AppConfigHelper.NormalizePathToWindows(db.DBPath)) +
                                                        "\\" + Path.GetFileName(AppConfigHelper.NormalizePathToWindows(db.BuildTreeWildReference));
          File.Copy(db.BuildTreeWildReference, db.BuildTreeDomesticReference, true);
          db.BuildTreeWildReference = string.Empty; // No longer need to overload it, now available for its intended purpose.
        }
      }

      if (!Directory.Exists(db.DBPath))
      {
        Directory.CreateDirectory(db.DBPath);
      }

      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " build_db -i " + AppConfigHelper.NormalizePathToLinux(db.Build_DBInput) + 
                                                                             " -o " + AppConfigHelper.NormalizePathToLinux(db.DBPath);
      return StandardCallToWSL();
    }

    internal static int DeleteDB()
    {
      SeqDB db = AppConfigHelper.seqdbConfig.Current();
      string filename = AppConfigHelper.NormalizePathToWindows(db.DBPath);
      if (File.Exists(filename))
      {
        string path = AppConfigHelper.GetDirectoryName(filename);
        Directory.Delete(path, true);

        AppConfigHelper.seqdbConfig.seqDBs.Remove(AppConfigHelper.seqdbConfig.LastDBSelected); // Remove all traces of this database.
        AppConfigHelper.SaveConfig();
        string dbName = AppConfigHelper.seqdbConfig.LastDBSelected;
        AppConfigHelper.seqdbConfig.LastDBSelected = AppConfigHelper.CurrentDBName();

        // Also update the global config to remove the database.
        db = AppConfigHelper.seqdbConfigGlobal.seqDBs[dbName];
        AppConfigHelper.seqdbConfigGlobal.seqDBs.Remove(dbName); // Remove all traces of this database.
        AppConfigHelper.seqdbConfigGlobal.LastDBSelected = AppConfigHelper.seqdbConfig.LastDBSelected;

        if (db.KipperPath != null) // This should be done first because these files might be in the same folder as the one being deleted below.
        {
          if (Directory.Exists(AppConfigHelper.NormalizePathToWindows(db.KipperPath))) // it could have been deleted if it was already in the same folder as the database itself.
          {
            DirectoryInfo dir = new DirectoryInfo(AppConfigHelper.NormalizePathToWindows(db.KipperPath));
            foreach (FileInfo file in dir.EnumerateFiles(db.KipperFilenamePrefix + "*.*"))
            {
              if (File.Exists(file.FullName)) // it could have been deleted if it was already in the same folder as the database itself.
              {
                file.Delete();
              }
            }
          }
        }
        AppConfigHelper.SaveConfigGlobal();
      }
      return 0;
    }

    public static string GetVersions(string dbPath)
    {
      // There are backup versions if there is a kipper.cfg file in the dbPath. In that case, get the path of the backup file.
      string versionString = string.Empty;
      Process P;
      int result;

      string kipperPath = AppConfigHelper.CurrentKipperPath() + "/" + AppConfigHelper.CurrentKipperFilenamePrefix();
      if (kipperPath == "/")
      {
        var infoCat = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic 'cat " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.GetDirectoryName(dbPath)) + "/kipper.cfg'")
        {
          UseShellExecute = false,
          CreateNoWindow = true,
          RedirectStandardInput = true,
          RedirectStandardOutput = true, // We can catch the output here.
          RedirectStandardError = true
        };
        P = Process.Start(infoCat);
        P.WaitForExit();
        result = P.ExitCode;

        if (result != 0)
        {
          return versionString; // No backup yet.
        }

        string kipper = P.StandardOutput.ReadToEnd(); // eg. "DB_PATH=\"/home/arnie/hpsuis_db/db/hpsuis\"\n"
        P.Close();

        kipper = kipper.Replace("\n", string.Empty).Replace("\"", string.Empty);
        kipperPath = kipper.Substring(kipper.IndexOf('=') + 1);
        AppConfigHelper.UpdateKipperPath(kipperPath.Substring(kipperPath.LastIndexOf("/") + 1), kipperPath.Substring(0, kipperPath.LastIndexOf("/")));
      }

      if (File.Exists(@"C:\Temp\versions.txt"))
      {
        File.Delete(@"C:\Temp\versions.txt");
      }

      kipperPath = AppConfigHelper.NormalizePathToLinux(kipperPath);
      AppConfigHelper.LastKipperList = "bash -ic '" + AppConfigHelper.CondaPrefix() + " " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.PathToSeqDB()) + 
                              " kipper -l  -d " + kipperPath + " > " + AppConfigHelper.LinuxCDrive() + "/Temp/versions.txt'";
      var info = new ProcessStartInfo(AppConfigHelper.PathToWSL(), AppConfigHelper.LastKipperList)
      {
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true
      };

      P = Process.Start(info);
      P.WaitForExit();
      result = P.ExitCode;

      versionString = File.ReadAllText(@"c:\Temp\versions.txt");

      if (result != 0)
      {
        Logger.Log.Debug("ERROR: " + versionString.Replace("\n", Environment.NewLine));
        Logger.Log.Debug("ERROR: " + P.StandardOutput.ReadToEnd() + Environment.NewLine + P.StandardError.ReadToEnd());
        P.Close();
        return string.Empty;
      }

      P.Close();
      AppConfigHelper.UpdateKipperPath(kipperPath.Substring(kipperPath.LastIndexOf("/") + 1), kipperPath.Substring(0, kipperPath.LastIndexOf("/")));
      return versionString.Replace("\n", Environment.NewLine);
    }

    internal static List<string> SampleIDs()
    {
      Process P;
      int result;
      List<string> sampleIDList = new List<string>();

      AppConfigHelper.LastError = string.Empty;

      string grepCmd = "grep \">\" " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath());
      var info = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic '" + grepCmd + " > " + AppConfigHelper.LinuxCDrive() + "/Temp/sampleIDs.txt'")
      {
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true
      };

      P = Process.Start(info);
      P.WaitForExit();
      result = P.ExitCode;

      if (result == 0)
      {
        string separator = AppConfigHelper.ShowDetail ? " " : "|";
        string sampleIDstring = File.ReadAllText(@"c:\\Temp\sampleIDs.txt");
        string[] samples = sampleIDstring.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string sample in samples)
        {
          string s = sample.Substring(1) + " "; // skip >
          if (!sampleIDList.Contains(s.Substring(0, s.IndexOf(separator))))
          {
            sampleIDList.Add(s.Substring(0, s.IndexOf(separator)));
          }
        }
      }
      else
      {
        RecordStandardOutput(P);
      }

      P.Close();
      return sampleIDList;
    }

    private static void RecordStandardOutput(Process P)
    {
      AppConfigHelper.LastError = string.Empty;
      AppConfigHelper.StandardOutput = P.StandardOutput.ReadToEnd();
      if (P.ExitCode != 0)
      {
        AppConfigHelper.LastError = P.StandardError.ReadToEnd();
      }
      AppConfigHelper.LastExitCode = P.ExitCode;
      AppConfigHelper.SaveConfig();
    }

    public static WSLProxyResponse ExtractSample(string sampleID, string outputPath)
    {
      // eg. ~/seqdb/seqdb extract -q 1616822_Hp -d /data/amrDB/hpsuis/hpsuis_db.fasta > /data/amrDB/hpsuis/extracted.fasta
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " extract -q " + sampleID + " -d " +
                                  AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath()) + " > " + 
                                  outputPath + "/" + sampleID + ".fasta";
      return StandardCallToWSL();
    }

    public static WSLProxyResponse Kraken2()
    {
      WSLProxyResponse WSLResponse = null;
      string inputFile = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InputPath("Kraken2"));
      if (AppConfigHelper.SampleChecked("Kraken2"))
      {
        // First extract the fasta file from the database.  
        WSLResponse = ExtractSample(AppConfigHelper.SampleID("Kraken2"), AppConfigHelper.NormalizePathToLinux("C:\\Temp"));
        if (WSLResponse.ExitCode == 0)
        {
          inputFile = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/" + AppConfigHelper.SampleID("Kraken2") + ".fasta";
        }
        else
        {
          return WSLResponse;
        }
      }

      // eg. /usr/local/kraken2/kraken2 --db /data/referenceDB/minikraken2_v1_8GB/ --threads 64 --report kraken.aggregates.txt --use-names --output kraken.txt $contig
      //     conda run -n refseq_masher-0.1.1 refseq_masher matches --output-type tab -o RefseqIdent.txt $contig
      AppConfigHelper.LastCommand = "/usr/local/kraken2/kraken2 --db /data/referenceDB/minikraken2_v1_8GB/ --threads 16 --report " +
                         AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("Kraken2") + "/kraken.aggregates.txt") + " --use-names --output " + 
                         AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("Kraken2") + "/kraken.txt") + " " + inputFile;
      WSLResponse = StandardCallToWSL();
      if (WSLResponse.ExitCode == 0)
      {
        AppConfigHelper.LastCommand = "conda run -n refseq_masher-0.1.1 refseq_masher matches --output-type tab -o " +
                                AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("Kraken2") + "/RefseqIdent.txt ") + inputFile;
        if (AppConfigHelper.SampleChecked("Kraken2"))
        {
          File.Delete("C:\\Temp\\" + AppConfigHelper.SampleID("Kraken2") + ".fasta");
        }
        return StandardCallToWSL();
      }

      return WSLResponse;
    }

    internal static WSLProxyResponse BBMap()
    {
      WSLProxyResponse WSLResponse = null;
      string inputFile = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InputPath("BBMap"));
      if (AppConfigHelper.SampleChecked("BBMap"))
      {
        // First extract the fasta file from the database.   
        WSLResponse = ExtractSample(AppConfigHelper.SampleID("BBMap"), AppConfigHelper.NormalizePathToLinux("C:\\Temp"));
        if (WSLResponse.ExitCode != 0)
        {
          return WSLResponse;
        }
        inputFile = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/" + AppConfigHelper.SampleID("BBMap") + ".fasta";
      }

      // Might need to consolidate multiple fastq files into one.
      string fastqPath = AppConfigHelper.BBMapFastqPath();
      string[] files = Directory.GetFiles(fastqPath, "*.fastq", SearchOption.TopDirectoryOnly);
      if (files.Length == 0)
      {
        WSLResponse = new WSLProxyResponse();
        WSLResponse.ExitCode = -3;
        WSLResponse.StandardError = "No *.fastq files found in " + fastqPath + ".";
        return WSLResponse;
      }

      //     cat $samplePath/*.fastq > ${sampleName}.fastq
      string fastqOutput = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/sample.fastq";
      ProcessStartInfo infoCat = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic 'cat " + 
                                                      AppConfigHelper.NormalizePathToLinux(fastqPath) + "/*.fastq > " + fastqOutput + "'")
      {
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true, // We can catch the output here.
        RedirectStandardError = true
      };
      Process P = Process.Start(infoCat);
      P.WaitForExit();
      int result = P.ExitCode;

      if (result != 0)
      {
        WSLResponse = new WSLProxyResponse();
        WSLResponse.ExitCode = -2;
        WSLResponse.StandardError = "Catenate to output " + fastqOutput + " failed for " + fastqPath + ".";
        return WSLResponse;
      }

      // Convert fastq to fastq
      // seqtk seq -A BC87_reads.fastq > sample.fasta
      string fastaReads = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/sample.fasta";
      infoCat = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic 'seqtk seq -A " + fastqOutput + " > " + fastaReads + "'")
      {
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true, // We can catch the output here.
        RedirectStandardError = true
      };
      P = Process.Start(infoCat);
      P.WaitForExit();
      result = P.ExitCode;
      if (result != 0)
      {
        WSLResponse = new WSLProxyResponse();
        WSLResponse.ExitCode = -4;
        WSLResponse.StandardError = P.StandardError.ReadToEnd();
        WSLResponse.StandardOutput = P.StandardOutput.ReadToEnd();
        return WSLResponse;
      }

      P.Close();

      // /usr/local/bbmap/bbmap.sh nodisk=f ref=BC87_trinity_assembly_minimap2/Trinity.fasta in=sample.fasta covstats=covstats.txt covhist=covhist.txt  basecov=basecov.txt bincov=bincov.txt
      // rm sample.fasta

      string outputPath = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("BBMap"));
      string bbmapInvocation = AppConfigHelper.CondaPrefix() + " bbmap.sh"; // On my machine, bbmap.sh is installed in conda.
      if (true)
      {
        bbmapInvocation = "/usr/local/bbmap/bbmap.sh"; // Where bbmap.sh is installed on WIMMER (set condition to true).
      }
      AppConfigHelper.LastCommand = bbmapInvocation + " nodisk=f ref=" + inputFile + " in=" + fastaReads + " covstats=" + outputPath + 
                        "/covstats.txt covhist=" + outputPath + "/covhist.txt basecov=" + outputPath + "/basecov.txt bincov=" + outputPath + "/bincov.txt";
      WSLResponse = StandardCallToWSL();
      if (WSLResponse.ExitCode == 0)
      {
        AppConfigHelper.LastCommand = "conda run -n refseq_masher-0.1.1 refseq_masher matches --output-type tab -o " + outputPath + "/RefseqIdent.txt " + inputFile;
        WSLResponse = StandardCallToWSL();
        if (WSLResponse.ExitCode == 0)
        {
          if (AppConfigHelper.SampleChecked("BBMap"))
          {
            File.Delete("C:\\Temp\\" + AppConfigHelper.SampleID("BBMap") + ".fasta");
          }

          // Get rid of sample.fasta and the fastq file.
          if (File.Exists(@"c:\Temp\sample.fastq"))
          {
            File.Delete(@"c:\Temp\sample.fastq");
          }
          if (File.Exists(@"c:\Temp\sample.fasta"))
          {
            File.Delete(@"c:\Temp\sample.fasta");
          }
        }
      }

      return WSLResponse;
    }

    internal static WSLProxyResponse VFabricate()
    {
      // ./VFabricateBioSeqDB.sh ${samplepath} $contig $vfabricate $output path
      //# $1 Sample name (Use 'Abricate' when no sample picked).
      //# $2 Input contig path
      //# $3 Gene XRef path
      //# $4 Output folder
      string inputFile = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InputPath("VFabricate"));
      string sampleName = "Abricate";
      if (AppConfigHelper.SampleChecked("VFabricate"))
      {
        // First extract the fasta file from the database.          
        sampleName = AppConfigHelper.SampleID("VFabricate");
        WSLProxyResponse WSLResponse = ExtractSample(sampleName, AppConfigHelper.NormalizePathToLinux("C:\\Temp"));
        if (WSLResponse.ExitCode != 0)
        {
          return WSLResponse;
        }
        inputFile = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/" + AppConfigHelper.SampleID("VFabricate") + ".fasta";
      }

      AppConfigHelper.LastCommand = AppConfigHelper.CondaPrefixAbricate() + " ~/VFabricateBioSeqDB.sh " + sampleName + " " + inputFile + " " +
                                              AppConfigHelper.NormalizePathToLinux(AppConfigHelper.VFabricateGeneXref) + " " +
                                              AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("VFabricate")
                                              //+ " &> /mnt/c/Temp/stderr.txt"
                                              );
      return StandardCallToWSL();
    }

    internal static WSLProxyResponse Quast()
    {
      //   /usr/local/quast-5.0.2/quast.py -o quastRA --glimmer $contig

      string inputFile = AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InputPath("Quast"));
      string sampleName = "Quast";
      if (AppConfigHelper.SampleChecked("Quast"))
      {
        // First extract the fasta file from the database.          
        sampleName = AppConfigHelper.SampleID("Quast");
        WSLProxyResponse WSLResponse = ExtractSample(sampleName, AppConfigHelper.NormalizePathToLinux("C:\\Temp"));
        if (WSLResponse.ExitCode != 0)
        {
          return WSLResponse;
        }
        inputFile = AppConfigHelper.NormalizePathToLinux("C:\\Temp") + "/" + AppConfigHelper.SampleID("Quast") + ".fasta";
      }

      AppConfigHelper.LastCommand = "/usr/local/quast-5.0.2/quast.py -o " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.OutputPath("Quast") + 
                                                            "/quast" + sampleName + " --glimmer " + inputFile 
                                                                  //+ " &> /mnt/c/Temp/stderr.txt"
                                                              );
      return StandardCallToWSL();
    }

    public static WSLProxyResponse SearchSample()
    {
      // eg. ~/seqdb/seqdb search -q 1808103_Hp -c 1 -t 16 -i /home/arnie/1808103_Hp.fasta -d /data/amrDB/hpsuis/hpsuis_db.fasta -o /c/Temp/1808103_Hp.txt
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " search -q " + AppConfigHelper.SearchSampleID() +
                                      " -i " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.SearchInputPath()) + 
                                      " -c " + AppConfigHelper.SearchCutoff() + 
                                      " -t " + AppConfigHelper.SearchThreads() + 
                                      " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath()) + 
                                      " -o " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.SearchOutputPath() + 
                                                                      "\\" + AppConfigHelper.SearchSampleID() + ".txt");
      return StandardCallToWSL();
    }

    //public static WSLProxyResponse RemoveSample()
    //{
    //  // eg. ~/seqdb/seqdb remove -q 1616822_Hp -d /data/amrDB/hpsuis/hpsuis_db.fasta
    //  AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " remove -q " + AppConfigHelper.RemoveSampleIDs() + 
    //                                                                       " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath());
    //  return StandardCallToWSL();
    //}

    public static WSLProxyResponse InsertSample()
    {
      // eg. ~/seqdb/seqdb insert -q 1616822_Hp -i /data/amrDB/hpsuis/extracted.fasta -d /data/amrDB/hpsuis/hpsuis_db.fasta
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " insert -q " + AppConfigHelper.InsertSampleID() +
                                          " -i " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InsertInputPath()) +
                                          " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath());
      return StandardCallToWSL();
    }

    public static WSLProxyResponse ReplaceSample()
    {
      // This uses the same parameters as the InsertSample function.
      // eg. ~/seqdb/seqdb replace -q 1616822_Hp -i /data/amrDB/hpsuis/extracted.fasta -d /data/amrDB/hpsuis/hpsuis_db.fasta
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " replace -q " + AppConfigHelper.InsertSampleID() +
                                          " -i " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.InsertInputPath()) + 
                                          " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath());
      return StandardCallToWSL();
    }

    public static WSLProxyResponse BackupDatabase()
    {
      // eg. ~/seqdb/seqdb kipper -b  -i /data/amrDB/hpsuis/hpsuis_db.fasta -d ~/hpsuis_db/db/hpsuis
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " kipper -b -i " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentDBPath()) +
                                                      " -d " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.CurrentKipperPath() + "\\" + 
                                                                                            AppConfigHelper.CurrentKipperFilenamePrefix());
      return StandardCallToWSL();
    }

    internal static WSLProxyResponse RestoreDatabase()
    {
      // eg. ~/seqdb/seqdb kipper <archive path> -e -n <version> -o <output path> 
      AppConfigHelper.LastCommand = AppConfigHelper.PathToSeqDB() + " kipper -r -v " + AppConfigHelper.RestoreVersion() + " -d " +
                  AppConfigHelper.NormalizePathToLinux(AppConfigHelper.RestoreKipperPath() + "\\" + AppConfigHelper.RestoreKipperFilenamePrefix()) + 
                  " -o " + AppConfigHelper.NormalizePathToLinux(AppConfigHelper.RestoreOutputPath());
      return StandardCallToWSL();
    }

    private static WSLProxyResponse StandardCallToWSL()
    {
      //string prefix = "cd;export PATH=/home/arnie/.local/bin:/home/arnie/bin:/snap/bin:/home/arnie/.dotnet/tools:$PATH;"; // Prepend to each invocation of wsl.

      AppConfigHelper.StandardOutput = string.Empty;
      AppConfigHelper.LastError = string.Empty;
      AppConfigHelper.LastExitCode = 0;

      Logger.Log.Debug("StandardCallToWSL: " + AppConfigHelper.LastUser + " CMD: " + AppConfigHelper.LastCommand);

      var info = new ProcessStartInfo(AppConfigHelper.PathToWSL(), "bash -ic '" + AppConfigHelper.CondaPrefix() + " " + AppConfigHelper.LastCommand + "'")
      {
        WorkingDirectory = AppConfigHelper.NormalizePathToWindows(AppConfigHelper.LinuxHomeDirectory),
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true
      };

      WSLProxyResponse WSLResponse = new WSLProxyResponse();
      int rc = -1;
      using (var p = Process.Start(info))
      {
        p.WaitForExit();
        RecordStandardOutput(p);
        rc = p.ExitCode;
        WSLResponse.ExitCode = rc;
        WSLResponse.StandardOutput = p.StandardOutput.ReadToEnd();
        WSLResponse.StandardError = p.StandardError.ReadToEnd();
        p.Close();
      }

      return WSLResponse;
    }

    public static void ExecuteCommandLine(string fullCommandLine,
                                    string workingFolder = null,
                                    int waitForExitMs = 0,
                                    string verb = "OPEN",
                                    ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal)
    {
      string executable = fullCommandLine;
      string args = null;

      if (executable.StartsWith("\""))
      {
        int at = executable.IndexOf("\" ");
        if (at > 0)
        {
          args = executable.Substring(at + 1).Trim();
          executable = executable.Substring(0, at);
        }
      }
      else
      {
        int at = executable.IndexOf(" ");
        if (at > 0)
        {
          if (executable.Length > at + 1)
          {
            args = executable.Substring(at + 1).Trim();
          }
          executable = executable.Substring(0, at);
        }
      }

      var pi = new ProcessStartInfo();
      //pi.UseShellExecute = true;
      pi.Verb = verb;
      pi.WindowStyle = windowStyle;

      pi.FileName = executable;
      pi.WorkingDirectory = workingFolder;
      pi.Arguments = args;

      using (var p = Process.Start(pi))
      {
        if (waitForExitMs > 0)
        {
          if (!p.WaitForExit(waitForExitMs))
            throw new TimeoutException("Process failed to complete in time.");
        }
      }
    }
  }
}