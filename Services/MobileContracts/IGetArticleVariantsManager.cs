using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IGetArticleVariantsManager
    {
        List<ArticleVariantDto> GetArticlevariant(long id);
    }
}
