using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IOrderHeaderDetailsManager
    {
        List<OrderHeaderVm> GetOrderHeaderDetails();
    }
}
