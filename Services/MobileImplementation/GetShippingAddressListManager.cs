using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetShippingAddressListManager : IGetShippingAddressListManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetShippingAddressListManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<DefaultAddressVM> GetShippingAddressList(long CustId)
        {
            try
            {
                var res = _unitOfWork.GetShippingAdreesList.GetShippingAddressList(CustId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
