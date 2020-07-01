using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ArticleSettingsController : ControllerBase
    {
      
        private readonly ECommerceDatabaseContext _db;
        
        public ArticleSettingsController(ECommerceDatabaseContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetCategorys()
        {
            return Ok(_db.Categorys);
        }
        [HttpGet]
        public IActionResult GetSubCategorys()
        {
            return Ok(_db.SubCategories);
        }

        [HttpGet]
        public IActionResult GetBrand()
        {
            return Ok(_db.Brands);
        }
        [HttpGet]
        public IActionResult GetVat()
        {
            return Ok(_db.Vats);
        }
    }
}
