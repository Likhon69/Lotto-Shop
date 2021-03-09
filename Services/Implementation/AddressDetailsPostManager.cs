using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class AddressDetailsPostManager : IAddressDetailsPostManager
    {
        private IUnitOfWork _unitOfWork;
        public AddressDetailsPostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int PostAddressDetails(AddressDetailsVm model)
        {

            try
            {
                var res = _unitOfWork.PostAddress.PostAddressDetails(model);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
