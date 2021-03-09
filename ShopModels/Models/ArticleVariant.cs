using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ArticleVariant
    {
        public long ArtV_Id { get; set; }
        public string ArticleNo { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public string Style { get; set; }
        public int Quantity { get; set; }
        public ArticleDetails ArticleDetails { get; set; }

    }
}
