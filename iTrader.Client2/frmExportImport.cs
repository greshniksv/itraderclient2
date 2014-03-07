using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using itcDatabase;
using System.Drawing;
using itcClassess;
using System.Resources;
using System.Reflection;

//using itcDatabase;

namespace iTrader.Client2
{
// ReSharper disable InconsistentNaming
	public partial class frmExportImport : Form
// ReSharper restore InconsistentNaming
	{
		public frmExportImport()
		{
			InitializeComponent();
		}

        private void frmExportImport_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.GetExecutingAssembly());
            pBoxExport.Image = (Bitmap)resMan.GetObject(string.Format("export{0}", size));
            pBoxExport.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxClose.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxClose.SizeMode = PictureBoxSizeMode.CenterImage;
        }

// ReSharper disable InconsistentNaming
		private void chkDateStart_CheckStateChanged(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
		{
			dtpStart.Enabled = chkDateStart.Checked;
		}

		public void Export(bool onlyNotSync)
		{
			chkbIgnoreError.Enabled = false;
			chkbOnlySync.Enabled = false;
			chkDateStart.Enabled = false;
			dtpStart.Enabled = false;

			lbxLog.Items.Clear();
			lbxLog.Items.Add("Start export orders");
			saveFileDialog1.ShowDialog();
			string exportFile = saveFileDialog1.FileName;

			var ordersList = new List<Orders>();
			List<string> buffer;

			TextWriter tw = new StreamWriter(exportFile, false, Encoding.Default);

			Database.EXEC_Reader(onlyNotSync
			    ? "select id,oDate,oNumber,oShopId,oComment,oCreatorId,oItemsCount,oIsOfficial,oStoreId,oStart,oEnd,oCreateDate from tblOrders where __sysSR is null order by oDate"
			    : "select id,oDate,oNumber,oShopId,oComment,oCreatorId,oItemsCount,oIsOfficial,oStoreId,oStart,oEnd,oCreateDate from tblOrders order by oDate");

			Application.DoEvents();
			while ((buffer = Database.EXEC_GetRead()) != null)
			{
				string date;
				string date2;
				bool except = false;

				try
				{
					DateTime dt = DateTime.Parse(buffer[1]);
					date = dt.ToString("yyyy-MM-dd");
					TimeSpan ts = dt - dtpStart.Value;

					if (chkDateStart.Checked)
						if (ts.Seconds < 0) except = true;
				}
				catch { date = buffer[1]; }

				try
				{
					DateTime dt = DateTime.Parse(buffer[11]);
					date2 = dt.ToString("yyyy-MM-dd");
				}
				catch { date2 = buffer[1]; }

				if (!except)
				{
					var o = new Orders
					{
						Id = buffer[0],
						All =
							string.Format(
							" insert into tblOrders (id,oDate,oNumber,oShopId,oComment,oCreatorId," +
							" oItemsCount,oIsOfficial,oStoreId,oStart,oEnd,oCreateDate) values " +
							" ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');",
							buffer[0], date, buffer[2], buffer[3], buffer[4], buffer[5], buffer[6], buffer[7], buffer[8], buffer[9],
							buffer[10], date2)
					};
					ordersList.Add(o);
				}
			}

			Application.DoEvents();
			Database.EXEC_CloseReader();
			lbxLog.Items.Add("Loaded " + ordersList.Count + " order");

			int pp = 0; int odcount = 0;
			foreach (Orders o in ordersList)
			{
				pp++;
				if (pp * 100 / ordersList.Count != progressBar1.Value)
				{
					progressBar1.Value = pp * 100 / ordersList.Count;
					Application.DoEvents();
				}
				tw.WriteLine(o.All);

				Database.EXEC_Reader("select odOrderId,odProductId,odProductCount,odProductPrice,odIsPersonalPrice,odRest " +
					"from tblOrderDetails where odOrderId = '" + o.Id + "' ");
				while ((buffer = Database.EXEC_GetRead()) != null)
				{
					string details = string.Format("insert into tblOrderDetails " +
						"(odOrderId,odProductId,odProductCount,odProductPrice,odIsPersonalPrice,odRest)" +
						" values ('{0}','{1}','{2}','{3}','{4}','{5}'); ",
						buffer[0], buffer[1], buffer[2], buffer[3].Replace(',', '.'), buffer[4], buffer[5]);
					tw.WriteLine(details);
					//o.Details.Add(details);
					odcount++;
				}
				Database.EXEC_CloseReader();
			}
			lbxLog.Items.Add("Loaded " + odcount + " orderDetails");
			Application.DoEvents();

			lbxLog.Items.Add("Write to file");
			Application.DoEvents();
			ordersList.Clear();

			tw.Close();
			lbxLog.Items.Add("Orders exported successfoly");
			chkbIgnoreError.Enabled = true;
			chkbOnlySync.Enabled = true;
			chkDateStart.Enabled = true;
			dtpStart.Enabled = true;
		}

		public void Import(string file)
		{
			openFileDialog1.ShowDialog();
			string importFile = openFileDialog1.FileName;
			lbxLog.Items.Clear();
			lbxLog.Items.Add("Start import orders");

			int max = 0;
			TextReader tr = new StreamReader(importFile, Encoding.Default);
			string buf;
			while ((tr.ReadLine()) != null)
			{
				max++;
			}
			tr.Close();

			int pp = 0; int error = 0; int ok = 0;
			tr = new StreamReader(importFile, Encoding.Default);
			Database.TRANS_Begin();

			while ((buf = tr.ReadLine()) != null)
			{
				pp++;
				if (progressBar1.Value != pp * 100 / max)
				{
					progressBar1.Value = pp * 100 / max;
					Application.DoEvents();
				}

				try
				{
					//cmdd.CommandText = buf;
					//cmdd.ExecuteNonQuery();
					Database.TRANS_Exec(buf);
					ok++;
				}
				catch (Exception ex) { error++; if (!chkbIgnoreError.Checked) { MessageBox.Show(ex.ToString()); } }
			}
			Database.TRANS_Commit();
			tr.Close();
			lbxLog.Items.Add("Error insert: " + error + ", successfol insert: " + ok);
			lbxLog.Items.Add("Finish import " + pp + " orders");
		}

        private void pBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pBoxExport_Click(object sender, EventArgs e)
        {
            Export(chkbOnlySync.Checked);
        }

        private void pBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
		
	}

	class Orders
	{
		private List<string> _details = new List<string>();

		public List<string> Details { get { return _details; } set { _details = value; } }
		public string Id { get; set; }
		public string All { get; set; }
	}

}