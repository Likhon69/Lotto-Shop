using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class RemoveAddToCartItemManager : IRemoveAddToCartItemManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public RemoveAddToCartItemManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string RemoveAddToCartItem(RemoveAddToCartVM removeVm)
        {
            try
            {
                Guid OrderHeaderId = _unitOfWork.OrderPost.SingleOrDefault(c => c.CustomerId == removeVm.CustomerId && c.Approved=="N").OrderHeaderId;
                Guid OrderDetailId = _unitOfWork.OrderDetailsPost.SingleOrDefault(c => c.OrderHeaderId == OrderHeaderId && c.ArticleId == removeVm.ArticleId).OrderDetailId;
                _unitOfWork.OrderDetailsPost.RemoveOrder(OrderDetailId);
                _unitOfWork.Commit();
                return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
