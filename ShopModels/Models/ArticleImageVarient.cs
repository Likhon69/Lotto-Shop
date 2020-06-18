using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ArticleImageVarient
    {
        public int Img_Id { get; set; }
        public string ImageName { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_At { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
