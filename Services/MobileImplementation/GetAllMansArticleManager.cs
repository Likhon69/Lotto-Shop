using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAllMansArticleManager : IGetAllMansArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllMansArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<NewArraivalsVM> GetAllMansArticle()
        {
            var data = _unitOfWork.GetAllMansArticle.GetAllMansArticle();
            return data;
        }
    }
}
