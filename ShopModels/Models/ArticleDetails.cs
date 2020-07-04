using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ArticleDetails
    {
        public ArticleDetails()
        {
            
            ArticleImageVarients = new HashSet<ArticleImageVarient>();
            ArticleVariants = new HashSet<ArticleVariant>();
        }
        public int ArtD_Id { get; set; }
   
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public int CategoryC_Id { get; set; }
        public int SubCategoryS_Id { get; set; }
        public string Description { get; set; }
        public int Brand_Id { get; set; }
        public int Vat_Id { get; set; }
        public virtual ICollection<ArticleImageVarient> ArticleImageVarients { get; set; }
        public virtual ICollection<ArticleVariant> ArticleVariants { get; set; }
    }
}
