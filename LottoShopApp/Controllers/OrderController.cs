using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceDbContext;
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
        private readonly IOrderPickerManager _orderPickerManager;
        private readonly IOrderProcessManager _orderProcessManager;
        private readonly ECommerceDatabaseContext _db;
        public OrderController(IOrderCreateManager orderCreateManager,
            IOrderHeaderDetailsManager orderHeaderDetailsManager,
           IOrderDetailsByOrderNoManager orderDetailsByOrderNoManager,
           IOrderPickerManager orderPickerManager,
           IOrderProcessManager orderProcessManager,
           ECommerceDatabaseContext db)
        {
            _orderCreateManager = orderCreateManager;
            _orderHeaderDetailsManager = orderHeaderDetailsManager;
            _orderDetailsByOrderNoManager = orderDetailsByOrderNoManager;
            _orderPickerManager = orderPickerManager;
            _orderProcessManager = orderProcessManager;
            _db = db;
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
            var td = "dsfddd";
            var res = _orderDetailsByOrderNoManager.GetOrderDetailsByOrderNo(id);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderPickerByOrderNo(string id)
        {

            if (id != null)
            {
                var res = _orderPickerManager.GetOrderPickerByOrderNo(id);

                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public IActionResult OrderProcess(string id)
       {

            var created_By = "";
            if (User.Identity.IsAuthenticated)
            {
                
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;


                var user = _db.Users.FirstOrDefault(c => c.UserName == userId);

                
                      created_By = user.LoginId;
                    
                

            }
            var res = _orderProcessManager.OrderProcess(id, created_By);
            return Ok(res);
        }

    }
}
