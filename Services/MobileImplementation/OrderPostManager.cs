using AutoMapper;
using CommonUnitOfWork;
using ECommerceDbContext;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class OrderPostManager : IOrderPostManager
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public string OrderFinalPost(List<OrderArticleVM> articleList,int cnt, long ShipingId, long BillingId, double TotalAmount)
        {
            try
            {
                var id = articleList[0].CustomerId;
                Guid orderHeaderCId = _unitOfWork.OrderPost.SingleOrDefault(c => c.CustomerId == id && c.Approved == "N").OrderHeaderId;
                if (articleList.Count == cnt)
                {
                    
                    OrderHeader aOrderHeader = new OrderHeader();
                    aOrderHeader = _unitOfWork.OrderPost.GetByOrderId(orderHeaderCId);
                    aOrderHeader.Approved = "P";
                    aOrderHeader.FullySattelled = "P";
                    aOrderHeader.BillingId = ShipingId;
                    aOrderHeader.ShippingId = BillingId;
                    //aOrderHeader.Sattelled = RecieveAmount;
                    aOrderHeader.ApprovedDate = DateTime.Now;
                    aOrderHeader.TotalAmount = TotalAmount;
                    
                    _unitOfWork.Commit();
                }
                else
                {
                  
                    OrderHeader aOrderHeader = new OrderHeader();
                    aOrderHeader = _unitOfWork.OrderPost.GetByOrderId(orderHeaderCId);
                    aOrderHeader.PartialApproved = "Y";
                    aOrderHeader.FullySattelled = "P";
                    aOrderHeader.BillingId = ShipingId;
                    aOrderHeader.ShippingId = BillingId;
                    /*aOrderHeader.Sattelled = articleList[0].RecieveAmount;
                    aOrderHeader.PartialApprovedDate = DateTime.Now;
                    aOrderHeader.OrderAmount = articleList[0].OrderAmount;
                    aOrderHeader.TotalAmount = articleList[0].TotalAmount;
                    aOrderHeader.RecieveAmount = articleList[0].RecieveAmount;*/
                    _unitOfWork.Commit();
                }
                foreach(var orderInfo in articleList)
                {
                    OrderDetail aOrderDetail = new OrderDetail();
                    aOrderDetail = _unitOfWork.OrderDetailsPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderCId && c.ArticleNo == orderInfo.ArticleNo);
                    aOrderDetail.Approved = "Y";
                    aOrderDetail.ApprovedDate = DateTime.Now;
                    aOrderDetail.SalesQty = orderInfo.Quantity;
                    _unitOfWork.Commit();
                   
                }
                return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
