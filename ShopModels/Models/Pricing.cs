using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Pricing
    {
        public int ArtD_Id { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public string ArticleName { get; set; }
        public string Brand { get; set; }
        public ArticleMatrix ArticleMatrix { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

    }
}
