using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class OrderArticleVM
    {
        public string ArticleNo { get; set; }
        public int Quantity { get; set; }
        public long CustomerId { get; set; }
     
    }
}
