using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Sub_SubCategory
    {
        public Sub_SubCategory()
        {
            Sub_Sub_SubCategories = new HashSet<Sub_Sub_SubCategory>();
        }
        public long Sub_S_Id { get; set; }
        public string description { get; set; }
        public string Name { get; set; }
        public bool status { get; set; }
        public SubCategory SubCategory { get; set; }
        public Brand Brand { get; set; }
        public string SubSubCatImage { get; set; }
        public virtual ICollection<Sub_Sub_SubCategory> Sub_Sub_SubCategories { get; set; }
    }
}
