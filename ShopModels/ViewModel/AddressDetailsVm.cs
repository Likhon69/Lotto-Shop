using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class AddressDetailsVm
    {
        public string ReceipientFirstName { get; set; }
        public string ReceipientLastname { get; set; }
        public string RecipientMobile { get; set; }
        public long DistrictId { get; set; }
        public long DistAreaId { get; set; }
        public string AddressDetails { get; set; }

        public string SpecialInstruction { get; set; }
        public int AddressLabel { get; set; }
        public bool IsDefault { get; set; }
        public long CustomerId { get; set; }
        public string Created_by { get; set; }

    }
}
