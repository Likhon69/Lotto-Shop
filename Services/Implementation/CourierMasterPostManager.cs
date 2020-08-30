using AutoMapper;
using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{

    public class CourierMasterPostManager : ICourierMasterPostManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public CourierMasterPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public bool CourierMasterPost(CourierMasterVm model)
        {
            var courierMasterData = model.CourierDetails;
            var dataCourier = _mapper.Map<CourierCompanyMaster>(courierMasterData);
            string res = " ";
            try
            {
                if (dataCourier.company_Id == 0)
                {
                    _unitOfWork.PostCourierMaster.Add(dataCourier);

                    foreach(var person in model.ContactPersonList)
                    {
                        var personData = _mapper.Map<CourierContactPerson>(person);
                        dataCourier.CourierContactPersons.Add(personData);
                    }
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
