using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
  public  interface IGetPracticeEmployeeDetailsRepository
    {
        List<PracticeEmployeeVm> GetEmployeePracticeDetails(int id);
    }
}
