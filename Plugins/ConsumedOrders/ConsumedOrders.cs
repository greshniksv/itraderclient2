using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using itcInterface;
using System.Threading;
using itcClassess;
using System.Windows.Forms;

namespace ConsumedOrders
{
	public class ConsumedOrders : IPlugin
	{
        public static frmBuysHistory formBuysHistory = null;
        public static frmCheques formCheques = null;
        public static frmCustomers formCustomers = null;
        public static frmDiscounts formDiscounts = null;
        public static frmItemCard formItemCard = null;
		public static frmMain formMain = null;
        public static frmOrderDetails formOrderDetails = null;
        public static frmOrders formOrders = null;      
        public static frmPrice formPrice = null;
        public static frmReserves formReserves = null;
        public static frmRoute formRoute = null;
        public static frmShops formShops = null;

        public static bool firstRun=true;

        public ConsumedOrders()
        {
            /// Create application forms
            formBuysHistory = new frmBuysHistory();
            formCheques = new frmCheques();
            formCustomers = new frmCustomers();
            formDiscounts = new frmDiscounts();
            formItemCard = new frmItemCard();
            formMain = new frmMain();
            formOrderDetails = new frmOrderDetails();
            formOrders = new frmOrders();
            formPrice = new frmPrice();
            formReserves = new frmReserves();
            formRoute = new frmRoute();
            formShops = new frmShops();
        }

		string IPlugin.GetPluginName()
		{
			return "РН";
		}

		string IPlugin.GetPluginDescription()
		{
			return "Плагин для оформления расходных накладных";
		}
		
		string IPlugin.GetPluginVersion()
		{
			return @"0." + Assembly.GetExecutingAssembly().GetName().Version.Revision;
		}

		Icon IPlugin.GetAppIcon()
		{
            ResourceManager resMan = new ResourceManager("ConsumedOrders.Properties.Resources", Assembly.GetExecutingAssembly());
            return (Icon)resMan.GetObject("ordersIcon");
		}

		void IPlugin.Run()
		{
            if (firstRun)
            {
                firstRun = false;               
                StartRefreshData();                
            }
            formMain.ShowDialog();
		}

		void IPlugin.RefreshData()
        {
            StartRefreshData();
        }

        public void StartRefreshData()
        {

            Thread drThread = new Thread(new ThreadStart(RefData));
            drThread.Priority = ThreadPriority.Normal;
            drThread.IsBackground = true;
            drThread.Start();
        }

        private void RefData()
        {
            try
            {
                Status.AddLabel(formMain.StatusLabel);
                Status.UpdateStatus("Ин-ция просмотрщика накладной...", 5);
                formOrderDetails.PrepareForm();
                Status.UpdateStatus("Инициализация просмотрщика остатков...", 10);
                formReserves.PrepareForm();
                Status.UpdateStatus("Инициализация просмотрщика перфокарты...", 20);
                formCheques.PrepareForm();
                Status.UpdateStatus("Инициализация просмотрщика клиентов...", 40);
                formCustomers.PrepareForm();
                Status.UpdateStatus("Инициализация прайс листа...", 80);
                formPrice.PrepareForm();
                Status.UpdateStatus("Ready");
            }
            catch (Exception ex)
            {
                Status.UpdateStatus("Отсутствуют данные. Необходима инициализация");
                GLOBAL.SysLog.WriteError(ex.Message);
            }
        }
		void IPlugin.Close()
		{
            ConsumedOrders.formMain.Close();
            ConsumedOrders.formBuysHistory.Close();
            ConsumedOrders.formCheques.Close();
            ConsumedOrders.formCustomers.Close();
            ConsumedOrders.formDiscounts.Close();
            ConsumedOrders.formItemCard.Close();
            ConsumedOrders.formOrderDetails.Close();
            ConsumedOrders.formOrders.Close();
            ConsumedOrders.formPrice.Close();
            ConsumedOrders.formReserves.Close();
            ConsumedOrders.formRoute.Close();
            ConsumedOrders.formShops.Close();
            
		}
	}
}
