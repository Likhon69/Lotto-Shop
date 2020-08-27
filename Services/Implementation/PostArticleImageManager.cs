using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class PostArticleImageManager : IPostArticleImageManager
    {
        private IUnitOfWork _unitOfWork;

        public PostArticleImageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int PostEArticleImage(List<ArticleImageVm> model)
        {

            var result = 0;
             if (model != null)
                {
                    foreach (var item in model)
                    {
                         result = _unitOfWork.PostEArticleImage.PostEArticleImage(item);
                      
                    }
                }

            return result;


        }
    }
}
