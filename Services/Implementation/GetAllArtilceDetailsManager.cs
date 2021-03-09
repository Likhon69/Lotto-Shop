using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetAllArtilceDetailsManager : IGetAllArticleDetailsManager
    {
        private IUnitOfWork _unitOfWork;
        public GetAllArtilceDetailsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<EArticleDetailsVm> GetEArticleDetails()
        {
            var result = _unitOfWork.EGetAllArticle.GetEArticleDetails();

            return result;
        }
    }
}
