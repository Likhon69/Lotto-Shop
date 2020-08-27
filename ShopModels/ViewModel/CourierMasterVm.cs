using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class CourierMasterVm
    {
        public CourierDetailsVm CourierDetails { get; set; }
        public ICollection<ContactPersonVm> ContactPersonList { get; set; }
    }
}
