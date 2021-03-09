using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetSubSubCatDiscountArticleManager : IGetSubSubCatDiscountArticleManager
    {
        private IUnitOfWork _unitOfWork;
        public GetSubSubCatDiscountArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DiscountCatArticleVM> GetForSubSubCatDiscountArticle(long id)
        {
            try
            {
                var res = _unitOfWork.GetDiscountForSubSubCatArticle.GetForSubSubCatDiscountArticle(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
