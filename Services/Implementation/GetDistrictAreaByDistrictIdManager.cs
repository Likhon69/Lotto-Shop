using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetDistrictAreaByDistrictIdManager : IGetDistrictAreaByDistrictIdManager
    {
        private IUnitOfWork _unitOfWork;
        public GetDistrictAreaByDistrictIdManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DistrictAreaVm> GetDistrictAreaById(int id)
        {
            try
            {
                var result = _unitOfWork.GetDistrictArea.GetDistrictAreaByDistrictId(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
