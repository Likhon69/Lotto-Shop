using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Sysdocsrno
    {
        public long? Regid { get; set; }
        public string Documentid { get; set; }
        public string ForMat { get; set; }
        public string Format1 { get; set; }
        public long? Lastserialno { get; set; }
    }
}
