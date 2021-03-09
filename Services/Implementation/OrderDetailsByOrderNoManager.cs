using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderDetailsByOrderNoManager : IOrderDetailsByOrderNoManager
    {
        private IUnitOfWork _unitOfWork;
        public OrderDetailsByOrderNoManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderDetailsByOrderNoVm> GetOrderDetailsByOrderNo(string orderNo)
        {
            try
            {
                var res = _unitOfWork.GetOrderDetailsByOrderNo.GetOrderDetailsByOrderNo(orderNo);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
