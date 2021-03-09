using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class DiscountDetail
    {
        public long DiscountDetailId { get; set; }
       
        public long ArticleId { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string EnteredBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal DiscountPrice { get; set; }
        public DiscountTime DiscountTime { get; set; }
    }
}
