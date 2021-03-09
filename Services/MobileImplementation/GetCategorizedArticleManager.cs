using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetCategorizedArticleManager : IGetCategorizedArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetCategorizedArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<CategorizedGetArticleVM> GetCategorizedArticle(long id)
        {
            var data = _unitOfWork.GetCategorizedArticle.GetCategorizedArticle(id);
            return data;
        }
    }
}
