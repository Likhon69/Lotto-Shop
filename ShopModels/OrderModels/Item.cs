using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.OrderModels
{
    public class Item
    {
       
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int ItemID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }

       
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
