using AutoMapper;
using CommonUnitOfWork;
using Services.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DiscountSettingsManager : IDiscountSettingsManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public DiscountSettingsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public string DiscountSettings(DiscountDetailsVM model, string loginId)
        {
            try
            {
                DiscountTime aDiscountT = new DiscountTime();
                aDiscountT.DateOfEntry = DateTime.Now;
                aDiscountT.DiscountFromDate = model.DiscountDetails.FromDate;
                aDiscountT.DiscountTimeTo = model.DiscountDetails.ToDate;
                aDiscountT.EnteredBy = loginId;
                aDiscountT.UpdatedAt = DateTime.Now;
                aDiscountT.UpdatedBy = loginId;
                foreach(var item in model.DiscountArticle)
                {
                    var percentage = model.DiscountDetails.DiscountPercentage;
                    var Pa = ((decimal)percentage/100);
                    DiscountDetail aDiscountD = new DiscountDetail();
                    var Price = _unitOfWork.Pricing.SingleOrDefault(c => c.ArticleDetails_Id == item.ArtD_Id).StandardPrice;
                    aDiscountD.DateOfEntry = DateTime.Now;
                    aDiscountD.DiscountPercentage = percentage;
                    aDiscountD.DiscountPrice = (Price-(Price * Pa));
                    aDiscountD.EnteredBy = loginId;
                    aDiscountD.UpdatedBy = loginId;
                    aDiscountD.ArticleId = item.ArtD_Id;
                    aDiscountT.DiscountDetails.Add(aDiscountD);
                }
                _unitOfWork.DiscountTime.Add(aDiscountT);
                
                BannerInfo aBanner = new BannerInfo();
                string finalImage = "";
                int pos = 12;
                if (pos != 0)
                {
                    // String after founder  
                    string afterFounder = model.DiscountDetails.Banner.Remove(pos);

                    // Remove everything before founder but include founder  
                    string beforeFounder = model.DiscountDetails.Banner.Remove(0, pos);
                    finalImage = beforeFounder;

                }
                aBanner.BannerImageName = finalImage;
                aBanner.BannerName = model.DiscountDetails.BannerName;
                aBanner.DateOfEntry = DateTime.Now;
                aBanner.EnteredBy = loginId;
                _unitOfWork.BannerInfo.Add(aBanner);
                _unitOfWork.Commit();
                foreach(var item in model.DiscountArticle)
                {
                    ArticleDetails articleDetails = new ArticleDetails();
                    articleDetails = _unitOfWork.ArticleDetails.GetById(item.ArtD_Id);
                    articleDetails.BannerId = aBanner.BannerId;
                    articleDetails.IsDiscount = true;
                    _unitOfWork.Commit();
                }
                return "success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
