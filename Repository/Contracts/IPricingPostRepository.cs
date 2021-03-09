using Repository.Base;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IPricingPostRepository : IBaseShopRepository<Pricing>
    {

        List<ArticleDetailsData> articleDetails();
    }
}
