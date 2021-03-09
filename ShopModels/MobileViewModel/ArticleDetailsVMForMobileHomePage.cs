using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class ArticleDetailsVMForMobileHomePage
    {
        public long ArtD_Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public string Description { get; set; }
        public bool IsDiscount { get; set; }
        public decimal StandardPrice { get; set; }
        public string ImageName { get; set; }
        public int DiscountPercentage { get; set; }
        public double Vat { get; set; }
        public bool IsDelivery { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
