using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.OrderModels
{
    public class Customer
    {

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }

       
        public virtual ICollection<Order> Orders { get; set; }
    }
}
