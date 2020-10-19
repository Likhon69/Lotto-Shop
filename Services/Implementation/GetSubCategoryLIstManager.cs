using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetSubCategoryLIstManager : IGetSubCategoryLIstManager
    {
        private IUnitOfWork _unitOfWork;
        public GetSubCategoryLIstManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<SubCategoryListVm> GetAllSubCategoryList(int id)
        {
            try
            {
                var result = _unitOfWork.SubCategoryList.GetAllSubCategoryList(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
