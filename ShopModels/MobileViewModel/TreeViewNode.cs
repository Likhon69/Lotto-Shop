using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class TreeViewNode
    {
        public string parent_id { get; set; }
        public string have_child { get; set; }
        public string book_cat_tree_id { get; set; }
        public string cat_title_en { get; set; }
        public string priority { get; set; }
        public string cat_title_bn { get; set; }
        public string Image { get; set; }
        public string passId { get; set; }
    }
}
