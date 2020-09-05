using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Imagemaster
    {
        public long ImageId { get; set; }
        public bool? IsDefault { get; set; }
        public string ImageName { get; set; }
        public string Article { get; set; }
        public int? ArtCode { get; set; }
        public short? DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
