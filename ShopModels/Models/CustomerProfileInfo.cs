using System;
using System.Collections.Generic;
using System.Text;

namespace ShopModels.Models
{
    public class CustomerProfileInfo
    {
        public int CustP_Id { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public string RecieverName { get; set; }
        public string RecieverPhoneNo { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
