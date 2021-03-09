using Repository.Base;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ICourierMasterPostRepository
    {
        int PostCourierMaster(CourierDetailsVm model1, ContactPersonVm model2);

    }
}
