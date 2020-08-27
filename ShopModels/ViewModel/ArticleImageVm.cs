using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class ArticleImageVm
    {
        public int art_Code { get; set; }
        public string articleImage { get; set; }
        public bool isDefault { get; set; }
        public string userId { get; set; }
    }
}
