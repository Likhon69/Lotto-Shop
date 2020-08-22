using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class GetProcedure : IGetProcedure
    {
        private IUnitOfWork _unitOfWork;
        public GetProcedure(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ArticleDetailsData> articleDetailsManager()
        {
            return _unitOfWork.GetProcedure.articleDetails();
        }
    }
}
