using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class CourierMasterPostRepository : BaseShopRepository<CourierCompanyMaster>, ICourierMasterPostRepository
    {
        public CourierMasterPostRepository(DbContext db):base(db)
        {

        }
    }
}
