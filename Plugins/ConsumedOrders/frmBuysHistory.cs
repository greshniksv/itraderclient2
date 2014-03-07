using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcDatabase;
using System.Threading;
using itcClassess;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmBuysHistory : Form
    {
        public delegate void NotifyHandler();
        private DataSet dsBuysHistory;
        private int cutomerId;
        private string lastProductName = "";
        private Thread thrFilter;
        private bool sipVisible = false;

        public frmBuysHistory()
        {
            InitializeComponent();
            var tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblProducts";

            var oDateCol = new DataGridTextBoxColumn();
            oDateCol.MappingName = "oDate";
            oDateCol.HeaderText = "Дата";
			oDateCol.Width = 28 * Screen.PrimaryScreen.Bounds.Width / 240; 
            tableStyle.GridColumnStyles.Add(oDateCol);

            var pNameCol = new DataGridTextBoxColumn();
            pNameCol.MappingName = "pName";
            pNameCol.HeaderText = "Название товара";
			pNameCol.Width = 145 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(pNameCol);

            var odProductCountCol = new DataGridTextBoxColumn();
            odProductCountCol.MappingName = "odProductCount";
            odProductCountCol.HeaderText = "Кво";
			odProductCountCol.Width = 23 * Screen.PrimaryScreen.Bounds.Width / 240; 
            tableStyle.GridColumnStyles.Add(odProductCountCol);

            var pPriceCol = new DataGridTextBoxColumn();
            pPriceCol.MappingName = "odProductPrice";
            pPriceCol.HeaderText = "Цена";
			pPriceCol.Width = 30 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(pPriceCol);

            dgBuysHistory.TableStyles.Add(tableStyle);
            dsBuysHistory = new DataSet();
            

        }

        private void frmBuysHistory_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pictBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pictBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pictBack_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pictBack_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            dateEnd.Value = dateStart.Value;
            //FillDataGrid(lastProductName);
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            FillDataGrid(lastProductName);
        }

        public void ShowBuysHistory(int cId)
        {
            this.cutomerId = cId;
			lblCustomer.Text = (string)Database.EXEC_ExecuteScalar(string.Format("SELECT cName FROM tblCustomers WHERE id = {0}", cutomerId));
			FillDataGrid("");
            ShowDialog();

        }

        private void FillDataGrid(string pName)
        {
            string strDateStart = string.Empty;
            string strDateEnd = string.Empty;

            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            strDateStart = dateStart.Value.ToString("yyyy-MM-dd");
                            strDateEnd = dateEnd.Value.ToString("yyyy-MM-dd");
                        }
                    )
                );
            }
            else
            {
                strDateStart = dateStart.Value.ToString("yyyy-MM-dd");
                strDateEnd = dateEnd.Value.ToString("yyyy-MM-dd");
            }

            string Query = string.Format(@"
                    SELECT o.oDate, p.pName, od.odProductPrice, od.odProductCount
					FROM tblOrderDetails od, tblOrders o, tblProducts p, tblShops s
					WHERE
						(s.sCustomerId = {0}) AND
						(s.id = o.oShopId) AND
						(od.odOrderId = o.id) AND
						(o.oDate >= '{1}') AND
						(o.oDate <= '{2}') AND
						(p.pName LIKE '%{3}%') AND
						(od.odProductId = p.id)
					ORDER BY pName ASC", cutomerId, strDateStart, strDateEnd, pName);
            dsBuysHistory = Database.EXEC_GetDataSet(Query, "tblProducts");
            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            dgBuysHistory.DataSource = dsBuysHistory.Tables[0].DefaultView;
                        }
                    )
                );
            }
            else
            {
                dgBuysHistory.DataSource = dsBuysHistory.Tables[0].DefaultView;
            }

        }

        private void edtProductTitle_TextChanged(object sender, EventArgs e)
        {
            if (thrFilter != null)
                thrFilter.Abort();
            string text = ((TextBox)sender).Text;
            thrFilter = new Thread(() => res(text)) { IsBackground = true };
            thrFilter.Start();
        }

        void res(object productName)
        {
            Thread.Sleep(1000);
            FillDataGrid((string)productName);
        }

        private void edtProductTitle_LostFocus(object sender, EventArgs e)
        {
            Sip.Hide();
        }

        private void edtProductTitle_GotFocus(object sender, EventArgs e)
        {
            Sip.Show();
        }

        private void pBoxKeyBoard_Click(object sender, EventArgs e)
        {
            if (!sipVisible)
            {
                Sip.Show();
                sipVisible = true;
            }
            else
            {
                Sip.Hide();
                sipVisible = false;
            }
        }

    }
}