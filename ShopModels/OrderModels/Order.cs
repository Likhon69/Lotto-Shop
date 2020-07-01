using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopModels.OrderModels
{
    public class Order
    {
      
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string PMethod { get; set; }
        public Nullable<decimal> GTotal { get; set; }

        [NotMapped]
        public string DeletedOrderItemIDs { get; set; }

        public virtual Customer Customer { get; set; }
       
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
