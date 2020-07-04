using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleDetailsData
    {
        public string ArticleTitle { get; set; }
        public string ArticleSubTitle { get; set; }
        public int CategoryC_Id { get; set; }
        public int SubCategoryS_Id { get; set; }
        public string Description { get; set; }

        public Decimal StandardPrice { get; set; }
        public Decimal FranchisePrice { get; set; }
        public Decimal InstitutePrice { get; set; }
        public Decimal PurchaseCost { get; set; }
        public Decimal WholeSalePrice { get; set; }
        public Decimal DealerPrice { get; set; }
        public Decimal OtherPrice { get; set; }

        public int DiscontPrice { get; set; }
        public Decimal DiscountRate { get; set; }

        public int Brand_Id { get; set; }
        public int Vat_Id { get; set; }
    }
}
