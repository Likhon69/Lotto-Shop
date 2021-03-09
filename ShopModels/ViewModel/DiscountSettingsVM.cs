using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.ViewModel
{
    public class DiscountSettingsVM
    {
        public int DiscountPercentage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Banner { get; set; }
        public string BannerName { get; set; }
    }
}
