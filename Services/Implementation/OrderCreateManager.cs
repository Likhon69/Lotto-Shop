using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderCreateManager : IOrderCreateManager
    {
        private IUnitOfWork _unitOfWork;
        public OrderCreateManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int PostOrderCreate(CreateOrderVm model)
        {

            try
            {
                OrderCreateInfVm order = new OrderCreateInfVm();
                order.CustomerId = model.CustomerId;
                order.ShipmentAddId = model.ShipmentAddId;
                order.BillingAddId = model.BillingAddId;
                order.PaymentType = model.PaymentType;
                order.PaidAmount = model.PaidAmount;
                string[] array = model.ArticleCodeStrings.ToArray();
                string combindedString = string.Join(",", array);
                var res = _unitOfWork.OrderCreate.PostOrderCreate(combindedString, order);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
