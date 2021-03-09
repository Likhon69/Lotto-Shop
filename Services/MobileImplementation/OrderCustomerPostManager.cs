using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class OrderCustomerPostManager : IOrderCustomerPostManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public OrderCustomerPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string OrderPost(OrderVM order, List<long> artList)
        {
            try
            {
                var id = order.CustomerId;
           
                var orderHeaderInfoN = _unitOfWork.OrderPost.SingleOrDefault(c=>c.CustomerId==id && c.Approved=="N");
                var orderHeaderInfoP = _unitOfWork.OrderPost.SingleOrDefault(c => c.CustomerId == id && c.PartialApproved == "Y");
                if (orderHeaderInfoN == null || orderHeaderInfoP!=null)
                {
                    var dataOrder = _mapper.Map<OrderDetail>(order);
                    Guid orderHeaderId = Guid.NewGuid();
                    OrderHeader aOrderHeader = new OrderHeader();
                    aOrderHeader.OrderHeaderId = orderHeaderId;
                    aOrderHeader.Approved = "N";
                    aOrderHeader.CustomerId = order.CustomerId;
                    aOrderHeader.Date = DateTime.Now;
                    aOrderHeader.DateOfEntry = DateTime.Now;
                    aOrderHeader.FullySattelled = "N";
                    aOrderHeader.Sattelled = 0.0;
                    aOrderHeader.OrderAmount = (order.Quantity*order.Price);
                    aOrderHeader.TotalAmount = 0;
                    aOrderHeader.RecieveAmount = 0;
                    dataOrder.DateOfEntry = DateTime.Now;
                    dataOrder.SalesQty = 0;
                    dataOrder.Approved = "N";
                    dataOrder.TotalPrice = (order.Quantity * order.Price);
                    dataOrder.OrderDetailId = Guid.NewGuid();
                    aOrderHeader.OrderDetails.Add(dataOrder);
                    _unitOfWork.OrderPost.Add(aOrderHeader);
                    _unitOfWork.Commit();
                    if (orderHeaderInfoP != null)
                    {
                        Guid orderHeaderPId = _unitOfWork.OrderPost.SingleOrDefault(c => c.CustomerId == id && c.PartialApproved == "Y").OrderHeaderId;
                        if (orderHeaderPId != null)
                        {
                            OrderHeader bOrderHeader = new OrderHeader();
                            bOrderHeader = _unitOfWork.OrderPost.Single(c => c.OrderHeaderId == orderHeaderPId);
                            bOrderHeader.Approved = "TY";
                            bOrderHeader.PartialApproved = "N";
                            _unitOfWork.Commit();
                            foreach (var lis in artList)
                            {
                                Guid OrderDetailsId = _unitOfWork.OrderDetailsPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderPId
                      && c.ArticleId == lis).OrderDetailId;
                                OrderDetail bOrderDeatil = new OrderDetail();
                                bOrderDeatil = _unitOfWork.OrderDetailsPost.Single(c => c.OrderDetailId == OrderDetailsId);
                                bOrderDeatil.OrderHeaderId = orderHeaderId;
                                _unitOfWork.Commit();
                            }
                        }
                    }
                    return "Data saved Succesfully!";
                }
                else
                {

                    Guid orderHeaderCId = _unitOfWork.OrderPost.SingleOrDefault(c => c.CustomerId == id && c.Approved == "N").OrderHeaderId;
                    var dataOrder = _mapper.Map<OrderDetail>(order);
                    var OrderDetailsInfo = _unitOfWork.OrderDetailsPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderCId
                   && c.ArticleId == dataOrder.ArticleId);
                    if (OrderDetailsInfo == null)
                    {
                        dataOrder.SalesQty = 0;
                        dataOrder.OrderDetailId = Guid.NewGuid();
                        dataOrder.OrderHeaderId = orderHeaderCId;
                        dataOrder.DateOfEntry = DateTime.Now;
                        dataOrder.TotalPrice = (dataOrder.Quantity * dataOrder.Price);
                        dataOrder.Approved = "N";
                        _unitOfWork.OrderDetailsPost.Add(dataOrder);
                        _unitOfWork.Commit();

                        var OrderAmount = _unitOfWork.OrderPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderCId).OrderAmount;
                        OrderHeader cOrder = new OrderHeader();
                        cOrder = _unitOfWork.OrderPost.GetByOrderId(orderHeaderCId);
                        cOrder.OrderAmount = ((dataOrder.Quantity * dataOrder.Price) + OrderAmount);
                        _unitOfWork.Commit();
                    }
                    else
                    {
                        Guid OrderDetailsId = _unitOfWork.OrderDetailsPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderCId
                   && c.ArticleId == dataOrder.ArticleId).OrderDetailId;
                        OrderDetail aOrderDetail = new OrderDetail();
                        aOrderDetail = _unitOfWork.OrderDetailsPost.Single(c => c.OrderDetailId == OrderDetailsId);
                        aOrderDetail.Quantity = dataOrder.Quantity;
                        aOrderDetail.DateOfEntry = DateTime.Now;
                        aOrderDetail.TotalPrice = (dataOrder.Quantity * dataOrder.Price);
                        _unitOfWork.Commit();

                        var OrderAmount = _unitOfWork.OrderPost.SingleOrDefault(c => c.OrderHeaderId == orderHeaderCId).OrderAmount;
                        OrderHeader cOrder = new OrderHeader();
                        cOrder = _unitOfWork.OrderPost.GetByOrderId(orderHeaderCId);
                        cOrder.OrderAmount = ((dataOrder.Quantity * dataOrder.Price) + OrderAmount);
                        _unitOfWork.Commit();
                    }

                    return "Data Updated Succesfully!";
                }
               
            }
            catch (Exception ex)
            {

                return ex.Message;

            }
          
                
        }
    }
}
