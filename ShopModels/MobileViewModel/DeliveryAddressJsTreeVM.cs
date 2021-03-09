using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.MobileViewModel
{
    public class DeliveryAddressJsTreeVM
    {
        public string ParentId { get; set; }
        public string haveChild { get; set; }
        public string CurrentAddressName { get; set; }
        public string CurrentAddressId { get; set; }
    }
}
