using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleDetailsInsert
    {
        public int ArtD_Id { get; set; }
        public int CategoryC_Id { get; set; }
        public int SubCategoryS_Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }

        public string Description { get; set; }

        
        public int Brand_Id { get; set; }
        public int Vat_Id { get; set; }
    }
}
