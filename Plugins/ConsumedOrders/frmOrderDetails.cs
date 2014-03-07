using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using System.Threading;
using ConsumedOrders.DataContainers;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsumedOrders
{
    public partial class frmOrderDetails : Form
    {
        public delegate void NotifyHandler();
        //private int customerId;
        private bool formEnabled;
        private bool existOrderType;
        private int shopId;
        private DataSet dsOrderDetails = new DataSet();
        private bool sipVisible = false;

        public DialogResult ShowOrderDetails(int shopId)
        {
            if (!formEnabled)
                EnableForm(true);
            this.shopId = shopId;
            string oOrderId = (Guid.NewGuid()).ToString();
            int UserId = int.Parse(GLOBAL.CONFIG.GetValue("UserId", "-1", "Main"));
            OrderContainer.CurrentOrder = new Order(oOrderId, shopId, UserId);
            // TODO: change this code
            OrderContainer.CurrentOrder.OrderPositionAdd += new OrderPositionHandler(CurrentOrder_OrderPositionAdd);
            OrderContainer.CurrentOrder.OrderPositionDelete += new OrderPositionHandler(CurrentOrder_OrderPositionDelete);
            OrderContainer.CurrentOrder.OnlyAdditionalInfoInput = OrderContainer.OnlyAdditionalInfoInput;
            dtpOrderDate.Value = DateTime.Now.AddDays(1);
            lblOrderCaption.Text = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT c.cName + ' (' + sName + ',' + sAddress + ')' FROM tblShops s
                JOIN tblCustomers c ON c.id = s.sCustomerId
                WHERE s.id = {0}", shopId));
            return ShowDialog();
        }

        void CurrentOrder_OrderPositionDelete(int productId)
        {
            string pgName = GetProductGroupName(productId);
            if (pgName.IndexOf("Пиво") != -1)
                OrderContainer.CurrentOrder.OSkuBeer--;
            else if (pgName.IndexOf("САН") != -1)
                OrderContainer.CurrentOrder.OSkuSan--;
            else if (pgName.IndexOf("БАН") != -1)
                OrderContainer.CurrentOrder.OSkuBan--;
            else if (pgName.IndexOf("МВ") != -1)
                OrderContainer.CurrentOrder.OSkuMw--;
        }

        void CurrentOrder_OrderPositionAdd(int productId)
        {
            string pgName = GetProductGroupName(productId);
            if (pgName.IndexOf("Пиво") != -1)
                OrderContainer.CurrentOrder.OSkuBeer++;
            else if (pgName.IndexOf("САН") != -1)
                OrderContainer.CurrentOrder.OSkuSan++;
            else if (pgName.IndexOf("БАН") != -1)
                OrderContainer.CurrentOrder.OSkuBan++;
            else if (pgName.IndexOf("МВ") != -1)
                OrderContainer.CurrentOrder.OSkuMw++;
        }

        private string GetProductGroupName(int productId)
        {
            string Query = string.Format(@"
            SELECT pGroupId2 FROM tblProducts 
            WHERE id = {0}", productId);
            int pGroupId2 = (int)Database.EXEC_ExecuteScalar(Query);
            Query = string.Format(@"
            SELECT pgName FROM tblProductGroups 
            WHERE id = {0}", pGroupId2);
            return (string)Database.EXEC_ExecuteScalar(Query);
        }

        public frmOrderDetails()
        {
            InitializeComponent();
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblProducts";

            DataGridTextBoxColumn odFakeId = new DataGridTextBoxColumn();
            tableStyle.GridColumnStyles.Add(odFakeId);

            DataGridTextBoxColumn pNameCol = new DataGridTextBoxColumn();
            pNameCol.MappingName = "pName";
            pNameCol.HeaderText = "Товар";
            pNameCol.Width = 143 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(pNameCol);

            DataGridTextBoxColumn odProductCountCol = new DataGridTextBoxColumn();
            odProductCountCol.MappingName = "odProductCount";
            odProductCountCol.HeaderText = "Кво";
            odProductCountCol.Width = 30 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(odProductCountCol);

			DataGridTextBoxColumn odProductCountRest = new DataGridTextBoxColumn();
			odProductCountRest.MappingName = "odRest";
			odProductCountRest.HeaderText = "Ост";
			odProductCountRest.Width = 30 * Screen.PrimaryScreen.Bounds.Width / 240;
			tableStyle.GridColumnStyles.Add(odProductCountRest);

            DataGridTextBoxColumn pPriceCol = new DataGridTextBoxColumn();
            pPriceCol.MappingName = "odProductPrice";
            pPriceCol.HeaderText = "Цена";
            pPriceCol.Width = 30 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(pPriceCol);

            dgOrderDetails.TableStyles.Add(tableStyle);

            dsOrderDetails.Tables.Add("tblProducts");
            dsOrderDetails.Tables[0].Columns.Add("productId");
            dsOrderDetails.Tables[0].Columns.Add("pName");
            dsOrderDetails.Tables[0].Columns.Add("odProductCount");
            dsOrderDetails.Tables[0].Columns.Add("odProductPrice");
			dsOrderDetails.Tables[0].Columns.Add("odRest");

            dgOrderDetails.DataSource = dsOrderDetails.Tables[0].DefaultView;
            formEnabled = true;
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAddItem.Image = (Bitmap)resMan.GetObject(string.Format("add{0}", size));
            pBoxAddItem.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxEditItem.Image = (Bitmap)resMan.GetObject(string.Format("edit{0}", size));
            pBoxEditItem.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDeleteItem.Image = (Bitmap)resMan.GetObject(string.Format("delete{0}", size));
            pBoxDeleteItem.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDiscounts.Image = (Bitmap)resMan.GetObject(string.Format("discount{0}", size));
            pBoxDiscounts.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxBuyHistory.Image = (Bitmap)resMan.GetObject(string.Format("buyhistory{0}", size));
            pBoxBuyHistory.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxChangeComment.Image = (Bitmap)resMan.GetObject(string.Format("comment{0}", size));
            pBoxChangeComment.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxChangeShop.Image = (Bitmap)resMan.GetObject(string.Format("shop{0}", size));
            pBoxChangeShop.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDebit.Image = (Bitmap)resMan.GetObject(string.Format("debit{0}", size));
            pBoxDebit.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;

            CheckExistOrderType();
        }

        private void CheckExistOrderType()
        {
            // Check existing field "oType" in tblOrders
            var ret = Database.EXEC_ExecuteScalar(string.Format(@"SELECT count(oType) FROM tblOrders where id='00000000-0000-0000-0000-000000000000'"), true);

            existOrderType = (ret != null);
            chkReturn.Enabled = existOrderType;
        }

        public void PrepareForm()
        {
            this.Invoke
            (
                new NotifyHandler(
                    delegate()
                    {
                        DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
                        if (cmbStores.Items.Count > 0)
                            cmbStores.SelectedIndex = 0;
                    }
                )
            );
        }

        private void SetControls()
        {

            dtpOrderDate.Value = OrderContainer.CurrentOrder.ODate;
            if (OrderContainer.CurrentOrder.OIsOfficial == 1)
                chkOfficial.Checked = true;
            else
                chkOfficial.Checked = false;
            int storeId = OrderContainer.CurrentOrder.OStoreId;
            int selectedItem = 0;
            for (int i = 0; i < cmbStores.Items.Count; i++)
            {
                ComboBoxItem cmbItem = (ComboBoxItem)cmbStores.Items[i];
                if (cmbItem.Id == storeId.ToString())
                {
                    selectedItem = i;
                    break;
                }
            }

            cmbStores.SelectedIndex = selectedItem;
            shopId = OrderContainer.CurrentOrder.OShopId;
            lblOrderCaption.Text = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT c.cName + ' (' + sName + ',' + sAddress + ')' FROM tblShops s
                JOIN tblCustomers c ON c.id = s.sCustomerId
                WHERE s.id = {0}", shopId));
            foreach (OrderDetails ord in OrderContainer.CurrentOrder.Positions)
            {
                string pgName = GetProductGroupName(ord.OdProductId);
                if (pgName.IndexOf("Пиво") != -1)
                    OrderContainer.CurrentOrder.OSkuBeer++;
                else if (pgName.IndexOf("САН") != -1)
                    OrderContainer.CurrentOrder.OSkuSan++;
                else if (pgName.IndexOf("БАН") != -1)
                    OrderContainer.CurrentOrder.OSkuBan++;
                else if (pgName.IndexOf("МВ") != -1)
                    OrderContainer.CurrentOrder.OSkuMw++;
            }
            RefreshSku();
        }

        public void ShowForEditing(string orderId)
        {
            GLOBAL.SysLog.WriteInfom("Open order for edit. OrderID: " + orderId);
            if (!formEnabled)
                EnableForm(true);
            OrderContainer.FillCurrentOrderFromDB(orderId);

            // TODO: change this code
            OrderContainer.CurrentOrder.OrderPositionAdd += new OrderPositionHandler(CurrentOrder_OrderPositionAdd);
            OrderContainer.CurrentOrder.OrderPositionDelete += new OrderPositionHandler(CurrentOrder_OrderPositionDelete);
            SetControls();

            dsOrderDetails.Tables[0].Rows.Clear();
            double Cost = 0;
            foreach (OrderDetails ord in OrderContainer.CurrentOrder.Positions)
            {
                string pName = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT pName FROM tblProducts 
                WHERE id = {0}", ord.OdProductId));
                dsOrderDetails.Tables[0].Rows.Add(ord.OdFakeId, pName, ord.OdProductCount, ord.OdProductPrice, ord.OdRest);
                Cost += ord.OdProductPrice * ord.OdProductCount;
            }
            lblCost.Text = Cost.ToString();
            ShowDialog();
        }

        private void EnableForm(bool state)
        {
            dtpOrderDate.Enabled = state;
            pBoxAddItem.Enabled = state;
            pBoxEditItem.Enabled = state;
            pBoxDeleteItem.Enabled = state;
            pBoxDiscounts.Enabled = state;
            pBoxBuyHistory.Enabled = state;
            pBoxChangeShop.Enabled = state;
            pBoxChangeComment.Enabled = state;
            pBoxDebit.Enabled = state;
            cmbStores.Enabled = state;
            chkOfficial.Enabled = state;
            formEnabled = state;
        }

        public void ShowForViewing(string orderId)
        {
            GLOBAL.SysLog.WriteInfom("Open order read only. OrderId:" + orderId);
            if (formEnabled)
                EnableForm(false);
            OrderContainer.FillCurrentOrderFromDB(orderId);
            SetControls();
            dsOrderDetails.Tables[0].Rows.Clear();
            double Cost = 0;
            foreach (OrderDetails ord in OrderContainer.CurrentOrder.Positions)
            {
                string pName = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT pName FROM tblProducts 
                WHERE id = {0}", ord.OdProductId));
                dsOrderDetails.Tables[0].Rows.Add(ord.OdFakeId, pName, ord.OdProductCount, ord.OdProductPrice, ord.OdRest);
                Cost += ord.OdProductPrice * ord.OdProductCount;
            }
            lblCost.Text = Cost.ToString();
            ShowDialog();
        }
        public void ContinueEditingAfterFail()
        {
            GLOBAL.SysLog.WriteInfom("Continue editing after fail save");
            //OrderContainer.CurrentOrder allready seted
            SetControls();
            dsOrderDetails.Tables[0].Rows.Clear();
            foreach (OrderDetails ord in OrderContainer.CurrentOrder.Positions)
            {
                string pName = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT pName FROM tblProducts 
                WHERE id = {0}", ord.OdProductId));
				dsOrderDetails.Tables[0].Rows.Add(ord.OdFakeId, pName, ord.OdProductCount, ord.OdProductPrice, ord.OdRest);
            }
            GLOBAL.SysLog.WriteInfom(string.Format("Continue editing order {0} after fail", OrderContainer.CurrentOrder.Id));
            ShowDialog();
        }

        /// <summary>
        /// Check order and save to database
        /// </summary>
        /// <returns></returns>
        private int CheckOrderAndSave()
        {
            GLOBAL.SysLog.WriteInfom("Check order and save to db");
            if (OrderContainer.CurrentOrder == null)
                return 1;
            if (UserConfig.GetValue("OrderLimit") == "1" && OrderContainer.CurrentOrder.OnlyAdditionalInfoInput == false
                && OrderContainer.CurrentOrder.getOrderSum() > 0)
            {
                int UserId = int.Parse(GLOBAL.CONFIG.GetValue("UserId", "-1", "Main"));
                if (UserId == -1)
                    throw new Exception("Конфиг файл не корректен");
                int Limit;
                object obj = null;
                string Query;
                try
                {
                    Query = string.Format(@"
                    SELECT slOrderSum FROM tblShopLimitation
                    WHERE slShopId = {0} AND slUserId = {1}",
                        shopId, UserId);
                    obj = Database.EXEC_ExecuteScalar(Query);
                }
                catch
                {
                    obj = null;
                }
                if (obj == null)
                {
                    Query = string.Format(@"
                    SELECT uplLimit 
                    FROM tblUserProductLimit 
                    WHERE uplUserId = {0}", UserId);
                    Limit = (int)Database.EXEC_ExecuteScalar(Query, true);
                }
                else
                    Limit = (int)obj;
                if (OrderContainer.CurrentOrder.getOrderSum() < Limit)
                {
                    string Message = string.Format(@"Сумма по накладной должна быть не меньше {0}. Выйти не сохраняя накладную?", Limit);
                    if (MessageBox.Show(Message, "Ошибка",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {

                        GLOBAL.SysLog.WriteInfom("Exit from order without saving");
                        OrderContainer.CurrentOrder.Clear();
                        if (File.Exists(GLOBAL.TempOrderPath))
                            File.Delete(GLOBAL.TempOrderPath);
                        return 1;
                    }
                    else
                        return 0;
                }
            }

            //if (chkOfficial.Checked)
            //    OrderContainer.CurrentOrder.OIsOfficial = 1;
            //else
            //    OrderContainer.CurrentOrder.OIsOfficial = 0;

            OrderContainer.CurrentOrder.OIsOfficial = (chkOfficial.Checked ? 1 : 0);
            OrderContainer.CurrentOrder.OType = (chkReturn.Checked ? 1 : 0);

            ComboBoxItem cmbItem = (ComboBoxItem)cmbStores.SelectedItem;
            OrderContainer.CurrentOrder.OStoreId = int.Parse(cmbItem.Id);
            OrderContainer.CurrentOrder.ODate = dtpOrderDate.Value;

            if (existOrderType) { SaveOrderToDbWithType(); } else { SaveOrderToDb(); }

            return 1;
        }

        private bool SaveOrderToDb()
        {
            GLOBAL.SysLog.WriteInfom("Save order to DB");

            Order order = OrderContainer.CurrentOrder;
            order.OEnd = DateTime.Now.ToString("HH:mm:ss");

            string Query = string.Format(@"
            SELECT id FROM tblOrders WHERE id = '{0}'", order.Id);
            object rez = Database.EXEC_ExecuteScalar(Query);
            if (rez is DBNull || rez == null)
            {
                //TODO : after adding oDebit field to db rewrite this code
                Query = string.Format(@"
                INSERT INTO tblOrders (id, oDate, oShopId, oComment, oCreatorId, oItemsCount, oIsOfficial, oStoreId, oStart, oEnd, oCreateDate)
                VALUES ('{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}')",
                order.Id, order.ODate.ToString("yyyy-MM-dd"), order.OShopId, order.OComment + '&' + order.ODebit.ToString().Replace('.', ','), order.OCreatorId, order.OItemsCount,
                order.OIsOfficial, order.OStoreId, order.OStart, order.OEnd, order.OCreateDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                Query = string.Format(@"
                UPDATE tblOrders SET oDate = '{0}', oShopId = '{1}', oComment = '{2}', oCreatorId = {3}, oItemsCount = {4}, oIsOfficial = {5},
                    oStoreId = {6}, oStart = '{7}', oEnd = '{8}', oCreateDate = '{9}'
                WHERE id = '{10}'", order.ODate.ToString("yyyy-MM-dd"), order.OShopId, order.OComment + '&' + order.ODebit.ToString().Replace('.', ','), order.OCreatorId, order.OItemsCount,
                                  order.OIsOfficial, order.OStoreId, order.OStart, order.OEnd, order.OCreateDate.ToString("yyyy-MM-dd"), order.Id);
            }
            Database.TRANS_Begin();

            //Database.EXEC_SqlNonQuery(Query);
            Database.TRANS_Exec(Query);
            Query = string.Format(@"DELETE FROM tblOrderDetails where odOrderId = '{0}'", order.Id);

            //Database.EXEC_SqlNonQuery(Query);
            Database.TRANS_Exec(Query);
            foreach (OrderDetails orDetails in order.Positions)
            {
                if (orDetails.OdFacing == -99 && orDetails.OdShopPrice == -99 && orDetails.OdRest == -99)
                {
                    Query = string.Format(@"
                INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice)
                VALUES ('{0}', {1}, {2}, {3}, {4})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                  orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice);
                    //Database.EXEC_SqlNonQuery(Query);
                    Database.TRANS_Exec(Query);
                }
                else
                {
                    Query = string.Format(@"
                INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice, odRest, odShopPrice, odFacing)
                VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                                      orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice, orDetails.OdRest,
                                                                      orDetails.OdShopPrice.ToString().Replace(',', '.'), orDetails.OdFacing);
                    //Database.EXEC_SqlNonQuery(Query);
                    Database.TRANS_Exec(Query);
                }
            }
            if (File.Exists(GLOBAL.TempOrderPath))
                File.Delete(GLOBAL.TempOrderPath);
            Database.TRANS_Commit();
            Database.Disconnect();
            Database.Connect();
            GLOBAL.SysLog.WriteInfom(string.Format("Order {0} saved. ShopId: {1}, ItemsCount: {2}", order.Id, order.OShopId, order.OItemsCount));
            return true;
        }

        //existOrderType
        private bool SaveOrderToDbWithType()
        {
            GLOBAL.SysLog.WriteInfom("Save order to DB");

            Order order = OrderContainer.CurrentOrder;
            order.OEnd = DateTime.Now.ToString("HH:mm:ss");

            string Query = string.Format(@"
            SELECT id FROM tblOrders WHERE id = '{0}'", order.Id);
            object rez = Database.EXEC_ExecuteScalar(Query);
            if (rez is DBNull || rez == null)
            {
                //TODO : after adding oDebit field to db rewrite this code
                Query = string.Format(@"
                INSERT INTO tblOrders (id, oDate, oShopId, oComment, oCreatorId, oItemsCount, oIsOfficial, oStoreId, oStart, oEnd, oCreateDate, oType)
                VALUES ('{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', '{11}')",
                order.Id, order.ODate.ToString("yyyy-MM-dd"), order.OShopId, order.OComment + '&' + order.ODebit.ToString().Replace('.', ','), order.OCreatorId, order.OItemsCount,
                order.OIsOfficial, order.OStoreId, order.OStart, order.OEnd, order.OCreateDate.ToString("yyyy-MM-dd"), order.OType);
            }
            else
            {
                Query = string.Format(@"
                UPDATE tblOrders SET oDate = '{0}', oShopId = '{1}', oComment = '{2}', oCreatorId = {3}, oItemsCount = {4}, oIsOfficial = {5},
                    oStoreId = {6}, oStart = '{7}', oEnd = '{8}', oCreateDate = '{9}', oType = '{10}'
                WHERE id = '{11}'", order.ODate.ToString("yyyy-MM-dd"), order.OShopId, order.OComment + '&' + order.ODebit.ToString().Replace('.', ','), order.OCreatorId, order.OItemsCount,
                                  order.OIsOfficial, order.OStoreId, order.OStart, order.OEnd, order.OCreateDate.ToString("yyyy-MM-dd"), order.OType, order.Id);
            }
            Database.TRANS_Begin();

            //Database.EXEC_SqlNonQuery(Query);
            Database.TRANS_Exec(Query);
            Query = string.Format(@"DELETE FROM tblOrderDetails where odOrderId = '{0}'", order.Id);

            //Database.EXEC_SqlNonQuery(Query);
            Database.TRANS_Exec(Query);
            foreach (OrderDetails orDetails in order.Positions)
            {
                if (orDetails.OdFacing == -99 && orDetails.OdShopPrice == -99 && orDetails.OdRest == -99)
                {
                    Query = string.Format(@"
                INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice)
                VALUES ('{0}', {1}, {2}, {3}, {4})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                  orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice);
                    //Database.EXEC_SqlNonQuery(Query);
                    Database.TRANS_Exec(Query);
                }
                else
                {
                    Query = string.Format(@"
                INSERT INTO tblOrderDetails (odOrderId, odProductId, odProductCount, odProductPrice, odIsPersonalPrice, odRest, odShopPrice, odFacing)
                VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7})", orDetails.OdOrderId, orDetails.OdProductId, orDetails.OdProductCount,
                                                                      orDetails.OdProductPrice.ToString().Replace(',', '.'), orDetails.OdIsPersonalPrice, orDetails.OdRest,
                                                                      orDetails.OdShopPrice.ToString().Replace(',', '.'), orDetails.OdFacing);
                    //Database.EXEC_SqlNonQuery(Query);
                    Database.TRANS_Exec(Query);
                }
            }
            if (File.Exists(GLOBAL.TempOrderPath))
                File.Delete(GLOBAL.TempOrderPath);
            Database.TRANS_Commit();
            Database.Disconnect();
            Database.Connect();
            GLOBAL.SysLog.WriteInfom(string.Format("Order {0} saved. ShopId: {1}, ItemsCount: {2}", order.Id, order.OShopId, order.OItemsCount));
            return true;
        }





        private void AddItem()
        {
            GLOBAL.SysLog.WriteInfom("Add product item");
            ComboBoxItem cmbItem = (ComboBoxItem)cmbStores.SelectedItem;
            OrderContainer.CurrentOrder.OStoreId = int.Parse(cmbItem.Id);
            OrderContainer.CurrentOrder.ODate = dtpOrderDate.Value;
            if (chkOfficial.Checked)
                OrderContainer.CurrentOrder.OIsOfficial = 1;
            else
                OrderContainer.CurrentOrder.OIsOfficial = 0;
            cmbStores.Enabled = false;

            int storeId = int.Parse(cmbItem.Id);
            if (storeId != ConsumedOrders.formPrice.StoreId)
            {
                ConsumedOrders.formPrice.PrepareForm(storeId, cmbItem.Name);
            }
            ConsumedOrders.formPrice.ShowDialog();
            FillDataGrid();
            RefreshSku();
        }

        private void RefreshSku()
        {
            lblSku.Text = string.Format("СКЮ: Пиво={0} БАН={1} САН={2} МВ={3}",
                OrderContainer.CurrentOrder.OSkuBeer, OrderContainer.CurrentOrder.OSkuBan,
                OrderContainer.CurrentOrder.OSkuSan, OrderContainer.CurrentOrder.OSkuMw);
        }

        private void ChangeItemCount()
        {
            GLOBAL.SysLog.WriteInfom("Change item count");
            if (dsOrderDetails.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Список позиций пуст", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            int odFakeId = int.Parse(dsOrderDetails.Tables[0].Rows[dgOrderDetails.CurrentRowIndex].ItemArray[0].ToString());
            OrderDetails orderDetail = OrderContainer.CurrentOrder.getOrderDetailsByFakeId(odFakeId);
            ConsumedOrders.formItemCard.ShowForEdit(orderDetail);
            FillDataGrid();
        }

        private void ShowBuysHistory()
        {
            GLOBAL.SysLog.WriteInfom("Open form BuysHistory");

            int customerId = (int)Database.EXEC_ExecuteScalar(string.Format(@"
            SELECT sCustomerId FROM tblShops WHERE id = {0}", OrderContainer.CurrentOrder.OShopId));
            ConsumedOrders.formBuysHistory.ShowBuysHistory(customerId);
        }

        private void ShowDiscounts()
        {
            GLOBAL.SysLog.WriteInfom("Open form Discount");
            int customerId = (int)Database.EXEC_ExecuteScalar(string.Format(@"
            SELECT sCustomerId FROM tblShops WHERE id = {0}", OrderContainer.CurrentOrder.OShopId));
            ConsumedOrders.formDiscounts.ShowCustomerDiscounts(customerId.ToString());
        }

        private void FillDataGrid()
        {
            dsOrderDetails.Tables[0].Rows.Clear();
            double Cost = 0;
            foreach (OrderDetails ord in OrderContainer.CurrentOrder.Positions)
            {
                string pName = (string)Database.EXEC_ExecuteScalar(string.Format(@"
                SELECT pName FROM tblProducts 
                WHERE id = {0}", ord.OdProductId));
				dsOrderDetails.Tables[0].Rows.Add(ord.OdFakeId, pName, ord.OdProductCount, ord.OdProductPrice, ord.OdRest);
                Cost += ord.OdProductPrice * ord.OdProductCount;
            }

            lblCost.Text = Cost.ToString();
        }

        // TODO: write this method
        private bool ClientIsBlocked()
        {
            return false;
        }

        private void btnCancelComment_Click(object sender, EventArgs e)
        {
            pnlComment.Hide();
        }

        private void btnChangeComment_Click(object sender, EventArgs e)
        {
            GLOBAL.SysLog.WriteInfom("Change comment for order.");
            OrderContainer.CurrentOrder.OComment = txbComment.Text;
            txbComment.Text = "";
            pnlComment.Hide();
        }

        private void DeleteItem()
        {
            if (dsOrderDetails.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Список позиций пуст", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            string productName = dsOrderDetails.Tables[0].Rows[dgOrderDetails.CurrentRowIndex].ItemArray[1].ToString();
            GLOBAL.SysLog.WriteInfom("Delete item from order. ProductName: " + productName);

            string message = string.Format(@"Удалить {0} из накладной?", productName);
            if (MessageBox.Show(message, "Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int odFakeId = int.Parse(dsOrderDetails.Tables[0].Rows[dgOrderDetails.CurrentRowIndex].ItemArray[0].ToString());
                OrderContainer.CurrentOrder.deletePosition(odFakeId);
                FillDataGrid();
            }
            RefreshSku();
        }

        private void ChangeShop()
        {
            int customerId = (int)Database.EXEC_ExecuteScalar(string.Format(@"
            SELECT sCustomerId FROM tblShops WHERE id = {0}", OrderContainer.CurrentOrder.OShopId));
            if (ConsumedOrders.formShops.ShowShops(customerId) == DialogResult.OK)
            {
                OrderContainer.CurrentOrder.OShopId = ConsumedOrders.formShops.SelectedShopId;
            }
            GLOBAL.SysLog.WriteInfom("Change shop to " + OrderContainer.CurrentOrder.OShopId);
        }

        private void ChangeComment()
        {
            pnlDebit.Visible = false;
            GLOBAL.SysLog.WriteInfom("Change comment");
            if (ClientIsBlocked()) return;
            txbComment.Text = OrderContainer.CurrentOrder.OComment;
            if (pnlComment.Visible)
                pnlComment.Hide();
            else
                pnlComment.Show();
        }

        private void TryToSaveAndClose()
        {
            GLOBAL.SysLog.WriteInfom("Order details closing.");
            if (!formEnabled)
            {
                dsOrderDetails.Tables[0].Rows.Clear();
                DialogResult = DialogResult.OK;
                chkOfficial.Checked = false;
                cmbStores.Enabled = true;
            }
            else
            {
                if (OrderContainer.CurrentOrder.Positions.Count == 0)
                {
                    DialogResult = DialogResult.OK;
                    chkOfficial.Checked = false;
                    cmbStores.Enabled = true;
                }
                else if (CheckOrderAndSave() != 0)
                {
                    dsOrderDetails.Tables[0].Rows.Clear();
                    DialogResult = DialogResult.OK;
                    chkOfficial.Checked = false;
                    cmbStores.Enabled = true;
                }
            }
        }

        private void ShowDebitInput()
        {
            pnlComment.Visible = false;
            if (pnlDebit.Visible)
            {
                pnlDebit.Visible = false;
                txbDebit.Text = "";
            }

            else
            {
                pnlDebit.Visible = true;
                if (OrderContainer.CurrentOrder.ODebit > 0)
                {
                    txbDebit.Text = OrderContainer.CurrentOrder.ODebit.ToString();
                }
            }
        }

        private void txbComment_GotFocus(object sender, EventArgs e)
        {
            Sip.Show();
        }

        private void txbComment_LostFocus(object sender, EventArgs e)
        {
            Sip.Hide();
        }

        private void dgOrderDetails_DoubleClick(object sender, EventArgs e)
        {
            ChangeItemCount();
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
            pnlDebit.Hide();
            TryToSaveAndClose();
        }

        private void pBoxAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void pBoxEditItem_Click(object sender, EventArgs e)
        {
            ChangeItemCount();
        }

        private void pBoxDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void pBoxDiscount_Click(object sender, EventArgs e)
        {
            ShowDiscounts();
        }

        private void pBoxBuyHistory_Click(object sender, EventArgs e)
        {
            ShowBuysHistory();
        }

        private void pBoxChangeShop_Click(object sender, EventArgs e)
        {
            ChangeShop();
        }

        private void pBoxChangeComment_Click(object sender, EventArgs e)
        {
            ChangeComment();
        }

        private void pBoxDebit_Click(object sender, EventArgs e)
        {
            ShowDebitInput();
        }

        private void btnSetDept_Click(object sender, EventArgs e)
        {
            GLOBAL.SysLog.WriteInfom("Change debit for order.");
            try
            {
                OrderContainer.CurrentOrder.ODebit = double.Parse(txbDebit.Text.Replace('.', ','));
                txbDebit.Text = "";
                pnlDebit.Hide();
            }
            catch
            {
                MessageBox.Show("Введите дробное число", "Неверный тип данных", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
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


        private void txbComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            string c = e.KeyChar.ToString();

            if (!(Regex.Match(c, @"^[a-zA-Zа-яА-Я,-;:?! \b]+$").Success))
            {
                e.Handled = true;
            }
        }

        private void pnlComment_MouseDown(object sender, MouseEventArgs e)
        {        
        }

        private void txbComment_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}