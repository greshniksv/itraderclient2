using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmDiscounts : Form
    {
        private DataSet dsDiscounts = null;
        private string customerId = "0";
        private string storeId = "1";
        public frmDiscounts()
        {
            InitializeComponent();
            /// Data Grid style definition
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblProducts";

            DataGridTextBoxColumn dgdDiscountCol = new DataGridTextBoxColumn();
            dgdDiscountCol.MappingName = "dgdDiscount";
            dgdDiscountCol.HeaderText = "Ск.";
			dgdDiscountCol.Width = 30 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(dgdDiscountCol);

            DataGridTextBoxColumn pNameCol = new DataGridTextBoxColumn();
            pNameCol.MappingName = "pName";
            pNameCol.HeaderText = "Название товара";
			pNameCol.Width = 550 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(pNameCol);

            dgDiscounts.TableStyles.Add(tableStyle);

            dsDiscounts = new DataSet();
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDiscountDetails.Image = (Bitmap)resMan.GetObject(string.Format("viewdetailed{0}", size));
            pBoxDiscountDetails.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public void PrepareForm()
        {
            this.Invoke(
                new NotifyHandler(
                    delegate()
                    {
                        DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
                    }
                )
            );
        }

        public void ShowCustomerDiscounts(string cId)
        {
            this.customerId = cId;
            UpdateDiscountsGrid();
            this.ShowDialog();
        }

        private void UpdateDiscountsGrid()
        {
            lblCustomer.Text = (string)Database.EXEC_ExecuteScalar(string.Format("SELECT cName FROM tblCustomers WHERE id = {0}", this.customerId));
            string Query = string.Format(@"
                SELECT p.id, p.pName, dgd.dgdDiscount
                FROM tblDiscountGroupDetails dgd, tblCustomers c, tblProducts p, tblReserves r
                WHERE
                	(
                		(dgd.dgdProductGroupId = p.pGroupId3) OR
                		(dgd.dgdProductGroupId = p.pGroupId2) OR
                		(dgd.dgdProductGroupId = p.pGroupId1)
                	) AND
                	(dgd.dgdDiscountGroupId = c.cDiscountGroupId) AND
                	(p.id = r.rProductId) AND
                	(c.id = {0})
                GROUP BY c.id, r.rStoreId, p.id, p.pName, dgd.dgdDiscount
                HAVING (r.rStoreId = {1})", customerId, storeId);

            dsDiscounts = Database.EXEC_GetDataSet(Query, "tblProducts");
            dgDiscounts.DataSource = dsDiscounts.Tables[0].DefaultView;
        }

        private void ShowDiscountDetails()
        {
            string pId = "0";

            try
            {
                pId = dsDiscounts.Tables[0].Rows[dgDiscounts.CurrentRowIndex].ItemArray[0].ToString();
            }

            catch
            {
                MessageBox.Show("Список товаров пуст", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            string Query = string.Format(@"
                SELECT p.pName, r.rProductPrice1, r.rProductPrice2, r.rProductPrice3, r.rProductPrice4, r.rProductPrice5, dgd.dgdDiscount, dgd.dgdPriceNum
                FROM tblDiscountGroupDetails dgd, tblCustomers c, tblProducts p, tblReserves
                WHERE
                	(
                		(dgd.dgdProductGroupId = p.pGroupId3) OR
                		(dgd.dgdProductGroupId = p.pGroupId2) OR
                		(dgd.dgdProductGroupId = p.pGroupId1)
                	) AND
                	(dgd.dgdDiscountGroupId = c.cDiscountGroupId) AND
                	(p.id = r.rProductId) AND
                	(c.id = {0})
                GROUP BY c.id, r.rStoreId, p.id, p.pName, r.rProductPrice1, r.rProductPrice2, r.rProductPrice3, r.rProductPrice4, r.rProductPrice5, dgd.dgdDiscount, dgd.dgdPriceNum
                HAVING (p.id = {1}) AND (r.rStoreId = {2})", customerId, pId, storeId);

            Database.EXEC_Reader(Query);
            List<object> rdrResults = Database.EXEC_rdrReadObjects();

            byte priceNum = (byte)rdrResults[7];
            string prices = "";

            /// Generate prices
            /// Cool one-line coding :) huh...
            for (byte i = 1; i < 6; i++)
                prices += "   " + i.ToString() + ". " + ((priceNum == i) ? ("[" + ((double)rdrResults[i]).ToString() + "] => " + (((double)rdrResults[i] * (1 - (double)rdrResults[6] / 100)).ToString())) : (((double)rdrResults[i]).ToString())) + "\n";

            MessageBox.Show(
                " Скидка для:\n   " +
                lblCustomer.Text +
                "\n---------------------------------\n На товар:\n   " +
                (string)rdrResults[0] + "\n---------------------------------\n Номинал скидки: " +
                (string)rdrResults[6] + "%\n---------------------------------\n Цены:\n" +
                prices,
                "Информация о скидке", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1
            );
            Database.EXEC_CloseReader();

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
            DialogResult = DialogResult.OK;
        }

        private void pBoxDiscountDetails_Click(object sender, EventArgs e)
        {
            ShowDiscountDetails();
        }


    }
}