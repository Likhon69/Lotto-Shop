using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IDiscountSettingsManager
    {
        string DiscountSettings(DiscountDetailsVM model, string loginId);
    }
}
