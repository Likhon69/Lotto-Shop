using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class DefaultAddressVM
    {
        public long BillingAdd_Id { get; set; }
        public long ShippingAdd_Id { get; set; }
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public long AreaId { get; set; }
        public string Address { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public bool IsDeafultAddress { get; set; }
        public long CustomerId { get; set; }
        public bool IsHome { get; set; }
        public bool IsOffice { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
    }
}
