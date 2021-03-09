using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.MobileContracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileImplementation
{
    public class OrderDetailsPostRepository: BaseShopRepository<OrderDetail>, IOrderDetailsPostRepository
    {
        public OrderDetailsPostRepository(DbContext db):base(db)
        {

        }
    }
}
