using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class OrderDetailsTmpVm
    {
        public string Article { get; set; }
        public string Size { get; set; }
        public int Qty { get; set; }
        public decimal DiscPrcnt { get; set; }
        public string Created_By { get; set; }
        public int CustomerID { get; set; }
    }
}
