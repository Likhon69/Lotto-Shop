using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Category
    {
        public Category()
        {
            subCategories = new HashSet<SubCategory>();
        }
        public long C_Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public string CatImage { get; set; }
        public virtual ICollection<SubCategory> subCategories { get; set; }
    }
}
