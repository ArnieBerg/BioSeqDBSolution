using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqSplash : Form, ISplashForm
  {
    public BioSeqSplash()
    {
      InitializeComponent();
    }

    #region ISplashForm
    void ISplashForm.SetStatusInfo(string NewStatusInfo)
    {
      lbStatusInfo.Text = NewStatusInfo;
    }
    #endregion
  }
}