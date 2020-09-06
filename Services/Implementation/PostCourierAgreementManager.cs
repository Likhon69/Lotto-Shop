using AutoMapper;
using CommonUnitOfWork;
using ECommerceDbContext.ECOMDBENTITIES;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class PostCourierAgreementManager : IPostCourierAgreementManager
    {

        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public PostCourierAgreementManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public int PostCourierAgreement(CourierAgreementVm model)
        {
            var agreementData = new CourierAgreementMaster();
            agreementData.DistAreaId = model.area;
            agreementData.CourierId = model.company;
            agreementData.Amount = model.Amount;
          
            string res = "";
            try
            {
                _unitOfWork.CourierAgreement.Add(agreementData);
                var result = _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                throw ex;
            }
        }
    }
}
