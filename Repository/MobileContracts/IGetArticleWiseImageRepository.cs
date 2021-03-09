using ShopModels.MobileViewModel;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileContracts
{
    public interface IGetArticleWiseImageRepository
    {
        List<ArticleImageMobileVM> GetArticleIamge(long id);
    }
}
