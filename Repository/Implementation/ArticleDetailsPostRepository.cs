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
    public class ArticleDetailsPostRepository : BaseShopRepository<ArticleDetails>,IArticleDetailsPostRepository
    {
        
        public ArticleDetailsPostRepository(DbContext db) : base(db)
        {
        
        }
    }
}
