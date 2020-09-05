using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class SalesOrderHeader
    {
        public string ExternalId { get; set; }
        public string OrderNo { get; set; }
        public bool? InstanceId { get; set; }
        public long? RefId { get; set; }
        public string CustomerId { get; set; }
        public double? DiscAllowed { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ValidToDate { get; set; }
        public int? SalesEmployeeId { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public int? BusinessUnitId { get; set; }
        public string Remarks { get; set; }
        public int? IsPosted { get; set; }
        public int? Status { get; set; }
        public int? DeviceId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
