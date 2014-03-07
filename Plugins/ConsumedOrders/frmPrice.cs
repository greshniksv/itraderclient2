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
using ConsumedOrders.DataContainers;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmPrice : Form
    {
        public delegate void NotifyHandler();
        private int storeId;
        private string storeName;
        private string pGroupId;
        private string pGroupNumber = string.Empty;
        private DataSet dsPrice = new DataSet();
        private BindingSource bsPrice = new BindingSource();
        private string UserId;
        Thread thrFilter;
        private bool sipVisible = false;

        public frmPrice()
        {
            InitializeComponent();
            UserId = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
			pnlToolBar.Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Height-pnlToolBar.Height);

            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblProducts";

            DataGridTextBoxColumn pNameCol = new DataGridTextBoxColumn();
            pNameCol.MappingName = "pName";
            pNameCol.HeaderText = "Название товара";

			pNameCol.Width = 188 * Screen.PrimaryScreen.Bounds.Width / 240;

            tableStyle.GridColumnStyles.Add(pNameCol);

            DataGridTextBoxColumn pAvailCountCol = new DataGridTextBoxColumn();
            pAvailCountCol.MappingName = "rProductAvailCount";
            pAvailCountCol.HeaderText = "Ост.";

			pAvailCountCol.Width = 38 * Screen.PrimaryScreen.Bounds.Width / 240;

            tableStyle.GridColumnStyles.Add(pAvailCountCol);
            dgPrice.TableStyles.Add(tableStyle);
            UserConfig.ConfigReaded += (UserConfig_ConfigReaded);
            UserConfig_ConfigReaded();
            dgPrice.DataSource = bsPrice;
        }

        private void frmPrice_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pictBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pictBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pictAdd.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pictAdd.SizeMode = PictureBoxSizeMode.CenterImage;
            pictFilters.Image = (Bitmap)resMan.GetObject(string.Format("filter{0}", size));
            pictFilters.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;            
        }

        void UserConfig_ConfigReaded()
        {
            if (UserConfig.GetValue("FullPrice") == "1")
            {
                chkbShowFullPrice.Visible = true;
                cmbFilter.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width * 129 / 240, cmbFilter.Height);
            }
            else
            {
                chkbShowFullPrice.Visible = false;
                cmbFilter.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width * 232 / 240, cmbFilter.Height);
            }
        }

        public void PrepareForm()
        {
            Database.EXEC_Reader("SELECT id, sName FROM tblStores");
            List<object> resList = null;
            resList = Database.EXEC_rdrReadObjects();
            this.storeId = (int)resList[0];
            this.storeName = (string)resList[1];
            InitDataGrid("");
            
        }

        public void PrepareForm(int storeId, string storeName)
        {
            this.storeId = storeId;
            this.storeName = storeName;
            InitDataGrid("");
        }

        private void FilterDataGrid(string pName)
        {
            string AdditionalFilter = "";
            if (pGroupNumber != "")
            {
                AdditionalFilter = string.Format(@" and pGroupId{0} = {1}", pGroupNumber, pGroupId);
            }
            string minAvailCount = string.Empty;
            if (this.InvokeRequired)
            {
                this.Invoke
                    (
                    new NotifyHandler(
                        delegate()
                        {
                            if (chkbShowFullPrice.Checked)
                                minAvailCount = "-99";
                            else
                                minAvailCount = "0";
                        }
                )
                );
            }
            else
            {
                if (chkbShowFullPrice.Checked)
                    minAvailCount = "-99";
                else
                    minAvailCount = "0";
            }
            if (this.InvokeRequired)
            {
                this.Invoke
                    (
                    new NotifyHandler(
                        delegate()
                        {
                            bsPrice.Filter = string.Format("pName like '%{0}%' and rProductAvailCount > {1}{2}",
                                 pName, minAvailCount, AdditionalFilter);
                        }
                )
                );
            }
            else
            {
                bsPrice.Filter = string.Format("pName like '%{0}%' and rProductAvailCount > {1}{2}",
                     pName, minAvailCount, AdditionalFilter);
            }
            
        }
        private void InitDataGrid(string pName)
        {
			bsPrice = new BindingSource();

			if (this.InvokeRequired)
			{
				this.Invoke
				(
					new NotifyHandler(
						delegate()
						{
							dgPrice.DataSource = bsPrice;
						}
					)
				);
			}
			else
			{
				dgPrice.DataSource = bsPrice;
			}


            string AdditionalFilter = "";
            if (pGroupNumber != "")
            {
           //     AdditionalFilter = string.Format(@" and pGroupId{0} = {1}", pGroupNumber, pGroupId);
            }
            string minAvailCount = string.Empty;
            if (this.InvokeRequired)
            {
                this.Invoke
                    (
                    new NotifyHandler(
                        delegate()
                        {
                            if (chkbShowFullPrice.Checked)
                                minAvailCount = "-99";
                            else
                                minAvailCount = "0";
                        }
                )
                );
            }
            else
            {
                if (chkbShowFullPrice.Checked)
                    minAvailCount = "-99";
                else
                    minAvailCount = "0";
            }

            string Query = string.Format(@"
                SELECT id, pName, rProductAvailCount, pGroupId1, pGroupId2, pGroupId3
                FROM tblProducts p
                JOIN tblReserves r ON r.rProductId = p.id{2}
                WHERE r.rStoreId = {0} and pName like '%{1}%' and rProductAvailCount > {3}
                AND id NOT IN (SELECT upfProductId FROM tblUserProductFilter WHERE upfUserId = {4})
                ORDER BY pName", storeId, pName, AdditionalFilter, minAvailCount, UserId);

            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            Database.SetBindingSource(bsPrice, dsPrice, "tblProducts", Query);
                        }
                    )
                );
            }
            else
            {
                Database.SetBindingSource(bsPrice, dsPrice, "tblProducts", Query);
            }

        	
        }

        private void edtProductTitle_TextChanged(object sender, EventArgs e)
        {
            if (thrFilter != null)
                thrFilter.Abort();
            string text = ((TextBox)sender).Text;
            thrFilter = new Thread(() => FilterAfterSleep(text)) { IsBackground = true };
            thrFilter.Start();
        }

        void FilterAfterSleep(object productName)
        {
            Thread.Sleep(1000);
            FilterDataGrid((string)productName);
        }

        private void edtProductTitle_GotFocus(object sender, EventArgs e)
        {
            Sip.Show();
        }

        private void edtProductTitle_LostFocus(object sender, EventArgs e)
        {
            Sip.Hide();
        }

        private void pictAdd_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pictAdd_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pictBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgPrice_CurrentCellChanged(object sender, EventArgs e)
        {
            string rProductId = ((DataRowView)bsPrice.Current).Row.ItemArray[0].ToString();
            lblProduct.Text = ((DataRowView)bsPrice.Current).Row.ItemArray[1].ToString();
            string Query = string.Format(@"
                SELECT rProductPrice1, rProductPrice2, rProductPrice3, rProductPrice4, rProductPrice5 
                FROM tblReserves
                WHERE rProductId = {0} and rStoreId = {1}", rProductId, storeId);
            List<string> productPrices = null;
            if (Database.EXEC_Reader(Query))
                productPrices = Database.EXEC_GetRead();
            else
            {
                MessageBox.Show("Error during executing query", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            lblPrices.Text = "Цены:";
            foreach (string strPrice in productPrices)
            {
                lblPrices.Text += string.Format(" {0} |", strPrice);
            }
        }

        private void pictAdd_Click(object sender, EventArgs e)
        {
            AddPosition();
        }

        private void dgPrice_DoubleClick(object sender, EventArgs e)
        {
            AddPosition();
        }

        private void AddPosition()
        {	
			// if no selected element - return 0
			if (bsPrice.Current==null) return;

            int ProductId = int.Parse(((DataRowView)bsPrice.Current).Row.ItemArray[0].ToString());

            string ProductName = ((DataRowView)bsPrice.Current).Row.ItemArray[1].ToString();
            double AvailCount = double.Parse(((DataRowView)bsPrice.Current).Row.ItemArray[2].ToString());
            foreach (OrderDetails odd in OrderContainer.CurrentOrder.Positions)
            {
                if (odd.OdProductId == ProductId)
                {
                    ConsumedOrders.formItemCard.ShowForEdit(odd);
                    return;
                }
            }
			GLOBAL.SysLog.WriteInfom("Add product id:"+ProductId);

            string ShopName = Database.EXEC_ExecuteScalar(string.Format(@"
                        SELECT sName FROM tblShops WHERE id = {0}", OrderContainer.CurrentOrder.OShopId)).ToString();

            string Query = string.Format(@"
                SELECT od.odProductCount, COALESCE(od.odRest, -1), o.oDate
                FROM tblOrderDetails od 
                JOIN tblOrders o ON o.id = od.odOrderId
                JOIN tblShops s ON s.id = o.oShopId 
                WHERE odProductId = {0} 
                and s.id = {1}
                ORDER BY oDate DESC", ProductId, OrderContainer.CurrentOrder.OShopId);
            Database.EXEC_Reader(Query);
            List<object> values = null;
            List<LastOrders> lastOrders = new List<LastOrders>();
            int i = 0;
            while ((values = Database.EXEC_rdrReadObjects()) != null && i < 3)
            {
                int Count = (int)values[0];
                int Rest = (int)values[1];
                string date = ((DateTime)values[2]).ToString("dd-MM-yy");
                lastOrders.Add(new LastOrders(date, Count, Rest));
                i++;
            }
            ConsumedOrders.formItemCard.ShowForAdd(ProductId, ProductName, storeName, AvailCount, ShopName, lastOrders);

        }

        private void rbn_FilterCheckedChanged(object sender, EventArgs e)
        {
            FillFilterComboBox();
        }

        private void FillFilterComboBox()
        {
            string pGoupNumber = "";
            if (rbnGroup.Checked)
                pGoupNumber = "1";
            else
                if (rbnType.Checked)
                    pGoupNumber = "2";
                else
                    if (rbnView.Checked)
                        pGoupNumber = "3";

            cmbFilter.Items.Clear();

            string Query = string.Format(@"
            SELECT DISTINCT pg.id, pgName 
            FROM tblProductGroups pg
            RIGHT JOIN tblProducts p ON p.pGroupId{0} = pg.id 
            ORDER BY pgName", pGoupNumber);

            Database.EXEC_Reader(Query);

            List<string> rdrRez = null;

            while ((rdrRez = Database.EXEC_GetRead()) != null)
            {
                ComboBoxItem item = new ComboBoxItem(rdrRez[0], rdrRez[1]);
                cmbFilter.Items.Add(item);
            }
        }

        private void pictFilters_Click(object sender, EventArgs e)
        {
            if (pnlProductsFilter.Visible)
                pnlProductsFilter.Hide();
            else
                pnlProductsFilter.Show();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbFilter.SelectedItem;
            pGroupId = item.Id;
            if (rbnGroup.Checked)
                pGroupNumber = "1";
            else
                if (rbnType.Checked)
                    pGroupNumber = "2";
                else
                    if (rbnView.Checked)
                        pGroupNumber = "3";
            FilterDataGrid(edtProductTitle.Text);
        }

        public int StoreId
        {
            get {return storeId;}
        }

        private void chkbShowFullPrice_CheckStateChanged(object sender, EventArgs e)
        {
            InitDataGrid(edtProductTitle.Text);
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