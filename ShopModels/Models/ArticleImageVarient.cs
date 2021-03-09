using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ArticleImageVarient
    {
        public long Img_Id { get; set; }
        public string ImageName { get; set; }
        public ArticleDetails ArticleDetails { get; set; }
        public bool IsMaster { get; set; }

    }
}
