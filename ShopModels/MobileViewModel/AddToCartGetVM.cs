using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class AddToCartGetVM
    {
        public long CustomerId { get; set; }
        public long ArticleId { get; set; }
        public double Discount { get; set; }
        public double VatRate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public bool IsDelivery { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string ImageName { get; set; }
    }
}
