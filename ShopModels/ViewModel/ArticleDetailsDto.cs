using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleDetailsDto
    {
        public ArticleDetailsData ArticleDetailsData { get; set; }
        public virtual ICollection<ArticleImageVarient> ArticleImageList { get; set; }
        public virtual ICollection<ArticleVariant> ArticleVariantList { get; set; }
    }
}
