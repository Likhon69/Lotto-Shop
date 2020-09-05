using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class AreaRate
    {
        public int DistAreaId { get; set; }
        public short WeightKg { get; set; }
        public decimal Rate { get; set; }
    }
}
