using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class OrderVM
    {
        public long ArticleId { get; set; }
        public int Quantity { get; set; }
        public long CustomerId { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public string ArticleNo { get; set; }
        
    }
}
