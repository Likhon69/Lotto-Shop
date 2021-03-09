using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class ArticleImageVariantPostRepository : BaseShopRepository<ArticleImageVarient>, IArticleImageVariantPostRepository
    {
        public ArticleImageVariantPostRepository(DbContext db) : base(db)
        {

        }
    }
}
