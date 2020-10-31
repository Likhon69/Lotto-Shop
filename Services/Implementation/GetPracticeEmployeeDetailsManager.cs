using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
  public class GetPracticeEmployeeDetailsManager : IGetPracticeEmployeeDetailsManager
    {
        private IUnitOfWork _unitOfWork;
        public GetPracticeEmployeeDetailsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<PracticeEmployeeVm> GetEmployeePracticeDetails(int id)
        {
            try
            {
                var res = _unitOfWork.PracticeEmployeeDetailsList.GetEmployeePracticeDetails(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
