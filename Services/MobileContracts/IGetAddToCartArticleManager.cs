﻿using ShopModels.MobileViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileContracts
{
    public interface IGetAddToCartArticleManager
    {
        List<AddToCartGetVM> GetAddToCartArticle(long CustId);
    }
}
