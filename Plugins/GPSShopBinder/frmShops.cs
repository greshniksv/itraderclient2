using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using OpenNETCF.IO.Serial.GPS;
using System.Resources;

namespace GPSShopBinder
{
	public partial class frmShops : Form
	{
		public string CustomerId;
		public GPS GpsDevice;
		private int _indocatorImage = 0;
		private Position _localPosition;
		private DataSet _dsShops;

		public string Bauds;
		public string DisState;
		public string CommState;
		public string GpsSentence;
		public string Satelites;
		public int SatelitesActive;
		public int ComPort = 0;

		public frmShops()
		{
			InitializeComponent();

			var tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "tblShops";

			var sBindedCol = new DataGridTextBoxColumn();
			sBindedCol.MappingName = "sBinded";
			sBindedCol.HeaderText = "П";
			sBindedCol.Width = 12 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(sBindedCol);

			var sNameCol = new DataGridTextBoxColumn();
			sNameCol.MappingName = "sName";
			sNameCol.HeaderText = "Название";
			sNameCol.Width = 75 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(sNameCol);

			var sAddressCol = new DataGridTextBoxColumn();
			sAddressCol.MappingName = "sAddress";
			sAddressCol.HeaderText = "Адрес";
			sAddressCol.Width = 141 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(sAddressCol);

			dgShops.TableStyles.Add(tableStyle);
		}

		private void UpdateShopsGrid()
		{
			try
			{
				_dsShops = Database.EXEC_GetDataSet(
					"SELECT s.id, s.sNodeId, s.sName, s.sAddress, "+
					"ROUND(CONVERT(float, s.sNodeId) / (s.sNodeId + 1), 0) AS sBinded\n" +
					"FROM tblShops s\n" +
					"WHERE s.sCustomerId = '" + CustomerId + "'\n" +
					"ORDER BY sName", "tblShops");
				dgShops.DataSource = _dsShops.Tables[0].DefaultView;
			}

			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError("GPSBinderApplication.UpdateShopsGrid. \nex:"+ex);
			}

		}

		private void BindShop()
		{
			if ((_localPosition.Latitude_Fractional != 0) && (_localPosition.Longitude_Fractional != 0))
			{
				string shopId = "0";
				string nodeId = "0";

				try
				{
					shopId = _dsShops.Tables[0].Rows[dgShops.CurrentRowIndex].ItemArray[0].ToString();
					nodeId = _dsShops.Tables[0].Rows[dgShops.CurrentRowIndex].ItemArray[1].ToString();
					GLOBAL.SysLog.WriteInfom("Bind gps coordinates for shops [" + shopId + "]");
				}

				catch
				{
					MessageBox.Show(@"Список магазинов пуст", @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					return;
				}

				try
				{
					// If we have no nodes assigned to shop
					if (nodeId == "0")
					//	Create new one
					{
						Database.EXEC_SqlNonQuery(
							"INSERT INTO tblNodes (nLatitude, nLongitude, nAccuracy)\n" +
							"VALUES\n" +
							"('" + Misc.DecimalDegreesToIntPacked(_localPosition.Latitude_Decimal) + "', '" + Misc.DecimalDegreesToIntPacked(_localPosition.Longitude_Decimal) + "', 1)"
						);

						

						// Get last inserted node id
						int lastNodeId = Int32.Parse(DatabaseService.GetOneRow("SELECT @@IDENTITY")[0]);
						
						// Update shop record
						Database.EXEC_SqlNonQuery(
							"UPDATE tblShops\n" +
							"SET sNodeId = '" + lastNodeId + "'\n" +
							"WHERE id = '" + shopId + "'"
						);
					}
					else
					// Or update existing
					{
						Database.EXEC_SqlNonQuery(
							"UPDATE tblNodes\n" +
							"SET\n" +
							"	nLatitude = '" + Misc.DecimalDegreesToIntPacked(_localPosition.Latitude_Decimal) + "',\n" +
							"	nLongitude = '" + Misc.DecimalDegreesToIntPacked(_localPosition.Longitude_Decimal) + "',\n" +
							"	nAccuracy = 1\n" +
							"WHERE id = '" + nodeId + "'"
						);
					}

					MessageBox.Show(
						"Магазин " + _dsShops.Tables[0].Rows[dgShops.CurrentRowIndex].ItemArray[2] + "\n" +
						"привязан к точке с координатами:\n" +
						"    " + lblCurrLatitude.Text + ",\n" +
						"    " + lblCurrLongitude.Text,
						"Выполнено",
						MessageBoxButtons.OK,
						MessageBoxIcon.Asterisk,
						MessageBoxDefaultButton.Button1
					);

					lblShopLatitude.ForeColor = SystemColors.ControlText;
					lblShopLongitude.ForeColor = SystemColors.ControlText;

					UpdateShopsGrid();
				}

				catch (Exception e)
				{
					GLOBAL.SysLog.WriteError("ERROR GPSBinder. BindShop. ex:"+e);
				}

			}
			else
				MessageBox.Show(@"Неизвестны текущие координаты. Дождитесь их определения", @"Нет координат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
		}


		public void UpdateGPSPositionAsync(Position pos)
		{
			this.Invoke(
				new GPS.PositionEventHandler(frmShopsGPSPositionChanged),
				new object[] { null, pos }
			);
		}

		private void frmShopsGPSPositionChanged(object sender, Position pos)
		{
			if (_indocatorImage == 1)
			{
				pbIndicator.Image = imgIconList.Images[3];
				_indocatorImage = 0;
			}
			else
			{
				pbIndicator.Image = imgIconList.Images[4];
				_indocatorImage = 1;
			}

			lblBauds.Text = Bauds;
			lblCommState.Text = CommState+"  GPSPort: COM"+ComPort+":";
			lblGPSSentence.Text = GpsSentence;
			lblSatelites.Text = Satelites;
			lblDisState.Text = DisState;
			pgSatelitesActive.Value = SatelitesActive;


			if (pos != null)
			{
				_localPosition = pos;
				lblFixation.Text = (GpsDevice.FixIndicator == Fix_Indicator.NotSet) ? "---" : (GpsDevice.FixIndicator == Fix_Indicator.Mode2D) ? "2D" : "3D";
				lblCurrLatitude.Text = pos.Latitude_Sexagesimal + ((pos.DirectionLatitude == CardinalDirection.North) ? " С.ш." : " Ю.ш.");
				lblCurrLongitude.Text = pos.Longitude_Sexagesimal + ((pos.DirectionLongitude == CardinalDirection.East) ? " В.д." : " З.д.");
			}
		}

		public void RefreshData()
		{
			this.Invoke(
			new NotifyHandler(
				delegate()
					{
						lblCustomerName.Text = DatabaseService.GetOneRow("select cName from tblCustomers where id='" + CustomerId + "' ")[0];
						UpdateShopsGrid();
					}
				)
			);
		}

		public void ShowShops(string CustomerId)
		{
			this.CustomerId = CustomerId;
            this.timUpdate.Tick += new System.EventHandler(this.timUpdate_Tick);
			RefreshData();
			ShowDialog();
		}

		
		private void ilblCloseInformPanel_Click(object sender, EventArgs e)
		{
			pnlMoreInfo.Visible = false;
		}

		

		private void dgShops_CurrentCellChanged(object sender, EventArgs e)
		{
			string nodeId = "";
			int shopLatitude = 0;
			int shopLongitude = 0;

			try
			{
				nodeId = _dsShops.Tables[0].Rows[dgShops.CurrentRowIndex].ItemArray[1].ToString();
				//sqlRdr = Database.ExecReader("SELECT nLatitude, nLongitude, nAccuracy FROM tblNodes WHERE id = '" + nodeId + "'");
				var rez = DatabaseService.GetOneRow("SELECT nLatitude, nLongitude, nAccuracy FROM tblNodes WHERE id = '" + nodeId + "'");
				shopLatitude = Int32.Parse(rez[0]);
				shopLongitude = Int32.Parse(rez[1]);
				if (Byte.Parse(rez[2]) == 0)
				{
					lblShopLatitude.ForeColor = Color.DarkRed;
					lblShopLongitude.ForeColor = Color.DarkRed;
				}
				else
				{
					lblShopLatitude.ForeColor = SystemColors.ControlText;
					lblShopLongitude.ForeColor = SystemColors.ControlText;
				}
			}

			catch(Exception ex)
			{
				MessageBox.Show(@"Error get coord for client. ex:"+ex);
				lblShopLatitude.Text = "---";
				lblShopLongitude.Text = "---";
				return;
			}

			lblShopLatitude.Text = Misc.DecimalToSexagesimal(Misc.DecimalToFractionalDegrees(Misc.IntPackedToDecimalDegrees(shopLatitude))) + ((shopLatitude > 0) ? " С.ш." : " Ю.ш.");
			lblShopLongitude.Text = Misc.DecimalToSexagesimal(Misc.DecimalToFractionalDegrees(Misc.IntPackedToDecimalDegrees(shopLongitude))) + ((shopLongitude > 0) ? " В.д." : " З.д.");
		}

		private void timUpdate_Tick(object sender, EventArgs e)
		{
			lblBauds.Text = Bauds;
			lblCommState.Text = CommState + "  GPSPort: COM" + ComPort + ":";
			lblGPSSentence.Text = GpsSentence;
			lblSatelites.Text = Satelites;
			lblDisState.Text = DisState;
			pgSatelitesActive.Value = SatelitesActive;
		}

		private void frmShops_Load(object sender, EventArgs e)
		{
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxMoreInfo.Image = (Bitmap)resMan.GetObject(string.Format("info{0}", size));
            pBoxMoreInfo.SizeMode = PictureBoxSizeMode.CenterImage;
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
            timUpdate.Enabled = false;
            GpsDevice.Stop();
            Thread.Sleep(1000);
            Close();
        }

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            BindShop();
        }

        private void pBoxMoreInfo_Click(object sender, EventArgs e)
        {
            pnlMoreInfo.Visible = true;
        }

        private void frmShops_Closed(object sender, EventArgs e)
        {
            this.timUpdate.Tick -= this.timUpdate_Tick;
        }


	}
}