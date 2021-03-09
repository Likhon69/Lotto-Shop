using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class DiscountType
    {
        public long DiscountTypeId { get; set; }
        public string DiscountName { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime Date { get; set; }
    }
}
