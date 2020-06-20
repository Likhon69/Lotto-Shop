﻿using System;
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
        public string VatRate { get; set; }
        public Decimal DiscontPrice { get; set; }
        public string DiscountRate { get; set; }
        public int ArticleDetails_Id { get; set; }
        public ArticleDetails ArticleDetails { get; set; }
    }
}
