using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class ShoePost : BaseShopRepository<Shoe>, IShoePost
    {
        private DbContext _db;
        public ShoePost(DbContext db):base(db)
        {
            _db = db;
        }
        
    }
}
