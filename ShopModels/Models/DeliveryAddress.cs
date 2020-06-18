using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class DeliveryAddress
    {
        public int DeAdd_Id { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public int RoadNo { get; set; }
        public int HouseNo { get; set; }
        public int floorNo { get; set; }
    }
}
