using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Articlepricemaster
    {
        public short? OrgId { get; set; }
        public long ArtCode { get; set; }
        public short? BunitId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? BookingQty { get; set; }
        public decimal? PickingQty { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? WhPrice { get; set; }
        public decimal? FrPrice { get; set; }
        public decimal? DsPrice { get; set; }
        public decimal? InPrice { get; set; }
        public decimal? OnPrice { get; set; }
        public decimal? OtPrice { get; set; }
        public decimal? Purchacost { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? Mrpsales { get; set; }
        public decimal? Mrppurchase { get; set; }
        public decimal? ReorderLevel { get; set; }
        public decimal? ReorderSize { get; set; }
        public decimal? SeftystkLevel { get; set; }
        public decimal? Loyltyearn { get; set; }
        public decimal? Loyaltycearn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public short? Instanceid { get; set; }
    }
}
