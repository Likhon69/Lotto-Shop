using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class GetAddToCartArticleManager : IGetAddToCartArticleManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAddToCartArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<AddToCartGetVM> GetAddToCartArticle(long CustId)
        {
            try
            {
                var data = _unitOfWork.GetAddToCartArticle.GetAddToCartArticle(CustId);
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
