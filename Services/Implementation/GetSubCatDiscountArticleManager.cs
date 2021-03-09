using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetSubCatDiscountArticleManager : IGetSubCatDiscountArticleManager
    {
        private IUnitOfWork _unitOfWork;
        public GetSubCatDiscountArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DiscountCatArticleVM> GetForSubCatDiscountArticle(long id)
        {
            try
            {
                var res = _unitOfWork.GetDiscountForSubCatArticle.GetForSubCatDiscountArticle(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
