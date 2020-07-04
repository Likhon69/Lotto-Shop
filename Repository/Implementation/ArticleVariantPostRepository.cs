using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class ArticleVariantPostRepository : BaseShopRepository<ArticleVariant>, IArticleVariantPostRepository
    {
        public ArticleVariantPostRepository(DbContext db) : base(db)
        {

        }
    }
}
