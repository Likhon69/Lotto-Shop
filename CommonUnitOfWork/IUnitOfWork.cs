using Repository.Contracts;
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
        int Commit();
    }
}
