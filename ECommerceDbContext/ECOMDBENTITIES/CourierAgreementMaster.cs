using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class CourierAgreementMaster
    {
        public int AgreementId { get; set; }
        public int? DistAreaId { get; set; }
        public int? CourierId { get; set; }
        public decimal? Amount { get; set; }
    }
}
