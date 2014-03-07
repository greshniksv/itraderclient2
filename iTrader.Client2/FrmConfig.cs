using System;
//using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using System.Resources;
using System.Reflection;
using System.Drawing;

namespace iTrader.Client2
{
	public partial class FrmConfig : Form
	{
		public FrmConfig()
		{
			InitializeComponent();
		}

// ReSharper disable InconsistentNaming
		private void FrmConfig_Load(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
		{
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.GetExecutingAssembly());
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;

			LoadingParams();
			LoadingFromComponent();
		}

		private void LoadingFromComponent()
		{
			// ---- Loading user comboBox ---------------------
			var userId = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
			DatabaseService.FillComboBox(cmbUsers, "tblUsers", "id", "uFullName", userId);

			// ---- Loading manual config listView (lvConfig) --------------

			lvConfig.Items.Clear();
			
            DatabaseService.FillListView(lvConfig,"tblPpcConfig",
				new List<string> { "pcVariable", "pcValue" }, "pcVariable");
		}

		private void Save()
		{
			GLOBAL.SysLog.WriteInfom(@"Save configuration");
			GLOBAL.CONFIG.SetValue("InternetUrl", edtInternetUrl.Text, "Replication");
			GLOBAL.CONFIG.SetValue("Publisher", edtPublisher.Text, "Replication");
			GLOBAL.CONFIG.SetValue("PublisherDatabase", edtPublisherDatabase.Text, "Replication");
			GLOBAL.CONFIG.SetValue("Publication", edtPublication.Text, "Replication");
			GLOBAL.CONFIG.SetValue("Database", edtDBFile.Text, "Main");
			GLOBAL.CONFIG.SetValue("Log", edtLogFile.Text, "Main");
			GLOBAL.CONFIG.SetValue("UpdateServer", edtUpdateServer.Text, "Main");
			
			if(cmbUsers.SelectedItem!=null)
			{
				GLOBAL.CONFIG.SetValue("UserId", ((ComboBoxItem) cmbUsers.SelectedItem).Id ?? "0", "Main");
			}
			else
			{
				GLOBAL.CONFIG.SetValue("UserId", "0", "Main");
			}

		}

		private void LoadingParams()
		{
			const string defDbFile = @"\Program Files\iTraderClient2\Database\itdb.client.sdf";
			const string defInternetUrl = @"http://194.146.135.170:6666/itdb/sqlcesa35.dll";
			const string defPublisher = @"itradersql";
			const string defPublication = @"itdbPubl";
			const string defPublisherDatabase = @"itdb.server";
			const string defUpdateServer = @"http://update.lat.org.ua:9854/Update.php";
			const string defLogFile = @"\Program Files\iTraderClient2\iTraderClient2.conf";

			edtInternetUrl.Text = GLOBAL.CONFIG.GetValue("InternetUrl", defInternetUrl, "Replication");
			edtPublisher.Text = GLOBAL.CONFIG.GetValue("Publisher", defPublisher, "Replication");
			edtPublisherDatabase.Text = GLOBAL.CONFIG.GetValue("PublisherDatabase", defPublisherDatabase, "Replication");
			edtPublication.Text = GLOBAL.CONFIG.GetValue("Publication", defPublication, "Replication");
			edtDBFile.Text = GLOBAL.CONFIG.GetValue("Database", defDbFile, "Main");
			edtLogFile.Text = GLOBAL.CONFIG.GetValue("Log", defLogFile, "Main");
			edtUpdateServer.Text = GLOBAL.CONFIG.GetValue("UpdateServer", defUpdateServer, "Main");
			GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
		}

		private void btnBrowseDb_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog 
			{Filter = "(*.sdf)|*.sdf", FileName = "itdb.client.sdf"};
			saveFileDialog.ShowDialog();
			edtDBFile.Text = saveFileDialog.FileName;
		}

		private void btnBrowseLog_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog 
			{ Filter = "(*.log)|*.log", FileName = "iTraderClient2.log" };
			saveFileDialog.ShowDialog();
			edtLogFile.Text = saveFileDialog.FileName;
		}

		

		private void edtUpdateServer_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtUpdateServer_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtLogFile_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtLogFile_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtDBFile_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtDBFile_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtInternetUrl_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtInternetUrl_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtPublisher_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtPublisher_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtPublication_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtPublication_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

		private void edtPublisherDatabase_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void edtPublisherDatabase_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void pBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pBoxBack_Click(object sender, EventArgs e)
        {
            Close();
        }

	}

}