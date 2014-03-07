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
    public partial class frmRoute : Form
    {
        private string UserId;
        public frmRoute()
        {
            InitializeComponent();
            UserId = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
        }

        private void frmRoute_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDelete.Image = (Bitmap)resMan.GetObject(string.Format("delete{0}", size));
            pBoxDelete.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAdd.Image = (Bitmap)resMan.GetObject(string.Format("add{0}", size));
            pBoxAdd.SizeMode = PictureBoxSizeMode.CenterImage;

			GLOBAL.SysLog.WriteInfom("Open form ROUTE");
            cmbDayOfWeek.Items.Clear();
            ComboBoxItem item = new ComboBoxItem("1", "Понедельник");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("2", "Вторник");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("3", "Среда");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("4", "Четверг");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("5", "Пятница");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("6", "Суббота");
            cmbDayOfWeek.Items.Add(item);
            item = new ComboBoxItem("7", "Воскресенье");
            cmbDayOfWeek.Items.Add(item);
            cmbDayOfWeek.SelectedIndex = 0;

            DatabaseService.FillComboBox(cmbCustomer, "tblCustomers", "id", "cName", "0");
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbCustomer.SelectedItem;

            string Query = string.Format(@"
            SELECT id, sName 
            FROM tblShops
            WHERE sCustomerId = {0}", item.Id);
            Database.EXEC_Reader(Query);

            List<string> values = null;
            ComboBoxItem sItem = null;
            cmbShop.Items.Clear();
            while ((values = Database.EXEC_GetRead()) != null)
            {
                sItem = new ComboBoxItem(values[0], values[1]);
                cmbShop.Items.Add(sItem);
            }
            Database.EXEC_CloseReader();
        }

        private void cmbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillShopListBox();
        }

        private void FillShopListBox()
        {
            ComboBoxItem item = (ComboBoxItem)cmbDayOfWeek.SelectedItem;
            string Query = string.Format(@"
            SELECT roShopId, s.sName + ', ' + s.sAddress FROM tblRoute r
            JOIN tblShops s ON s.id = r.roShopId
            WHERE roDayOfWeekId = {0} ORDER BY s.sName", item.Id);

            Database.EXEC_Reader(Query);

            List<string> values = null;
            ComboBoxItem sItem = null;
            lstbShop.Items.Clear();
            while ((values = Database.EXEC_GetRead()) != null)
            {
                sItem = new ComboBoxItem(values[0], values[1]);
                lstbShop.Items.Add(sItem);
            }
            if (lstbShop.Items.Count > 0)
                lstbShop.SelectedIndex = 0;
        }

        private void DelRoute()
        {
            ComboBoxItem itemDay = (ComboBoxItem)cmbDayOfWeek.SelectedItem;
            ComboBoxItem itemShop = (ComboBoxItem)lstbShop.SelectedItem;

            Database.EXEC_ExecuteScalar(string.Format(
                "DELETE FROM tblRoute WHERE roShopId = {0} and roDayOfWeekId = {1}",
                                              itemShop.Id, itemDay.Id));
            FillShopListBox();
        }

        private void AddRoute()
        {
            ComboBoxItem itemDay = (ComboBoxItem)cmbDayOfWeek.SelectedItem;
            ComboBoxItem itemShop = (ComboBoxItem)cmbShop.SelectedItem;

            if (Database.EXEC_ExecuteScalar(string.Format(
                    "SELECT * FROM tblRoute WHERE roShopId = {0} and roDayOfWeekId = {1}",
                                              itemShop.Id, itemDay.Id)) == null)
            {
                Database.EXEC_SqlNonQuery(string.Format(
                    "INSERT INTO tblRoute (roUserId, roShopId, roDayOfWeekId) VALUES({0}, {1}, {2})",
                    UserId, itemShop.Id, itemDay.Id));
                FillShopListBox();
            }
        }

        private void lstbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem itemShop = (ComboBoxItem)lstbShop.SelectedItem;
            lblCustomer.Text = "Клиент: " + Database.EXEC_ExecuteScalar(string.Format(@"
                    SELECT cName FROM tblCustomers c
                    JOIN tblShops s ON s.sCustomerId = c.id
                    WHERE s.id = {0}", itemShop.Id));
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

        private void pBoxDelete_Click(object sender, EventArgs e)
        {
            DelRoute();
        }

        private void pBoxAdd_Click(object sender, EventArgs e)
        {
            AddRoute();
        }

    }
}