using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CustomerController : ControllerBase
    {
        private readonly IAddressDetailsPostManager _addressDetailsPostManager;
        public CustomerController(IAddressDetailsPostManager addressDetailsPostManager)
        {
            _addressDetailsPostManager = addressDetailsPostManager;
        }

        [HttpPost]
        public IActionResult PostAddress(AddressDetailsVm model)
        {
            var res = _addressDetailsPostManager.PostAddressDetails(model);

            return Ok(res);
        }
      
    }
}
