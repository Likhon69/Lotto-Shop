using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class CourierContactPerson
    {
        public int person_Id { get; set; }
        public string personName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string status { get; set; }
        public string created_By { get; set; }
        public DateTime Created_At { get; set; }
    }
}
