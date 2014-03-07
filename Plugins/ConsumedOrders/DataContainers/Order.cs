using System;

using System.Collections.Generic;
using System.Text;

namespace ConsumedOrders.DataContainers
{
    public delegate void OrderPositionHandler(int productId);
    [Serializable]
    public class Order
    {
        // Fields in Database
        private string id;
        private DateTime oDate;
        private int oShopId;
        private string oComment;
        private int oCreatorId;
        private int oIsOfficial;
        private int oStoreId;
        private string oStart;
        private string oEnd;
        private int oType;
        private DateTime oCreateDate;
        // Fields in Database
        private double oDebit;
        private int oSkuBeer;
        private int oSkuBan;
        private int oSkuSan;
        private int oSkuMw;

        private bool onlyAdditionalInfoInput = false;
        
        [NonSerialized]
        private int odFakeId;

        private List<OrderDetails> orderPositions = new List<OrderDetails>();

        /// <summary>
        /// Fired only if ProductCount > 0
        /// </summary>
        public event OrderPositionHandler OrderPositionAdd;

        /// <summary>
        /// Fired only if ProductCount > 0
        /// </summary>
        public event OrderPositionHandler OrderPositionDelete;

        public Order()
        {

        }

        public Order(string id, int oShopId, int oCreatorId) : this(id, DateTime.Now, oShopId, string.Empty, oCreatorId, 0, 0, 
            DateTime.Now.ToString("HH:mm:ss"), "", DateTime.Now, 0)
        {
            
        }

        public Order(string id, DateTime oDate, int oShopId, string oComment, int oCreatorId, 
            int oIsOfficial, int oStoreId, string oStart, string oEnd, DateTime oCreateDate, double oDebit)
        {
            this.id = id;
            this.oDate = oDate;
            this.oShopId = oShopId;
            this.oComment = oComment;
            this.oCreatorId = oCreatorId;
            this.oIsOfficial = oIsOfficial;
            this.oStoreId = oStoreId;
            this.oStart = oStart;
            this.oEnd = oEnd;
            this.oCreateDate = oCreateDate;
            this.oDebit = oDebit;
            //this.oItemsCount = 0;
            this.odFakeId = 1;
        }

        public void AddPosition(int odProductId, int odProductCount, double odProductPrice,
                            int odIsPersonalPersonal, int odRest, double odShopPrice, int odFacing)
        {
            OrderDetails exOrderDetail = null;
            foreach (OrderDetails orderdetails in orderPositions)
            {
                if (orderdetails.OdProductId == odProductId)
                {
                    exOrderDetail = orderdetails;
                }
            }

            if (exOrderDetail != null) // position allready exist in Order
            {
                exOrderDetail.OdProductCount += odProductCount;
                exOrderDetail.OdRest = odRest;
                exOrderDetail.OdShopPrice = odShopPrice;
                exOrderDetail.OdFacing = odFacing;
            }
            else
            {
                OrderDetails ord = new OrderDetails(odFakeId, id, odProductId, odProductCount, odProductPrice, odIsPersonalPersonal, odRest, odShopPrice, odFacing);
                orderPositions.Add(ord);
                if (odProductCount > 0)
                    if (OrderPositionAdd != null)
                        OrderPositionAdd(odProductId);
                odFakeId++;
            }
        }

        public double getOrderSum()
        {
            double sum = 0.0;
            foreach (OrderDetails ord in orderPositions)
            {
                sum += ord.OdProductPrice * ord.OdProductCount;
            }
            return sum;
        }

        public void Clear()
        {
            orderPositions.Clear();
            id = "";
            oDate = new DateTime(2000, 1, 1);
            oShopId = 0;
            oComment = "";
            oCreatorId = 0;
            oIsOfficial = 0;
            oStoreId = 0;
            odFakeId = 0;
        }

        public OrderDetails getOrderDetailsByFakeId(int fakeId)
        {
            foreach (OrderDetails ord in Positions)
            {
                if (ord.OdFakeId == fakeId)
                {
                    return ord;
                }
            }
            return null;
        }

        public void deletePosition(int fakeId)
        {
            foreach (OrderDetails ord in Positions)
            {
                if (ord.OdFakeId == fakeId)
                {
                    Positions.Remove(ord);
                    if (ord.OdProductCount > 0)
                        if (OrderPositionDelete != null)
                            OrderPositionDelete(ord.OdProductId);
                    break;
                }
            }
        }

        #region Properties
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime ODate
        {
            get { return oDate; }
            set { oDate = value; }
        }

        public int OShopId
        {
            get { return oShopId; }
            set { oShopId = value; }
        }

        public string OComment
        {
            get { return oComment; }
            set { oComment = value; }
        }

        public int OCreatorId
        {
            get { return oCreatorId; }
            set { oCreatorId = value; }
        }

        public int OIsOfficial
        {
            get { return oIsOfficial; }
            set { oIsOfficial = value; }
        }

        public int OStoreId
        {
            get { return oStoreId; }
            set { oStoreId = value; }
        }

        public string OStart
        {
            get { return oStart; }
            set { oStart = value; }
        }

        public string OEnd
        {
            get { return oEnd; }
            set { oEnd = value; }
        }

        public int OType
        {
            get { return oType; }
            set { oType = value; }
        }

        public DateTime OCreateDate
        {
            get { return oCreateDate; }
            set { oCreateDate = value; }
        }

        public double ODebit
        {
            get { return oDebit; }
            set { oDebit = value; }
        }

        public int OSkuBeer
        {
            get { return oSkuBeer; }
            set { oSkuBeer = value; }
        }

        public int OSkuBan
        {
            get { return oSkuBan; }
            set { oSkuBan = value; }
        }

        public int OSkuSan
        {
            get { return oSkuSan; }
            set { oSkuSan = value; }
        }

        public int OSkuMw
        {
            get { return oSkuMw; }
            set { oSkuMw = value; }
        }

        public List<OrderDetails> Positions
        {
            get { return orderPositions; }
            //set
            //{
            //    orderPositions = value;
            //}
        }

        public int OItemsCount
        {
            get { return orderPositions.Count; }
        }

        public bool OnlyAdditionalInfoInput
        {
            get { return onlyAdditionalInfoInput; }
            set { onlyAdditionalInfoInput = value; }
        }

        #endregion
    }
}
