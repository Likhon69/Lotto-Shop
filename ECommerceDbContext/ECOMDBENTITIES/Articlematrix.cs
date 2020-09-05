using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Articlematrix
    {
        public int Artmid { get; set; }
        public int? Matrixid { get; set; }
        public string Extid { get; set; }
        public string Discode { get; set; }
        public string Description { get; set; }
    }
}
