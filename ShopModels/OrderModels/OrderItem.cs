using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.OrderModels
{
    public class OrderItem
    {
        public long OrderItemID { get; set; }
        public Nullable<long> OrderID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
