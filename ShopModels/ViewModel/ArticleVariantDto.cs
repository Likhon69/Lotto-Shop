using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleVariantDto
    {
        public long ArtD_Id { get; set; }
        public string ArticleNo { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
       
    }
}
