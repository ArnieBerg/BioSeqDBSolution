using System;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqRemove : Form
  {
    // Remove a sample from the database.

    public BioSeqRemove()
    {
      InitializeComponent();
      btnOK.Enabled = false;
      txtSampleID.Text = AppConfigHelper.RemoveSampleID();
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtSampleID.Text.Trim().Length > 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      AppConfigHelper.RemoveSample(txtSampleID.Text.Trim());
    }

    private void txtSampleID_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }
  }
}