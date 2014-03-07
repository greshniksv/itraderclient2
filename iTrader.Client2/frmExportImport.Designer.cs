namespace iTrader.Client2
{
	partial class frmExportImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportImport));
            this.chkDateStart = new System.Windows.Forms.CheckBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkbIgnoreError = new System.Windows.Forms.CheckBox();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.chkbOnlySync = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.imageList = new System.Windows.Forms.ImageList();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxClose = new System.Windows.Forms.PictureBox();
            this.pBoxExport = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDateStart
            // 
            this.chkDateStart.Checked = true;
            this.chkDateStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateStart.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkDateStart.Location = new System.Drawing.Point(5, 132);
            this.chkDateStart.Name = "chkDateStart";
            this.chkDateStart.Size = new System.Drawing.Size(119, 20);
            this.chkDateStart.TabIndex = 31;
            this.chkDateStart.Text = "с даты и по ...";
            this.chkDateStart.CheckStateChanged += new System.EventHandler(this.chkDateStart_CheckStateChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dtpStart.Location = new System.Drawing.Point(5, 153);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(119, 20);
            this.dtpStart.TabIndex = 30;
            // 
            // chkbIgnoreError
            // 
            this.chkbIgnoreError.Enabled = false;
            this.chkbIgnoreError.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkbIgnoreError.Location = new System.Drawing.Point(2, 179);
            this.chkbIgnoreError.Name = "chkbIgnoreError";
            this.chkbIgnoreError.Size = new System.Drawing.Size(234, 20);
            this.chkbIgnoreError.TabIndex = 29;
            this.chkbIgnoreError.Text = "Пропускать ошибки импорта";
            // 
            // lbxLog
            // 
            this.lbxLog.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbxLog.Location = new System.Drawing.Point(5, 9);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(231, 119);
            this.lbxLog.TabIndex = 28;
            // 
            // chkbOnlySync
            // 
            this.chkbOnlySync.Checked = true;
            this.chkbOnlySync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbOnlySync.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkbOnlySync.Location = new System.Drawing.Point(2, 200);
            this.chkbOnlySync.Name = "chkbOnlySync";
            this.chkbOnlySync.Size = new System.Drawing.Size(234, 20);
            this.chkbOnlySync.TabIndex = 27;
            this.chkbOnlySync.Text = "Только неотправленные накладные";
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(61, 221);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(178, 15);
            this.lblProgress.Text = "...";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(5, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.Text = "Прогресс:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 20);
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "SQL file|*.sql";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "export_file";
            this.saveFileDialog1.Filter = "SQL file|*.sql";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxClose);
            this.panel4.Controls.Add(this.pBoxExport);
            this.panel4.Location = new System.Drawing.Point(-1, 271);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxClose
            // 
            this.pBoxClose.Location = new System.Drawing.Point(5, 3);
            this.pBoxClose.Name = "pBoxClose";
            this.pBoxClose.Size = new System.Drawing.Size(20, 20);
            this.pBoxClose.Click += new System.EventHandler(this.pBoxClose_Click);
            this.pBoxClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxExport
            // 
            this.pBoxExport.Location = new System.Drawing.Point(31, 3);
            this.pBoxExport.Name = "pBoxExport";
            this.pBoxExport.Size = new System.Drawing.Size(20, 20);
            this.pBoxExport.Click += new System.EventHandler(this.pBoxExport_Click);
            this.pBoxExport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxExport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // frmExportImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chkDateStart);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.chkbIgnoreError);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.chkbOnlySync);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "frmExportImport";
            this.Text = "frmExportImport";
            this.Load += new System.EventHandler(this.frmExportImport_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox chkDateStart;
		private System.Windows.Forms.DateTimePicker dtpStart;
		private System.Windows.Forms.CheckBox chkbIgnoreError;
		private System.Windows.Forms.ListBox lbxLog;
		private System.Windows.Forms.CheckBox chkbOnlySync;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxClose;
        private System.Windows.Forms.PictureBox pBoxExport;
	}
}