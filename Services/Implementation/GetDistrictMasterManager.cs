using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetDistrictMasterManager : IGetDistrictMasterManager
    {
        private IUnitOfWork _unitOfWork;
        public GetDistrictMasterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DistrictMasterVm> GetDistrictMaster()
        {
            try
            {
                var result = _unitOfWork.GetAllDistrictMaster.GetAllDistrictMaster();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
