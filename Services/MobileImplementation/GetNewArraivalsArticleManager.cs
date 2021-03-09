using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetNewArraivalsArticleManager : IGetNewArraivalsArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetNewArraivalsArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<NewArraivalsVM> GetAllNewArraivalsArticle()
        {
            var data = _unitOfWork.GetAllNewArraivalArticle.GetAllNewArraivalsArticle();
            return data;
        }
    }
}
