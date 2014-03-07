using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTrader;
using System.Data;
using System.Data.SqlServerCe;
using System.Threading;
using itcDatabase;

namespace ReportApplication
{
	public partial class FrmMain : Form
	{
		public bool ThreadActive = false;
		private string date_start = string.Empty;
		private string date_end = string.Empty;
		private string customer = string.Empty;
		private string shop = string.Empty;

		delegate void ShowProgressEventHandler(int progressToShow, string inf);
		event ShowProgressEventHandler ShowProgress;

		delegate void ShowReportEventHandler(string column1, string column2);
		event ShowReportEventHandler ShowReport;


		public FrmMain()
		{
			InitializeComponent();
			ShowProgress += new ShowProgressEventHandler(FrmMain_ShowProgress);
			ShowReport += new ShowReportEventHandler(FrmMain_ShowReport);
		}

		void FrmMain_ShowReport(string column1, string column2)
		{
			ListViewItem ii = new ListViewItem();
			ii.SubItems[0].Text = column1;
			ii.SubItems.Add(column2);
			lwReport.Items.Add(ii);
		}

		

		void FrmMain_ShowProgress(int progressToShow, string inf)
		{
			if (inf == "start") {  }
			if (inf == "end") { ThreadActive = false; LockControl(false); }
			if (inf != "") { lblStatus.Text = inf; }
			if (progressToShow > 0 & progressToShow <= 100) { progressBar1.Value = progressToShow; }
		}

		void ShowProgB(int progressToShow, string inf)
		{
			ShowProgressEventHandler handler = ShowProgress;
			if (handler != null)
			{
				if (this.InvokeRequired)
				{
					this.Invoke(handler, new object[] { progressToShow, inf });
				}
			}
		}

		void AddToReport(string column1, string column2)
		{
			ShowReportEventHandler handler = ShowReport;
			if (handler != null)
			{
				if (this.InvokeRequired)
				{
					this.Invoke(handler, new object[] { column1, column2 });
				}
			}
		}

		private void combCustomers_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int CustomerId = ((ComboIntString)combCustomers.SelectedItem).Int;

				// loading shops list
				combShops.Items.Clear();
                Database.EXEC_Reader("select id,sName,sAddress from tblShops where sCustomerId" + (CustomerId >= 0 ? "=" : ">") + "'" + CustomerId.ToString() + "' order by sName");
                List<string> rdrRez;
				while ((rdrRez = Database.EXEC_GetRead()) != null)
				{
					ComboIntString cis = new ComboIntString(Int32.Parse(rdrRez[0]), rdrRez[1] + "_" + rdrRez[2]);
					combShops.Items.Add(cis);
				}
                Database.EXEC_CloseReader();
				ComboIntString cis1 = new ComboIntString(-1, "Все");
				combShops.Items.Add(cis1);
				combShops.SelectedItem = cis1;
			}
			catch (Exception ex) { MessageBox.Show("ERROR load shops. \n" + ex.ToString()); }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pnlProgress.Visible = true;
			LockControl(true);
			lwReport.Items.Clear();
			Application.DoEvents();

			date_start = dtpStart.Value.ToString("yyyy-MM-dd");
			date_end = dtpEnd.Value.ToString("yyyy-MM-dd");

			try
			{
				customer = ((ComboIntString)combCustomers.SelectedItem).Int.ToString();
				shop = ((ComboIntString)combShops.SelectedItem).Int.ToString();
			}
			catch(Exception ex) { MessageBox.Show("Error select data from comboBox \n"+ex.ToString()); }

			Thread th = new Thread(new ThreadStart(CalculateReport));
			th.IsBackground = true;
			th.Start();
			ThreadActive = true;
			Application.DoEvents();

			while (true)
			{
				Application.DoEvents();
				if (!ThreadActive) break;
			}

			pnlResult.Location = new Point(panel1.Location.X, panel1.Location.Y);
			pnlResult.Size = new Size(panel1.Size.Width, panel1.Size.Height);
			pnlResult.Visible = true;
			pnlProgress.Visible = false;
		}

		private void CalculateReport()
		{
			ShowProgB(1, "start");
			try
			{
				string ShopList = string.Empty;
                List<string> rdrRez;
				if(customer!="-1")
					if (shop == "-1")
					{
						Database.EXEC_Reader("select id from tblShops where sCustomerId="+customer);
                        
						while ((rdrRez = Database.EXEC_GetRead()) != null)
						{
							if (ShopList.Length > 1) { ShopList += ","; }
							ShopList += "'"+rdrRez[0]+"'";
						}
                        Database.EXEC_CloseReader();
					}

				if (shop != "-1")
				{
					ShopList = "'" + shop + "'";
				}

				List<ComboIntString> Products = new List<ComboIntString>();

				Database.EXEC_Reader("select p.id,p.pName from tblProducts p, tblOrders o, tblOrderDetails od " +
				" where o.id = od.odOrderId and odProductId = p.id and o.oDate >='" + date_start + "' and " +
				" o.oDate <= '" + date_end + "' " + (ShopList.Length > 2 ? "and oShopId in(" + ShopList + ")" : " ") +
				" group by p.pName,p.id");
                rdrRez = null;
				while ((rdrRez = Database.EXEC_GetRead()) != null)
				{
					try
					{
                        ShowProgB(-1, "Загрузка: " + rdrRez[1]);
						string n = rdrRez[1].Substring(0, rdrRez[1].Length);
                        n = rdrRez[1].Substring(0, rdrRez[1].IndexOf("/UA") > 1 ? rdrRez[1].IndexOf("/UA") : rdrRez[1].Length);
                        ComboIntString cis = new ComboIntString(Int32.Parse(rdrRez[0]), n);
						Products.Add(cis);
					}
                    catch { MessageBox.Show("IndexOf:" + rdrRez[1].IndexOf("/UA").ToString() + "\n " + rdrRez[1], "ERROR"); }
				}
                Database.EXEC_CloseReader();

				for (int i = 0; i < Products.Count; i++)
				{
					ShowProgB(i * 100 / Products.Count, "Обработка: " + Products[i].Str);
					Database.EXEC_Reader("select odProductId,sum(od.odProductCount) " +
					" from  tblOrders o, tblOrderDetails od " +
					" where o.id = od.odOrderId and odProductId ='" + Products[i].Int.ToString() + "' and o.oDate >='" + date_start + "' and " +
					" o.oDate <= '" + date_end + "' " + (ShopList.Length > 2 ? "and oShopId in(" + ShopList + ")" : " ") +
					" group by odProductId");
					if ((rdrRez = Database.EXEC_GetRead()) != null)
					{
                        AddToReport(Products[i].Str, rdrRez[1]);
					}
                    Database.EXEC_CloseReader();
				}
				Products.Clear();
			}
			catch(Exception ex) { MessageBox.Show("Error calculate report. \n"+ex.ToString()); }

			ThreadActive = false;
			ShowProgB(0,"end");
		}

		private void LockControl(bool action)
		{
			combShops.Enabled = !action;
			combCustomers.Enabled = !action;
			dtpStart.Enabled = !action;
			dtpEnd.Enabled = !action;
		}

		public void RefreshData()
		{
			try
			{
				// loading customers list
				Database.EXEC_Reader("select id,cName from tblCustomers order by cName");
                List<string> rdrRez;
				while ((rdrRez = Database.EXEC_GetRead()) != null)
				{

					ComboIntString cis = new ComboIntString(Int32.Parse(rdrRez[0]), rdrRez[1]);
					combCustomers.Items.Add(cis);
				}
                Database.EXEC_CloseReader();
				ComboIntString cis1 = new ComboIntString(-1, "Все");
				combCustomers.Items.Add(cis1);
				combCustomers.SelectedItem = cis1;

				//loading shops list
				Database.EXEC_Reader("select id,sName,sAddress from tblShops order by sName");
                rdrRez = null;
                while ((rdrRez = Database.EXEC_GetRead()) != null)
				{
					ComboIntString cis = new ComboIntString(Int32.Parse(rdrRez[0]), rdrRez[1] + "_" + rdrRez[2]);
					combShops.Items.Add(cis);
				}
                Database.EXEC_CloseReader();
				cis1 = new ComboIntString(-1, "Все");
				combShops.Items.Add(cis1);
				combShops.SelectedItem = cis1;
			}
			catch (Exception ex) { MessageBox.Show(ex.ToString()); }
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pnlResult.Visible = false;
		}

        private void btbClose_Click(object sender, EventArgs e)
        {
            Close();
        }


	}
}