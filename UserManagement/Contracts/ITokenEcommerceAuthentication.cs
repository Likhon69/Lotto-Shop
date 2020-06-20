using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Contracts
{
    public interface ITokenEcommerceAuthentication
    {
        string Authentication(UserDto model);
    }
}
