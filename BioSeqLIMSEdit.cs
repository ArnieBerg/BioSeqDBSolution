using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqLIMSEdit : Form
  {
    // Edit the LIMS identifiers for any SeqDB sample.

    private Dictionary<string, string> LIMSBaseList; // Key is LIMS identifiers. This is the list since the last Apply.
    private Dictionary<string, string> LIMSList; // Key is SeqDB sample identifiers. This is the current list with active changes.
    // private bool isDirty; Instead of using an isDirty flag, use the Enabled status of btnApply.
    private string LIMSListKey; // Current LIMSList selection.

    public BioSeqLIMSEdit()
    {
      InitializeComponent();

      btnOK.Enabled = false;
      btnApply.Enabled = false;

      Cursor.Current = Cursors.WaitCursor;
      LIMSBaseList = ServiceCallHelper.ReadLIMSData(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig());
      LIMSList = new Dictionary<string, string>();
      foreach (string key in LIMSBaseList.Keys)
      {
        LIMSList.Add(LIMSBaseList[key], key);
      }

      lstSampleIDs.Items.Clear();
      lstSampleIDs.Items.AddRange(ServiceCallHelper.SampleIDs(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig()).ToArray());
      if (lstSampleIDs.Items.Count > 0)
      {
        lstSampleIDs.SetSelected(0, true);

        lstSampleIDs.ItemCheck -= lstSampleIDs_ItemCheck;
        for (int i = 0; i < lstSampleIDs.Items.Count; i++)
        {
          lstSampleIDs.SetItemChecked(i, LIMSList.ContainsKey(lstSampleIDs.Items[i].ToString()));
        }
        lstSampleIDs.ItemCheck += lstSampleIDs_ItemCheck;
      }
      Cursor.Current = Cursors.Default;
    }

    private void TrafficLightSwitch()
    {
      bool greenLight = true;
      btnApply.Enabled = btnOK.Enabled = false;

      if ((txtCaseNumber.Text.Trim() == string.Empty || txtLIMSTestID.Text.Trim() == string.Empty || txtLIMSSampleID.Text.Trim() == string.Empty) &&
                                                      (txtCaseNumber.Text.Trim() + txtLIMSSampleID.Text.Trim() + txtLIMSSampleID.Text.Trim()).Length > 0)
      {
        greenLight = false;
      }
      else // Commit the changes to LIMSList.
      {
        if (IsDuplicate())
        {
          greenLight = false;
        }
        else
        {
          if (LIMSList.ContainsKey(LIMSListKey))
          {
            if ((txtCaseNumber.Text.Trim() + ";" + txtLIMSTestID.Text.Trim() + ";" + txtLIMSSampleID.Text.Trim()) == ";;") // remove this sample
            {
              LIMSList.Remove(LIMSListKey);
            }
            else // Update
            {
              LIMSList[LIMSListKey] = txtCaseNumber.Text.Trim() + ";" + txtLIMSTestID.Text.Trim() + ";" + txtLIMSSampleID.Text.Trim();
            }
          }
          else if ((txtCaseNumber.Text.Trim() + ";" + txtLIMSTestID.Text.Trim() + ";" + txtLIMSSampleID.Text.Trim()) != ";;")  // insert
          {
              LIMSList[LIMSListKey] = txtCaseNumber.Text.Trim() + ";" + txtLIMSTestID.Text.Trim() + ";" + txtLIMSSampleID.Text.Trim();
          }
          btnApply.Enabled = btnOK.Enabled = AnyChanges();
        }
      }

      picLights.BackgroundImage = greenLight ? Properties.Resources.greenlight : Properties.Resources.redlight;
      picLights.Refresh();
      picLights.Visible = true;
    }

    private bool AnyChanges()
    {
      // Compare the two LIMS lists and return true if there are any differences.
      if (LIMSList.Keys.Count != LIMSBaseList.Keys.Count)
      {
        return true;
      }

      foreach (string value in LIMSList.Values)
      {
        if (!LIMSBaseList.Keys.Contains(value))
        {
          return true;
        }
      }

      foreach (string value in LIMSBaseList.Values)
      {
        if (!LIMSList.Keys.Contains(value))
        {
          return true;
        }
      }

      return false;
    }

    private bool IsDuplicate()
    {
      // Return true if the current values occur in LIMSList for another sample.
      string values = txtCaseNumber.Text.Trim() + ";" + txtLIMSTestID.Text.Trim() + ";" + txtLIMSSampleID.Text.Trim();
      if (values == ";;")
      {
        return false;
      }

      foreach (string key in LIMSList.Keys)
      {
        if (LIMSList[key] == values && key != LIMSListKey)
        {
          return true;
        }
      }

      return false;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (btnApply.Enabled) // prompt to save changes
      {
        ConfirmApply.MainInstruction = "There are outstanding changes.  Do you want to apply them?";
        TaskDialogButton button = ConfirmApply.ShowDialog(this);
        if (button == btnYes)
        {
          btnApply_Click(sender, e);
        }
      }
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      // Copy LIMSList to LIMSBaseList and write to <dbname>_LIMS.fasta.
      //LIMSBaseList = LIMSList.ToDictionary(entry => entry.Key, entry => entry.Value);

      LIMSBaseList = new Dictionary<string, string>();
      foreach (string key in LIMSList.Keys)
      {
        LIMSBaseList.Add(LIMSList[key], key);
      }
      ServiceCallHelper.WriteLIMSData(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), LIMSBaseList);
      btnApply.Enabled = btnOK.Enabled = AnyChanges(); // There should not be any.
      lstSampleIDs.ItemCheck -= lstSampleIDs_ItemCheck;
      lstSampleIDs.SetItemChecked(lstSampleIDs.SelectedIndex, true);
      lstSampleIDs.ItemCheck += lstSampleIDs_ItemCheck;
    }

    private string KeyOfValue(string sampleID, Dictionary<string, string> dict)
    {
      foreach (string key in dict.Keys)
      {
        if (dict[key] == sampleID)
        {
          return key;
        }
      }

      return string.Empty;
    }

    private void lstSampleIDs_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      e.NewValue = e.CurrentValue; // Keep it the same, cannot change.
    }

    private void lstSampleIDs_SelectedIndexChanged(object sender, EventArgs e)
    {
      // For the selected sample, display current values, and put base values in tool tips for text fields if different.
      txtCaseNumber.TextChanged -= txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged -= txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged -= txtLIMSSampleID_TextChanged;

      txtCaseNumber.Text = txtLIMSTestID.Text = txtLIMSSampleID.Text = string.Empty;
      txtCaseNumber.Tag = txtLIMSTestID.Tag = txtLIMSSampleID.Tag = string.Empty;
      toolTip1.SetToolTip(txtCaseNumber, string.Empty);
      toolTip1.SetToolTip(txtLIMSTestID, string.Empty);
      toolTip1.SetToolTip(txtLIMSSampleID, string.Empty);

      LIMSListKey = lstSampleIDs.SelectedItem.ToString();
      if (LIMSList.ContainsKey(LIMSListKey) && LIMSList[LIMSListKey].Length > 0)
      {
        string[] fields = LIMSList[LIMSListKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        txtCaseNumber.Text = fields[0];
        txtLIMSTestID.Text = fields[1];
        txtLIMSSampleID.Text = fields[2];

        string key = KeyOfValue(LIMSListKey, LIMSBaseList);
        if (key.Length > 0)
        {
          fields = key.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
          toolTip1.SetToolTip(txtCaseNumber, fields[0]);
          txtCaseNumber.Tag = fields[0]; // Keep base values in Tag as well as tooltip.
          toolTip1.SetToolTip(txtLIMSTestID, fields[1]);
          txtLIMSTestID.Tag = fields[1];
          toolTip1.SetToolTip(txtLIMSSampleID, fields[2]);
          txtLIMSSampleID.Tag = fields[2];
        }
      }

      txtCaseNumber.TextChanged += txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged += txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged += txtLIMSSampleID_TextChanged;

      TrafficLightSwitch();
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
      txtCaseNumber.TextChanged -= txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged -= txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged -= txtLIMSSampleID_TextChanged;

      txtCaseNumber.Text = (string)txtCaseNumber.Tag;
      txtLIMSTestID.Text = (string)txtLIMSTestID.Tag;
      txtLIMSSampleID.Text = (string)txtLIMSSampleID.Tag;

      txtCaseNumber.TextChanged += txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged += txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged += txtLIMSSampleID_TextChanged;

      TrafficLightSwitch();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtCaseNumber.TextChanged -= txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged -= txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged -= txtLIMSSampleID_TextChanged;

      txtCaseNumber.Text = txtLIMSTestID.Text = txtLIMSSampleID.Text = string.Empty;
      lstSampleIDs.ItemCheck -= lstSampleIDs_ItemCheck;
      lstSampleIDs.SetItemChecked(lstSampleIDs.SelectedIndex, false);
      lstSampleIDs.ItemCheck += lstSampleIDs_ItemCheck;

      txtCaseNumber.TextChanged += txtCaseNumber_TextChanged;
      txtLIMSTestID.TextChanged += txtLIMSTestID_TextChanged;
      txtLIMSSampleID.TextChanged += txtLIMSSampleID_TextChanged;

      TrafficLightSwitch();
    }

    private void txtCaseNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.KeyChar = (e.KeyChar.ToString().ToUpper())[0];
    }

    private void txtLIMSTestID_KeyPress(object sender, KeyPressEventArgs e)
    {
      OnlyNumeric(e);
    }

    private void txtLIMSSampleID_KeyPress(object sender, KeyPressEventArgs e)
    {
      OnlyNumeric(e);
    }

    private static void OnlyNumeric(KeyPressEventArgs e)
    {
      e.Handled = (!Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back &&
         e.KeyChar != (Char)Keys.Delete) || e.KeyChar == '.';  // Numerics only  isNumeric
    }

    private void txtCaseNumber_TextChanged(object sender, EventArgs e)
    {
      TrafficLightSwitch();
    }

    private void txtLIMSTestID_TextChanged(object sender, EventArgs e)
    {
      TrafficLightSwitch();
    }

    private void txtLIMSSampleID_TextChanged(object sender, EventArgs e)
    {
      TrafficLightSwitch();
    }
  }
}