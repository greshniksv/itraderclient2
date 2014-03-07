using System;
using System.Data;
using System.Windows.Forms;
using itcDatabase;
using System.Drawing;
using itcClassess;
using System.Resources;
using System.Reflection;

namespace GPSShopBinder
{
	public partial class frmCustomers : Form
	{
		private DataSet dsCustomers;
		public string SelectedCustomers = "0";

		public frmCustomers()
		{
			InitializeComponent();

			var tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "tblCustomers";

			var cNameCol = new DataGridTextBoxColumn();
			cNameCol.MappingName = "cName";
			cNameCol.HeaderText = "Название клиента";
			cNameCol.Width = 210 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(cNameCol);

			dgCustomers.TableStyles.Add(tableStyle);
		}

		private void UpdateCustomerGrid()
		{
			string customersFilter = string.Empty;

			if (edtCustomerName.Text != "")
			{
				customersFilter = " WHERE (cName LIKE '%" + edtCustomerName.Text.Trim() + "%') ";
			}

			try
			{
				dsCustomers = Database.EXEC_GetDataSet(
					"SELECT id, cName FROM tblCustomers " + customersFilter + "ORDER BY cName", "tblCustomers");
				dgCustomers.DataSource = dsCustomers.Tables[0].DefaultView;
			}

			catch (Exception ex)
			{
				itcClassess.GLOBAL.SysLog.WriteError("GPSBinderApplication.UpdateShopsGrid. \nex:" + ex);
			}

		}

		private void frmCustomers_Load(object sender, EventArgs e)
		{
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
			UpdateCustomerGrid();
		}

		private void dgCustomers_DoubleClick(object sender, EventArgs e)
		{
			SelectCustomer();
			Close();
		}

		private void SelectCustomer()
		{
			string custId = "0";
			try
			{
				custId = dsCustomers.Tables[0].Rows[dgCustomers.CurrentRowIndex].ItemArray[0].ToString();
			}

			catch
			{
				MessageBox.Show(@"Список клиентов пуст", @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}

			SelectedCustomers = custId;
			
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
            SelectedCustomers = null;
            DialogResult = DialogResult.Cancel;
        }

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            SelectCustomer();
            Close();
        }


	}
}