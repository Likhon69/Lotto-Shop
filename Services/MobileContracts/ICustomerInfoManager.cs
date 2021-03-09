using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface ICustomerInfoManager
    {
        long CustomerInfoId(string mobileNo);
    }
}
