using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class DeliveryInfoDetails
    {
        public long Del_InId { get; set; }
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public decimal DeliveryAmount { get; set; }
        public long CompanyId { get; set; }
        public string Remarks { get; set; }
        public DateTime DateOfEntry { get; set; }
        public long EnteredBy { get; set; }
    }
}
