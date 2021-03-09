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
        public long ArtD_Id { get; set; }
   
        public string ArticleTitle { get; set; }
        public string ArticleSubtitle { get; set; }
        public long CategoryC_Id { get; set; }
        public long SubCategoryS_Id { get; set; }
        public string Description { get; set; }
        public int Brand_Id { get; set; }
        public int Vat_Id { get; set; }
        public bool IsDiscount { get; set; }
        public long SubSubCategoryS_Id { get; set; }
        public long SubSubSubCategoryS_Id { get; set; }
        public DateTime DateOfEntry { get; set; }
        public long EnteredBy { get; set; }
        public long UpdatedBy { get; set; }
        public bool IsNewAraival { get; set; }
        public long BannerId { get; set; }
        public bool IsDelivery { get; set; }
        public string ArticleCode { get; set; }
        public virtual ICollection<ArticleImageVarient> ArticleImageVarients { get; set; }
        public virtual ICollection<ArticleVariant> ArticleVariants { get; set; }
    }
}
