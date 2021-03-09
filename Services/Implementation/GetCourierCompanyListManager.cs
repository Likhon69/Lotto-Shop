using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetCourierCompanyListManager : IGetCourierCompanyListManager
    {
        private IUnitOfWork _unitOfWork;
        public GetCourierCompanyListManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CourierDetailsVm> GetCourierCompanyList()
        {
            try
            {
                var result = _unitOfWork.GetCourierCompanyList.GetCourierDetailsList();
                return result;
            }
            catch (Exception ex )
            {

                throw ex;
            }
            
        }
    }
}
