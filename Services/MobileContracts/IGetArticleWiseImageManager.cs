using ShopModels.MobileViewModel;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IGetArticleWiseImageManager
    {
        List<ArticleImageMobileVM> GetArticleIamge(long id);
    }
}
