using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class RegCustomerPostManager : IRegCustomerPostManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public RegCustomerPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string PostregCustomer(RegCustomerVm model)
        {
			try
			{
                var existCustomer = _unitOfWork.PostRegCustomer.SingleOrDefault(c => c.CustomerMobileNo == model.MobileNo);
                if (existCustomer == null)
                {
                   
                        CustomerInstallationInfo aCustomerIn = new CustomerInstallationInfo();
                        aCustomerIn.CustomerMobileNo = model.MobileNo;
                        aCustomerIn.CustomerName = model.CustomerName;
                        aCustomerIn.InstallationDate = DateTime.Now;
                        _unitOfWork.PostRegCustomer.Add(aCustomerIn);
                        _unitOfWork.Commit();
                       
                }
                else
                {
                    var CustomerId = _unitOfWork.PostRegCustomer.SingleOrDefault(c => c.CustomerMobileNo == model.MobileNo).CusPIn_Id;
                
                    CustomerInstallationInfo aCustomerIn = new CustomerInstallationInfo();
                    aCustomerIn = _unitOfWork.PostRegCustomer.GetById(CustomerId);
                    //aCustomerIn.CusPIn_Id = CustomerId;
                    aCustomerIn.CustomerMobileNo = model.MobileNo;
                    aCustomerIn.CustomerName = model.CustomerName;
                    aCustomerIn.InstallationDate = DateTime.Now;
                    //_unitOfWork.PostRegCustomer.Update(aCustomerIn);
                    _unitOfWork.Commit();
                }

                var res = "success";
                return res;

            }
			catch (Exception ex)
			{

				return ex.Message;
			}
        }
    }
}
