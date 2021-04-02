using BioSeqDB.ModelClient;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqDBAbout : Form
  {
    private Dictionary<int, ThreadStat> threadStats;
    private Dictionary<string, UserStat> userStats;

    public BioSeqDBAbout()
    {
      InitializeComponent();
      lblLastSeqDBCall.Text = AppConfigHelper.LastCommand;
      threadStats = new Dictionary<int, ThreadStat>();
      userStats = new Dictionary<string, UserStat>();
    }

    private void panel1_Click(object sender, System.EventArgs e)
    {
      Clipboard.SetText(lblLastSeqDBCall.Text);
      MessageBox.Show("Last command text copied.", "Copy", MessageBoxButtons.OK);
    }

    private void BioSeqDBAbout_Shown(object sender, System.EventArgs e)
    {
      //labelVersion.Text = string.Format("Version {0} ", Assembly.GetExecutingAssembly().GetName().Version.ToString());

      string currentVersion = string.Empty;
      if (ApplicationDeployment.IsNetworkDeployed)
      {
        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
        currentVersion = ad == null ? string.Empty : ad.CurrentVersion.ToString();
      }
      labelVersion.Text = string.Format("Version {0} ", Assembly.GetExecutingAssembly().GetName().Version.ToString() + " v." + currentVersion);
      labelVersion.Visible = true;
      lblServer.Text = "Server: " + Properties.Settings.Default.ModelServer;
      lblServer.Visible = true;
      ShowStats();
    }

    private void ShowStats()
    {
      threadStats = BioSeqDBModel.Instance.GetThreadStats();

      lvThreads.Items.Clear();
      foreach (int key in threadStats.Keys)
      {
        ListViewItem lvItem = new ListViewItem(key.ToString());
        lvItem.SubItems.Add(threadStats[key].threadID.ToString());
        lvItem.SubItems.Add(threadStats[key].StartTime ?? "(idle)");
        lvItem.SubItems.Add(threadStats[key].User ?? string.Empty);
        lvItem.SubItems.Add(threadStats[key].Memo ?? string.Empty);
        string s1 = threadStats[key].Request ?? string.Empty;
        if (s1.EndsWith("--stats"))
        {
          s1 = "(thread stats)";
          lvItem.BackColor = System.Drawing.Color.LawnGreen;
        }
        lvItem.SubItems.Add(s1);
        lvThreads.Items.Insert(lvThreads.Items.Count, lvItem);
      }

      userStats = BioSeqDBModel.Instance.GetUserStats();

      lvUsers.Items.Clear();
      foreach (string key in userStats.Keys)
      {
        ListViewItem lvItem = new ListViewItem(key.ToString());
        lvItem.SubItems.Add(userStats[key].LoginTime);
        lvItem.SubItems.Add(userStats[key].LastActiveTime);
        lvItem.SubItems.Add(userStats[key].LogoutTime);
        lvItem.BackColor = System.Drawing.Color.FromArgb(255, System.Drawing.Color.FromArgb(userStats[key].BackColor));
        lvUsers.Items.Insert(lvUsers.Items.Count, lvItem);
      }
    }

    private void pictureBox1_Click(object sender, System.EventArgs e)
    {
      ShowStats();
    }

    private void btnChangeLog_Click(object sender, System.EventArgs e)
    {
      try
      {
        Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ChangeLog.txt");
      }
      finally { }
    }
  }
}
