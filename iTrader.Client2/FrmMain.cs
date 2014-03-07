using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using itcDatabase;
using itcClassess;


namespace iTrader.Client2
{
	public partial class FrmMain : Form
	{
		
		public FrmMain()
		{
			InitializeComponent();

			lblVersion.Text = @"iTraderClient v.0." + Assembly.GetExecutingAssembly().GetName().Version.Revision;

			// ---- Initialize config -----------------
			GLOBAL.CONFIG.Initialization(@"\Program Files\iTraderClient2\iTraderClient2.conf");

			// ---- Initialize log -----------------
			string log = GLOBAL.CONFIG.GetValue("Log", @"\Program Files\iTraderClient2\iTraderClient2.log", "Main");
			if (!GLOBAL.SysLog.Initialization(log, 1000000)) MessageBox.Show(@"Error init log file");
			GLOBAL.SysLog.WriteInfom("Starting");

			// ---- Loading user details ---------------
			GLOBAL.UserInfo.Number = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");

			string database = GLOBAL.CONFIG.GetValue("Database", @"\Program Files\iTraderClient2\Database\itdb.client.sdf", "Main");
			Database.SetDatabaseFile(database);
			Database.Connect();
			Database.DbStatusUpdated += (DatabaseDbStatusUpdated);
			
			if (Database.Connected())
			{
				DatabaseService.UpdateUserName();
                DatabaseService.UpdateGetUrlForPrintCheques();
				lblUser.Text = GLOBAL.UserInfo.Name;
			}
			else
			{
				GLOBAL.SysLog.WriteWarning("Error connect to local db");
				lwPlugin.Enabled = false;
				MessageBox.Show("Отсутствует подлючение к локальной базе данных", @"Отсутствует подключение", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			}

			// ---- Loading plugin -------------
			GLOBAL.PluginList.Load();

			// ---- Put plugin to list view -----------
			foreach (var plugin in GLOBAL.PluginList.PluginList)
			{
				var appItem = new ListViewItem(plugin.GetPluginName());
				pluginImageList.Images.Add(plugin.GetAppIcon());
				appItem.ImageIndex = pluginImageList.Images.Count - 1;
				lwPlugin.Items.Add(appItem);
			}

			GLOBAL.Status.Invoke += (StatusInvoke);
            Status.AddLabel(lblStatus);
            Updater.UpdateDone += new Updater.UpdateDoneHandler(Updater_UpdateDone);

 		}

        void Updater_UpdateDone()
        {
            GLOBAL.SysLog.WriteInfom("Exit from programm");
            if (this.InvokeRequired)
            {
                this.Invoke((NotifyHandler)delegate
                {
                    for (int i = 0; i < itcClassess.GLOBAL.PluginList.PluginList.Count; i++)
                    {
                        try
                        {
                            GLOBAL.PluginList.PluginList[i].Close();
                        }
                        catch (Exception ex)
                        {
                            GLOBAL.SysLog.WriteInfom("Error close plugin: " + GLOBAL.PluginList.PluginList[i].GetPluginName());
                            GLOBAL.SysLog.WriteInfom(ex.Message);
                        }
                    }
                    this.Close();
                    Application.Exit();
                });
            }
            else
            {
                for (int i = 0; i < itcClassess.GLOBAL.PluginList.PluginList.Count; i++)
                {
                    try
                    {
                        GLOBAL.PluginList.PluginList[i].Close();
                    }
                    catch (Exception ex)
                    {
                        GLOBAL.SysLog.WriteInfom("Error close plugin: " + GLOBAL.PluginList.PluginList[i].GetPluginName());
                        GLOBAL.SysLog.WriteInfom(ex.Message);
                    }
                }
                this.Close();
                Application.Exit();
            }
        }

		void StatusInvoke()
		{
			lblStatus.Text = GLOBAL.Status.ToString();
		}

		void DatabaseDbStatusUpdated()
		{
			if (Status.CurrentStatus == "Синхронизация завершена")
			{
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            mnuSyncDB.Enabled = true;
                            mnuInitDB.Enabled = true;
                            mnuImportExport.Enabled = true;
                            mnuConfig.Enabled = true;
                            mnuAutoConfig.Enabled = true;
                            lwPlugin.Enabled = true;
                            DatabaseService.UpdateUserName();
                            DatabaseService.UpdateGetUrlForPrintCheques();
                            lblUser.Text = GLOBAL.UserInfo.Name;
                        }
                    )
                );


				return;
			}

            if (Status.CurrentStatus == "Статус соединения: OK")
			{
				mnuSyncDB.Enabled = false;
				mnuInitDB.Enabled = false;
				mnuImportExport.Enabled = false;
				mnuConfig.Enabled = false;
				mnuAutoConfig.Enabled = false;
				lwPlugin.Enabled = false;
				return;
			}
		}

		private void mnuInitDB_Click(object sender, EventArgs e)
		{
			if (!Authentificate()) return;

			if (MessageBox.Show(@"Вы действительно хотите произвести инициализацию БД?\nБудут удалены все неотправленные накладные. На низкоскоростном соединении это может занять много времени (и денег :)", @"Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Database.InitDatabase();
			}
		}

		private void mnuSyncDB_Click(object sender, EventArgs e)
		{
			Database.Sync();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(@"Вы действительно хотите завершить работу?", @"Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				GLOBAL.SysLog.WriteInfom("Exit from programm");
				for (int i = 0; i < itcClassess.GLOBAL.PluginList.PluginList.Count; i++)
				{ 
					try { GLOBAL.PluginList.PluginList[i].Close(); }
					catch { GLOBAL.SysLog.WriteInfom("Error close plugin: " + GLOBAL.PluginList.PluginList[i].GetPluginName()); }
				}
                this.Close();
				Application.Exit();
			}
		}

		private void lwPlugin_ItemActivate(object sender, EventArgs e)
		{
			// ---- Run plugin -------------
            //try
            //{
                GLOBAL.PluginList.PluginList[lwPlugin.SelectedIndices[0]].Run();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Errrrrror", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            //}
		}

		private void mnuConfig_Click(object sender, EventArgs e)
		{
			if (!Authentificate()) return;

			var frmConfig = new FrmConfig();
			frmConfig.ShowDialog();
		}

		private void mnuAutoConfig_Click(object sender, EventArgs e)
		{
			if (!Authentificate()) return;

			var frmAutoconfig = new FrmAutoconfig();
			frmAutoconfig.ShowDialog();
		}

		private void mnuImportExport_Click(object sender, EventArgs e)
		{
			if (!Authentificate()) return;

			var frmExportImport = new frmExportImport();
			frmExportImport.ShowDialog();
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			//new Thread(DatabaseService.Updating){IsBackground = true}.Start();
		}

		public bool Authentificate()
		{
			if (GLOBAL.MainFormAuthentificate) return true;
			var fromAuth = new FrmAuth();
			fromAuth.ShowDialog();
			GLOBAL.MainFormAuthentificate = fromAuth.Result;
			return fromAuth.Result;
		}

	}
}