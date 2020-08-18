using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopModels.Models;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ArticleGetController : ControllerBase
    {
        private readonly ECommerceDatabaseContext _db;
        public ArticleGetController(ECommerceDatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllArticleDetails()
        {

            var result = from data in _db.ArticleDetails
                         join pdata in _db.Pricings
                         on data.ArtD_Id equals pdata.ArticleDetails_Id

                         select new
                         {
                             ArticleId = data.ArtD_Id,
                             ArticleTitle = data.ArticleTitle,
                             ArticleSubtitle = data.ArticleSubtitle,
                             ArticleMasterImage = data.ArticleMasterImage,
                             Description = data.Description,
                             StandardPrice = pdata.StandardPrice,
                             DiscountPrice = pdata.DiscontPrice,
                             DiscountRate = pdata.DiscountRate,
                             Quantity = data.Quantity

                         };



            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetArticleImageListByID(int id)
        {

            var result = _db.ArticleDetails
                         .Where(c => c.ArtD_Id == id)
                         .SelectMany(c => c.ArticleImageVarients);










            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetArticleVarianListByID(int id)
        {

            var result = _db.ArticleDetails
                         .Where(c => c.ArtD_Id == id)
                         .SelectMany(c => c.ArticleVariants);










            return Ok(result);
        }

        [HttpPost]

        public IActionResult PostData(TestClass1 model)
        {

            _db.TestClass1s.Add(model);

            return Ok(_db.SaveChanges());
            
        }
    }
}
