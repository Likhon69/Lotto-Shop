using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IGetBillingAddressListManager
    {
        List<DefaultAddressVM> GetBillingAddressList(long CustId);
    }
}
