﻿using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IPostCustomerAddressManager
    {
        string PostDeliveryAddress(DeliveryAddressVM address);
    }
}
