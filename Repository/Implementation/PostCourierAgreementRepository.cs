using ECommerceDbContext.ECOMDBENTITIES;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class PostCourierAgreementRepository: BaseShopRepository<CourierAgreementMaster>, IPostCourierAgreementRepository
    {
        private DbContext _db;

        public PostCourierAgreementRepository(DbContext db):base(db)
        {

        }
    }
}
