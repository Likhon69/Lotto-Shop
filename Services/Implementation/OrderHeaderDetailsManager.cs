using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderHeaderDetailsManager : IOrderHeaderDetailsManager
    {
        private IUnitOfWork _unitOfWork;

        public OrderHeaderDetailsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderHeaderVm> GetOrderHeaderDetails()
        {
            try
            {
                var res = _unitOfWork.GetOrderHeader.GetOrderHeaderDetails();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
