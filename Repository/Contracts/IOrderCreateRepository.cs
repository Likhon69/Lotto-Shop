using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IOrderCreateRepository
    {
        int PostOrderCreate(string combindedString, OrderCreateInfVm order);
    }
}
