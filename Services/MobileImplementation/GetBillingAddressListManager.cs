using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetBillingAddressListManager : IGetBillingAddressListManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetBillingAddressListManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<DefaultAddressVM> GetBillingAddressList(long CustId)
        {
            try
            {
                var res = _unitOfWork.GetBillingAdreesList.GetBillingAddressList(CustId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
