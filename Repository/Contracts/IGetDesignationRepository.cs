using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
   public interface IGetDesignationRepository
    {
        List<DesignationListVm> GetAllDesignationList();
    }
}
