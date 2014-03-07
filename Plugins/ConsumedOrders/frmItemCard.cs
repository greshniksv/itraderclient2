using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcDatabase;
using ConsumedOrders.DataContainers;
using itcClassess;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmItemCard : Form
    {
        private int productId;
        private string productName;
        private string storeName;
        private double availCount;
        private ActionState actionState;
        private OrderDetails currentOrderDetail;
        private bool sipVisible = false;
        private int iMinProductCount;
        private int iPiecesInBox;

        public frmItemCard()
        {
            InitializeComponent();
        }

        private void frmItemCard_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private bool ConfirmInput()
        {
            int productCount = 0;
            if (actionState == ActionState.Editing)
            {
                productId = currentOrderDetail.OdProductId;               
            }
            if (!chkNoOrder.Checked)
            {
            	try
            	{
            		productCount = (int) numUpDownProductCount.Value;
            		if (productCount < 0)
            			throw new Exception();
            	}
            	catch
            	{
            		MessageBox.Show("Неправильно введен заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand,
            		                MessageBoxDefaultButton.Button1);
            		return false;
            	}



				if (UserConfig.GetValue("SuperMultiplicity") == "1")
				{
					if (iMinProductCount > productCount)
					{
						MessageBox.Show("Вы ввели слишком мало товара. Минимальное количество: " + iMinProductCount.ToString(),
										"Ошибка ввода данных",
										MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						return false;
					}

					if ((productCount % iMinProductCount) > 0)
					{
						MessageBox.Show("Количество товара должно быть кратным " + iMinProductCount.ToString(), "Ошибка ввода данных",
										MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						return false;
					}

				}
				else
				{

					if (UserConfig.GetValue("ProductLimit") == "1")
					{
						if (iMinProductCount > productCount)
						{
							MessageBox.Show("Вы ввели слишком мало товара. Минимальное количество: " + iMinProductCount.ToString(),
							                "Ошибка ввода данных",
							                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
							return false;
						}

						if (UserConfig.GetValue("Multiplicity") == "1")
						{
							if (iPiecesInBox > productCount)
							{
								//float fRest = (float)productCount / (float)MinProductCount;
								if ((productCount%iMinProductCount) > 0)
								{
									MessageBox.Show("Количество товара должно быть кратным " + iMinProductCount.ToString(), "Ошибка ввода данных",
									                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
									return false;
								}
							}
							else
							{
								if (iPiecesInBox > 0)
								{
									int iRes = productCount%iPiecesInBox;
									if (iRes > 0)
									{
										MessageBox.Show(
											"Количество товара больше количества в упакове и поэтому должно быть кратным " + iPiecesInBox.ToString(),
											"Ошибка ввода данных",
											MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
										return false;
									}
								}
							}
						}
					}

				}


            	//if (productCount > availCount)
                //{
                //    if (MessageBox.Show("Вы ввели товара больше, чем есть на складе! Изменить количество?", "Предупреждение",
                //        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //        return false;
                //}
            }
            if (actionState == ActionState.Creating)
            {
                int Rest = -99;
                double ProductShopPrice = -99;
                int ProductFacing = -99;
                try
                {
                    if (UserConfig.GetValue("Rest") == "1" && txbRest.Text != "")
                        Rest = int.Parse(txbRest.Text);
                    if (UserConfig.GetValue("ProductShopPrice") == "1" && txbProductShopPrice.Text != "")
                        ProductShopPrice = double.Parse(txbProductShopPrice.Text);
                    if (UserConfig.GetValue("ProductFacing") == "1" && txbProductFacing.Text != "")
                        ProductFacing = int.Parse(txbProductFacing.Text);

					GLOBAL.SysLog.WriteInfom("Rest: "+Rest+" ProductShopPrice: "+ProductShopPrice+
						" ProductFacing: "+ProductFacing+" ");
                }
                catch (FormatException ex)
                {
					GLOBAL.SysLog.WriteError("ProductItemForm. Incorrect data.");
                    MessageBox.Show("Неправильно введены данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return false;
                }

                int CustomerId = (int)Database.EXEC_ExecuteScalar(string.Format(@"
                            SELECT sCustomerId FROM tblShops
                            WHERE id = {0}", OrderContainer.CurrentOrder.OShopId));
                OrderContainer.CurrentOrder.AddPosition(productId, productCount,
                    GetPriceForCustomer(CustomerId.ToString(), productId.ToString(), OrderContainer.CurrentOrder.OStoreId.ToString()),
                    0, Rest, ProductShopPrice, ProductFacing);
            }
            else if (actionState == ActionState.Editing)
            {
                try
                {
                    if (UserConfig.GetValue("Rest") == "1")
                        currentOrderDetail.OdRest = int.Parse(txbRest.Text);
                    if (UserConfig.GetValue("ProductShopPrice") == "1")
                        currentOrderDetail.OdShopPrice = double.Parse(txbProductShopPrice.Text);
                    if (UserConfig.GetValue("ProductFacing") == "1")
                        currentOrderDetail.OdFacing = int.Parse(txbProductFacing.Text);
                }
                catch (FormatException ex)
                {
					GLOBAL.SysLog.WriteError("ProductItemForm. Incorrect data.");
                    MessageBox.Show("Неправильно введены данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return false;
                }
                currentOrderDetail.OdProductCount = productCount;
            }
            OrderContainer.BackupCurrentOrderToFile(GLOBAL.TempOrderPath);
            return true;
        }

        public void ShowForAdd(int productId, string productName, string storeName, double availCount, string ShopName, List<LastOrders> lastOrders)
        {
            this.productId = productId;
            this.productName = productName;
            this.storeName = storeName;
            this.availCount = availCount;
            lblProduct.Text = "Товар: " + productName;
            lblStore.Text = "Склад: " + storeName;
            lblRemains.Text = "Остаток на складе: " + availCount;
            lblShop.Text = ShopName;
            PrepareForm(lastOrders);
            actionState = ActionState.Creating;
            numUpDownProductCount.Value = 0;
            txbRest.Text = string.Empty;
            txbProductShopPrice.Text = string.Empty;
            txbProductFacing.Text = string.Empty;
            SetLimitationParameters();
            SetLastRestAndPrice();
            SetControlsState();
            ShowDialog();
        }

        public void ShowForEdit(OrderDetails orderDetail)
        {
            this.productId = orderDetail.OdProductId;
			GLOBAL.SysLog.WriteInfom("Show ItemCard for edit.");
            string Query = string.Format(@"
            SELECT st.sName, p.pName, s.sName, r.rProductAvailCount
            FROM tblStores st, tblProducts p, tblShops s, tblReserves r
            WHERE st.id = {0} and p.id = {1} and s.id = {2} and p.id = r.rProductId and r.rStoreId = {0} "
            //"and r.rProductAvailCount > 0"
			, OrderContainer.CurrentOrder.OStoreId, orderDetail.OdProductId, OrderContainer.CurrentOrder.OShopId);
            Database.EXEC_Reader(Query);
            List<string> rez = Database.EXEC_GetRead();
            lblProduct.Text = "Товар: " + rez[1];
            lblStore.Text = "Склад: " + rez[0];
            lblRemains.Text = "Остаток на складе: " + rez[3];
            availCount = int.Parse(rez[3]);
            lblShop.Text = rez[2];
            numUpDownProductCount.Value = (decimal)orderDetail.OdProductCount;
            if (orderDetail.OdProductCount == 0)
                chkNoOrder.Checked = true;

            if (UserConfig.GetValue("Rest") == "1")
                txbRest.Text = orderDetail.OdRest.ToString();
            if (UserConfig.GetValue("ProductShopPrice") == "1")
                txbProductShopPrice.Text = orderDetail.OdShopPrice.ToString();
            if (UserConfig.GetValue("ProductFacing") == "1")
                txbProductFacing.Text = orderDetail.OdFacing.ToString();
            Query = string.Format(@"
                SELECT od.odProductCount, COALESCE(od.odRest, -1), o.oDate
                FROM tblOrderDetails od 
                JOIN tblOrders o ON o.id = od.odOrderId
                JOIN tblShops s ON s.id = o.oShopId 
                WHERE odProductId = {0} 
                and s.id = {1}
                ORDER BY oDate DESC", orderDetail.OdProductId, OrderContainer.CurrentOrder.OShopId);
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
            PrepareForm(lastOrders);
            actionState = ActionState.Editing;
            currentOrderDetail = orderDetail;
            SetLimitationParameters();
            SetControlsState();
            ShowDialog();
        }

        private void SetLimitationParameters()
        {
        	if (UserConfig.GetValue("ProductLimit") == "1")
            {
                int test = 1;
                string Query = string.Format(@"
                    SELECT pplProductLimit 
                    FROM tblPpcProductLimit 
                    WHERE pplProductId = {0}", productId);
                Object obj = Database.EXEC_ExecuteScalar(Query);
                if (obj is System.DBNull || obj == null)
                    iMinProductCount = 1;
                else
                    iMinProductCount = (int)obj;
                if (UserConfig.GetValue("Multiplicity") == "1")
                {
                    Query = string.Format(@"
                    SELECT pPiecesInBox 
                    FROM tblProducts 
                    WHERE id = {0}", productId);
                    obj = Database.EXEC_ExecuteScalar(Query);
                    if (obj is System.DBNull || obj == null)
                        iPiecesInBox = 1;
                    else
                        iPiecesInBox = (int)obj;
                }
                else
                    iPiecesInBox = 1;
            }
        }

        private void SetLastRestAndPrice()
        {
            double lastShopPrice = 0;
            int newRest = 0;
            if (txbRest.Enabled == false || txbProductShopPrice.Enabled == false)
                return;
            lastShopPrice = 0;
            newRest = 0;
            string Query = string.Format(@"
                    SELECT coalesce(od.odShopPrice,-1), coalesce(od.odRest,-1), od.odProductCount
					FROM tblOrderDetails od, tblOrders o
					WHERE od.odOrderId = o.id
					AND o.oShopId = {0}
					AND od.odProductId = {1}
					ORDER BY oDate DESC", OrderContainer.CurrentOrder.OShopId, productId);
            Database.EXEC_Reader(Query);
            List<object> res = null;
            while ((res = Database.EXEC_rdrReadObjects()) != null)
            {
                if ((double)res[0] != -1)
                {
                    lastShopPrice = (double)res[0];
                    newRest = 20 * ((int)res[1] + (int)res[2]) / 100;
                    break;
                }
            }
            
            if (txbRest.Enabled && newRest != 0)
                txbRest.Text = newRest.ToString();
            if (txbProductShopPrice.Enabled && lastShopPrice != 0)
                txbProductShopPrice.Text = lastShopPrice.ToString();
        }
        private void SetControlsState()
        {
            if (OrderContainer.CurrentOrder.OnlyAdditionalInfoInput || availCount == 0)
            {
                chkNoOrder.Checked = true;
                chkNoOrder.Enabled = false;
            }
            else
            {
                chkNoOrder.Enabled = true;
                chkNoOrder.Checked = false;
                numUpDownProductCount.Focus();
               
            }

			if (UserConfig.GetValue("Multiplicity") == "1" || UserConfig.GetValue("SuperMultiplicity") == "1")
            {
                string Query = string.Format(@"
                    SELECT pplProductLimit 
                    FROM tblPpcProductLimit 
                    WHERE pplProductId = {0}", productId);
                object obj = Database.EXEC_ExecuteScalar(Query);
                if (obj != null)
                    numUpDownProductCount.Increment = (decimal)((int)obj);
            }
            else
            {
                numUpDownProductCount.Increment = 1;
            }
        }
        private void PrepareForm(List<LastOrders> lastOrders)
        {
            if (lastOrders.Count > 0)
            {
                lblFirstDate.Text = lastOrders[0].Date;
                lblFirstValue.Text = lastOrders[0].Value;
                if (lastOrders.Count > 1)
                {
                    lblSecondDate.Text = lastOrders[1].Date;
                    lblSecondValue.Text = lastOrders[1].Value;
                    if (lastOrders.Count > 2)
                    {
                        lblThirdDate.Text = lastOrders[2].Date;
                        lblThirdValue.Text = lastOrders[2].Value;
                    }
                }
            }

            if (UserConfig.GetValue("Rest") == "1")
                txbRest.Enabled = true;
            else
                txbRest.Enabled = false;
            if (UserConfig.GetValue("ProductShopPrice") == "1")
                txbProductShopPrice.Enabled = true;
            else
                txbProductShopPrice.Enabled = false;
            if (UserConfig.GetValue("ProductFacing") == "1")
                txbProductFacing.Enabled = true;
            else
                txbProductFacing.Enabled = false;
        }

        private static double GetPriceForCustomer(string customerId, string productId, string storeId)
        {
            byte priceNum = 1;
            double discount = 0;
            double price = 0;
            string Query;
            List<string> rdrRez = null;
            try
            {
                Query = "SELECT dgd.dgdPriceNum, dgd.dgdDiscount\n" +
                    "FROM\n" +
                    "	tblDiscountGroupDetails dgd,\n" +
                    "	tblCustomers c,\n" +
                    "	tblProducts p\n" +
                    "WHERE\n" +
                    "	(dgd.dgdProductGroupId = p.pGroupId3) AND\n" +
                    "	(dgd.dgdDiscountGroupId = c.cDiscountGroupId) AND\n" +
                    "	(c.id = " + customerId + ") AND\n" +
                    "	(p.id = " + productId + ")";
                Database.EXEC_Reader(Query);
                rdrRez = Database.EXEC_GetRead();

                try
                {
                    priceNum = byte.Parse(rdrRez[0]);
                    discount = double.Parse(rdrRez[1]);
                }
                catch
                {
                    Database.EXEC_CloseReader();
                    Query = "SELECT dgd.dgdPriceNum, dgd.dgdDiscount\n" +
                        "FROM\n" +
                        "	tblDiscountGroupDetails dgd,\n" +
                        "	tblCustomers c,\n" +
                        "	tblProducts p\n" +
                        "WHERE\n" +
                        "	(dgd.dgdProductGroupId = p.pGroupId2) AND\n" +
                        "	(dgd.dgdDiscountGroupId = c.cDiscountGroupId) AND\n" +
                        "	(c.id = " + customerId + ") AND\n" +
                        "	(p.id = " + productId + ")";
                    Database.EXEC_Reader(Query);
                    rdrRez = Database.EXEC_GetRead();

                    try
                    {
                        priceNum = byte.Parse(rdrRez[0]);
                        discount = double.Parse(rdrRez[1]);
                    }
                    catch
                    {
                        Database.EXEC_CloseReader();
                        Query = "SELECT dgd.dgdPriceNum, dgd.dgdDiscount\n" +
                            "FROM\n" +
                            "	tblDiscountGroupDetails dgd,\n" +
                            "	tblCustomers c,\n" +
                            "	tblProducts p\n" +
                            "WHERE\n" +
                            "	(dgd.dgdProductGroupId = p.pGroupId1) AND\n" +
                            "	(dgd.dgdDiscountGroupId = c.cDiscountGroupId) AND\n" +
                            "	(c.id = " + customerId + ") AND\n" +
                            "	(p.id = " + productId + ")";
                        Database.EXEC_Reader(Query);
                        rdrRez = Database.EXEC_GetRead();

                        try
                        {
                            priceNum = byte.Parse(rdrRez[0]);
                            discount = double.Parse(rdrRez[1]);
                        }
                        catch { }
                    }

                }

                Database.EXEC_CloseReader();
                Query = "SELECT r.rProductPrice" + priceNum.ToString() + "\n" +
                    "FROM\n" +
                    "	tblReserves r\n" +
                    "WHERE\n" +
                    "	(r.rProductId = '" + productId + "') AND\n" +
                    "	(r.rStoreId = '" + storeId + "')";
                decimal rProductPrice = (decimal)Database.EXEC_ExecuteScalar(Query);
                price = ((double)rProductPrice) * (1 - discount / 100);
            }

            catch (Exception ex)
            {
                //SysLog.PutLog("Service.GetPriceForCustomer", ex);
                GLOBAL.SysLog.WriteError("GetPriceForCustomer: " + ex.Message);
            }

            finally
            {
                Database.EXEC_CloseReader();
            }

            return price;
        }

        private void chkNoOrder_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkNoOrder.Checked)
            {
                numUpDownProductCount.Value = 0;
                numUpDownProductCount.Enabled = false;
            }
            else
                numUpDownProductCount.Enabled = true;
        }

        private void txbProductCount_GotFocus(object sender, EventArgs e)
        {
            Sip.Show();
        }

        private void txbProductCount_LostFocus(object sender, EventArgs e)
        {
            Sip.Hide();
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

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            if (ConfirmInput())
                DialogResult = DialogResult.OK;
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

        private void numUpDownProductCount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
				if (UserConfig.GetValue("SuperMultiplicity") == "1")
				{
					int iCurrentProductCount = (int)numUpDownProductCount.Value;
					if (iCurrentProductCount < 0)
						throw new Exception();

					numUpDownProductCount.Increment = (decimal)iMinProductCount;
				}
				else
				{
					if (UserConfig.GetValue("Multiplicity") == "1")
					{
						int iCurrentProductCount = (int) numUpDownProductCount.Value;
						if (iCurrentProductCount < 0)
							throw new Exception();

						if (iCurrentProductCount >= iPiecesInBox)
						{
							numUpDownProductCount.Increment = (decimal) iPiecesInBox;
						}
						else
						{
							numUpDownProductCount.Increment = (decimal) iMinProductCount;
						}
					}
				}
            }
            catch
            {
                MessageBox.Show("Неправильное значение", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}