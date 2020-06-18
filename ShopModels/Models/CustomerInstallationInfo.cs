using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class CustomerInstallationInfo
    {
        public int CusPIn_Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public DateTime InstallationDate { get; set; }
        
    }
}
