using AutoMapper;
using CommonUnitOfWork;
using Services.MobileContracts;
using ShopModels.MobileViewModel;
using ShopModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MobileImplementation
{
    public class PostCustomerAddressManager: IPostCustomerAddressManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public PostCustomerAddressManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string PostDeliveryAddress(DeliveryAddressVM address)
        {
            var CustAddressBil = _mapper.Map<BillingAddress>(address);
            var CustAddressShip = _mapper.Map<ShippingAddress>(address);
            try
            {
                var AddressInfoB = _unitOfWork.BillingAddress.GetById(address.CustomerId);
                var AddressInfoSH = _unitOfWork.ShippingAddress.GetById(address.CustomerId);
                if (address.ShippingId == 0 && address.BillingId==0)
                {
                    var shippingAd = _unitOfWork.ShippingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                    var billigAd = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                    if (address.IsDeafultAddress == true && shippingAd!=null && billigAd !=null)
                    {
                        ShippingAddress aShipping = new ShippingAddress();
                        BillingAddress aBilling = new BillingAddress();
                        aShipping = _unitOfWork.ShippingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                        aBilling = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                        aShipping.IsDeafultAddress = false;
                        aBilling.IsDeafultAddress = false;
                        _unitOfWork.Commit();

                    }
                    CustAddressShip.DateOfEntry = DateTime.Now;
                    CustAddressBil.DateOfEntry = DateTime.Now;
                    _unitOfWork.BillingAddress.Add(CustAddressBil);
                    _unitOfWork.ShippingAddress.Add(CustAddressShip);
                    _unitOfWork.Commit();

                }
                else if(address.ShippingId!=0)
                {
                    ShippingAddress aShippingUC = new ShippingAddress();
                    if (address.IsDeafultAddress == true)
                    {
                        aShippingUC = _unitOfWork.ShippingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                    }
                   /* var billigAd = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress );*/
                    if (address.IsDeafultAddress == true && aShippingUC != null)
                    {
                        ShippingAddress aShippingU = new ShippingAddress();
                        BillingAddress aBilling = new BillingAddress();
                        aShippingU = _unitOfWork.ShippingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                       /* aBilling = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);*/
                        aShippingU.IsDeafultAddress = false;
                        //aBilling.IsDeafultAddress = false;
                        _unitOfWork.Commit();

                    }
                    ShippingAddress aShipping = new ShippingAddress();
                    aShipping = _unitOfWork.ShippingAddress.GetById(address.ShippingId);
                    aShipping.RegionId = address.RegionId;
                    aShipping.CityId = address.CityId;
                    aShipping.AreaId = address.AreaId;
                    aShipping.CustName = address.CustName;
                    aShipping.CustPhone = address.CustPhone;
                    //aShipping.CustomerId = address.CustomerId;
                    aShipping.Address = address.Address;
                    aShipping.DateOfEntry = DateTime.Now;
                    aShipping.IsDeafultAddress = address.IsDeafultAddress;
                    aShipping.IsHome = address.IsHome;
                    aShipping.IsOffice = address.IsOffice;
                    _unitOfWork.Commit();
                }
                else if (address.BillingId != 0)
                {
                   
                    BillingAddress aBillingC = new BillingAddress();
                    if (address.IsDeafultAddress == true)
                    {
                        aBillingC = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                    }
                    if (address.IsDeafultAddress == true  && aBillingC != null)
                    {
                        ShippingAddress aShipping = new ShippingAddress();
                        BillingAddress aBillingU = new BillingAddress();
                       /* aShipping = _unitOfWork.ShippingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);*/
                        aBillingU = _unitOfWork.BillingAddress.SingleOrDefault(c => c.CustomerId == address.CustomerId && c.IsDeafultAddress == address.IsDeafultAddress);
                        //aShipping.IsDeafultAddress = false;
                        aBillingU.IsDeafultAddress = false;
                        _unitOfWork.Commit();

                    }
                    BillingAddress aBilling = new BillingAddress();
                    aBilling = _unitOfWork.BillingAddress.GetById(address.BillingId);
                    aBilling.RegionId = address.RegionId;
                    aBilling.CityId = address.CityId;
                    aBilling.AreaId = address.AreaId;
                    aBilling.CustName = address.CustName;
                    aBilling.CustPhone = address.CustPhone;
                    //aShipping.CustomerId = address.CustomerId;
                    aBilling.Address = address.Address;
                    aBilling.DateOfEntry = DateTime.Now;
                    aBilling.IsDeafultAddress = address.IsDeafultAddress;
                    aBilling.IsHome = address.IsHome;
                    aBilling.IsOffice = address.IsOffice;
                    _unitOfWork.Commit();
                }

                    return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
