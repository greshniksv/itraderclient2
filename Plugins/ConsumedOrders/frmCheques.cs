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
using ConsumedOrders.WebReference;

namespace ConsumedOrders
{
    public delegate void MethodInvoker();
    public partial class frmCheques : Form
    {
        private List<Cheques> chequesList = new List<Cheques>();

        private bool sipVisible = false;
        PrintChequesService pcs;

        public frmCheques()
        {
            InitializeComponent();
        }

        private void frmCheques_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxDelete.Image = (Bitmap)resMan.GetObject(string.Format("delete{0}", size));
            pBoxDelete.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxClear.Image = (Bitmap)resMan.GetObject(string.Format("clearall{0}", size));
            pBoxClear.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxPrint.Image = (Bitmap)resMan.GetObject(string.Format("print{0}", size));
            pBoxPrint.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxKeyBoard.Image = (Bitmap)resMan.GetObject(string.Format("keyboard{0}", size));
            pBoxKeyBoard.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public void PrepareForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NotifyHandler(
                    delegate()
                    {
                        DatabaseService.FillComboBox(cmbCustomers, "tblCustomers", "id", "cName", "0");
                        DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
                    })
                );
            }
            else
            {
                DatabaseService.FillComboBox(cmbCustomers, "tblCustomers", "id", "cName", "0");
                DatabaseService.FillComboBox(cmbStores, "tblStores", "id", "sName", "0");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBoxItem custItem = (ComboBoxItem)cmbCustomers.SelectedItem;
                //ComboBoxItem storeItem = (ComboBoxItem)cmbStores.SelectedItem;
                double summ = double.Parse(txbSumm.Text);
                foreach (Cheques chqItem in chequesList)
                {
                    if (chqItem.CustomerName == custItem.Name)
                    {
                        chequesList.Remove(chqItem);
                        for (int i = 0; i < listViewClients.Items.Count; i++)
                        {
                            if (listViewClients.Items[i].Text == custItem.Name)
                            {
                                listViewClients.Items.Remove(listViewClients.Items[i]);
                                break;
                            }
                        }
                        break;
                    }
                }
                Cheques chqs = new Cheques(custItem.Name, summ);
                chequesList.Add(chqs);

                ListViewItem lstvItem = new ListViewItem(chqs.CustomerName);
                lstvItem.SubItems.Add(chqs.Summ.ToString());
                listViewClients.Items.Add(lstvItem);
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно, либо введены не все данные", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void DeleteSelectedItem()
        {
            int index = listViewClients.SelectedIndices[0];
            string customerName = listViewClients.Items[0].Text;
            string message = string.Format("Удалить {0} из списка?", customerName);
            if (MessageBox.Show(message, "Ошибка",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                foreach (Cheques chqItem in chequesList)
                {
                    if (chqItem.CustomerName == customerName)
                    {
                        chequesList.Remove(chqItem);
                        for (int i = 0; i < listViewClients.Items.Count; i++)
                        {
                            if (listViewClients.Items[i].Text == customerName)
                            {
                                listViewClients.Items.Remove(listViewClients.Items[i]);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void DeleteAll()
        {
            string message = "Очистить весь список?";
            if (MessageBox.Show(message, "Ошибка",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                listViewClients.Items.Clear();
                chequesList.Clear();
            }
        }

        private void Print()
        {
            List<string> clientAndCostList = new List<string>();
            foreach (Cheques chqs in chequesList)
            {
                clientAndCostList.Add(chqs.ToString());
            }
            ComboBoxItem storeItem = (ComboBoxItem)cmbStores.SelectedItem;
            try
            {
                pcs = new PrintChequesService();
                //pcs.BeginPrint(GLOBAL.UserInfo.Name, storeItem.Name, clientAndCostList.ToArray(),
                //    ar =>
                //    {
                //        lblStatus.Text = pcs.EndPrint(ar);
                //    }, null);
                IAsyncResult iar = pcs.BeginPrint(GLOBAL.UserInfo.Name, storeItem.Name, clientAndCostList.ToArray(), new AsyncCallback(PrintEndCallBack), null);
                lblStatus.Text = "Статус: отправка на печать...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintEndCallBack(IAsyncResult iar)
        {
            
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        lblStatus.Text = pcs.EndPrint(iar);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        lblStatus.Text = "Статус:Ошибка во время печати";
                    }
                });
            else
                lblStatus.Text = string.Format("Статус: {0}", pcs.EndPrint(iar));
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
            DeleteSelectedItem();
        }

        private void pBoxPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void pBoxClear_Click(object sender, EventArgs e)
        {
            DeleteAll();
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