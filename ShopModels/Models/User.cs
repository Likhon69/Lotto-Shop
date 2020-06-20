using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopModels.Models
{
    public class User
    {
        public int User_Id { get; set; }
     
        public string UserName { get; set; }
        
        public string LoginId { get; set; }
      
        public string Email { get; set; }
      
        public string MobileNo { get; set; }
        public string Password { get; set; }
     
        public string Roles { get; set; }
    }
}
