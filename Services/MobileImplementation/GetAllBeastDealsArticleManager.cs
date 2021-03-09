
using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAllBeastDealsArticleManager : IGetAllBeastDealsArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllBeastDealsArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<NewArraivalsVM> GetAllBestDealsArticle()
        {
            var data = _unitOfWork.GetAllBestDealsArticle.GetAllBestDealsArticle();
            return data;
        }
    }
}
