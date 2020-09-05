using System;
using System.Collections.Generic;

namespace ECommerceDbContext.ECOMDBENTITIES
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
