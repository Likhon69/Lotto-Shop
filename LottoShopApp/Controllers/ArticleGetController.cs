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
        private readonly IGetCategoryListManager _getCategoryListManager;
        private readonly IGetSubCategoryLIstManager _getSubCategoryLIstManager;
        private readonly IGetSubSubCategoryManager _getSubSubCategoryManager;

        private readonly IGetCourierCompanyListManager _getCourierCompanyListManager;
        public ArticleGetController(
            IGetProcedure getProcedure,
            IGetAllArticleDetailsManager getAllArticleDetailsManager,
            IGetDistrictMasterManager getDistrictMasterManager,
            IGetDistrictAreaByDistrictIdManager getDistrictAreaByDistrictIdManager,
             IGetCourierCompanyListManager getCourierCompanyListManager,
             IGetCategoryListManager getCategoryListManager,
            IGetSubCategoryLIstManager getSubCategoryLIstManager,
            IGetSubSubCategoryManager getSubSubCategoryManager
            )
        {

            _getProcedure = getProcedure;
            _getAllArticleDetailsManager = getAllArticleDetailsManager;
            _getDistrictMasterManager = getDistrictMasterManager;
            _getDistrictAreaByDistrictIdManager = getDistrictAreaByDistrictIdManager;
            _getCourierCompanyListManager = getCourierCompanyListManager;
            _getCategoryListManager = getCategoryListManager;
            _getSubCategoryLIstManager = getSubCategoryLIstManager;
            _getSubSubCategoryManager = getSubSubCategoryManager;
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

        [HttpGet]

        public IActionResult GetCategoryList()
        {
            var result = _getCategoryListManager.GetAllCategoryList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubCategoryList(int id)
        {
            var result = _getSubCategoryLIstManager.GetAllSubCategoryList(id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubSubCategoryList(int id)
        {
            var result = _getSubSubCategoryManager.GetAllSubSubCategory(id);
            return Ok(result);
        }
    }
}
