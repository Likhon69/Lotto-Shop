using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class CustomerMaster
    {
        public int? CustomerId { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public long? AddressId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
