using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IAddressDetailsPostRepository
    {
        int PostAddressDetails(AddressDetailsVm model);
    }
}
