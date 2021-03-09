using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetArticleVariantsManager : IGetArticleVariantsManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetArticleVariantsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ArticleVariantDto> GetArticlevariant(long id)
        {
            var data = _unitOfWork.GetArticleVariant.GetArticlevariant(id);
            return data;
        }
    }
}
