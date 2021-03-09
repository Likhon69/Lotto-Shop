using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class ShippingAddress
    {
        public long ShippingAdd_Id { get; set; }
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public long AreaId { get; set; }
        public string Address { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public bool IsDeafultAddress { get; set; }
        public long CustomerId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public bool IsHome { get; set; }
        public bool IsOffice { get; set; }
    }
}
