using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class CourierContactPersons
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CourierCompanyMastercompanyId { get; set; }
    }
}
