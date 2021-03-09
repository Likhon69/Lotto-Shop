using Repository.Contracts;
using Repository.MobileContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IShoePost Shoe { get; }
        IArticleDetailsPostRepository ArticleDetails { get; }
        IArticleImageVariantPostRepository ArticleImageVariant { get; }
        IArticleVariantPostRepository ArticleVariant { get; }
        IPricingPostRepository Pricing { get; }
        IPricingPostRepository GetProcedure { get; }
        IGetAllArticleRepository EGetAllArticle { get; }
        IPostArticleImageRepository PostEArticleImage { get; }
        IGetDistrictMasterRepository GetAllDistrictMaster { get; }
        IGetDistrictAreaByDistrictIdRepository GetDistrictArea { get; }
        ICourierMasterPostRepository PostCourierMaster { get; }
        IGetCourierCompnayListRepository GetCourierCompanyList { get; }
        IOrderDetailsTempRepository PostOrderDetailSTemp { get; }
       
        IOrderCreateRepository OrderCreate { get; }
        IAddressDetailsPostRepository PostAddress { get; }
        IOrderHeaderDetailsRepository GetOrderHeader { get; }
        IOrderDetailsByOrderNoRepository GetOrderDetailsByOrderNo { get; }
        IOrderPickerRepository GetOrderPickerByOrderNo { get; }
        IOrderProcessRepository OrderProcess { get; }
        IGetAllArticleDetailsForMobileAppRepository GetAllArticleDetailsDataForMobile { get; }
        IGetArticleWiseImageRepository GetArticleImage { get; }
        IGetArticleVariantsRepository GetArticleVariant { get; }
        IRegCustomerPostRepository PostRegCustomer { get; }
        IGetNewArraivalsArticleRepository GetAllNewArraivalArticle { get; }
        IGetAllBeastDealsArticleRepository GetAllBestDealsArticle { get; }
        IGetAllKidsAricleRepository GetAllKidsArticle { get; }
        IGetAllMansArticleRepository GetAllMansArticle { get; }
        IGetAllWomensArticleRepository GetAllWomemnsArticle { get; }
        IGetCategorizedArticleRepository GetCategorizedArticle { get; }
        IOrderCustomerPostRepository OrderPost { get; }
        IOrderDetailsPostRepository OrderDetailsPost { get; }
        IGetAddToCartArticleRepository GetAddToCartArticle { get; }
        IPartialUpdateRepository PartialUpdate { get; }
        IPostBillingAddressRepository BillingAddress { get; }
        IPostShippingAddressRepository ShippingAddress { get; }
        IGetDefaultBillingAddressRepository GetDefaultBillingAddress { get; }
        IGetDefaultShippingAddressRepository GetDefaultShippingAddress { get; }
        IGetShippingAddressListRepository GetShippingAdreesList { get; }
        IGetBillingAddressListRepository GetBillingAdreesList { get; }
        IGetArticleCatDiscountRepository GetDiscountForCatArticle { get; }
        IGetSubCatDiscountArticleRepository GetDiscountForSubCatArticle { get; }
        IGetSubSubCatDiscountArticleRepository GetDiscountForSubSubCatArticle { get; }
        IGetSubSubSCatDiscountArticleRepository GetDiscountForSubSubSCatArticle { get; }
        IDiscountDetailsSettingsRepository DiscountDetail { get; }
        ISettingsDiscountTimeRepository DiscountTime { get; }
        ISettingsDiscoutBannerRepository BannerInfo { get; }
        int Commit();
    }
}
