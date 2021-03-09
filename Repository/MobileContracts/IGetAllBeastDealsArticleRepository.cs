using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileContracts
{
    public interface IGetAllBeastDealsArticleRepository
    {
        List<NewArraivalsVM> GetAllBestDealsArticle();
    }
}
