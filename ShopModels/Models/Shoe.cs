using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopModels.Models

{
    public class Shoe
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public Decimal ProductPrice { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public Decimal DiscountPrice { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
