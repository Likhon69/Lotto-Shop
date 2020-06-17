using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        
        public Decimal ProductPrice { get; set; }

        public string ProductImage { get; set; }

        public Decimal DiscountPrice { get; set; }
    }
}
