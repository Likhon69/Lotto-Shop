using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class OrderHeader
    {
        public OrderHeader()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Guid OrderHeaderId { get; set; }
        public long CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public double OrderAmount { get; set; }
        public double RecieveAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string Approved { get; set; }
        public double Sattelled { get; set; }
        public string FullySattelled { get; set; }
        public string PartialApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime PartialApprovedDate { get; set; }
        public long ShippingId { get; set; }
        public long BillingId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
