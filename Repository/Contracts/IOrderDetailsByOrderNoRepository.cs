using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IOrderDetailsByOrderNoRepository
    {
        List<OrderDetailsByOrderNoVm> GetOrderDetailsByOrderNo(string orderNo);
    }
}
