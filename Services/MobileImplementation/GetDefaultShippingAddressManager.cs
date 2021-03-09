using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetDefaultShippingAddressManager : IGetDefaultShippingAddressManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetDefaultShippingAddressManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<DefaultAddressVM> GetDefaultShippingAddress(long CustId)
        {
            try
            {
                var res = _unitOfWork.GetDefaultShippingAddress.GetDefaultShippingAddress(CustId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
