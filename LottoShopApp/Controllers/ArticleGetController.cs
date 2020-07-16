using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                             ArticleSubtitle = data.ArticleSubtitle,
                             ArticleMasterImage = data.ArticleMasterImage,
                             StandardPrice = pdata.StandardPrice

                         };



            return Ok(result);
        }
    }
}
