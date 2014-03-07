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
    public partial class frmShops : Form
    {
        private DataSet dsShops = new DataSet();
        private int cusomerId;
        private int selectedShopId;
        public frmShops()
        {
            InitializeComponent();
            /// Data Grid style definition
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "tblShops";

            DataGridTextBoxColumn sNameCol = new DataGridTextBoxColumn();
            sNameCol.MappingName = "sName";
            sNameCol.HeaderText = "Название";
        	sNameCol.Width = 75 * Screen.PrimaryScreen.Bounds.Width/240;
           
            tableStyle.GridColumnStyles.Add(sNameCol);

            DataGridTextBoxColumn sAddressCol = new DataGridTextBoxColumn();
            sAddressCol.MappingName = "sAddress";
            sAddressCol.HeaderText = "Адрес";
			sAddressCol.Width = 153 * Screen.PrimaryScreen.Bounds.Width / 240;
            tableStyle.GridColumnStyles.Add(sAddressCol);

            dgShops.TableStyles.Add(tableStyle);
        }

        public DialogResult ShowShops(int customerId)
        {
            this.cusomerId = customerId;
            return ShowDialog();
        }

        private void frmShops_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
            FillShopDataGrid();
        }

        private void FillShopDataGrid()
        {
            
            string HardRoute = UserConfig.GetValue("HardRoute");
            if (HardRoute == "1")
            {
                string week = (string)Database.EXEC_ExecuteScalar("select ppoValue from tblPpcOptions where ppoVariable = 'RealWeek'").ToString().Trim();
                dsShops = Database.EXEC_GetDataSet(string.Format(@"
                    SELECT s.id, s.sName, s.sAddress
                    FROM tblShops s
                    JOIN tblRoute r ON r.roShopId = s.id
                    WHERE s.sCustomerId = '{0}' and r.roDayOfWeekId='{1}'
                    ORDER BY sName", cusomerId, week), "tblShops");
                string DateSync = GLOBAL.CONFIG.GetValue("DateSync", "2010-01-01", "Main");
                int UserId = int.Parse(GLOBAL.CONFIG.GetValue("UserId", "0", "Main"));
                string Query = string.Format(@"
                    SELECT s.id, s.sName, s.sAddress
                    FROM tblShops s
                    JOIN tblRouteAdditional ra ON ra.rtShopId = s.id
                    WHERE ra.rtUserId= {0} and ra.rtDate = '{1}'
                    ORDER BY sName", UserId, DateSync);
                Database.EXEC_Reader(Query);
                List<string> res = null;
                while ((res = Database.EXEC_GetRead()) != null)
                {
                    dsShops.Tables[0].Rows.Add(res[0], res[1], res[2]);
                }
            }
            else
            {
                dsShops = Database.EXEC_GetDataSet(string.Format(@"
					SELECT s.id, s.sName, s.sAddress
					FROM tblShops s
					WHERE s.sCustomerId = '{0}'
					ORDER BY sName", cusomerId), "tblShops");
            }
            dgShops.DataSource = dsShops.Tables[0].DefaultView;
        }

        private void SelectShop()
        {
            try
            {
                selectedShopId = int.Parse(dsShops.Tables[0].Rows[dgShops.CurrentRowIndex].ItemArray[0].ToString());
                GLOBAL.SysLog.WriteInfom("selected shop [" + selectedShopId + "] ");

                if (UserConfig.GetValue("Protect") != "0")
                {
                    Database.EXEC_Reader(string.Format("SELECT * FROM tblProtect WHERE prShopId='{0}'", selectedShopId));
                    if (Database.EXEC_GetRead() != null)
                    {
                        MessageBox.Show("Вам запрещен набор накладных на этот магазин !!!", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                }
                DialogResult = DialogResult.OK;
            }

            catch
            {
                MessageBox.Show("Список магазинов пуст", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private void dgShops_DoubleClick(object sender, EventArgs e)
        {
            SelectShop();
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public int SelectedShopId
        {
            get { return selectedShopId; }
        }

        private void pBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            SelectShop();
        }

        private void pBoxBack_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}