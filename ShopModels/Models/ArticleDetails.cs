using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ArticleDetails
    {
        public int ArtD_Id { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public string ArticleName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Pricing Pricing { get; set; }
        public ArticleMatrix ArticleMatrix { get; set; }
        public Brand Brand { get; set; }
        public virtual ICollection<ArticleImageVarient> ArticleImageVarients { get; set; }
        public virtual ICollection<ArticleVariant> ArticleVariants { get; set; }
    }
}
