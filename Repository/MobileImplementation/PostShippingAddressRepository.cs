using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.MobileContracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileImplementation
{
    public class PostShippingAddressRepository : BaseShopRepository<ShippingAddress>, IPostShippingAddressRepository
    {
        public PostShippingAddressRepository(DbContext db) : base(db)
        {

        }
    }
}
