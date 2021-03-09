using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAllArticleDetailsForMobileHomePageManager : IGetAllArticleDetailsForMobileHomePageManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllArticleDetailsForMobileHomePageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ArticleDetailsVMForMobileHomePage> GetAllArticleForMobile()
        {
            var data = _unitOfWork.GetAllArticleDetailsDataForMobile.GetAllArticleDetailsForMobile();
            return data;
        }
    }
}
