using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.MobileContracts;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.Models;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class MobileController : ControllerBase
    {
        private readonly IGetAllArticleDetailsForMobileHomePageManager _getAllArticleDetails;
        private readonly IGetArticleWiseImageManager _getArticleImage;
        private readonly IGetArticleVariantsManager _getArticleVariants;
        private readonly ECommerceDatabaseContext _db;
        private readonly IGetNewArraivalsArticleManager _getNewArraivals;
        private readonly IGetAllBeastDealsArticleManager _getAllBeastDealsArticle;
        private readonly IGetAllKidsArticleManager _getAllKidsArticleManager;
        private readonly IGetAllMansArticleManager _getAllMansArticleManager;
        private readonly IGetAllWomensArticleManager _getAllWomensArticle;
        private readonly IGetCategorizedArticleManager _getCategorizedArticleManager;
        private readonly IGetAddToCartArticleManager _getAddToCartArticle;
        private readonly IGetDefaultBillingAddressManager _getDefaultBillingAddress;
        private readonly IGetDefaultShippingAddressManager _getDefaultShippingAddress;
        private readonly IGetShippingAddressListManager _getShippingAddressList;
        private readonly IGetBillingAddressListManager _getBillingAddressList;
        public MobileController
            (
            IGetAllArticleDetailsForMobileHomePageManager getAllArticleDetails,
            IGetArticleWiseImageManager getArticleImage,
            IGetArticleVariantsManager getArticleVariants,
            ECommerceDatabaseContext db,
            IGetNewArraivalsArticleManager getNewArraivals,
            IGetAllBeastDealsArticleManager getAllBeastDealsArticle,
            IGetAllKidsArticleManager getAllKidsArticleManager,
            IGetAllMansArticleManager getAllMansArticleManager,
            IGetAllWomensArticleManager getAllWomensArticle,
            IGetCategorizedArticleManager getCategorizedArticleManager,
            IGetAddToCartArticleManager getAddToCartArticle,
            IGetDefaultBillingAddressManager getDefaultBillingAddress,
            IGetDefaultShippingAddressManager getDefaultShippingAddress,
            IGetShippingAddressListManager getShippingAddressList,
            IGetBillingAddressListManager getBillingAddressList
            )
        {
            _getAllArticleDetails = getAllArticleDetails;
            _getArticleImage = getArticleImage;
            _getArticleVariants = getArticleVariants;
            _db = db;
            _getNewArraivals = getNewArraivals;
            _getAllBeastDealsArticle = getAllBeastDealsArticle;
            _getAllKidsArticleManager = getAllKidsArticleManager;
            _getAllMansArticleManager = getAllMansArticleManager;
            _getAllWomensArticle = getAllWomensArticle;
            _getCategorizedArticleManager = getCategorizedArticleManager;
            _getAddToCartArticle = getAddToCartArticle;
            _getDefaultBillingAddress = getDefaultBillingAddress;
            _getDefaultShippingAddress = getDefaultShippingAddress;
            _getShippingAddressList = getShippingAddressList;
            _getBillingAddressList = getBillingAddressList;
        }

        [HttpGet]
        public IActionResult GetAllArticleDetailsForMobile()
        {
            var result = _getAllArticleDetails.GetAllArticleForMobile();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetArtiucleWiseImageListForMobile(long id)
        {
            var res = _getArticleImage.GetArticleIamge(id);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetArticleVariantListForMobile(long id)
        {
            var res = _getArticleVariants.GetArticlevariant(id);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult AllCatJsTree()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            //Loop and add the Parent Nodes.
            foreach (Category cat in _db.Categorys)
            {
                nodes.Add(new TreeViewNode
                {
                    parent_id = "0",
                    have_child = "1",
                    book_cat_tree_id = cat.C_Id.ToString(),
                    cat_title_en = cat.Name,
                    Image = cat.CatImage

                });
            }
            foreach (var subCat in _db.SubCategories)
            {
                string Cat = "First_";
                //var data = _db.SubCategories.Find(subCat.S_Id);
                if (subCat.Name == "THONGS")
                {
                    nodes.Add(new TreeViewNode { parent_id = subCat.Category.C_Id.ToString(), have_child = "0", book_cat_tree_id = subCat.S_Id.ToString(), cat_title_en = subCat.Name, Image = "Default.png", passId = Cat + subCat.Category.C_Id.ToString() + "_" + subCat.S_Id.ToString() });
                } else if (subCat.Category.C_Id == 4)
                {
                    nodes.Add(new TreeViewNode { parent_id = subCat.Category.C_Id.ToString(), have_child = "0", book_cat_tree_id = subCat.S_Id.ToString(), cat_title_en = subCat.Name, Image = "Default.png", passId = Cat + subCat.Category.C_Id.ToString() + "_" + subCat.S_Id.ToString() });
                }
                else
                {
                    nodes.Add(new TreeViewNode { parent_id = subCat.Category.C_Id.ToString(), have_child = "1", book_cat_tree_id = subCat.S_Id.ToString(), cat_title_en = subCat.Name, Image = "Default.png", passId = Cat + subCat.Category.C_Id.ToString() + "_" + subCat.S_Id.ToString() });
                }

            }
            foreach (var subSubCat in _db.Sub_SubCategories)
            {
                string SubCat = "Second_";
                //var data = _db.SubCategories.Find(subCat.S_Id);
                if (((subSubCat.Name == "DRESS" || subSubCat.Name == "CASUAL" || subSubCat.Name == "SPORTY LIFESTYLE"
                    || subSubCat.Name == "CANVAS" || subSubCat.Name == "SAFETY") && subSubCat.SubCategory.S_Id == 2) || subSubCat.SubCategory.S_Id == 3 || subSubCat.SubCategory.S_Id == 5)
                {
                    nodes.Add(new TreeViewNode { parent_id = subSubCat.SubCategory.S_Id.ToString(), have_child = "0", book_cat_tree_id = subSubCat.Sub_S_Id.ToString(), cat_title_en = subSubCat.Name, Image = "Default.png",
                        passId = SubCat + subSubCat.SubCategory.S_Id.ToString() + "_" + subSubCat.Sub_S_Id.ToString() });

                } else if (subSubCat.SubCategory.S_Id == 7 || subSubCat.SubCategory.S_Id == 8 || subSubCat.SubCategory.S_Id == 10 || subSubCat.SubCategory.S_Id == 11 || subSubCat.SubCategory.S_Id == 12 || subSubCat.SubCategory.S_Id == 13 || subSubCat.SubCategory.S_Id == 17 || subSubCat.SubCategory.S_Id == 18)
                {
                    nodes.Add(new TreeViewNode { parent_id = subSubCat.SubCategory.S_Id.ToString(), have_child = "0", book_cat_tree_id = subSubCat.Sub_S_Id.ToString(), cat_title_en = subSubCat.Name, Image = "Default.png",
                        passId = SubCat + subSubCat.SubCategory.S_Id.ToString() + "_" + subSubCat.Sub_S_Id.ToString() });
                }
                else
                {
                    nodes.Add(new TreeViewNode { parent_id = subSubCat.SubCategory.S_Id.ToString(), have_child = "1", book_cat_tree_id = subSubCat.Sub_S_Id.ToString(), cat_title_en = subSubCat.Name, Image = "Default.png",
                        passId = SubCat + subSubCat.SubCategory.S_Id.ToString() + "_" + subSubCat.Sub_S_Id.ToString() });
                }

            }

            foreach (var subSubSubCat in _db.Sub_Sub_SubCategories)
            {
                string SubSubCat = "Third_";
                //var data = _db.SubCategories.Find(subCat.S_Id);
                nodes.Add(new TreeViewNode { parent_id = subSubSubCat.Sub_SubCategory.Sub_S_Id.ToString(), have_child = "0", book_cat_tree_id = subSubSubCat.SubSub_S_Id.ToString(), cat_title_en = subSubSubCat.Name, Image = "Default.png",
                    passId = SubSubCat + subSubSubCat.Sub_SubCategory.Sub_S_Id.ToString() + "_" + subSubSubCat.SubSub_S_Id.ToString() });
            }

            //Serialize to JSON string.
            var Data = JsonConvert.SerializeObject(nodes);
            return Ok(Data);
        }


        [HttpGet]
        public IActionResult GetAllNewArraivalsArticle()
        {
            var res = _getNewArraivals.GetAllNewArraivalsArticle();
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAllBeastDealsArticle()
        {
            var res = _getAllBeastDealsArticle.GetAllBestDealsArticle();
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAllKidsAritcle()
        {
            var res = _getAllKidsArticleManager.GetAllKidsArticle();
            return Ok(res);
        }
        [HttpGet]

        public IActionResult GHetAllMansArticle()
        {
            var res = _getAllMansArticleManager.GetAllMansArticle();
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAllWomenArticlle()
        {
            var res = _getAllWomensArticle.GetAllWomensArticle();
            //var data = res.Take(4);
            return Ok(res);
        }
        //Copy This
        [HttpGet]
        public IActionResult GetFourNewArraivalsArticle()
        {
            var res = _getNewArraivals.GetAllNewArraivalsArticle();
            var data = res.Take(4);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetFourBeastDealsArticle()
        {
            var res = _getAllBeastDealsArticle.GetAllBestDealsArticle();
            var data = res.Take(4);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetFourKidsAritcle()
        {
            var res = _getAllKidsArticleManager.GetAllKidsArticle();
            var data = res.Take(4);
            return Ok(data);
        }
        [HttpGet]

        public IActionResult GHetFourMansArticle()
        {
            var res = _getAllMansArticleManager.GetAllMansArticle();
            var data = res.Take(4);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetFourWomenArticlle()
        {
            var res = _getAllWomensArticle.GetAllWomensArticle();
            var data = res.Take(4);
            return Ok(data);
        }


        [HttpGet("{id}")]
        public IActionResult GetCategorizedArticlleById(long id)
        {
            var res = _getCategorizedArticleManager.GetCategorizedArticle(id);
            return Ok(res);
        }

        [HttpGet("{id}")]

        public IActionResult GetJustForYouAricleById(long id)
        {
            try
            {
                var jstForUId = _db.ArticleDetails.Find(id);
                var sbId = jstForUId.SubCategoryS_Id;
                var ssbId = jstForUId.SubSubCategoryS_Id;
                var sssbId = jstForUId.SubSubSubCategoryS_Id;
                List<ArticleDetailsVMForMobileHomePage> aData = new List<ArticleDetailsVMForMobileHomePage>();

                if (sssbId != 0)
                {
                    aData = (from A in _db.ArticleDetails
                             join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                             join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                             join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                             from subpet in gj.DefaultIfEmpty()
                             join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                             where (A.SubSubSubCategoryS_Id == sssbId && AM.IsMaster == true)
                             select new ArticleDetailsVMForMobileHomePage
                             {
                                 ArtD_Id = A.ArtD_Id,
                                 ArticleTitle = A.ArticleTitle,
                                 ArticleSubtitle = A.ArticleSubtitle,
                                 Description = A.Description,
                                 IsDiscount = A.IsDiscount,
                                 StandardPrice = PR.StandardPrice,
                                 ImageName = AM.ImageName,
                                 IsDelivery = A.IsDelivery,
                                 DiscountPercentage = subpet.DiscountPercentage,
                                 Vat = V.Vat_Rat,
                                 DiscountPrice = subpet.DiscountPrice

                             }).ToList();


                }
                else if (ssbId != 0 && aData.Count == 0)
                {
                    aData = (from A in _db.ArticleDetails
                             join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                             join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                             join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                             from subpet in gj.DefaultIfEmpty()
                             join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                             where (A.SubSubCategoryS_Id == ssbId && AM.IsMaster == true)
                             select new ArticleDetailsVMForMobileHomePage
                             {
                                 ArtD_Id = A.ArtD_Id,
                                 ArticleTitle = A.ArticleTitle,
                                 ArticleSubtitle = A.ArticleSubtitle,
                                 Description = A.Description,
                                 IsDiscount = A.IsDiscount,
                                 IsDelivery = A.IsDelivery,
                                 StandardPrice = PR.StandardPrice,
                                 ImageName = AM.ImageName,
                                 DiscountPercentage = subpet.DiscountPercentage,
                                 Vat = V.Vat_Rat,
                                 DiscountPrice = subpet.DiscountPrice

                             }).ToList();
                } else if (sbId != 0 && aData.Count == 0)
                {
                    aData = (from A in _db.ArticleDetails
                             join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                             join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                             join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                             from subpet in gj.DefaultIfEmpty()
                             join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                             where (A.SubCategoryS_Id == sbId && AM.IsMaster == true)
                             select new ArticleDetailsVMForMobileHomePage
                             {
                                 ArtD_Id = A.ArtD_Id,
                                 ArticleTitle = A.ArticleTitle,
                                 ArticleSubtitle = A.ArticleSubtitle,
                                 Description = A.Description,
                                 IsDiscount = A.IsDiscount,
                                 IsDelivery = A.IsDelivery,
                                 StandardPrice = PR.StandardPrice,
                                 ImageName = AM.ImageName,
                                 DiscountPercentage = subpet.DiscountPercentage,
                                 Vat = V.Vat_Rat,
                                 DiscountPrice = subpet.DiscountPrice

                             }).ToList();
                }

                return Ok(aData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }

        }
        [HttpGet]
        public IActionResult CategorysData(string name)
        {
            string Cat = "First_";
            string SubCat = "Second_";
            string SubSubCat = "Third_";
            bool r1 = Regex.IsMatch(name, Cat);
            bool r2 = Regex.IsMatch(name, SubCat);
            bool r3 = Regex.IsMatch(name, SubSubCat);
            List<ArticleDetailsVMForMobileHomePage> aData = new List<ArticleDetailsVMForMobileHomePage>();
            if (r1 == true)
            {
                var subCatId = name.Remove(0, 8);
                var d = Int32.Parse(subCatId);
                aData = (from A in _db.ArticleDetails
                         join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                         join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                         join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                         from subpet in gj.DefaultIfEmpty()
                         join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                         where (A.SubCategoryS_Id == d && AM.IsMaster == true)
                         select new ArticleDetailsVMForMobileHomePage
                         {
                             ArtD_Id = A.ArtD_Id,
                             ArticleTitle = A.ArticleTitle,
                             ArticleSubtitle = A.ArticleSubtitle,
                             Description = A.Description,
                             IsDiscount = A.IsDiscount,
                             IsDelivery = A.IsDelivery,
                             StandardPrice = PR.StandardPrice,
                             ImageName = AM.ImageName,
                             DiscountPercentage = subpet.DiscountPercentage,
                             Vat = V.Vat_Rat,
                             DiscountPrice = subpet.DiscountPrice


                         }).ToList();
            }
            else if (r2 == true)
            {
                var subSubCatId = name.Remove(0, 9);
                var d = Int32.Parse(subSubCatId);
                aData = (from A in _db.ArticleDetails
                         join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                         join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                         join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                         from subpet in gj.DefaultIfEmpty()
                         join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                         where (A.SubSubCategoryS_Id == d && AM.IsMaster == true)
                         select new ArticleDetailsVMForMobileHomePage
                         {
                             ArtD_Id = A.ArtD_Id,
                             ArticleTitle = A.ArticleTitle,
                             ArticleSubtitle = A.ArticleSubtitle,
                             Description = A.Description,
                             IsDiscount = A.IsDiscount,
                             IsDelivery = A.IsDelivery,
                             StandardPrice = PR.StandardPrice,
                             ImageName = AM.ImageName,
                             DiscountPercentage = subpet.DiscountPercentage,
                             Vat = V.Vat_Rat,
                             DiscountPrice = subpet.DiscountPrice

                         }).ToList();
            }
            else if (r3 == true)
            {
                var subSubSubCatId = name.Remove(0, 8);
                var d = Int32.Parse(subSubSubCatId);
                aData = (from A in _db.ArticleDetails
                         join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                         join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                         join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                         from subpet in gj.DefaultIfEmpty()
                         join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                         where (A.SubSubSubCategoryS_Id == d && AM.IsMaster == true)
                         select new ArticleDetailsVMForMobileHomePage
                         {
                             ArtD_Id = A.ArtD_Id,
                             ArticleTitle = A.ArticleTitle,
                             ArticleSubtitle = A.ArticleSubtitle,
                             Description = A.Description,
                             IsDiscount = A.IsDiscount,
                             IsDelivery = A.IsDelivery,
                             StandardPrice = PR.StandardPrice,
                             ImageName = AM.ImageName,
                             DiscountPercentage = subpet.DiscountPercentage,
                             Vat = V.Vat_Rat,
                             DiscountPrice = subpet.DiscountPrice

                         }).ToList();
            }
            /*        var l = name.Length;
                    var d1 = name.Remove(3, l - 3);
                    var d2 = name.Remove(4, l - 4);
                    var d3 = Int32.Parse(d2);
                    var d4 = name.Remove(5, l - 5);
                    var d5 = Int32.Parse(d4);*/
            return Ok(aData);
        }
        [HttpGet("{id}")]
        public IActionResult GetAddToCartarticleByCustomer(long id)
        {
            var res = _getAddToCartArticle.GetAddToCartArticle(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult DeliveryAddressJsTree()
        {
            List<DeliveryAddressJsTreeVM> nodes = new List<DeliveryAddressJsTreeVM>();

            foreach (Region region in _db.Regions)
            {
                nodes.Add(new DeliveryAddressJsTreeVM
                {
                    ParentId = "0",
                    haveChild = "1",
                    CurrentAddressName = region.RegionName.ToString(),
                    CurrentAddressId = region.RegionId.ToString()
                });
            }

            foreach (City city in _db.City)
            {
                nodes.Add(new DeliveryAddressJsTreeVM
                {
                    ParentId = city.Region.RegionId.ToString(),
                    haveChild = "1",
                    CurrentAddressName = city.CityName.ToString(),
                    CurrentAddressId = city.CityId.ToString()
                });
            }

            foreach (Area area in _db.Areas)
            {
                nodes.Add(new DeliveryAddressJsTreeVM
                {
                    ParentId = area.City.CityId.ToString(),
                    haveChild = "0",
                    CurrentAddressName = area.AreaName.ToString(),
                    CurrentAddressId = area.AreaId.ToString()
                });
            }
            var Data = JsonConvert.SerializeObject(nodes);
            return Ok(Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetDefaultBillingAddress(long id)
        {
            var res = _getDefaultBillingAddress.GetDefaultBillingAddress(id);
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
        public IActionResult GetDefaultShippingAddress(long id)
        {
            var res = _getDefaultShippingAddress.GetDefaultShippingAddress(id);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("{CustomerId}")]
        public IActionResult GetAddToCartCount(long CustomerId)
        {
            var lnth = (from O in _db.OrderHeaders
                        join OD in _db.OrderDetails on O.OrderHeaderId equals OD.OrderHeaderId

                        where (O.CustomerId == CustomerId && OD.Approved == "N")
                        select OD.Approved).Count();
            if (lnth != 0)
            {
                return Ok(new { Status = "200", Leangth = lnth });
            }
            else
            {
                return BadRequest(new { Status = "500" });
            }
        }
        [HttpGet]
        public IActionResult SerachProduct(string searchString)
        {
            List<ArticleDetailsVMForMobileHomePage> aData = new List<ArticleDetailsVMForMobileHomePage>();
            try
            {
                aData = (from A in _db.ArticleDetails
                         join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                         join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                         join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                         from subpet in gj.DefaultIfEmpty()
                         join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                         where (A.ArticleTitle.Contains(searchString) && AM.IsMaster == true)
                         select new ArticleDetailsVMForMobileHomePage
                         {
                             ArtD_Id = A.ArtD_Id,
                             ArticleTitle = A.ArticleTitle,
                             ArticleSubtitle = A.ArticleSubtitle,
                             Description = A.Description,
                             IsDiscount = A.IsDiscount,
                             IsDelivery = A.IsDelivery,
                             StandardPrice = PR.StandardPrice,
                             ImageName = AM.ImageName,
                             DiscountPercentage = subpet.DiscountPercentage,
                             Vat = V.Vat_Rat,
                             DiscountPrice = subpet.DiscountPrice

                         }).ToList();
                return Ok(aData);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet()]
        public IActionResult GetAddressForEdit(long CustomerId, int EditStatus)
        {
            try
            {
                if (EditStatus == 1)
                {
                    var res = _getShippingAddressList.GetShippingAddressList(CustomerId);
                    return Ok(res);
                }
                else
                {
                    var res = _getBillingAddressList.GetBillingAddressList(CustomerId);
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetBannerList()
        {
            try
            {
                var res = _db.BannerInfo.ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{bannerId}")]
        public IActionResult GetBannerDiscountArtcleById(long bannerId)
        {
            List<ArticleDetailsVMForMobileHomePage> aData = new List<ArticleDetailsVMForMobileHomePage>();
            try
            {
                aData = (from A in _db.ArticleDetails
                         join PR in _db.Pricings on A.ArtD_Id equals PR.ArticleDetails_Id
                         join AM in _db.ArticleImageVarients on A.ArtD_Id equals AM.ArticleDetails.ArtD_Id
                         join D in _db.DiscountDetails on A.ArtD_Id equals D.ArticleId into gj
                         from subpet in gj.DefaultIfEmpty()
                         join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                         where (A.BannerId == bannerId && AM.IsMaster == true)
                         select new ArticleDetailsVMForMobileHomePage
                         {
                             ArtD_Id = A.ArtD_Id,
                             ArticleTitle = A.ArticleTitle,
                             ArticleSubtitle = A.ArticleSubtitle,
                             Description = A.Description,
                             IsDiscount = A.IsDiscount,
                             StandardPrice = PR.StandardPrice,
                             ImageName = AM.ImageName,
                             DiscountPercentage = subpet.DiscountPercentage,
                             Vat = V.Vat_Rat,
                             DiscountPrice = subpet.DiscountPrice

                         }).ToList();
                return Ok(aData);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public IActionResult GetDeliveryInfo(long regionId, long CityId)
        {
            try
            {
                DeliveryInfoDetailsVM aDelivery = new DeliveryInfoDetailsVM();
                if (regionId == 1)
                {
                    var date1 = DateTime.Now.Date.AddDays(1);
                    string firstDate = date1.ToString("dd MMMM yyyy");
                    var date2 = DateTime.Now.Date.AddDays(4);
                    string secondDate = date2.ToString("dd MMMM yyyy");
                    var remarks = firstDate + "_" + secondDate;

                    aDelivery = (from D in _db.DeliveryInfoDetails
                                 join C in _db.courierCompanyMasters
                                 on D.CompanyId equals C.company_Id
                                 where D.RegionId == regionId && D.CityId == CityId
                                 select new DeliveryInfoDetailsVM
                                 {
                                     DeliveryAmount = D.DeliveryAmount,
                                     ShippedBy = C.companyName,
                                     Remarks = remarks
                                 }).FirstOrDefault();
                    return Ok(aDelivery);
                }
                else
                {
                    var date1 = DateTime.Now.Date.AddDays(1);
                    string firstDate = date1.ToString("dd MMMM yyyy");
                    var date2 = DateTime.Now.Date.AddDays(7);
                    string secondDate = date2.ToString("dd MMMM yyyy");
                    var remarks = firstDate + "_" + secondDate;

                    aDelivery = (from D in _db.DeliveryInfoDetails
                                 join C in _db.courierCompanyMasters
                                 on D.CompanyId equals C.company_Id
                                 where D.RegionId == regionId && D.CityId == CityId
                                 select new DeliveryInfoDetailsVM
                                 {
                                     DeliveryAmount = D.DeliveryAmount,
                                     ShippedBy = C.companyName,
                                     Remarks = remarks
                                 }).FirstOrDefault();
                    if (aDelivery != null)
                    {
                        return Ok(aDelivery);
                    }
                    else
                    {
                        return BadRequest(new { Status = "500", message = "No delivery information!" });
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public IActionResult GetCheckoutItem(long CustomerId, List<string> ListArticleNo)
        {
            try
            {
                List<AddToCartGetVM> listItem = new List<AddToCartGetVM>();

                Guid OrderHeaderId = _db.OrderHeaders.Where(c => c.CustomerId == CustomerId && c.Approved == "N").Select(c => c.OrderHeaderId).FirstOrDefault();
                foreach (var str in ListArticleNo)
                {
                    AddToCartGetVM aAdd = new AddToCartGetVM();
                    aAdd = (from O in _db.OrderHeaders
                            join OD in _db.OrderDetails on O.OrderHeaderId equals OD.OrderHeaderId
                            join A in _db.ArticleDetails on OD.ArticleId equals A.ArtD_Id
                            join AG in _db.ArticleImageVarients
                            on A.ArtD_Id equals AG.ArticleDetails.ArtD_Id
                            join AR in _db.ArticleVariants on OD.ArticleNo equals AR.ArticleNo
                            join V in _db.Vats on A.Vat_Id equals V.Vat_Id
                            where AG.IsMaster == true && OD.ArticleNo == str && OD.Approved == "N" && OD.OrderHeaderId == OrderHeaderId
                            select new AddToCartGetVM
                            {
                                ArticleTitle = A.ArticleTitle,
                                Discount = OD.Discount,
                                ArticleId = A.ArtD_Id,
                                CustomerId = O.CustomerId,
                                ArticleNo = OD.ArticleNo,
                                VatRate = V.Vat_Rat,
                                Price = OD.Price,
                                Quantity = OD.Quantity,
                                ImageName = AG.ImageName,
                                Size = AR.Size,
                                Color = AR.Color
                            }).FirstOrDefault();
                    listItem.Add(aAdd);
                }
                if (listItem != null)
                {
                    return Ok(listItem);
                }
                else
                {
                    return BadRequest(new { Status = "500", message = "No data found!" });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
