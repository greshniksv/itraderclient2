namespace iTrader.Client2
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuInitDB = new System.Windows.Forms.MenuItem();
            this.mnuSyncDB = new System.Windows.Forms.MenuItem();
            this.mnuAutoConfig = new System.Windows.Forms.MenuItem();
            this.mnuConfig = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mnuImportExport = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.lblVersion = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lwPlugin = new System.Windows.Forms.ListView();
            this.pluginImageList = new System.Windows.Forms.ImageList();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnuInitDB);
            this.menuItem1.MenuItems.Add(this.mnuSyncDB);
            this.menuItem1.MenuItems.Add(this.menuItem6);
            this.menuItem1.MenuItems.Add(this.mnuAutoConfig);
            this.menuItem1.MenuItems.Add(this.mnuConfig);
            this.menuItem1.MenuItems.Add(this.mnuImportExport);
            this.menuItem1.MenuItems.Add(this.menuItem8);
            this.menuItem1.MenuItems.Add(this.mnuExit);
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Программа";
            // 
            // mnuInitDB
            // 
            this.mnuInitDB.Text = "Инициализация БД";
            this.mnuInitDB.Click += new System.EventHandler(this.mnuInitDB_Click);
            // 
            // mnuSyncDB
            // 
            this.mnuSyncDB.Text = "Синхронизация изменений";
            this.mnuSyncDB.Click += new System.EventHandler(this.mnuSyncDB_Click);
            // 
            // mnuAutoConfig
            // 
            this.mnuAutoConfig.Text = "Автоконфиг";
            this.mnuAutoConfig.Click += new System.EventHandler(this.mnuAutoConfig_Click);
            // 
            // mnuConfig
            // 
            this.mnuConfig.Text = "Настройки";
            this.mnuConfig.Click += new System.EventHandler(this.mnuConfig_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "-";
            // 
            // mnuImportExport
            // 
            this.mnuImportExport.Text = "Экспорт";
            this.mnuImportExport.Click += new System.EventHandler(this.mnuImportExport_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Выход";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Enabled = false;
            this.menuItem2.Text = "Update";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Name = "toolBar1";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.SlateGray;
            this.lblVersion.Location = new System.Drawing.Point(52, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(170, 20);
            this.lblVersion.Text = "iTraderClient v.0.";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(4, 8);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(40, 40);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(-2, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            // 
            // lwPlugin
            // 
            this.lwPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lwPlugin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            this.lwPlugin.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lwPlugin.LargeImageList = this.pluginImageList;
            this.lwPlugin.Location = new System.Drawing.Point(0, 77);
            this.lwPlugin.Name = "lwPlugin";
            this.lwPlugin.Size = new System.Drawing.Size(240, 58);
            this.lwPlugin.TabIndex = 8;
            this.lwPlugin.ItemActivate += new System.EventHandler(this.lwPlugin_ItemActivate);
            // 
            // pluginImageList
            // 
            this.pluginImageList.ImageSize = new System.Drawing.Size(32, 32);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 14);
            this.label2.Text = "Список приложений:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(0, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(4, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.Text = "Пользователь";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(3, 253);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(237, 12);
            this.lblStatus.Text = "Ready";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDescription.Location = new System.Drawing.Point(7, 138);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(225, 75);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblUser.Location = new System.Drawing.Point(95, 228);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(143, 15);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lwPlugin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "iTraider.Client2";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.PictureBox logo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView lwPlugin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.MenuItem mnuInitDB;
		private System.Windows.Forms.MenuItem mnuSyncDB;
		private System.Windows.Forms.MenuItem mnuAutoConfig;
		private System.Windows.Forms.MenuItem mnuConfig;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuImportExport;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.ImageList pluginImageList;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.MenuItem menuItem2;
	}
}

