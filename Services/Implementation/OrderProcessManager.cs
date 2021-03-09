using CommonUnitOfWork;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class OrderProcessManager : IOrderProcessManager
    {
        private IUnitOfWork _unitOfWork;

        public OrderProcessManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int OrderProcess(string orderNo,string created_By)
        {
            try
            {
                var res = _unitOfWork.OrderProcess.OrderProcess(orderNo,created_By);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
