using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IOrderPickerManager
    {
        List<OrderPickerVm> GetOrderPickerByOrderNo(string orderNo);
    }
}
