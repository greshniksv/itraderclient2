using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using itcDatabase;
using itcClassess;
using System.Threading;
using ConsumedOrders.DataContainers;
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmCustomers : Form
    {
        public delegate void NotifyHandler();
        private DataSet dsCustomers = new DataSet();
        private int selectedCustomerId;
        private int UserId;
        string DateSync = "";
        private Thread thrFilter;
        private bool blockFilter;
        private bool sipVisible = false;
        public frmCustomers()
        {
            InitializeComponent();
            //string HightResolution = GLOBAL.CONFIG.GetValue("HightResolution", "0", "Main");
            UserId = int.Parse(GLOBAL.CONFIG.GetValue("UserId", "0", "Main"));
            // Data Grid style definition
            var tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblCustomers";

            var cNameCol = new DataGridTextBoxColumn();
            cNameCol.MappingName = "cName";
            cNameCol.HeaderText = "Название клиента";

			// if HightResolution
			cNameCol.Width = 223 * Screen.PrimaryScreen.Bounds.Width / 240;

            tableStyle.GridColumnStyles.Add(cNameCol);

            dgCustomers.TableStyles.Add(tableStyle);
            blockFilter = false;
        }

        #region Properties
        public int SelectedCustomerId
        {
            get { return selectedCustomerId; }
        }

        #endregion 

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxBuyHistory.Image = (Bitmap)resMan.GetObject(string.Format("buyhistory{0}", size));
            pBoxBuyHistory.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDiscount.Image = (Bitmap)resMan.GetObject(string.Format("discount{0}", size));
            pBoxDiscount.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public DialogResult ShowCustomers()
        {
            string curDate = GLOBAL.CONFIG.GetValue("DateSync", "2010-01-01", "Main");
            if (txbSearch.Text != "")
            {
                blockFilter = true;
                txbSearch.Text = "";
                FillDataGrid("");
                blockFilter = false;
            }
            else if (curDate != DateSync)
            {
                FillDataGrid("");
            }
            return ShowDialog();
        }
        public void PrepareForm()
        {
            FillDataGrid("");
        }

        private int GetSelectedCustomerId()
        {
            int custId = 0;

            try
            {
                custId = int.Parse(dsCustomers.Tables[0].Rows[dgCustomers.CurrentRowIndex].ItemArray[0].ToString());
                selectedCustomerId = custId;
            }

            catch
            {
                MessageBox.Show("Список клиентов пуст", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            return custId;
        }

        private void SelectCustomer()
        {
            //string Protect = GLOBAL.CONFIG.GetValue("Protect", "0", "ConsumedOrders");
            string Protect = UserConfig.GetValue("Protect");
            
            if (Protect == "1")
            {
                if (Database.EXEC_Reader("select * from tblProtect where prCustomerId='" +
                    GetSelectedCustomerId() + "'") == false)
                {
                    MessageBox.Show("Error during sql reader work", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                if (Database.EXEC_GetRead() != null)
                {
                    GLOBAL.SysLog.WriteInfom("selected blocked customers [" + GetSelectedCustomerId() + "]");

                    if (MessageBox.Show("Внимание. \nВам запрещен набор накладных на этого клиента. \nХотите ввести остатки?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        OrderContainer.OnlyAdditionalInfoInput = true;
                        DialogResult = (GetSelectedCustomerId() != 0) ? DialogResult.OK : DialogResult.Cancel;
                        return;
                    }
                    DialogResult = DialogResult.Cancel;
                    return;
                }
                else
                {
                    OrderContainer.OnlyAdditionalInfoInput = false;
                    GLOBAL.SysLog.WriteInfom("selected customers [" + GetSelectedCustomerId() + "] ");
                }
                Database.EXEC_CloseReader();
            }

            DialogResult = (GetSelectedCustomerId() != 0) ? DialogResult.OK : DialogResult.Cancel;
        }

        private void dgCustomers_DoubleClick(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            if (blockFilter)
                return;
            if (thrFilter != null)
                thrFilter.Abort();
            string text = ((TextBox)sender).Text;
            thrFilter = new Thread(() => res(text)) { IsBackground = true };
            thrFilter.Start();
        }

        void res(object custName)
        {
            Thread.Sleep(1000);
            FillDataGrid((string)custName);
        }

        private void FillDataGrid(string custName)
        {
            string customersFilter = string.Format(" and (cName LIKE '%{0}%') ", custName.Trim());
            string HardRoute = UserConfig.GetValue("HardRoute");
            DateSync = GLOBAL.CONFIG.GetValue("DateSync", "2010-01-01", "Main");
            if (HardRoute == "1")
            {
                string week = "0";
                week = (string)Database.EXEC_ExecuteScalar("select ppoValue from tblPpcOptions where ppoVariable = 'RealWeek'").ToString().Trim();
                string Query = string.Format(@"
                    SELECT c.id, cName 
                    FROM tblCustomers c
                    JOIN tblShops s ON s.sCustomerId = c.id
                    JOIN tblRoute r ON r.roShopId = s.id
                    WHERE r.roDayOfWeekId='{0}' 
                    and r.roUserId='{1}' and cName LIKE '%{2}%' 
                    GROUP BY c.id, cName
                    ORDER BY cName", week, UserId, custName.Trim());
                dsCustomers = Database.EXEC_GetDataSet(Query, "tblCustomers");
                
                Query = string.Format(@"
                    SELECT c.id, cName
                    FROM tblCustomers c
                    JOIN tblShops s ON s.sCustomerId = c.id
                    JOIN tblRouteAdditional ra ON ra.rtShopId = s.id
                    WHERE ra.rtUserId= {0} and ra.rtDate = '{1}' and cName LIKE '%{2}%'
                    GROUP BY c.id, cName
                    ORDER BY cName", UserId, DateSync, custName.Trim());
                Database.EXEC_Reader(Query);
                List<string> res = null;
                while ((res = Database.EXEC_GetRead()) != null)
                {
                    dsCustomers.Tables[0].Rows.Add(res[0], res[1]);
                }
            }
            else
            {
                dsCustomers = Database.EXEC_GetDataSet(string.Format(
                    "SELECT id, cName FROM tblCustomers WHERE cName LIKE '%{0}%' ORDER BY cName", custName.Trim()), "tblCustomers");
            }
            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            dgCustomers.DataSource = dsCustomers.Tables[0].DefaultView;
                        }
                    )
                );
            }
            else
                dgCustomers.DataSource = dsCustomers.Tables[0].DefaultView;
            
        }

        private void ShowBuysHistory()
        {
            ConsumedOrders.formBuysHistory.ShowBuysHistory(GetSelectedCustomerId());
        }

        private void ShowDiscounts()
        {
            ConsumedOrders.formDiscounts.ShowCustomerDiscounts(GetSelectedCustomerId().ToString());
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pBoxBack_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        private void pBoxDiscount_Click(object sender, EventArgs e)
        {
            ShowDiscounts();
        }

        private void pBoxBuyHistory_Click(object sender, EventArgs e)
        {
            ShowBuysHistory();
        }

        private void pBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
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