using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetArticleCatDiscountManager : IGetArticleCatDiscountManager
    {
        private IUnitOfWork _unitOfWork;
        public GetArticleCatDiscountManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DiscountCatArticleVM> GetForCatDiscountArticle(long id)
        {
            try
            {
                var res = _unitOfWork.GetDiscountForCatArticle.GetForCatDiscountArticle(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
