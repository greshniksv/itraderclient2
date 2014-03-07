using System;

using System.Collections.Generic;
using System.Text;

namespace ConsumedOrders.DataContainers
{
    public class LastOrders
    {
        private string date;
        private int order;
        private int rest;

        public LastOrders(string date, int order, int rest)
        {
            this.date = date;
            this.order = order;
            this.rest = rest;
        }

        public string Date
        {
            get { return date; }
        }

        public int Order
        {
            get { return order; }
        }

        public int Rest
        {
            get { return rest; }
        }

        public string Value
        {
            get
            {
                string strRest = "";
                if (rest == -1)
                    strRest = "--";
                else
                    strRest = rest.ToString();
                return string.Format(@"з:{0};о:{1}", order, strRest);
            }
        }
    }
}
