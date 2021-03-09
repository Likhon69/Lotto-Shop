using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class DiscountDetailsVM
    {
        public ICollection<DiscountCatArticleVM> DiscountArticle { get; set; }
        public DiscountSettingsVM DiscountDetails { get; set; }

    }
}
