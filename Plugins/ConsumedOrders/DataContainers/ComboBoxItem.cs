using System;

using System.Collections.Generic;
using System.Text;

namespace ConsumedOrders.DataContainers
{
    public class ComboBoxItem1
    {
        private string key;
        private string value;

        public ComboBoxItem1(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return key;
        }
    }
}
