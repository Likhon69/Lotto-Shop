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
        public int CourierMasterPost(CourierMasterVm model)
        {
            var courierMasterData = model.CourierDetails;

            int result = 0;
            try
            {
                foreach(var courierMaster in model.ContactPersonList)
                {
                  var res  = _unitOfWork.PostCourierMaster.PostCourierMaster(model.CourierDetails, courierMaster);
                    result = res;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
