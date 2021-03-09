using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class CategorizedGetArticleVM
    {
        public long ArtD_Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public string Description { get; set; }
        public bool IsDiscount { get; set; }
        public decimal StandardPrice { get; set; }
        public string ImageName { get; set; }
        public long ArticleDetailsArtD_Id { get; set; }
        public long CategoryC_Id { get; set; }
        public long SubCategoryS_Id { get; set; }
        public long SubSubCategoryS_Id { get; set; }
        public long SubSubSubCategoryS_Id { get; set; }
    }
}
