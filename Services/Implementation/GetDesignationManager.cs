using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetDesignationManager : IGetDesignationManager
    {
        private IUnitOfWork _unitOfWork;
        public GetDesignationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<DesignationListVm> GetAllDesignationList()
        {
            try
            {
                var res = _unitOfWork.DesignationLIst.GetAllDesignationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
