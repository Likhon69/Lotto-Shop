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
        private readonly IOrderHeaderDetailsManager _orderHeaderDetailsManager;
        private readonly IOrderDetailsByOrderNoManager _orderDetailsByOrderNoManager;
        public OrderController(IOrderCreateManager orderCreateManager, 
            IOrderHeaderDetailsManager orderHeaderDetailsManager,
           IOrderDetailsByOrderNoManager orderDetailsByOrderNoManager)
        {
            _orderCreateManager = orderCreateManager;
            _orderHeaderDetailsManager = orderHeaderDetailsManager;
            _orderDetailsByOrderNoManager = orderDetailsByOrderNoManager;
        }

        [HttpPost]
        public IActionResult OrderCreate(CreateOrderVm data)
        {
            var res = _orderCreateManager.PostOrderCreate(data);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetOrderHeaderDetails()
        {
            var res = _orderHeaderDetailsManager.GetOrderHeaderDetails();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailsByOrderNo(string id)
        {
            var res = _orderDetailsByOrderNoManager.GetOrderDetailsByOrderNo(id);
            return Ok(res);
        }
    }
}
