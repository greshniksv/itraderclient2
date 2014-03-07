using System;

using System.Collections.Generic;
using System.Text;

namespace ConsumedOrders.DataContainers
{
    public class Cheques
    {
        private string customerName;
        private double summ;

        public Cheques(string customerName, double summ)
        {
            this.customerName = customerName;
            this.summ = summ;
        }

        public string CustomerName
        {
            get { return customerName; }
        }

        public double Summ
        {
            get { return summ; }
        }

        public override string ToString()
        {
            return CustomerName + ";" + Summ.ToString();
        }
    }
}
