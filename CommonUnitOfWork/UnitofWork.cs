using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Contracts;
using Repository.Implementation;
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
        public IPostCourierAgreementRepository CourierAgreement => _postCourierAgreementRepository ?? new PostCourierAgreementRepository(_context);

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

        private IGetCategoryListRepository _getCategoryListRepository;
        public IGetCategoryListRepository CategoryList => _getCategoryListRepository ?? new GetCategoryListRepository();
        private IGetSubCategoryLIstRepository _getSubCategoryLIstRepository;
        public IGetSubCategoryLIstRepository SubCategoryList => _getSubCategoryLIstRepository?? new GetSubCategoryLIstRepository();
        private IGetSubSubCategoryRepository _getSubSubCategoryRepository;
        public IGetSubSubCategoryRepository SubSubCategoryList =>_getSubSubCategoryRepository?? new GetSubSubCategoryRepository();
    }
}
