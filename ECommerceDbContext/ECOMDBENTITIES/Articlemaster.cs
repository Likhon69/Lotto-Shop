using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Articlemaster
    {
        public int? OrgId { get; set; }
        public long? ArtCode { get; set; }
        public string Artno { get; set; }
        public string ArtexCode { get; set; }
        public int? CatId { get; set; }
        public int? SubId { get; set; }
        public int? SegId { get; set; }
        public string ArtName { get; set; }
        public string Shortname { get; set; }
        public string Description { get; set; }
        public string ArtType { get; set; }
        public string ArtSource { get; set; }
        public int? SupCode { get; set; }
        public int? GendirId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int? BrandId { get; set; }
        public int? StyleId { get; set; }
        public int? SessionId { get; set; }
        public int? MaterialId { get; set; }
        public int? FashionId { get; set; }
        public int? FlavourId { get; set; }
        public int? DesignId { get; set; }
        public int? GradeId { get; set; }
        public double? VatRat { get; set; }
        public bool? Discounted { get; set; }
        public bool? DisApply { get; set; }
        public string Online { get; set; }
        public string NewArr { get; set; }
        public string Rptop1 { get; set; }
        public string Rptop2 { get; set; }
        public bool? LoyaErn { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Particle { get; set; }
        public string Pimage { get; set; }
    }
}
