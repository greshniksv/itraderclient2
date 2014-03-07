using System;

using System.Collections.Generic;
using System.Text;
using itcClassess;
using itcDatabase;

namespace ConsumedOrders
{
    public delegate void ConfigReadHandler();
    public static class  UserConfig
    {
        
        /// <summary>
        /// Occurs after reading config
        /// </summary>
        public static event ConfigReadHandler ConfigReaded;
        private static Dictionary<string, string> dictOptions = new Dictionary<string,string>();

        public static void ReadConfig()
        {
            try
            {
                dictOptions.Clear();
                string UserId = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
                Database.EXEC_Reader(string.Format("select pcVariable, pcValue FROM tblPpcConfig WHERE pcUserId = '{0}'", UserId));
                List<string> list = new List<string>();
                while ((list = Database.EXEC_GetRead()) != null)
                {
                    dictOptions[list[0]] = list[1];
                }
                if (ConfigReaded != null)
                    ConfigReaded();
            }
            catch
            {

            }
        }

        public static string GetValue(string Variable)
        {
            if (dictOptions.ContainsKey(Variable))
                return dictOptions[Variable];
            else
            {
                switch (Variable)
                {
                    case "Rest":
                        return "0";
                    case "ShopDeny":
                        return "0";
                    case "ProductLimit":
                        return "0";
                    case "OrderLimit":
                        return "0";
                    case "HardRoute":
                        return "0";
                    case "FullPrice":
                        return "0";
                    case "ShowProductGroup":
                        return "0";
                    case "CashOrder":
                        return "0";
                    case "Multiplicity":
                        return "0";
                    case "ProductFacing":
                        return "0";
                    case "ProductShopPrice":
                        return "0";
                    case "HightResolution":
                        return "0";
                    case "Protect":
                        return "0";
                    case "workStart":
                        return "07:00:00";
                    case "workEnd":
                        return "18:30:00";
                    case "maxOrderCount":
                        return "3";
                    default:
                        return "0";
                }
            }
             
        }

    }
}
