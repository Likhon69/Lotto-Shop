using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetSubSubCategoryLIstManager : IGetSubSubCategoryManager
    {
        private IUnitOfWork _unitOfWork;
        public GetSubSubCategoryLIstManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<SubSubCategoryVm> GetAllSubSubCategory(int id)
        {
            try
            {
                var result = _unitOfWork.SubSubCategoryList.GetAllSubSubCategory(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
