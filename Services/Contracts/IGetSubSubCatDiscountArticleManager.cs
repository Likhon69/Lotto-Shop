using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IGetSubSubCatDiscountArticleManager
    {
        List<DiscountCatArticleVM> GetForSubSubCatDiscountArticle(long id);
    }
}
