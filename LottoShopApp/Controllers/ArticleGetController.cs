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
        private readonly IAddPracticePostManager _addPracticePostManager;
        private readonly IGetDesignationManager _getDesignationManager;
        private readonly IGetPracticeManager _getPracticeManager;
        private readonly IGetPracticeEmployeeDetailsManager _getPracticeEmployeeDetailsManager;
        private readonly IDeletePracticeManager _deletePracticeManager;

        private readonly IGetCourierCompanyListManager _getCourierCompanyListManager;
        public ArticleGetController(
            IGetProcedure getProcedure,
            IGetAllArticleDetailsManager getAllArticleDetailsManager,
            IGetDistrictMasterManager getDistrictMasterManager,
            IGetDistrictAreaByDistrictIdManager getDistrictAreaByDistrictIdManager,
             IGetCourierCompanyListManager getCourierCompanyListManager,
             IGetCategoryListManager getCategoryListManager,
            IGetSubCategoryLIstManager getSubCategoryLIstManager,
            IGetSubSubCategoryManager getSubSubCategoryManager,
            IAddPracticePostManager addPracticePostManager,
            IGetDesignationManager getDesignationManager,
            IGetPracticeManager getPracticeManager,
            IGetPracticeEmployeeDetailsManager getPracticeEmployeeDetailsManager,
            IDeletePracticeManager deletePracticeManager
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
            _addPracticePostManager = addPracticePostManager;
            _getDesignationManager = getDesignationManager;
            _getPracticeManager = getPracticeManager;
            _getPracticeEmployeeDetailsManager = getPracticeEmployeeDetailsManager;
            _deletePracticeManager = deletePracticeManager;
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
        [HttpPost]
        public IActionResult PostPractice(PracticseVm practicseVm )
        {
            var res = "jhgdsjhdd";
            return Ok();
        }

        [HttpPost]
        public IActionResult PostTest(EmployeeVm employee)
        {
            var res = _addPracticePostManager.PracticePost(employee);

            return Ok(res);
        }
        [HttpGet]

        public IActionResult GetDesignationList()
        {
            var result = _getDesignationManager.GetAllDesignationList();
            return Ok(result);
        }
        [HttpGet]

        public IActionResult GetPracticeList()
        {
            var result = _getPracticeManager.GetEmployeeDetails();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public IActionResult GetPracticeEmployeeList(int id)
        {
            var result = _getPracticeEmployeeDetailsManager.GetEmployeePracticeDetails(id);
            return Ok(result);
        }

        [HttpPost("{id}")]

        public IActionResult DeletePractice(int id)
        {
            var result = _deletePracticeManager.DeletePracticeMaster(id);
            return Ok(result);
        }
    }
}
