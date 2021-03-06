namespace BioSeqDB
{
  partial class BioSeqSalmonella
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioSeqSalmonella));
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOutputPath = new System.Windows.Forms.Button();
      this.txtOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.chkTrim = new System.Windows.Forms.CheckBox();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.chkAll = new System.Windows.Forms.CheckBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnFastqPicker = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lvSamples = new System.Windows.Forms.ListView();
      this.colSampleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.txtThreads = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(691, 54);
      this.label4.TabIndex = 13;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.FlatAppearance.BorderSize = 2;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.Location = new System.Drawing.Point(539, 423);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(65, 22);
      this.btnOK.TabIndex = 10;
      this.btnOK.Text = "Run";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatAppearance.BorderSize = 2;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.Location = new System.Drawing.Point(625, 423);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(61, 22);
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOutputPath
      // 
      this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutputPath.Location = new System.Drawing.Point(621, 346);
      this.btnOutputPath.Name = "btnOutputPath";
      this.btnOutputPath.Size = new System.Drawing.Size(31, 23);
      this.btnOutputPath.TabIndex = 6;
      this.btnOutputPath.Text = "...";
      this.btnOutputPath.UseVisualStyleBackColor = true;
      this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
      // 
      // txtOutputPath
      // 
      this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutputPath.Location = new System.Drawing.Point(12, 348);
      this.txtOutputPath.Name = "txtOutputPath";
      this.txtOutputPath.Size = new System.Drawing.Size(609, 20);
      this.txtOutputPath.TabIndex = 5;
      this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 332);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(124, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Path to output folder";
      // 
      // chkTrim
      // 
      this.chkTrim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkTrim.AutoSize = true;
      this.chkTrim.Checked = true;
      this.chkTrim.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkTrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkTrim.Location = new System.Drawing.Point(12, 386);
      this.chkTrim.Name = "chkTrim";
      this.chkTrim.Size = new System.Drawing.Size(194, 17);
      this.chkTrim.TabIndex = 7;
      this.chkTrim.Text = "Adaptor trimming by porechop";
      this.chkTrim.UseVisualStyleBackColor = true;
      // 
      // txtMemo
      // 
      this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMemo.Location = new System.Drawing.Point(12, 427);
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(470, 20);
      this.txtMemo.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 411);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(255, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "Memo (to help identify task in notifications):";
      // 
      // chkAll
      // 
      this.chkAll.AutoSize = true;
      this.chkAll.Location = new System.Drawing.Point(15, 100);
      this.chkAll.Name = "chkAll";
      this.chkAll.Size = new System.Drawing.Size(71, 17);
      this.chkAll.TabIndex = 65;
      this.chkAll.Text = "(all/none)";
      this.chkAll.UseVisualStyleBackColor = true;
      this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.Location = new System.Drawing.Point(557, 146);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(122, 23);
      this.btnDelete.TabIndex = 64;
      this.btnDelete.Text = "Remove unchecked";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnFastqPicker
      // 
      this.btnFastqPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFastqPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFastqPicker.Location = new System.Drawing.Point(557, 117);
      this.btnFastqPicker.Name = "btnFastqPicker";
      this.btnFastqPicker.Size = new System.Drawing.Size(122, 23);
      this.btnFastqPicker.TabIndex = 63;
      this.btnFastqPicker.Text = "Fastq file picker...";
      this.btnFastqPicker.UseVisualStyleBackColor = true;
      this.btnFastqPicker.Click += new System.EventHandler(this.btnFastqPicker_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 84);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(257, 13);
      this.label5.TabIndex = 66;
      this.label5.Text = "Fastq files representing Salmonella samples:";
      // 
      // lvSamples
      // 
      this.lvSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvSamples.CheckBoxes = true;
      this.lvSamples.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSampleID,
            this.colPath});
      this.lvSamples.FullRowSelect = true;
      this.lvSamples.HideSelection = false;
      this.lvSamples.Location = new System.Drawing.Point(12, 118);
      this.lvSamples.MultiSelect = false;
      this.lvSamples.Name = "lvSamples";
      this.lvSamples.Size = new System.Drawing.Size(539, 200);
      this.lvSamples.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.lvSamples.TabIndex = 67;
      this.lvSamples.UseCompatibleStateImageBehavior = false;
      this.lvSamples.View = System.Windows.Forms.View.Details;
      // 
      // colSampleID
      // 
      this.colSampleID.Text = "Sample ID";
      this.colSampleID.Width = 100;
      // 
      // colPath
      // 
      this.colPath.Text = "Path";
      this.colPath.Width = 1200;
      // 
      // txtThreads
      // 
      this.txtThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtThreads.Location = new System.Drawing.Point(437, 387);
      this.txtThreads.Name = "txtThreads";
      this.txtThreads.Size = new System.Drawing.Size(45, 20);
      this.txtThreads.TabIndex = 68;
      this.txtThreads.Text = "1";
      this.txtThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtThreads.TextChanged += new System.EventHandler(this.txtThreads_TextChanged);
      this.txtThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThreads_KeyPress);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(316, 390);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(115, 13);
      this.label6.TabIndex = 69;
      this.label6.Text = "Number of threads:";
      // 
      // BioSeqSalmonella
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(720, 455);
      this.Controls.Add(this.txtThreads);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.lvSamples);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.chkAll);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnFastqPicker);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.chkTrim);
      this.Controls.Add(this.btnOutputPath);
      this.Controls.Add(this.txtOutputPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Name = "BioSeqSalmonella";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BioSeqDB Salmonella Serotyping";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOutputPath;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkTrim;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkAll;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnFastqPicker;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListView lvSamples;
    private System.Windows.Forms.ColumnHeader colSampleID;
    private System.Windows.Forms.ColumnHeader colPath;
    private System.Windows.Forms.TextBox txtThreads;
    private System.Windows.Forms.Label label6;
  }
}