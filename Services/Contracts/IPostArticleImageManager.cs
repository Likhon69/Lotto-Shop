using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IPostArticleImageManager
    {
        int PostEArticleImage(List<ArticleImageVm> model);
    }
}
