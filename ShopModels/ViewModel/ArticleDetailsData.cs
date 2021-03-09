using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleDetailsData
    {
        public long ArtD_Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSubTitle { get; set; }
        public string Description { get; set; }
        public long CategoryC_Id { get; set; }
        public long SubCategoryS_Id { get; set; }
        public long SubSubCategoryS_Id { get; set; }
        public long SubSubSubCategoryS_Id { get; set; }
        public int Vat_Id { get; set; }
        public bool IsNewAraival { get; set; }
        public long Brand_Id { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal FranchisePrice { get; set; }
        public decimal InstitutePrice { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal DealerPrice { get; set; }
        public decimal OtherPrice { get; set; }
        public int Quantity { get; set; }

    }
}
