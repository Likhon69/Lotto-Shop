using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Area
    {
        public long AreaId { get; set; }
        public string AreaName { get; set; }
        public City City { get; set; }
    }
}
