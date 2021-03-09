using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IOrderCustomerPostManager
    {
        string OrderPost(OrderVM order, List<long> artList);
    }
}
