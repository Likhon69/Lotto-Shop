using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class SoldArticle
    {
        public long SArt_Id { get; set; }
        public string ArticleName { get; set; }
        public string ArticleNo { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
    }
}
