using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Brand
    {
        public Brand()
        {
            SubCategories = new HashSet<SubCategory>();
        }
        public long Brand_Id { get; set; }
        public string BrandName { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Sub_SubCategory> Sub_SubCategories { get; set; }
    }
}
