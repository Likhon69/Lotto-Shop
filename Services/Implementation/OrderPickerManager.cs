using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderPickerManager : IOrderPickerManager
    {
        private IUnitOfWork _unitOfWork;
        public OrderPickerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderPickerVm> GetOrderPickerByOrderNo(string orderNo)
        {
            try
            {
                var res = _unitOfWork.GetOrderPickerByOrderNo.GetOrderPickerByOrderNo(orderNo);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
