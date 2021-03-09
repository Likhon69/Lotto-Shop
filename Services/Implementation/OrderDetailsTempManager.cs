using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderDetailsTempManager : IOrderDetailsTempManager
    {
        private IUnitOfWork _unitOfWork;
        public OrderDetailsTempManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int PostOrderDetailsTmp(OrderDetailsTmpVm model)
        {
            var result = _unitOfWork.PostOrderDetailSTemp.PostOrderDetailsTmp(model);

            return result;
        }
    }
}
