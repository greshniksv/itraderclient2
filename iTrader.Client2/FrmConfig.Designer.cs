namespace iTrader.Client2
{
	partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.edtUpdateServer = new System.Windows.Forms.TextBox();
            this.btnBrowseDb = new System.Windows.Forms.Button();
            this.btnBrowseLog = new System.Windows.Forms.Button();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtDBFile = new System.Windows.Forms.TextBox();
            this.edtLogFile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabReplicate = new System.Windows.Forms.TabPage();
            this.edtPublication = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edtPublisherDatabase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtPublisher = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtInternetUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabAdditionConfig = new System.Windows.Forms.TabPage();
            this.lvConfig = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabReplicate.SuspendLayout();
            this.tabAdditionConfig.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabReplicate);
            this.tabControl1.Controls.Add(this.tabAdditionConfig);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 270);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.label13);
            this.tabMain.Controls.Add(this.edtUpdateServer);
            this.tabMain.Controls.Add(this.btnBrowseDb);
            this.tabMain.Controls.Add(this.btnBrowseLog);
            this.tabMain.Controls.Add(this.cmbUsers);
            this.tabMain.Controls.Add(this.label3);
            this.tabMain.Controls.Add(this.edtDBFile);
            this.tabMain.Controls.Add(this.edtLogFile);
            this.tabMain.Controls.Add(this.label10);
            this.tabMain.Controls.Add(this.label2);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.panel1);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(240, 247);
            this.tabMain.Text = "Общие";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(14, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(211, 13);
            this.label13.Text = "Сервер обновлений";
            // 
            // edtUpdateServer
            // 
            this.edtUpdateServer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.edtUpdateServer.Location = new System.Drawing.Point(22, 202);
            this.edtUpdateServer.Name = "edtUpdateServer";
            this.edtUpdateServer.Size = new System.Drawing.Size(207, 19);
            this.edtUpdateServer.TabIndex = 58;
            this.edtUpdateServer.GotFocus += new System.EventHandler(this.edtUpdateServer_GotFocus);
            this.edtUpdateServer.LostFocus += new System.EventHandler(this.edtUpdateServer_LostFocus);
            // 
            // btnBrowseDb
            // 
            this.btnBrowseDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDb.Location = new System.Drawing.Point(205, 51);
            this.btnBrowseDb.Name = "btnBrowseDb";
            this.btnBrowseDb.Size = new System.Drawing.Size(24, 21);
            this.btnBrowseDb.TabIndex = 22;
            this.btnBrowseDb.Text = "...";
            this.btnBrowseDb.Click += new System.EventHandler(this.btnBrowseDb_Click);
            // 
            // btnBrowseLog
            // 
            this.btnBrowseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLog.Location = new System.Drawing.Point(205, 102);
            this.btnBrowseLog.Name = "btnBrowseLog";
            this.btnBrowseLog.Size = new System.Drawing.Size(24, 21);
            this.btnBrowseLog.TabIndex = 21;
            this.btnBrowseLog.Text = "...";
            this.btnBrowseLog.Click += new System.EventHandler(this.btnBrowseLog_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUsers.Location = new System.Drawing.Point(22, 152);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(207, 22);
            this.cmbUsers.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 16);
            this.label3.Text = "Работающий пользователь:";
            // 
            // edtDBFile
            // 
            this.edtDBFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDBFile.Location = new System.Drawing.Point(22, 51);
            this.edtDBFile.Name = "edtDBFile";
            this.edtDBFile.Size = new System.Drawing.Size(184, 21);
            this.edtDBFile.TabIndex = 16;
            this.edtDBFile.GotFocus += new System.EventHandler(this.edtDBFile_GotFocus);
            this.edtDBFile.LostFocus += new System.EventHandler(this.edtDBFile_LostFocus);
            // 
            // edtLogFile
            // 
            this.edtLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLogFile.Location = new System.Drawing.Point(22, 102);
            this.edtLogFile.Name = "edtLogFile";
            this.edtLogFile.Size = new System.Drawing.Size(184, 21);
            this.edtLogFile.TabIndex = 15;
            this.edtLogFile.GotFocus += new System.EventHandler(this.edtLogFile_GotFocus);
            this.edtLogFile.LostFocus += new System.EventHandler(this.edtLogFile_LostFocus);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(14, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 16);
            this.label10.Text = "Файл базы данных:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.Text = "Файл журнала:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 16);
            this.label1.Text = "Общие настройки программы";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(2, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            // 
            // tabReplicate
            // 
            this.tabReplicate.Controls.Add(this.edtPublication);
            this.tabReplicate.Controls.Add(this.label8);
            this.tabReplicate.Controls.Add(this.edtPublisherDatabase);
            this.tabReplicate.Controls.Add(this.label7);
            this.tabReplicate.Controls.Add(this.edtPublisher);
            this.tabReplicate.Controls.Add(this.label5);
            this.tabReplicate.Controls.Add(this.edtInternetUrl);
            this.tabReplicate.Controls.Add(this.label6);
            this.tabReplicate.Controls.Add(this.label4);
            this.tabReplicate.Controls.Add(this.panel2);
            this.tabReplicate.Location = new System.Drawing.Point(0, 0);
            this.tabReplicate.Name = "tabReplicate";
            this.tabReplicate.Size = new System.Drawing.Size(240, 247);
            this.tabReplicate.Text = "Репликация";
            // 
            // edtPublication
            // 
            this.edtPublication.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.edtPublication.Location = new System.Drawing.Point(16, 144);
            this.edtPublication.Name = "edtPublication";
            this.edtPublication.Size = new System.Drawing.Size(207, 19);
            this.edtPublication.TabIndex = 34;
            this.edtPublication.GotFocus += new System.EventHandler(this.edtPublication_GotFocus);
            this.edtPublication.LostFocus += new System.EventHandler(this.edtPublication_LostFocus);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(8, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 16);
            this.label8.Text = "Имя публикации";
            // 
            // edtPublisherDatabase
            // 
            this.edtPublisherDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPublisherDatabase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.edtPublisherDatabase.Location = new System.Drawing.Point(16, 189);
            this.edtPublisherDatabase.Name = "edtPublisherDatabase";
            this.edtPublisherDatabase.Size = new System.Drawing.Size(207, 19);
            this.edtPublisherDatabase.TabIndex = 33;
            this.edtPublisherDatabase.GotFocus += new System.EventHandler(this.edtPublisherDatabase_GotFocus);
            this.edtPublisherDatabase.LostFocus += new System.EventHandler(this.edtPublisherDatabase_LostFocus);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(8, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 16);
            this.label7.Text = "База данных публикации:";
            // 
            // edtPublisher
            // 
            this.edtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPublisher.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.edtPublisher.Location = new System.Drawing.Point(16, 99);
            this.edtPublisher.Name = "edtPublisher";
            this.edtPublisher.Size = new System.Drawing.Size(207, 19);
            this.edtPublisher.TabIndex = 32;
            this.edtPublisher.GotFocus += new System.EventHandler(this.edtPublisher_GotFocus);
            this.edtPublisher.LostFocus += new System.EventHandler(this.edtPublisher_LostFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 16);
            this.label5.Text = "Сервер публикации:";
            // 
            // edtInternetUrl
            // 
            this.edtInternetUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInternetUrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.edtInternetUrl.Location = new System.Drawing.Point(16, 52);
            this.edtInternetUrl.Name = "edtInternetUrl";
            this.edtInternetUrl.Size = new System.Drawing.Size(207, 19);
            this.edtInternetUrl.TabIndex = 31;
            this.edtInternetUrl.GotFocus += new System.EventHandler(this.edtInternetUrl_GotFocus);
            this.edtInternetUrl.LostFocus += new System.EventHandler(this.edtInternetUrl_LostFocus);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(8, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 16);
            this.label6.Text = "Интернет-адрес дистрибьютера:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 16);
            this.label4.Text = "Настройки репликации SQL Server";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            // 
            // tabAdditionConfig
            // 
            this.tabAdditionConfig.Controls.Add(this.lvConfig);
            this.tabAdditionConfig.Location = new System.Drawing.Point(0, 0);
            this.tabAdditionConfig.Name = "tabAdditionConfig";
            this.tabAdditionConfig.Size = new System.Drawing.Size(240, 247);
            this.tabAdditionConfig.Text = "Дополнительные";
            // 
            // lvConfig
            // 
            this.lvConfig.Columns.Add(this.columnHeader2);
            this.lvConfig.Columns.Add(this.columnHeader1);
            this.lvConfig.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lvConfig.FullRowSelect = true;
            this.lvConfig.Location = new System.Drawing.Point(3, 2);
            this.lvConfig.Name = "lvConfig";
            this.lvConfig.Size = new System.Drawing.Size(234, 241);
            this.lvConfig.TabIndex = 0;
            this.lvConfig.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Наименование опции";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Val";
            this.columnHeader1.Width = 75;
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxAccept);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxAccept
            // 
            this.pBoxAccept.Location = new System.Drawing.Point(25, 2);
            this.pBoxAccept.Name = "pBoxAccept";
            this.pBoxAccept.Size = new System.Drawing.Size(20, 20);
            this.pBoxAccept.Click += new System.EventHandler(this.pBoxAccept_Click);
            this.pBoxAccept.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxAccept.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxBack
            // 
            this.pBoxBack.Location = new System.Drawing.Point(3, 2);
            this.pBoxBack.Name = "pBoxBack";
            this.pBoxBack.Size = new System.Drawing.Size(20, 20);
            this.pBoxBack.Click += new System.EventHandler(this.pBoxBack_Click);
            this.pBoxBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tabControl1);
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabReplicate.ResumeLayout(false);
            this.tabAdditionConfig.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabReplicate;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox edtUpdateServer;
		private System.Windows.Forms.Button btnBrowseDb;
		private System.Windows.Forms.Button btnBrowseLog;
		private System.Windows.Forms.ComboBox cmbUsers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtDBFile;
		private System.Windows.Forms.TextBox edtLogFile;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox edtPublication;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox edtPublisherDatabase;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox edtPublisher;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox edtInternetUrl;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TabPage tabAdditionConfig;
        private System.Windows.Forms.ListView lvConfig;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
	}
}