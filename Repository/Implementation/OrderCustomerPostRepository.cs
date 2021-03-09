using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.MobileContracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class OrderCustomerPostRepository:BaseShopRepository<OrderHeader>, IOrderCustomerPostRepository
    {
        public OrderCustomerPostRepository(DbContext db):base(db)
        {

        }
    }
}
