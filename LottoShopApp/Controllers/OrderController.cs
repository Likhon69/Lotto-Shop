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
    public class OrderController : ControllerBase
    {
        private readonly IOrderCreateManager _orderCreateManager;
        public OrderController(IOrderCreateManager orderCreateManager)
        {
            _orderCreateManager = orderCreateManager;
        }

        [HttpPost]
        public IActionResult TestData(CreateOrderVm data)
        {
            var res = _orderCreateManager.PostOrderCreate(data);
            return Ok(res);
        }
    }
}
