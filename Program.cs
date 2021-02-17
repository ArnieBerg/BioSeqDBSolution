using BioSeqDB.ModelClient;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BioSeqDB
{
  static class Program
  {
    private static Mutex s_Mutex; // To detect multiple instance.

    /// <summary>
    /// Our logger.
    /// </summary>
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      s_Mutex = new Mutex(true, "BioSeqDB");

      if (!s_Mutex.WaitOne(0, false))
        return;

      Cursor.Current = Cursors.WaitCursor;
      Logger.Initialize(logger);

      // Check if BioSeqService is listening.
      string fiClientOnServer = string.Empty;
      try
      {
        fiClientOnServer = ServiceCallHelper.HelloBioSeqDBService();
      }
      catch (Exception ex)
      {
        MessageBox.Show("It appears that the BioSeqDB service is not running on the '" + Properties.Settings.Default.ModelServer + 
                                                                                      "' server.", "ERROR", MessageBoxButtons.OK);
        return;
      }

      // Check if WSLProxy is listening.
      try
      {
        string message = BioSeqDBModel.Instance.WSLVersion();
      }
      catch (Exception ex)
      {
        MessageBox.Show("It appears that the WSLProxy service is not running on the server.", "ERROR", MessageBoxButtons.OK);
        Logger.Log.Debug("It appears that the WSLProxy service is not running on the server. Exception\n" + ex.ToString());
        return;
      }

      try
      {
        BioSeqDBLogin frmLogin = new BioSeqDBLogin(fiClientOnServer);
        if (frmLogin.ShowDialog() == DialogResult.OK)
        {
          Application.Run(new BioSeqUI());
        }
      }
      catch (Exception ex)
      {
        Logger.Log.Debug("Fatal error: " + ex.ToString());
        MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK);
      }
    }
  }
}
