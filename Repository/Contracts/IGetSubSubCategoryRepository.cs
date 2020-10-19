using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
   public interface IGetSubSubCategoryRepository
    {
        List<SubSubCategoryVm> GetAllSubSubCategory( int id);
    }
}
