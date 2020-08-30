using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ArticleGetController : ControllerBase
    {
      
        private readonly IGetProcedure _getProcedure;
        private readonly IGetAllArticleDetailsManager _getAllArticleDetailsManager;
        private readonly IGetDistrictMasterManager _getDistrictMasterManager;
        private readonly IGetDistrictAreaByDistrictIdManager _getDistrictAreaByDistrictIdManager;
        private readonly ECommerceDatabaseContext _db;
        private readonly IGetCourierCompanyListManager _getCourierCompanyListManager;
        public ArticleGetController(ECommerceDatabaseContext db, 
            IGetProcedure getProcedure, 
            IGetAllArticleDetailsManager getAllArticleDetailsManager, 
            IGetDistrictMasterManager getDistrictMasterManager, 
            IGetDistrictAreaByDistrictIdManager getDistrictAreaByDistrictIdManager,
             IGetCourierCompanyListManager getCourierCompanyListManager)
        {
            _db = db;
            _getProcedure = getProcedure;
            _getAllArticleDetailsManager = getAllArticleDetailsManager;
            _getDistrictMasterManager = getDistrictMasterManager;
            _getDistrictAreaByDistrictIdManager = getDistrictAreaByDistrictIdManager;
            _getCourierCompanyListManager = getCourierCompanyListManager;
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

        [HttpGet]
        public IActionResult GetProcedureData()
        {
            return Ok(_getProcedure.articleDetailsManager());
        }

        [HttpGet]
        public IActionResult EGetAllArticleDetails()
        {

            return Ok(_getAllArticleDetailsManager.GetEArticleDetails());
        }
        [HttpGet]
        public IActionResult GetAllDistrictMaster()
        {
            var result = _getDistrictMasterManager.GetDistrictMaster();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetDistrictMasterById(int id)
        {
            var result = _getDistrictAreaByDistrictIdManager.GetDistrictAreaById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCourierDetailsList()
        {
            var result = _getCourierCompanyListManager.GetCourierCompanyList();
            return Ok(result);
        }
    }
}
