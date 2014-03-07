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
using System.Resources;
using System.Reflection;

namespace ConsumedOrders
{
    public partial class frmReserves : Form
    {
        private DataSet dsProducts = null;
        public delegate void NotifyHandler();
        Thread thrFilter = null;
        private bool allowFillDataGrid;
        private bool sipVisible = false;

        public frmReserves()
        {
            InitializeComponent();

            /// Data Grid style definition
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
			pAvailCountCol.Width = 40 * Screen.PrimaryScreen.Bounds.Width / 240;

            tableStyle.GridColumnStyles.Add(pAvailCountCol);
            dgProducts.TableStyles.Add(tableStyle);
            dsProducts = new DataSet();
            allowFillDataGrid = false;
        }

        private void frmReserves_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pictBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pictBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public DialogResult ShowReserves()
        {
            if (edtProductTitle.Text == "")
                FillDataGrid("");
            else
                edtProductTitle.Text = "";
            return ShowDialog();
        }

        public void PrepareForm()
        {
            allowFillDataGrid = false;
            if (this.InvokeRequired)
            {
                this.Invoke(new NotifyHandler(
                    delegate()
                    {
                        DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
                        //if (cmbStores.Items.Count > 0)
                        //    cmbStores.SelectedIndex = 0;
                    })
                );
            }
            else
            {
                DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
                //if (cmbStores.Items.Count > 0)
                //    cmbStores.SelectedIndex = 0;
            }
            allowFillDataGrid = true;
        }

        private void FillDataGrid(string productName)
        {
            string minReservesValue = "";
            ComboBoxItem item = null;
            if (this.InvokeRequired)
            {
                this.Invoke(new NotifyHandler(
                    delegate()
                    {
                        item = (ComboBoxItem)cmbStores.SelectedItem;
                        if (fullPriceCheck.Checked)
                            minReservesValue = "-99";
                        else
                            minReservesValue = "0";
                    })
                );
            }
            else
            {
                item = (ComboBoxItem)cmbStores.SelectedItem;
                if (fullPriceCheck.Checked)
                    minReservesValue = "-99";
                else
                    minReservesValue = "0";
            }

            string Query = string.Format(@"
                SELECT id, pName, rProductAvailCount 
                FROM tblProducts p
                JOIN tblReserves r ON r.rProductId = p.id
                WHERE r.rStoreId = {0} and pName like '%{1}%' and rProductAvailCount > {2}
                ORDER BY pName", item.Id, productName, minReservesValue);
            dsProducts = Database.EXEC_GetDataSet(Query, "tblProducts");
            if (this.InvokeRequired)
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            dgProducts.DataSource = dsProducts.Tables[0].DefaultView;
                        }
                    )
                );
            }
            else
                dgProducts.DataSource = dsProducts.Tables[0].DefaultView;
        }

        private void edtProductTitle_TextChanged(object sender, EventArgs e)
        {
            if (thrFilter != null)
                thrFilter.Abort();
            string text = ((TextBox)sender).Text;
            thrFilter = new Thread(delegate()
                {
                    Thread.Sleep(1000);
                    FillDataGrid(text);
                });
            thrFilter.IsBackground = true;
            thrFilter.Start();
        }

        private void edtProductTitle_GotFocus(object sender, EventArgs e)
        {
            Sip.Show();
        }

        private void edtProductTitle_LostFocus(object sender, EventArgs e)
        {
            Sip.Hide();
        }

        private void pictBack_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pictBack_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pictBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowFillDataGrid)
                FillDataGrid(edtProductTitle.Text);
        }

        private void fullPriceCheck_CheckStateChanged(object sender, EventArgs e)
        {
            FillDataGrid(edtProductTitle.Text);
        }

        private void dgProducts_CurrentCellChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = null;
            if (this.InvokeRequired)
            {
                this.Invoke(new NotifyHandler(
                    delegate()
                    {
                        item = (ComboBoxItem)cmbStores.SelectedItem;
                    })
                );
            }
            else
            {
                item = (ComboBoxItem)cmbStores.SelectedItem;
            }

            string rProductId = dsProducts.Tables[0].Rows[dgProducts.CurrentRowIndex].ItemArray[0].ToString();
            lblProduct.Text = dsProducts.Tables[0].Rows[dgProducts.CurrentRowIndex].ItemArray[1].ToString();
            string Query = string.Format(@"
                SELECT rProductPrice1, rProductPrice2, rProductPrice3, rProductPrice4, rProductPrice5 
                FROM tblReserves
                WHERE rProductId = {0} and rStoreId = {1}", rProductId, item.Id);
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