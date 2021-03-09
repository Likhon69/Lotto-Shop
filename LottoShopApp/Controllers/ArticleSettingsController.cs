using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceDbContext;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ArticleSettingsController : ControllerBase
    {

        private readonly ECommerceDatabaseContext _db;

        private IArticleDetailsPostService _services;
        private IPostArticleImageManager _postArticleImageManager;
        private ICourierMasterPostManager _courierMasterPostManager;
        private IOrderDetailsTempManager _orderDetailsTempManager;
        private readonly IMapper _mapper;
        private readonly IPostCourierAgreementManager _postCourierAgreementManager;
        private readonly IDiscountSettingsManager _discountSettingsManager;
        public ArticleSettingsController(ECommerceDatabaseContext db, 
            IArticleDetailsPostService services, 
            IPostArticleImageManager postArticleImageManager, 
            ICourierMasterPostManager courierMasterPostManager,
           IOrderDetailsTempManager orderDetailsTempManager,
            IMapper mapper,
            IPostCourierAgreementManager postCourierAgreementManager,
            IDiscountSettingsManager discountSettingsManager
            )
        {
            _db = db;
            _services = services;
            _postArticleImageManager = postArticleImageManager;
            _courierMasterPostManager = courierMasterPostManager;
            _orderDetailsTempManager = orderDetailsTempManager;
             _mapper = mapper;
            _postCourierAgreementManager = postCourierAgreementManager;
            _discountSettingsManager = discountSettingsManager;
        }
        [HttpGet]
        public IActionResult GetCategorys()
        {
            return Ok(_db.Categorys);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubCategorys(long id)
        {
            var data = _db.SubCategories.Where(c => c.Category.C_Id == id).ToList();
            if (data.Count>0)
            {
                return Ok(data);
            }
            else
            {
            return BadRequest();
            }
            
        }
        [HttpGet("{id}")]
        public IActionResult GetSubSubCategorys(long id)
        {
            var data = _db.Sub_SubCategories.Where(c => c.SubCategory.S_Id == id).ToList();
            if (data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetSubSubSubCategorys(long id)
        {
            var data = _db.Sub_Sub_SubCategories.Where(c => c.Sub_SubCategory.Sub_S_Id == id).ToList();
            if (data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

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

        [HttpPost]
        public IActionResult GetAllArticleData(ArticleDetailsDto model)
        {
            var result = _services.ArticleDetailsPost(model);
            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //3-4-2021
        [HttpPost]
        public IActionResult PostDiscountData(DiscountDetailsVM model)
        {
            
           
                string loginId = "";
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;


                    var user = _db.Users.FirstOrDefault(c => c.UserName == userId);

                  
                        loginId = user.LoginId;
                    

                }
                var res = _discountSettingsManager.DiscountSettings(model, loginId);
            if(res== "success")
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
                
         
            
        }

        [HttpPost]
        public IActionResult PostArticleImage(List<ArticleImageVm> model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;


                var user = _db.Users.FirstOrDefault(c => c.UserName == userId);
               
                foreach(var item in model)
                {
                    item.userId = user.LoginId;
                }

            }
            var result = _postArticleImageManager.PostEArticleImage(model);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostCourierMaster(CourierMasterVm model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var masterData = model.CourierDetails;
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;


                var user = _db.Users.FirstOrDefault(c => c.UserName == userId);

                foreach (var item in model.ContactPersonList)
                {
                    item.created_By = user.LoginId;
                    masterData.createdBy = user.LoginId;
                }

            }
            var res = _courierMasterPostManager.CourierMasterPost(model);
            return Ok(res);

        }

     /*   [HttpPost]
        public IActionResult PostAgreement(CourierAgreementVm model)
        {
            var res = _postCourierAgreementManager.PostCourierAgreement(model);
            return Ok(res);
        }*/

        [HttpPost]
        public IActionResult PostOrderDetails(OrderDetailsTmpVm model)
        {
            var res = _orderDetailsTempManager.PostOrderDetailsTmp(model);

            return Ok(res);
        }
        //7-1-2021
        [HttpGet]
        public IActionResult EditForArticleSettings()
        {
            try
            {
                var res = (from A in _db.ArticleDetails join P in _db.Pricings on A.ArtD_Id equals P.ArticleDetails_Id
                           join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id where AM.IsMaster==true
                           select new ArticleSettingsEditVM {
                           ArtD_Id = A.ArtD_Id,
                           ArticleTitle = A.ArticleTitle,
                           ArticleSubTitle = A.ArticleSubtitle,
                           CategoryC_Id = A.CategoryC_Id,
                           SubCategoryS_Id = A.SubCategoryS_Id,
                           Description = A.Description,
                           Brand_Id = A.Brand_Id,
                           Vat_Id = A.Vat_Id,
                           SubSubCategoryS_Id = A.SubSubCategoryS_Id,
                           SubSubSubCategoryS_Id = A.SubSubSubCategoryS_Id,
                           IsNewAraival = A.IsNewAraival,
                           ArticleCode = A.ArticleCode,
                           Pricing_Id = P.Pricing_Id,
                           StandardPrice = P.StandardPrice,
                           FranchisePrice = P.FranchisePrice,
                           InstitutePrice = P.InstitutePrice,
                           PurchaseCost = P.PurchaseCost,
                           WholeSalePrice = P.WholeSalePrice,
                           DealerPrice = P.DealerPrice,
                           OtherPrice = P.OtherPrice,
                           MasterImageName = AM.ImageName
                           }
                           ).ToList();

                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetImageListForEdit(long id)
        {
            try
            {
                var res = _db.ArticleImageVarients.Where(c => c.ArticleDetails.ArtD_Id == id).Select(c => new
                {
                    c.Img_Id,
                    c.ImageName,
                    c.IsMaster
                }).ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetArticleVariantListForEdit(long id)
        {
            try
            {
                var res = _db.ArticleVariants.Where(c => c.ArticleDetails.ArtD_Id == id).Select(c => new
                {
                    c.ArtV_Id,
                    c.ArticleNo,
                    c.Gender,
                    c.Color,
                    c.Size,
                    c.Style,
                    c.Quantity
                }).ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
