using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IPostCourierAgreementManager
    {
        int PostCourierAgreement(CourierAgreementVm model);
    }
}
