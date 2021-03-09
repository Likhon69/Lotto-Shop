using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAllWomensArticleManager : IGetAllWomensArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllWomensArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<NewArraivalsVM> GetAllWomensArticle()
        {
            var data = _unitOfWork.GetAllWomemnsArticle.GetAllWomensArticle();
            return data;
        }
    }
}
