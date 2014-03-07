namespace ReportApplication
{
	partial class FrmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lwReport = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.combShops = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.combCustomers = new System.Windows.Forms.ComboBox();
            this.btbClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlResult);
            this.panel1.Controls.Add(this.pnlProgress);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.combShops);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combCustomers);
            this.panel1.Controls.Add(this.btbClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 291);
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.button2);
            this.pnlResult.Controls.Add(this.lwReport);
            this.pnlResult.Location = new System.Drawing.Point(6, 148);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(229, 54);
            this.pnlResult.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(12, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 19);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выйти";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lwReport
            // 
            this.lwReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lwReport.Columns.Add(this.columnHeader1);
            this.lwReport.Columns.Add(this.columnHeader2);
            this.lwReport.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lwReport.FullRowSelect = true;
            this.lwReport.Location = new System.Drawing.Point(3, 3);
            this.lwReport.Name = "lwReport";
            this.lwReport.Size = new System.Drawing.Size(223, 23);
            this.lwReport.TabIndex = 0;
            this.lwReport.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Товар";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Кол-во";
            this.columnHeader2.Width = 60;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblStatus);
            this.pnlProgress.Controls.Add(this.progressBar1);
            this.pnlProgress.Location = new System.Drawing.Point(6, 208);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(229, 54);
            this.pnlProgress.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(3, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(223, 15);
            this.lblStatus.Text = "label4";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 20);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сформировать отчет";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 15);
            this.label3.Text = "Выберите магазин";
            // 
            // combShops
            // 
            this.combShops.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.combShops.Location = new System.Drawing.Point(3, 122);
            this.combShops.Name = "combShops";
            this.combShops.Size = new System.Drawing.Size(234, 20);
            this.combShops.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 15);
            this.label2.Text = "Выбор даты";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(128, 25);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(109, 22);
            this.dtpEnd.TabIndex = 2;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(3, 25);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(119, 22);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 15);
            this.label1.Text = "Выберите клиента";
            // 
            // combCustomers
            // 
            this.combCustomers.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.combCustomers.Location = new System.Drawing.Point(3, 73);
            this.combCustomers.Name = "combCustomers";
            this.combCustomers.Size = new System.Drawing.Size(234, 20);
            this.combCustomers.TabIndex = 0;
            this.combCustomers.SelectedIndexChanged += new System.EventHandler(this.combCustomers_SelectedIndexChanged);
            // 
            // btbClose
            // 
            this.btbClose.Location = new System.Drawing.Point(156, 268);
            this.btbClose.Name = "btbClose";
            this.btbClose.Size = new System.Drawing.Size(76, 20);
            this.btbClose.TabIndex = 12;
            this.btbClose.Text = "Выход";
            this.btbClose.Click += new System.EventHandler(this.btbClose_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Отчеты";
            this.panel1.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dtpStart;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox combShops;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel pnlProgress;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Panel pnlResult;
		private System.Windows.Forms.ListView lwReport;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox combCustomers;
        private System.Windows.Forms.Button btbClose;


	}
}