using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class BannerInfo
    {
        public long BannerId { get; set; }
        public string BannerName { get; set; }
        public string BannerImageName { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string EnteredBy { get; set; }
        
    }
}
