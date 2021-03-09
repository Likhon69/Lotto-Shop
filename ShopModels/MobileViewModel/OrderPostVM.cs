using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class OrderPostVM
    {
        public long CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public double OrderAmount { get; set; }
        public double RecieveAmount { get; set; }
    }
}
