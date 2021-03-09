using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class BasketValueDiscount
    {
        public long BasketValueDiscountId { get; set; }
        public long ArticleId { get; set; }
        public int BasketValueDiscountPercentage { get; set; }
        public DateTime DateOfEntry { get; set; }
        public double Amount { get; set; }
        public long EnteredBy { get; set; }
        public long UpdatedBy { get; set; }

        public DiscountTime DiscountTime { get; set; }
    }
}
