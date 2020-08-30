using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class CourierCompanyMaster
    {
        public CourierCompanyMaster()
        {
            CourierContactPersons = new HashSet<CourierContactPerson>();
        }
        public int company_Id { get; set; }
        public string companyName { get; set; }
        public string contactPerson { get; set; }
        public string Email { get; set; }
        public string website { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public string status { get; set; }
        public DateTime created_At { get; set; }
        public string  created_By { get; set; }
        public virtual ICollection<CourierContactPerson> CourierContactPersons { get; set; }
    }
}
