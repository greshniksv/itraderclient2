using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using System.IO;
using ConsumedOrders.DataContainers;
using System.Xml.Serialization;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Net;
using System.Collections.Specialized;


namespace ConsumedOrders
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();

            UserConfig.ReadConfig();
            GLOBAL.Status.Invoke += (StatusInvoke);
            Database.DbStatusUpdated += new itcDatabase.DbStatusUpdatedDelegate(Database_DbStatusUpdated);
            Updater.UpdateDone += new Updater.UpdateDoneHandler(Updater_UpdateDone);
        }

        void Updater_UpdateDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((NotifyHandler)delegate
                {
                    DialogResult = DialogResult.Cancel;
                });
            }
            else
                DialogResult = DialogResult.Cancel;
            
        }

        void Database_DbStatusUpdated()
        {
            this.Invoke
            (
                new NotifyHandler(
                    delegate()
                    {
                        ButtonsEnable(true);
                    }
                )
            );
            if (Status.CurrentStatus == "Синхронизация завершена")
            {
                this.Invoke
                (
                    new NotifyHandler(
                        delegate()
                        {
                            UserConfig.ReadConfig();
                            if (this.Visible)
                            {
                                new Thread(delegate()
                                    {
                                        ConsumedOrders.formCustomers.PrepareForm();
                                        ConsumedOrders.formPrice.PrepareForm();
                                    }) { Priority = ThreadPriority.Normal, IsBackground = true }.Start();
                            }
                        }
                    )
                );
				
                return;
            }
        }


        public Label StatusLabel
        {
            get { return lblStatus;}
            set { lblStatus = value; }
        }

        void StatusInvoke()
        {
            lblStatus.Text = GLOBAL.Status.ToString();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ConsumedOrders.formCustomers.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
			GLOBAL.SysLog.WriteInfom("Click create new order.");
            string message = CheckPermission();
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            string DateSync = GLOBAL.CONFIG.GetValue("DateSync", "2010-01-01", "Main");
            if (DateSync != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                GLOBAL.SysLog.WriteWarning("needed sync");
			    MessageBox.Show("Нет возможности набора накладных. Необходимо синхронизироваться!!! ", 
				    		"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 
					    	MessageBoxDefaultButton.Button1);
			    return;
            }
            
            if (ConsumedOrders.formCustomers.ShowCustomers() == DialogResult.OK)
            {
                if (ConsumedOrders.formShops.ShowShops(ConsumedOrders.formCustomers.SelectedCustomerId) == DialogResult.OK)
                {
                    ConsumedOrders.formOrderDetails.ShowOrderDetails(ConsumedOrders.formShops.SelectedShopId);
                }
            }
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

        private void btnSyncAll_Click(object sender, EventArgs e)
        {
			ButtonsEnable(false);
            SendStatistics();
            SendLogToServer();
            Database.Sync();
        }

        public static string HttpPost(string uri, string parameters, string user)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. 
            //Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes("param=" + parameters + "&uid=" + user);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            var sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        private void SendLogToServer()
        {
            Status.UpdateStatus("Отправка логов");
            Application.DoEvents();

            try
            {
                string uid = GLOBAL.UserInfo.Number;
                string data = GLOBAL.SysLog.ReadAll();
                var dd = Convert.ToBase64String(Zip.sss(Encoding.UTF8.GetBytes(data)));
                var logsz = dd.Replace('+', '.').Replace('=', ',').Replace('/', '!');
                HttpPost("http://sync.npf-poisk.org.ua/ppc_statistic.php", logsz, uid);
                GLOBAL.SysLog.Clear();
            }
            catch { }
        }

        static string GetMd5Hash(string input)
        {
            StringBuilder sBuilder;
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void SendStatistics()
        {
            Status.UpdateStatus("Отправка статистики");
            Application.DoEvents();

            /* Statistic */
            try
            {
                int oNumberNullCount = (int)Database.EXEC_ExecuteScalar("SELECT COUNT(*) FROM tblOrders WHERE oNumber IS NULL");
                int __sysSRNullCount = (int)Database.EXEC_ExecuteScalar("SELECT COUNT(*) FROM tblOrders WHERE __sysSR IS NULL");
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string uname = GLOBAL.UserInfo.Name.Replace(' ', '_');
                string uid = GLOBAL.UserInfo.Number;
                string dt = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");

                string url = "http://sync.npf-poisk.org.ua/ppc_statistic.php?uid=" + uid +
                    "&uname=" + uname + "&orderc=" + oNumberNullCount + "&ordercs=" + __sysSRNullCount + "&dt=" + dt + "&ver=" + version;
                //MessageBox.Show(url);

                WebRequest request = WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                stream.Close();
            }
            catch { }
        }

        public void ButtonsEnable(bool state)
        {
            btnSyncAll.Enabled = state;
            btnNewOrder.Enabled = state;
            btnOrderList.Enabled = state;
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            string dayForRoute = Database.EXEC_ExecuteScalar("select ppoValue from tblPpcOptions where ppoVariable ='UpdateRoute'").ToString().Trim();
            string dayNowId = Database.EXEC_ExecuteScalar("select ppoValue from tblPpcOptions where ppoVariable = 'RealWeek'").ToString().Trim();

            if (dayNowId == dayForRoute)
            {
                ConsumedOrders.formRoute.ShowDialog();
            }
            else
            {
                string dayNameNow = string.Empty;
                switch (dayNowId)
                {
                    case "1": dayNameNow = "Понедельник"; break;
                    case "2": dayNameNow = "Вторник"; break;
                    case "3": dayNameNow = "Среда"; break;
                    case "4": dayNameNow = "Четверг"; break;
                    case "5": dayNameNow = "Пятница"; break;
                    case "6": dayNameNow = "Суббота"; break;
                    case "7": dayNameNow = "Воскресенье"; break;
                }

                string dayNameForRoute = string.Empty;
                switch (dayForRoute)
                {
                    case "1": dayNameForRoute = "Понедельник"; break;
                    case "2": dayNameForRoute = "Вторник"; break;
                    case "3": dayNameForRoute = "Среду"; break;
                    case "4": dayNameForRoute = "Четверг"; break;
                    case "5": dayNameForRoute = "Пятницу"; break;
                    case "6": dayNameForRoute = "Субботу"; break;
                    case "7": dayNameForRoute = "Воскресенье"; break;
                }

				GLOBAL.SysLog.WriteInfom("Try open Route form. Block. ");
                MessageBox.Show("Сегодня " + dayNameNow + ". Вы можете изменять свой маршрут только в " + dayNameForRoute);
            }
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
			GLOBAL.SysLog.WriteInfom("View orders");
            ConsumedOrders.formOrders.ShowDialog();
        }

        private void btnReserves_Click(object sender, EventArgs e)
        {
			GLOBAL.SysLog.WriteInfom("View reserves");
            ConsumedOrders.formReserves.ShowReserves();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.Load("iTrader.Client2"));
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;

            if (File.Exists(GLOBAL.TempOrderPath))
            {
				GLOBAL.SysLog.WriteWarning("Query editing failed order.");
                string Message = "Возможно произошло аварийное выключение. Обнаружена несохраненная накладная. Продолжить ее редактирование? Если нажать \"NO\" накладная будет удалена";
                if (MessageBox.Show(Message, "Ошибка",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
					GLOBAL.SysLog.WriteInfom("Restore file order");
                    try
                    {
                        Stream fStream = File.OpenRead(GLOBAL.TempOrderPath);
                        XmlSerializer xmlFormat = new XmlSerializer(typeof(Order));
                        OrderContainer.CurrentOrder = (Order)xmlFormat.Deserialize(fStream);
                        fStream.Close();
                        ConsumedOrders.formOrderDetails.ContinueEditingAfterFail();
                    }
                    catch (Exception ex)
                    {
                        GLOBAL.SysLog.WriteError("Failed to deserialize Order. InnerException.Message: " + ex.InnerException.Message);
                        GLOBAL.SysLog.WriteError("Failed to deserialize Order. Exception.Message: " + ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    GLOBAL.SysLog.WriteWarning("Deny continue editing order after fail");
                    File.Delete(GLOBAL.TempOrderPath);
                }
            }
        }

        private void btnPerf_Click(object sender, EventArgs e)
        {
            ConsumedOrders.formCheques.ShowDialog();
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
	}
}