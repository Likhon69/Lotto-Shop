using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderHeaderId { get; set; }
        public long ArticleId { get; set; }
        public double Discount { get; set; }
        public double VatAmount { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int Quantity { get; set; }
        public int SalesQty { get; set; }
        public double Price { get; set; }
        public string ArticleNo { get; set; }
        public string Approved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public double TotalPrice { get; set; }
        public double SalesTotalPrice { get; set; }
        public  OrderHeader OrderHeader { get; set; }
    }
}
