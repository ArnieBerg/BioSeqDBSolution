using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqRemove : Form
  {
    // Remove sample(s) from the database.

    public BioSeqRemove()
    {
      InitializeComponent();
      lstSampleIDs.Items.AddRange(AppConfigHelper.RemoveSampleIDs.ToArray());
      btnOK.Enabled = lstSampleIDs.Items.Count > 0;
    }
  }
}