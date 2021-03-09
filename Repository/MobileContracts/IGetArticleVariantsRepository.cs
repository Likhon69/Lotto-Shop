using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileContracts
{
    public interface IGetArticleVariantsRepository
    {
        List<ArticleVariantDto> GetArticlevariant(long id);
    }
}
