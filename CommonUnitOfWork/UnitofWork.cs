using ECommerceDbContext;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using Repository.Implementation;
using Repository.MobileContracts;
using Repository.MobileImplementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonUnitOfWork
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly DbContext _context;
       
        private bool _disposed;
        private Hashtable _repositories;

      

        public UnitofWork(DbContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IBaseShopRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseShopRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(BaseShopRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseShopRepository<TEntity>)_repositories[type];
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                if (_repositories != null)
                {
                    foreach (IDisposable repository in _repositories.Values)
                    {
                        repository.Dispose();
                    }
                }
            }
            _disposed = true;
        }

        private IShoePost _shoePost;
        public IShoePost Shoe => _shoePost ?? new ShoePost(_context);
        private IArticleDetailsPostRepository _articleDetailsPostRepository;
        public IArticleDetailsPostRepository ArticleDetails => _articleDetailsPostRepository ?? new ArticleDetailsPostRepository(_context);
        private IArticleImageVariantPostRepository _articleImageVariantPostRepository;
        public IArticleImageVariantPostRepository ArticleImageVariant => _articleImageVariantPostRepository ?? new ArticleImageVariantPostRepository(_context);
        private IArticleVariantPostRepository _articleVariantPostRepository;
        public IArticleVariantPostRepository ArticleVariant => _articleVariantPostRepository ?? new ArticleVariantPostRepository(_context);
        private IPricingPostRepository _pricingPostRepository;
        public IPricingPostRepository Pricing => _pricingPostRepository ?? new PricingPostRepository(_context);
        private IPricingPostRepository _pricingGetRepository;
        public IPricingPostRepository GetProcedure => _pricingGetRepository?? new PricingPostRepository(_context);

        private IGetAllArticleRepository _getAllArticleRepository;
        public IGetAllArticleRepository EGetAllArticle => _getAllArticleRepository ?? new GetAllArticleDetailsRepository();

        private IPostArticleImageRepository _postArticleImageRepository;
        public IPostArticleImageRepository PostEArticleImage => _postArticleImageRepository ?? new PostArticleImageRepository();
        private IGetDistrictMasterRepository _getDistrictMasterRepository;
        public IGetDistrictMasterRepository GetAllDistrictMaster => _getDistrictMasterRepository??new GetDistrictMasterRepository();
        private IGetDistrictAreaByDistrictIdRepository _getDistrictAreaByDistrictRepository;
        public IGetDistrictAreaByDistrictIdRepository GetDistrictArea => _getDistrictAreaByDistrictRepository ?? new GetDistrictAreaByDistrictIdRepository();

        private ICourierMasterPostRepository _courierMasterPostRepository;
        public ICourierMasterPostRepository PostCourierMaster => _courierMasterPostRepository ?? new CourierMasterPostRepository();

        private IGetCourierCompnayListRepository _getCourierCompnayListRepository;
        public IGetCourierCompnayListRepository GetCourierCompanyList => _getCourierCompnayListRepository ?? new GetCourierCompnayListRepository();
        private IOrderDetailsTempRepository _orderDetailsTempRepository;
        public IOrderDetailsTempRepository PostOrderDetailSTemp => _orderDetailsTempRepository ?? new OrderDetailsTempRepository();

        private IPostCourierAgreementRepository _postCourierAgreementRepository;
    

        private IOrderCreateRepository _orderCreateRepository;
        public IOrderCreateRepository OrderCreate => _orderCreateRepository?? new OrderCreateRepository();

        private IAddressDetailsPostRepository _addressDetailsPostRepository;
        public IAddressDetailsPostRepository PostAddress => _addressDetailsPostRepository??new AddressDetailsPostRepository();

        private IOrderHeaderDetailsRepository _orderHeaderDetailsRepository;
        public IOrderHeaderDetailsRepository GetOrderHeader => _orderHeaderDetailsRepository ?? new OrderHeaderDetailsRepository();

        private IOrderDetailsByOrderNoRepository _orderDetailsByOrderNoRepository;
        public IOrderDetailsByOrderNoRepository GetOrderDetailsByOrderNo => _orderDetailsByOrderNoRepository ?? new OrderDetailsByOrderNoRepository();
        private IOrderPickerRepository _orderPickerRepository;
        public IOrderPickerRepository GetOrderPickerByOrderNo => _orderPickerRepository ?? new OrderPickerRepository();
        private IOrderProcessRepository _orderProcessRepository;
        public IOrderProcessRepository OrderProcess => _orderProcessRepository?? new OrderProcessRepository();

        private IGetAllArticleDetailsForMobileAppRepository _getAllArticleDetailsForMobileAppRepository;
        public IGetAllArticleDetailsForMobileAppRepository GetAllArticleDetailsDataForMobile => _getAllArticleDetailsForMobileAppRepository ?? new GetAllArticleDetailsForMobileAppRepository();
        private IGetArticleWiseImageRepository _getArticleImage;
        public IGetArticleWiseImageRepository GetArticleImage => _getArticleImage ?? new GetArticleWiseImageRepository();
        private IGetArticleVariantsRepository _getArticleVariants;
        public IGetArticleVariantsRepository GetArticleVariant => _getArticleVariants ?? new GetArticleVariantsRepository();
        private IRegCustomerPostRepository _regPostCustomer;
        public IRegCustomerPostRepository PostRegCustomer => _regPostCustomer?? new RegCustomerPostRepository(_context);
        private IGetNewArraivalsArticleRepository _getNewArraivalsArticleRepository;
        public IGetNewArraivalsArticleRepository GetAllNewArraivalArticle => _getNewArraivalsArticleRepository ?? new GetNewArraivalsArticleRepository();
        private IGetAllBeastDealsArticleRepository _getAllBeastDealsArticleRepository;
        public IGetAllBeastDealsArticleRepository GetAllBestDealsArticle => _getAllBeastDealsArticleRepository ?? new GetAllBeastDealsArticleRepository();
        private IGetAllKidsAricleRepository _getAllKidsAricleRepository;
        public IGetAllKidsAricleRepository GetAllKidsArticle => _getAllKidsAricleRepository ?? new GetAllKidsAricleRepository();
        private IGetAllMansArticleRepository _mansArticleRepository;
        public IGetAllMansArticleRepository GetAllMansArticle => _mansArticleRepository ?? new GetAllMansArticleRepository();
        private IGetAllWomensArticleRepository _getAllWomensArticle;
        public IGetAllWomensArticleRepository GetAllWomemnsArticle => _getAllWomensArticle ?? new GetAllWomensArticleRepository();
        private IGetCategorizedArticleRepository _getCategorizedArticle;
        public IGetCategorizedArticleRepository GetCategorizedArticle => _getCategorizedArticle ?? new GetCategorizedArticleRepository();
        private IOrderCustomerPostRepository _orderCustomerPost;
        public IOrderCustomerPostRepository OrderPost => _orderCustomerPost??new OrderCustomerPostRepository(_context);
        private IOrderDetailsPostRepository _orderDetailsPost;
        public IOrderDetailsPostRepository OrderDetailsPost => _orderDetailsPost?? new OrderDetailsPostRepository(_context);
        private IGetAddToCartArticleRepository _getAddToCartArticle;
        public IGetAddToCartArticleRepository GetAddToCartArticle => _getAddToCartArticle?? new GetAddToCartArticleRepository();
        private IPartialUpdateRepository _partialUpdate;
        public IPartialUpdateRepository PartialUpdate => _partialUpdate??new PartialUpdateRepository();
        private IPostBillingAddressRepository _postBillingAddress;
        public IPostBillingAddressRepository BillingAddress => _postBillingAddress?? new PostBillingAddressRepository(_context);
        private IPostShippingAddressRepository _postShippingAddress;
        public IPostShippingAddressRepository ShippingAddress => _postShippingAddress?? new PostShippingAddressRepository(_context);
        private IGetDefaultBillingAddressRepository _getDefaultBillingAddress;
        public IGetDefaultBillingAddressRepository GetDefaultBillingAddress => _getDefaultBillingAddress??new GetDefaultBillingAddressRepository();
        private IGetDefaultShippingAddressRepository _getDefaultShipping;
        public IGetDefaultShippingAddressRepository GetDefaultShippingAddress => _getDefaultShipping??new GetDefaultShippingAddressRepository();
        private IGetShippingAddressListRepository _getShippingAddress;
        public IGetShippingAddressListRepository GetShippingAdreesList => _getShippingAddress??new GetShippingAddressListRepository();
        private IGetBillingAddressListRepository _getBillingAddressList;
        public IGetBillingAddressListRepository GetBillingAdreesList => _getBillingAddressList?? new GetBillingAddressListRepository();
        private IGetArticleCatDiscountRepository _getArticleCat;
        public IGetArticleCatDiscountRepository GetDiscountForCatArticle => _getArticleCat??new GetArticleCatDiscountRepository();
        private IGetSubCatDiscountArticleRepository _getDiscountSubCatFor;
        public IGetSubCatDiscountArticleRepository GetDiscountForSubCatArticle => _getDiscountSubCatFor??new GetSubCatDiscountArticleRepository();
        private IGetSubSubCatDiscountArticleRepository _getSubSubCatDiscountArticleRepository;
        public IGetSubSubCatDiscountArticleRepository GetDiscountForSubSubCatArticle => _getSubSubCatDiscountArticleRepository?? new GetSubSubCatDiscountArticleRepository();
        private readonly IGetSubSubSCatDiscountArticleRepository _getSubSubSCatDiscountArticle;
        public IGetSubSubSCatDiscountArticleRepository GetDiscountForSubSubSCatArticle => _getSubSubSCatDiscountArticle??new GetSubSubSCatDiscountArticleRepository();
        private IDiscountDetailsSettingsRepository _discountDetailsSettings;
        public IDiscountDetailsSettingsRepository DiscountDetail => _discountDetailsSettings?? new DiscountDetailsSettingsRepository(_context);
        private ISettingsDiscountTimeRepository _settingsDiscountTime;
        public ISettingsDiscountTimeRepository DiscountTime => _settingsDiscountTime??new SettingsDiscountTimeRepository(_context);
        private ISettingsDiscoutBannerRepository _settingsDiscoutBanner;
        public ISettingsDiscoutBannerRepository BannerInfo => _settingsDiscoutBanner?? new SettingsDiscoutBannerRepository(_context);
    }
}
