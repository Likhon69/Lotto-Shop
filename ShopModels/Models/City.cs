using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class City
    {
        public City()
        {
            Area = new HashSet<Area>();
        }
        public long CityId { get; set; }
        public string CityName { get; set; }
        public Region Region { get; set; }
        public virtual ICollection<Area> Area { get; set; }
    }
}
