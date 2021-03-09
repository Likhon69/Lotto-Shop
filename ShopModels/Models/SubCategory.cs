using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            Sub_SubCategories = new HashSet<Sub_SubCategory>();
        }
        public long S_Id { get; set; }
        public string description { get; set; }
        public string Name { get; set; }
        public bool status { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string SubCatImage { get; set; }
        public virtual ICollection<Sub_SubCategory> Sub_SubCategories { get; set; }
    }
}
