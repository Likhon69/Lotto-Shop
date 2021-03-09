using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetSubSubSCatDiscountArticleManager : IGetSubSubSCatDiscountArticleManager
    {
        private IUnitOfWork _unitOfWork;
        public GetSubSubSCatDiscountArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DiscountCatArticleVM> GetForSubSubSCatDiscountArticle(long id)
        {
            try
            {
                var res = _unitOfWork.GetDiscountForSubSubSCatArticle.GetForSubSubSCatDiscountArticle(id);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
