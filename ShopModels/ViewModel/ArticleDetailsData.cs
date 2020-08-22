using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleDetailsData
    {
        public int ArtD_Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubTitle { get; set; }
        public string ArticleMasterImage { get; set; }
        public string Description { get; set; }

        public Decimal StandardPrice { get; set; }
      

        public int DiscontPrice { get; set; }
        public Decimal DiscountRate { get; set; }
        public int Quantity { get; set; }

    }
}
