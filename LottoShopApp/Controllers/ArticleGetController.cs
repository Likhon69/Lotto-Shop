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
        private readonly IGetArticleCatDiscountManager _getArticleCatDiscountManager;
        private readonly IGetCourierCompanyListManager _getCourierCompanyListManager;
        private readonly IGetSubCatDiscountArticleManager _getSubCatDiscountArticleManager;
        private readonly IGetSubSubCatDiscountArticleManager _getSubSubCatDiscountArticle;
        private readonly IGetSubSubSCatDiscountArticleManager _getSubSubSCatDiscountArticle;
        public ArticleGetController(
            IGetProcedure getProcedure,
            IGetAllArticleDetailsManager getAllArticleDetailsManager,
            IGetDistrictMasterManager getDistrictMasterManager,
            IGetDistrictAreaByDistrictIdManager getDistrictAreaByDistrictIdManager,
            IGetCourierCompanyListManager getCourierCompanyListManager,
            IGetArticleCatDiscountManager getArticleCatDiscountManager,
            IGetSubCatDiscountArticleManager getSubCatDiscountArticleManager,
            IGetSubSubCatDiscountArticleManager getSubSubCatDiscountArticle,
            IGetSubSubSCatDiscountArticleManager getSubSubSCatDiscountArticle
             )

        {

            _getProcedure = getProcedure;
            _getAllArticleDetailsManager = getAllArticleDetailsManager;
            _getDistrictMasterManager = getDistrictMasterManager;
            _getDistrictAreaByDistrictIdManager = getDistrictAreaByDistrictIdManager;
            _getCourierCompanyListManager = getCourierCompanyListManager;
            _getArticleCatDiscountManager = getArticleCatDiscountManager;
            _getSubCatDiscountArticleManager = getSubCatDiscountArticleManager;
            _getSubSubCatDiscountArticle = getSubSubCatDiscountArticle;
            _getSubSubSCatDiscountArticle = getSubSubSCatDiscountArticle;
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

        [HttpGet("{id}")]
        public IActionResult GetCatDiscountArticle(long id)
        {
            var res = _getArticleCatDiscountManager.GetForCatDiscountArticle(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSubCatDiscountArticle(long id)
        {
            var res = _getSubCatDiscountArticleManager.GetForSubCatDiscountArticle(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSubSubCatDiscountArticle(long id)
        {
            var res = _getSubSubCatDiscountArticle.GetForSubSubCatDiscountArticle(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSubSubSCatDiscountArticle(long id)
        {
            var res = _getSubSubSCatDiscountArticle.GetForSubSubSCatDiscountArticle(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

       
    }
}
