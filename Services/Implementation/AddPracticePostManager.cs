using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class AddPracticePostManager : IAddPracticePostManager
    {
        private IUnitOfWork _unitOfWork;
        public AddPracticePostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
       

        public int PracticePost(EmployeeVm employeeVm)
        {
            try
            {
                var result = _unitOfWork.Practice.PostPracticeMaster(employeeVm);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

              
            

          
        }
    }
}
