using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IOrderPostManager
    {
        string OrderFinalPost(List<OrderArticleVM> articleList, int cnt, long ShipingId, long BillingId, double RecieveAmount);
    }
}
