using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetCategoryListManager : IGetCategoryListManager
    {
        private IUnitOfWork _unitOfWork;
        public GetCategoryListManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<CategoryListVM> GetAllCategoryList()
        {
           
                try
            {
                var res = _unitOfWork.CategoryList.GetAllCategoryList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
