using BioSeqDB.ModelClient;
using BioSeqDBConfigModel;
using FSExplorer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BioSeqDB
{
  public partial class BioSeqBackupOffsite : Form
  {
    // Backup the priority folders to the target folder on another device.
    private bool isNewRecurEvent;
    private bool IsNewRecurEvent
    {
      get { return isNewRecurEvent; }
      set
      {
        isNewRecurEvent = value;
      }
    }
    private bool ShowingRecurrence { get; set; }
    private Recurrence RecurrenceEvent { get; set; }  // Possible new recurrence event.
    private BackupOffsiteParms backupOffsiteParms { get; set; } // Offsite backup parms stored on server.

    public BioSeqBackupOffsite()
    {
      InitializeComponent();

      btnOK.Enabled = false;
      IsNewRecurEvent = false;
      PopulateUserDropdownAndSelect();
      RecurrenceEvent = new Recurrence();
      RecurrenceEvent.StartDate = dtpStart.Value.Date;
      radWeekly.Checked = true;

      backupOffsiteParms = BioSeqDBModel.Instance.GetBackupOffsiteParms();

      ReloadFolderList();

      txtTargetPath.Text = backupOffsiteParms.TargetPath;
      txtLastBackupDate.Text = backupOffsiteParms.LastBackupBegin != DateTime.MinValue ? backupOffsiteParms.LastBackupBegin.ToString("MMM d, yyyy") : string.Empty;
      txtLastBackupDateEnd.Text = backupOffsiteParms.LastBackupEnd != DateTime.MinValue ? backupOffsiteParms.LastBackupEnd.ToString("MMM d, yyyy") : string.Empty;
      txtLastBackupTime.Text = backupOffsiteParms.LastBackupBegin != DateTime.MinValue ? backupOffsiteParms.LastBackupBegin.ToString("HH:mm:ss") : string.Empty;
      txtLastBackupTimeEnd.Text = backupOffsiteParms.LastBackupEnd != DateTime.MinValue ? backupOffsiteParms.LastBackupEnd.ToString("HH:mm:ss") : string.Empty;
    }

    private void ReloadFolderList()
    {
      if (backupOffsiteParms.BackupFolderList != null && backupOffsiteParms.BackupFolderList.Count > 0)
      {
        int row = -1;
        dgvFolders.RowCount = backupOffsiteParms.BackupFolderList.Count;
        foreach (string key in backupOffsiteParms.BackupFolderList.Keys)
        {
          row++;
          dgvFolders[0, row].Style.BackColor = Color.White;
          dgvFolders[0, row].Style.ForeColor = Color.Black;
          dgvFolders[0, row].Value = string.Empty;
          dgvFolders[1, row].Value = string.Empty;
          dgvFolders[2, row].Value = string.Empty;
          dgvFolders[3, row].Value = string.Empty;
          dgvFolders[4, row].Value = string.Empty;

          BackupFolderDetails backupFolderDetails = backupOffsiteParms.BackupFolderList[key];
          dgvFolders[0, row].Value = backupFolderDetails.Checked;
          dgvFolders[1, row].Value = backupFolderDetails.ID;
          dgvFolders[2, row].Value = backupFolderDetails.Compress;
          dgvFolders[3, row].Value = backupFolderDetails.RetentionDate == DateTime.MinValue ? string.Empty : backupFolderDetails.RetentionDate.ToString("MMM d, yyyy");
          dgvFolders[4, row].Value = backupFolderDetails.FolderPath;
        }
      }
      EnableOK();
    }

    private void PopulateUserDropdownAndSelect()
    {
      // Populate the drop down.
      cmbUser.Items.Clear();
      if (AppConfigHelper.seqdbConfigGlobal.Users.Count > 0)
      {
        foreach (User user in AppConfigHelper.seqdbConfigGlobal.Users.Values)
        {
          cmbUser.Items.Add(user.Username);
        }
      }

      if (!string.IsNullOrEmpty(AppConfigHelper.seqdbConfigGlobal.LastUser))
      {
        for (int i = 0; i < cmbUser.Items.Count; i++)
        {
          if (cmbUser.Items[i].ToString() == AppConfigHelper.seqdbConfigGlobal.LastUser)
          {
            cmbUser.SelectedIndex = i; // Pick the last selected.
            break;
          }
        }
      }
      else
      {
        cmbUser.SelectedIndex = 0;  // Pick the first one.
      }
    }

    private void EnableOK()
    {
      btnOK.Enabled = txtTargetPath.Text.Trim().Length > 0 && backupOffsiteParms.BackupFolderList.Count > 0;
    }

    private void txtDBPath_TextChanged(object sender, EventArgs e)
    {
      EnableOK();
    }

    private void btnFindTargetPath_Click(object sender, EventArgs e)
    {
      string path = AppConfigHelper.NormalizePathToWindows(txtTargetPath.Text + "\\");
      Cursor.Current = Cursors.WaitCursor;
      Explorer.frmExplorer = new Explorer(AppConfigHelper.LoggedOnUser, AppConfigHelper.JsonConfig(), "Target path",
                                          DirectoryHelper.IsServerPath(txtTargetPath.Text), DirectoryHelper.CleanPath(path),
                                          string.Empty, null, AppConfigHelper.UbuntuPrefix());
      Cursor.Current = Cursors.Default;
      Explorer.frmExplorer.ShowDialog();
      if (Explorer.frmExplorer.DialogResult == DialogResult.OK)
      {
        txtTargetPath.Text = Explorer.PresentServerPath + Explorer.PresentLocalPath; // One of these is empty.
      }
      Explorer.frmExplorer = null;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      // Update config to reflect selection.
      backupOffsiteParms.TargetPath = txtTargetPath.Text.Trim();
      BioSeqDBModel.Instance.PutBackupOffsiteParms(backupOffsiteParms);
    }

    private void PanelsInvisible()
    {
      pnlDay.Visible = pnlWeek.Visible = pnlMonth.Visible = pnlYear.Visible = false;
    }

    private void radDaily_Click(object sender, EventArgs e)
    {
      PanelsInvisible();
      pnlDay.Location = new Point(92, 24);
      pnlDay.Visible = true;
      if (!ShowingRecurrence)
      {
        if (isNewRecurEvent) // Establish default values for this event.
        {
          radDaySubrule1.Checked = true;
          RecurrenceEvent.N = 1;
        }
        if (RecurrenceEvent.PrimaryRule != "D")
        {
          RecurrenceEvent.PrimaryRule = "D";
          //ConditionalUpdate();
        }
      }
    }

    private void radDaySubrule1_CheckedChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence && radDaySubrule1.Checked)
      {
        RecurrenceEvent.SubRule = 1;
        RecurrenceEvent.N = string.IsNullOrEmpty(txtDayDay.Text) ? 0 : int.Parse(txtDayDay.Text);
        //ConditionalUpdate();
      }
    }

    private void radDaySubrule2_CheckedChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence && radDaySubrule2.Checked)
      {
        RecurrenceEvent.SubRule = 2;
        //ConditionalUpdate();
      }
    }

    private void radMonthly_Click(object sender, EventArgs e)
    {
      PanelsInvisible();
      pnlMonth.Location = new Point(92, 24);
      pnlMonth.Visible = true;
      if (!ShowingRecurrence)
      {
        if (isNewRecurEvent) // Establish default values for this event.
        {
          radMonthSubrule1.Checked = true;
          RecurrenceEvent.M = 1;
          RecurrenceEvent.N = string.IsNullOrEmpty(txtMonthDay.Text) ? 0 : int.Parse(txtMonthDay.Text);
        }
        if (RecurrenceEvent.PrimaryRule != "M")
        {
          RecurrenceEvent.PrimaryRule = "M";
          //ConditionalUpdate();
        }
      }

      // If after all this the subrule is not selected, select subrule1.
      if (!radMonthSubrule1.Checked && !radMonthSubrule2.Checked)
      {
        radMonthSubrule1.Checked = true;
      }
    }

    private void radMonthSubrule1_CheckedChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence && radMonthSubrule1.Checked)
      {
        RecurrenceEvent.SubRule = 1;
        RecurrenceEvent.N = string.IsNullOrEmpty(txtMonthDay.Text) ? 0 : int.Parse(txtMonthDay.Text);
        RecurrenceEvent.M = string.IsNullOrEmpty(txtMonthMonths1.Text) ? 0 : int.Parse(txtMonthMonths1.Text);
        //ConditionalUpdate();
      }
    }

    private void radMonthSubrule2_CheckedChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence && radMonthSubrule2.Checked)
      {
        RecurrenceEvent.SubRule = 2; // Set up defaults.
        if (cmbMonthFirst.SelectedIndex == -1)
        {
          cmbMonthFirst.SelectedIndex = 0;
        }
        if (cmbMonthDayOfWeek.SelectedIndex == -1)
        {
          cmbMonthDayOfWeek.SelectedIndex = 0;
        }
        RecurrenceEvent.N = cmbMonthFirst.SelectedIndex;
        RecurrenceEvent.M = string.IsNullOrEmpty(txtMonthMonths2.Text) ? 0 : int.Parse(txtMonthMonths2.Text);
        RecurrenceEvent.ComposeDayString(cmbMonthDayOfWeek.SelectedIndex); // Only one of these will be selected.
        //ConditionalUpdate();
      }
    }

    private void radWeekly_Click(object sender, EventArgs e)
    {
      PanelsInvisible();
      pnlWeek.Location = new Point(92, 24);
      pnlWeek.Visible = true;
      if (!ShowingRecurrence)
      {
        if (isNewRecurEvent) // Establish default values for this event.
        {
          radWeekRule1.Checked = true;
          RecurrenceEvent.N = 1;
        }
        if (RecurrenceEvent.PrimaryRule != "W")
        {
          RecurrenceEvent.PrimaryRule = "W";
          //ConditionalUpdate();
        }
      }
    }

    private void radYearly_Click(object sender, EventArgs e)
    {
      PanelsInvisible();
      pnlYear.Location = new Point(92, 24);
      pnlYear.Visible = true;
      pnlYear.BringToFront();

      if (!ShowingRecurrence)
      {
        radYearEvery.Checked = true;
        if (cmbYearMonths.SelectedIndex == -1)
        {
          cmbYearMonths.SelectedIndex = 0;
        }
        if (isNewRecurEvent) // Establish default values for this event.
        {
          RecurrenceEvent.N = 1;
        }
        if (RecurrenceEvent.M == 0)
        {
          RecurrenceEvent.M = string.IsNullOrEmpty(txtYearDayOfMonth.Text) ? 0 : int.Parse(txtYearDayOfMonth.Text);
        }
        if (RecurrenceEvent.PrimaryRule != "Y")
        {
          RecurrenceEvent.PrimaryRule = "Y";
          //ConditionalUpdate();
        }
      }
    }

    private void txtDayDay_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = AppConfigHelper.IsNumeric(e.KeyChar);
    }

    private void txtDayDay_KeyUp(object sender, KeyEventArgs e)
    {
      radDaySubrule1.Checked = true;
      RecurrenceEvent.N = string.IsNullOrEmpty(txtDayDay.Text) ? 0 : int.Parse(txtDayDay.Text);
      RecurrenceEvent.SubRule = 1;
    }

    private void txtMonthDay_KeyUp(object sender, KeyEventArgs e)
    {
      radMonthSubrule1.Checked = true;
      RecurrenceEvent.N = string.IsNullOrEmpty(txtMonthDay.Text) ? 0 : int.Parse(txtMonthDay.Text);
      RecurrenceEvent.SubRule = 1;
    }

    private void txtMonthMonths1_KeyUp(object sender, KeyEventArgs e)
    {
      radMonthSubrule1.Checked = true;
      RecurrenceEvent.M = string.IsNullOrEmpty(txtMonthMonths1.Text) ? 0 : int.Parse(txtMonthMonths1.Text);
      RecurrenceEvent.SubRule = 1;
    }

    private void txtMonthMonths2_KeyUp(object sender, KeyEventArgs e)
    {
      radMonthSubrule2.Checked = true;
      RecurrenceEvent.M = string.IsNullOrEmpty(txtMonthMonths2.Text) ? 0 : int.Parse(txtMonthMonths2.Text);
      RecurrenceEvent.SubRule = 2;
    }

    private void txtWeekWeek_KeyUp(object sender, KeyEventArgs e)
    {
      radWeekRule1.Checked = true;
      RecurrenceEvent.N = string.IsNullOrEmpty(txtWeekWeek.Text) ? 0 : int.Parse(txtWeekWeek.Text);
    }

    private void txtYearDayOfMonth_KeyUp(object sender, KeyEventArgs e)
    {
      radYearEvery.Checked = true;
      RecurrenceEvent.M = string.IsNullOrEmpty(txtYearDayOfMonth.Text) ? 0 : int.Parse(txtYearDayOfMonth.Text);
    }

    private void chkWeekFriday_CheckedChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence)
      {
        radWeekRule1.Checked = true;
        RecurrenceEvent.ComposeWeekString((chkWeekSunday.Checked ? "1" : "0") +
                                          (chkWeekMonday.Checked ? "1" : "0") +
                                          (chkWeekTuesday.Checked ? "1" : "0") +
                                          (chkWeekWednesday.Checked ? "1" : "0") +
                                          (chkWeekThursday.Checked ? "1" : "0") +
                                          (chkWeekFriday.Checked ? "1" : "0") +
                                          (chkWeekSaturday.Checked ? "1" : "0")); // All checked days will be selected.
        RecurrenceEvent.SubRule = 1;
      }
    }

    private void cmbMonthDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence)
      {
        radMonthSubrule2.Checked = true;
        RecurrenceEvent.ComposeDayString(cmbMonthDayOfWeek.SelectedIndex); // Only one of these will be selected.
        RecurrenceEvent.SubRule = 2;
        //ConditionalUpdate();
      }
    }

    private void cmbMonthFirst_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence)
      {
        radMonthSubrule2.Checked = true;
        RecurrenceEvent.N = cmbMonthFirst.SelectedIndex;
        RecurrenceEvent.SubRule = 2;
        //ConditionalUpdate();
      }
    }

    private void cmbYearMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!ShowingRecurrence)
      {
        radYearEvery.Checked = true;
        RecurrenceEvent.N = cmbYearMonths.SelectedIndex;
        //ConditionalUpdate();
      }
    }

    private void btnFolderPicker_Click(object sender, EventArgs e)
    {
      Dictionary<string, string> folderList = new Dictionary<string, string>();
      if (backupOffsiteParms.BackupFolderList != null)
      {
        foreach (BackupFolderDetails backupFolderDetails in backupOffsiteParms.BackupFolderList.Values)
        {
          folderList.Add(backupFolderDetails.ID, (backupFolderDetails.Checked ? "1" : "0") + backupFolderDetails.FolderPath);
        }
      }
      BioSeqFolderPicker frm = new BioSeqFolderPicker(folderList, "Priority Backup");
      if (frm.ShowDialog() == DialogResult.OK)
      {
        folderList = frm.alreadySelected;
        AppConfigHelper.RebuildBackupFolderList(backupOffsiteParms.BackupFolderList, folderList);
        ReloadFolderList();
      }
    }

    private void dgvFolders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = (dgvFolders.CurrentCell.ColumnIndex == 1 || dgvFolders.CurrentCell.ColumnIndex == 4);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      DataGridViewRow dgvRow = dgvFolders.Rows[dgvFolders.CurrentCell.RowIndex];
      string ID = dgvRow.Cells["colID"].FormattedValue.ToString();
      string folderPath = dgvRow.Cells["colFolderPath"].FormattedValue.ToString();
      if (MessageBox.Show("OK to remove folder " + ID + " (" + folderPath + ")?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        backupOffsiteParms.BackupFolderList.Remove(ID);
        AppConfigHelper.SaveConfig();
        ReloadFolderList();
      }
    }
  }
}