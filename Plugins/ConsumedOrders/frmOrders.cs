using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcDatabase;
using itcClassess;
using ConsumedOrders.DataContainers;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmOrders : Form
    {
        private delegate void NotifyHandler();
        private DataSet dsOrders = new DataSet();
        public frmOrders()
        {
            InitializeComponent();

            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblOrders";

            DataGridTextBoxColumn oDateCol = new DataGridTextBoxColumn();
            oDateCol.MappingName = "oDate";
            oDateCol.HeaderText = "Дата";
			oDateCol.Width = 28 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(oDateCol);

            DataGridTextBoxColumn cNameCol = new DataGridTextBoxColumn();
            cNameCol.MappingName = "cName";
            cNameCol.HeaderText = "Клиент";
			cNameCol.Width = 130 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(cNameCol);

            DataGridTextBoxColumn oIsOfficialCol = new DataGridTextBoxColumn();
            oIsOfficialCol.MappingName = "oIsOfficial";
            oIsOfficialCol.HeaderText = "Оф";
			oIsOfficialCol.Width = 20 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(oIsOfficialCol);

            DataGridTextBoxColumn oSumCol = new DataGridTextBoxColumn();
            oSumCol.MappingName = "oSum";
            oSumCol.HeaderText = "Сум";
			oSumCol.Width = 40 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(oSumCol);

            dgOrders.TableStyles.Add(tableStyle);
        }

        private void dtPrickerBegin_ValueChanged(object sender, EventArgs e)
        {
            dtPickerEnd.Value = dtPrickerBegin.Value;
            //FillDataGrid(dtPrickerBegin.Value.ToString("yyyy-MM-dd"), dtPickerEnd.Value.ToString("yyyy-MM-dd"));
        }

        private void dtPickerEnd_ValueChanged(object sender, EventArgs e)
        {
            FillDataGrid(dtPrickerBegin.Value.ToString("yyyy-MM-dd"), dtPickerEnd.Value.ToString("yyyy-MM-dd"));
        }

        private void FillDataGrid(string strDateStart, string strDateEnd)
        {
            string Query = string.Format(@"
            SELECT o.id, oDate, c.cName, oIsOfficial, SUM (COALESCE(odProductCount * odProductPrice, 0)) as oSum
            FROM tblOrders o
            JOIN tblShops s ON s.id = o.oShopId
            JOIN tblCustomers c ON c.id = s.sCustomerId
            LEFT JOIN tblOrderDetails od ON od.odOrderId = o.id
            WHERE oDate >= '{0}' and oDate <= '{1}'
            GROUP BY o.id, oDate, c.cName, oIsOfficial order by c.cName", strDateStart, strDateEnd);
            dsOrders = Database.EXEC_GetDataSet(Query, "tblOrders");

            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            dgOrders.DataSource = dsOrders.Tables[0].DefaultView;

                        }
                    )
                );
            }
            else
                dgOrders.DataSource = dsOrders.Tables[0].DefaultView;
            Query = string.Format(@"
                SELECT SUM (odProductCount * odProductPrice) as oSum
                            FROM tblOrders o
                            JOIN tblOrderDetails od ON od.odOrderId = o.id
                            WHERE oDate >= '{0}' and oDate <= '{1}'", strDateStart, strDateEnd);
            string summ = Database.EXEC_ExecuteScalar(Query).ToString();
            int emptyOrdersCount = 0;
            for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
            {
                if (double.Parse(dsOrders.Tables[0].Rows[i].ItemArray[4].ToString()) <= 0) { emptyOrdersCount++; }
            }
            lblEmptyOrdersCount.Text = string.Format("Пустых: {0}", emptyOrdersCount);
            lblOrdersCount.Text = string.Format("Всего: {0} Сумма: {1}", dsOrders.Tables[0].Rows.Count, summ);
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxEdit.Image = (Bitmap)resMan.GetObject(string.Format("edit{0}", size));
            pBoxEdit.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxCopy.Image = (Bitmap)resMan.GetObject(string.Format("copy{0}", size));
            pBoxCopy.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDelete.Image = (Bitmap)resMan.GetObject(string.Format("delete{0}", size));
            pBoxDelete.SizeMode = PictureBoxSizeMode.CenterImage;

            DateTime dt = DateTime.Now.AddDays(1);
            dtPrickerBegin.Value = dt;
        }

        private int GetCustomerId(string orderId)
        {
            int customerId = (int)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT c.id FROM tblOrders o
                JOIN tblShops s ON s.id = o.oShopId
                JOIN tblCustomers c ON c.id = s.sCustomerId
                WHERE o.id = '{0}'", orderId));
            return customerId;
                
        }

        private void DeleteOrder()
        {
            if (dsOrders.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Список накладных пуст", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить накладную?", "Внимание", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string oId = dsOrders.Tables[0].Rows[dgOrders.CurrentRowIndex].ItemArray[0].ToString();
                string Query = string.Format(@"DELETE FROM tblOrderDetails WHERE odOrderId = '{0}'", oId);
                Database.EXEC_SqlNonQuery(Query);
                Query = string.Format(@"DELETE FROM tblOrders WHERE id = '{0}'", oId);
                Database.EXEC_SqlNonQuery(Query);
                FillDataGrid(dtPrickerBegin.Value.ToString("yyyy-MM-dd"), dtPickerEnd.Value.ToString("yyyy-MM-dd"));
            }
        }

        private void TryToViewOrder()
        {
            string oId = dsOrders.Tables[0].Rows[dgOrders.CurrentRowIndex].ItemArray[0].ToString();
            ConsumedOrders.formOrderDetails.ShowForViewing(oId);
        }
        private void TryToEditOrder()
        {
            
            if (dsOrders.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Список накладных пуст", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            string oId = dsOrders.Tables[0].Rows[dgOrders.CurrentRowIndex].ItemArray[0].ToString();
            object rez = Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT oNumber FROM tblOrders WHERE id = '{0}'", oId));
            if (!(rez is System.DBNull))
            {
                MessageBox.Show("Редактировать накладную запрещено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                TryToViewOrder();
                return;
            }

            rez = Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT __sysSR FROM tblOrders WHERE id = '{0}'", oId));
            if (!(rez is System.DBNull))
            {
                MessageBox.Show("Редактировать накладную запрещено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                TryToViewOrder();
                return;
            }

            string Protect = UserConfig.GetValue("Protect");

            if (Protect == "1")
            {
                int customerId = GetCustomerId(oId);
                if (Database.EXEC_Reader("select * from tblProtect where prCustomerId='" +
                    customerId + "'") == false)
                {
                    MessageBox.Show("Error during sql reader work", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (Database.EXEC_GetRead() != null)
                {
                    GLOBAL.SysLog.WriteInfom("selected blocked customers [" + customerId + "]");
                    MessageBox.Show("Внимание. \nИзменение накладной запрещено, клиент заблокирован.", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    Database.EXEC_CloseReader();
                    TryToViewOrder();
                    return;
                }
                Database.EXEC_CloseReader();
            }

            ConsumedOrders.formOrderDetails.ShowForEditing(oId);
            FillDataGrid(dtPrickerBegin.Value.ToString("yyyy-MM-dd"), dtPickerEnd.Value.ToString("yyyy-MM-dd"));
        }

        private bool CheckCustomer(int customerId)
        {
            if (Database.EXEC_Reader("select * from tblProtect where prCustomerId='" +
                customerId + "'") == false)
            {
                MessageBox.Show("Error during sql reader work", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (Database.EXEC_GetRead() != null)
            {
                GLOBAL.SysLog.WriteInfom("selected blocked customers [" + customerId + "]");
                MessageBox.Show("Внимание. \nИзменение  накладной запрещено, клиент заблокирован.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                Database.EXEC_CloseReader();
                return false;
            }
            Database.EXEC_CloseReader();
            return true;
        }

        private void TryToDuplicateOrder()
        {
            if (dsOrders.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Список накладных пуст", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            if (dgOrders.CurrentRowIndex == -1)
            {
                MessageBox.Show("-1");
                return;
            }
            string orderId = dsOrders.Tables[0].Rows[dgOrders.CurrentRowIndex].ItemArray[0].ToString();
            Order order = OrderContainer.GenerateOrderForDuplicate(orderId);
            if (CheckCustomer(GetCustomerId(orderId)) == false)
                return;
            order.OStart = DateTime.Now.ToString("HH:mm:ss");
            order.OEnd = DateTime.Now.ToString("HH:mm:ss");
            order.OCreateDate = DateTime.Now;

            string Query = string.Format(@"
                    INSERT INTO tblOrders (id, oDate, oShopId, oComment, oCreatorId, oItemsCount, oIsOfficial, oStoreId, oStart, oEnd, oCreateDate)
                    VALUES ('{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}')",
            order.Id, order.ODate.ToString("yyyy-MM-dd"), order.OShopId, order.OComment, order.OCreatorId, order.OItemsCount,
            order.OIsOfficial, order.OStoreId, order.OStart, order.OEnd, order.OCreateDate.ToString("yyyy-MM-dd"));
            Database.EXEC_SqlNonQuery(Query);

            foreach (OrderDetails orDetails in order.Positions)
            {
                if (orDetails.OdFacing == -99 && orDetails.OdShopPrice == -99 && orDetails.OdRest == -99)
                {
                    Query = string.Format(@"
                    INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice)
                    VALUES ('{0}', {1}, {2}, {3}, {4})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                  orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice);
                    Database.EXEC_SqlNonQuery(Query);
                }
                else
                {
                    Query = string.Format(@"
                    INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice, odRest, odShopPrice, odFacing)
                    VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                                      orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice, orDetails.OdRest,
                                                                      orDetails.OdShopPrice.ToString().Replace(',', '.'), orDetails.OdFacing);
                    Database.EXEC_SqlNonQuery(Query);
                }
            }
            GLOBAL.SysLog.WriteInfom(string.Format("Order {0} was duplicated as {1}", orderId, order.Id));
            FillDataGrid(dtPrickerBegin.Value.ToString("yyyy-MM-dd"), dtPickerEnd.Value.ToString("yyyy-MM-dd"));
        }

        private void dgOrders_DoubleClick(object sender, EventArgs e)
        {
            TryToEditOrder();
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
            DialogResult = DialogResult.Cancel;
        }

        private void pBoxEdit_Click(object sender, EventArgs e)
        {
            TryToEditOrder();
        }

        private void pBoxCopy_Click(object sender, EventArgs e)
        {
            string message = CheckPermission();
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            TryToDuplicateOrder();
        }

        private void pBoxDelete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }


        private string CheckPermission()
        {
            int maxNonSentOrders = int.Parse(UserConfig.GetValue("maxOrderCount"));
            int oNumberNullCount = (int)Database.EXEC_ExecuteScalar("SELECT COUNT(*) FROM tblOrders WHERE oNumber IS NULL");
            if (oNumberNullCount > maxNonSentOrders)
            {
                int __sysSRNullCount = (int)Database.EXEC_ExecuteScalar("SELECT COUNT(*) FROM tblOrders WHERE __sysSR IS NULL");
                if (__sysSRNullCount > maxNonSentOrders)
                {
                    GLOBAL.SysLog.WriteInfom("OrderBlocked. Quered sync.");
                    return "Набор накладных запрещен, необходимо синхронизироваться!";
                }
            }
            string timeForSleep = "Набор накладных запрещен. Пора спать!";
            int nHour = DateTime.Now.Hour;
            int nMinutes = DateTime.Now.Minute;
            string workStart = UserConfig.GetValue("workStart");
            string[] ar = workStart.Split(':');
            int minHour = int.Parse(ar[0]);
            int minMinutes = int.Parse(ar[1]);
            string workEnd = UserConfig.GetValue("workEnd");
            ar = workEnd.Split(':');
            int maxHour = int.Parse(ar[0]);
            int maxMinutes = int.Parse(ar[1]);
            if (nHour < minHour)
            {
                GLOBAL.SysLog.WriteInfom("Time to sleep");
                return timeForSleep;
            }
            else if (nHour == minHour)
            {
                if (nMinutes < minMinutes)
                {
                    GLOBAL.SysLog.WriteInfom("Time to sleep");
                    return timeForSleep;
                }
            }
            if (nHour > maxHour)
            {
                GLOBAL.SysLog.WriteInfom("Time to sleep");
                return timeForSleep;
            }
            else if (nHour == maxHour)
            {
                if (nMinutes > maxMinutes)
                {
                    GLOBAL.SysLog.WriteInfom("Time to sleep");
                    return timeForSleep;
                }
            }
            return string.Empty;
        }


    }
}