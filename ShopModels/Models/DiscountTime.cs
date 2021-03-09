using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class DiscountTime
    {
        public DiscountTime()
        {
            DiscountDetails = new HashSet<DiscountDetail>();
            BasketValueDiscounts = new HashSet<BasketValueDiscount>();
        }
        public long DiscountTimeId { get; set; }
        public DateTime DiscountFromDate { get; set; }
        public DateTime DiscountTimeTo { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string EnteredBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<DiscountDetail> DiscountDetails { get; set; }
        public virtual ICollection<BasketValueDiscount> BasketValueDiscounts { get; set; }
    }
}
