using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class OrderCreateInfVm
    {
        public long CustomerId { get; set; }
        public long BillingAddId { get; set; }
        public long ShipmentAddId { get; set; }
        public int PaymentType { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
