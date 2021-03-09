using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Pricing
    {
       
        public int Pricing_Id { get; set; }
        public Decimal StandardPrice { get; set; }
        public Decimal FranchisePrice { get; set; }
        public Decimal InstitutePrice { get; set; }
        public Decimal PurchaseCost { get; set; }
        public Decimal WholeSalePrice { get; set; }
        public Decimal DealerPrice { get; set; }
        public Decimal OtherPrice { get; set; }
        public long ArticleDetails_Id { get; set; }

    }
}
