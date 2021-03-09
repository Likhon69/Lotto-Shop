using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAllKidsArticleManager : IGetAllKidsArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllKidsArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<NewArraivalsVM> GetAllKidsArticle()
        {
            var data = _unitOfWork.GetAllKidsArticle.GetAllKidsArticle();
            return data;
        }
    }
}
