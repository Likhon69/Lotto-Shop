using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.MobileContracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileImplementation
{
    public class PostBillingAddressRepository: BaseShopRepository<BillingAddress>, IPostBillingAddressRepository
    {
        public PostBillingAddressRepository(DbContext db):base(db)
        {

        }
    }
}
