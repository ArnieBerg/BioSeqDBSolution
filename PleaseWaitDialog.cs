using System.Windows.Forms;

namespace BioSeqDB
{
  /// <summary>
  /// Provides a modal dialog for time consuming operations.
  /// </summary>
  public partial class PleaseWaitDialog : Form
  {
    /// <summary>
    /// The default please wait message.
    /// Usage: 
    /// PleaseWaitDialog dlg = new PleaseWaitDialog();
    /// // start background work...
    /// dlg.ShowDialog(this.ParentForm, "This could take a while...");
    /// // background work complete
    /// dlg.Hide();    
    /// </summary>
    public static string DEFAULT_MESSAGE = "Please wait...";

    private Form parentForm;

    /// <summary>
    /// Initializes a new instance of the <see cref="PleaseWaitDialog"/> class.
    /// </summary>
    public PleaseWaitDialog()
    {
      InitializeComponent();
      Message = DEFAULT_MESSAGE;
    }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>
    /// The message.
    /// </value>
    public string Message { get { return label1.Text; } set { label1.Text = value; } }

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <param name="message">The message.</param>
    public void ShowDialog(IWin32Window parent, string message)
    {
      parentForm = null;
      if (parent != null && parent is Control)
      {
        parentForm = ((Control)parent).FindForm();
      }
      Message = message;
      ShowDialog(parentForm?? parent);
    }

    /// <summary>
    /// Conceals the control from the user.
    /// </summary>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public new void Hide()
    {
      try
      {
        Close();
        if (parentForm != null)
        {
          parentForm.BringToFront();
          parentForm = null;
        }
      }
      finally
      {
        base.Hide();
      }
    }
  }
}