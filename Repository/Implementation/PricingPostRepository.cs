using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class PricingPostRepository : BaseShopRepository<Pricing>, IPricingPostRepository
    {
        public PricingPostRepository(DbContext db) : base(db)
        {

        }
    }
}
