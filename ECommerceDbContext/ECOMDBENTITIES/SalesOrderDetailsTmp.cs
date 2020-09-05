using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class SalesOrderDetailsTmp
    {
        public string OrderNo { get; set; }
        public bool? InstanceId { get; set; }
        public long? RefId { get; set; }
        public string ArticleNo { get; set; }
        public int? ArtCode { get; set; }
        public int? LineNo { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public int? Quantity { get; set; }
        public double? DiscPrcnt { get; set; }
        public double? DiscPrd { get; set; }
        public double? DiscAmt { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountRefType { get; set; }
        public decimal? GrossAmount { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CustomerId { get; set; }
    }
}
