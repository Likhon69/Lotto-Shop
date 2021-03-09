using AutoMapper;
using CommonUnitOfWork;
using Repository.MobileContracts;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetArticleWiseImageManager : IGetArticleWiseImageManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetArticleWiseImageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ArticleImageMobileVM> GetArticleIamge(long id)
        {
            var data = _unitOfWork.GetArticleImage.GetArticleIamge(id);
            return data;
        }
    }
}
