using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class DiscountCatArticleVM
    {
        public string ArticleTitle { get; set; }
        public long ArtD_Id { get; set; }
        public decimal StandardPrice { get; set; }
        public string BrandName { get; set; }
    }
}
