using AutoMapper;
using ShopModels.MobileViewModel;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp.Configuration
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            
            CreateMap<ArticleDetails, ArticleDetailsData>();
            CreateMap<ArticleDetailsData, ArticleDetails>();

            CreateMap<Pricing, ArticleDetailsData>();
            CreateMap<ArticleDetailsData, Pricing>();
            CreateMap<CourierCompanyMaster, CourierDetailsVm>();
            CreateMap<CourierDetailsVm, CourierCompanyMaster>();
            CreateMap<CourierContactPerson, ContactPersonVm>();
            CreateMap<ContactPersonVm, CourierContactPerson>();
            /* CreateMap<CourierCompanyMasters, CourierDetailsVm>();
             CreateMap<CourierDetailsVm, CourierCompanyMasters>();
             CreateMap<CourierContactPersons, ContactPersonVm>();
             CreateMap<ContactPersonVm, CourierContactPersons>();*/
            CreateMap<OrderDetail, OrderVM>();
            CreateMap<OrderVM, OrderDetail>();
            CreateMap<BillingAddress, DeliveryAddressVM>();
            CreateMap<DeliveryAddressVM, BillingAddress>();
            CreateMap<ShippingAddress, DeliveryAddressVM>();
            CreateMap<DeliveryAddressVM, ShippingAddress>();
        }
    }
}
