using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetPracticeManager : IGetPracticeManager
    {
        private IUnitOfWork _unitOfWork;
        public GetPracticeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<EmployeeVm> GetEmployeeDetails()
        {
            try
            {
                var res = _unitOfWork.PracticeList.GetEmployeeDetails();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
