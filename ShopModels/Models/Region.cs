using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class Region
    {
        public Region()
        {
            City = new HashSet<City>();
        }
        public long RegionId { get; set; }
        public string RegionName { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
