using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IGetSubCatDiscountArticleManager
    {
        List<DiscountCatArticleVM> GetForSubCatDiscountArticle(long id);
    }
}
