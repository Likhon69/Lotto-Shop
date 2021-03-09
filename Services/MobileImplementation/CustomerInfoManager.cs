using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class CustomerInfoManager : ICustomerInfoManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public CustomerInfoManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public long CustomerInfoId(string mobileNo)
        {
			try
			{
                var CustomerId = _unitOfWork.PostRegCustomer.SingleOrDefault(c => c.CustomerMobileNo == mobileNo).CusPIn_Id;
                return CustomerId;
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
