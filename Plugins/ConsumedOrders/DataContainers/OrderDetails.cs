using System;

using System.Collections.Generic;
using System.Text;

namespace ConsumedOrders.DataContainers
{
    [Serializable]
    public class OrderDetails
    {
        // Fields in database
        private string odOrderId = "";
        private int odProductId;
        private int odProductCount;
        private double odProductPrice;
        private int odIsPersonalPrice;
        private int odRest;
        private double odShopPrice;
        private int odFacing;
        // Fields in database

        [NonSerialized]
        private int odFakeId;

        public OrderDetails()
        {

        }

        public OrderDetails(int odFakeId, string odOrderId, int odProductId, int odProductCount, double odProductPrice,
                            int odIsPersonalPrice, int odRest, double odShopPrice, int odFacing)
        {
            this.odFakeId = odFakeId;
            this.odOrderId = odOrderId;
            this.odProductId = odProductId;
            this.odProductCount = odProductCount;
            this.odProductPrice = odProductPrice;
            this.odIsPersonalPrice = odIsPersonalPrice;
            this.odRest = odRest;
            this.odShopPrice = odShopPrice;
            this.odFacing = odFacing;
        }

        #region properties

        public int OdFakeId
        {
            get { return odFakeId; }
        }

        public string OdOrderId
        {
            get { return odOrderId; }
            set { odOrderId = value; }
        }

        public int OdProductId
        {
            get { return odProductId; }
            set { odProductId = value; }
        }

        public int OdProductCount
        {
            get { return odProductCount; }
            set { odProductCount = value; }
        }

        public double OdProductPrice
        {
            get { return odProductPrice; }
            set { odProductPrice = value; }
        }

        public int OdIsPersonalPrice
        {
            get { return odIsPersonalPrice; }
            set { odIsPersonalPrice = value; }
        }

        public int OdRest
        {
            get { return odRest; }
            set { odRest = value; }
        }

        public double OdShopPrice
        {
            get { return odShopPrice; }
            set { odShopPrice = value; }
        }

        public int OdFacing
        {
            get { return odFacing; }
            set { odFacing = value; }
        }

        #endregion
    }
}
