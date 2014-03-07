using System;

using System.Collections.Generic;
using System.Text;
using itcDatabase;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace ConsumedOrders.DataContainers
{
    public static class OrderContainer
    {
        public static bool OnlyAdditionalInfoInput = false;
        public static Order CurrentOrder;
        public static List<Order> Orders = new List<Order>();
        private static Thread thrBackup;

        public static void AddCurrenOrder()
        {
            Orders.Add(CurrentOrder);
        }

        private static Order FillCurrentOrderFromDB(string DBorderId, string NewOrderId)
        {
            string Query = string.Format(@"
            SELECT oDate, oShopId, oComment, oCreatorId, oItemsCount, oIsOfficial, oStoreId, oCreateDate, oCashOrder
            FROM tblOrders
            WHERE id = '{0}'", DBorderId);
            Database.EXEC_Reader(Query);
            List<object> order = Database.EXEC_rdrReadObjects();
            DateTime oDate = ((DateTime)order[0]);
            int oShopId = (int)order[1];
            // TODO : rewrite this code
            string oCommentODebit = "";
            if (!(order[2] is DBNull))
                oCommentODebit = (string)order[2];
            string[] arrCommentDebit = oCommentODebit.Split('&');
            string oComment = "";
            double oDebit = 0.0;


            try
            {

                if (arrCommentDebit.Length == 1)
                {
                    oComment = arrCommentDebit[0];
                }
                else if (arrCommentDebit.Length == 2)
                {
                    oComment = arrCommentDebit[0];
                    oDebit = double.Parse(arrCommentDebit[1].Replace(".",","));
                }
                else
                    throw new Exception("Error in FillCurrentOrderFromDB while parse oComment");
            }
            catch
            {
                throw new Exception("Error in FillCurrentOrderFromDB while parse oComment");
            }
 
            int oCreatorId = (int)order[3];
            int oItemsCount = (int)order[4];
            byte oIsOfficial = (byte)order[5];
            int oStoreId = (int)order[6];
            DateTime oCreateDate = DateTime.Now;
            if (!(order[7] is DBNull))
                oCreateDate = ((DateTime)order[7]);
            int oCashOrder = 0;
            if (!(order[8] is DBNull))
                oCashOrder = (byte)order[8];
            // TODO: after adding field oDebit in db - rewrite this code
            Order ord = new Order(NewOrderId, oDate, oShopId, oComment, oCreatorId, oIsOfficial, oStoreId,
                DateTime.Now.ToString("hh:mm:ss"), DateTime.Now.ToString("hh:mm:ss"), oCreateDate, oDebit);
            Database.EXEC_CloseReader();
            Query = string.Format(@"
            SELECT odProductId, odProductCount, odProductPrice, odIsPersonalPrice, odRest, odShopPrice, odFacing
            FROM tblOrderDetails 
            WHERE odOrderId = '{0}'", DBorderId);
            Database.EXEC_Reader(Query);
            List<object> orderDetailsList = null;
            while ((orderDetailsList = Database.EXEC_rdrReadObjects()) != null)
            {
                int odProductId = (int)orderDetailsList[0];
                int odProductCount = (int)orderDetailsList[1];
                double odProductPrice = (double)(decimal)orderDetailsList[2];
                byte odIsPresonalPrice = (byte)orderDetailsList[3];
                int odRest = -99;
                if (!(orderDetailsList[4] is DBNull))
                    odRest = (int)orderDetailsList[4];
                double odShopPrice = -99;
                if (!(orderDetailsList[5] is DBNull))
                    odShopPrice = (double)orderDetailsList[5];
                int odFacing = -99;
                if (!(orderDetailsList[6] is DBNull))
                    odFacing = (int)orderDetailsList[6];
                ord.AddPosition(odProductId, odProductCount, odProductPrice, odIsPresonalPrice, odRest, odShopPrice, odFacing);
            }
            return ord;
        }

        public static void FillCurrentOrderFromDB(string orderId)
        {
            CurrentOrder = FillCurrentOrderFromDB(orderId, orderId);
        }

        public static Order GenerateOrderForDuplicate(string orderId)
        {
            string newOrderId = (Guid.NewGuid()).ToString();
            return FillCurrentOrderFromDB(orderId, newOrderId);
        }

        public static void BackupCurrentOrderToFile(string filePath)
        {
            if (thrBackup != null)
                thrBackup.Abort();
            thrBackup = new Thread(() => DoBackup(filePath)) { IsBackground = false };
            thrBackup.Start();
        }

        private static void DoBackup(string filePath)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Order));
            Stream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            xmlFormat.Serialize(fStream, CurrentOrder);
            fStream.Close();
        }
    }
}
