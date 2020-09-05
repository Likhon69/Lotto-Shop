using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class CustomerAddressMaster
    {
        public long? AddressId { get; set; }
        public string ReceipientFirstname { get; set; }
        public string ReceipientLastname { get; set; }
        public string RecipientMobile { get; set; }
        public short? DistrictId { get; set; }
        public int? DistAreaId { get; set; }
        public string AddressDetails { get; set; }
        public string SpecialInstruction { get; set; }
        public short? AddressLabel { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsDefault { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
