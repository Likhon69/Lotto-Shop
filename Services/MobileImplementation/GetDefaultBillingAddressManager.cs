using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetDefaultBillingAddressManager : IGetDefaultBillingAddressManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetDefaultBillingAddressManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<DefaultAddressVM> GetDefaultBillingAddress(long CustId)
        {
            try
            {
                var res = _unitOfWork.GetDefaultBillingAddress.GetDefaultBillingAddress(CustId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
