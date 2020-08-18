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

            ArticleImageVarient articleImage = new ArticleImageVarient();
            ArticleVariant articleVariant = new ArticleVariant();
        }
        public int ArtD_Id { get; set; }
   
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public int CategoryC_Id { get; set; }
        public int SubCategoryS_Id { get; set; }
        public string Description { get; set; }
        public int Brand_Id { get; set; }
        public int Vat_Id { get; set; }
        public string ArticleMasterImage { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<ArticleImageVarient> ArticleImageVarients { get; set; }
        public virtual ICollection<ArticleVariant> ArticleVariants { get; set; }
    }
}
