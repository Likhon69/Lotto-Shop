using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Sub_Sub_SubCategory
    {
        public long SubSub_S_Id { get; set; }
        public string description { get; set; }
        public string Name { get; set; }
        public bool status { get; set; }
        public Sub_SubCategory Sub_SubCategory { get; set; }
        public string SubSubSubCatImage { get; set; }
        public Brand Brand { get; set; }

    }
}
