using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Description;
using ECommerceDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopModels.Models;
using ShopModels.OrderModels;
using ShopModels.ViewModel;
using UserManagement.Contracts;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class OAuthController : ControllerBase
    {

        private readonly ITokenEcommerceAuthentication _tokenEcommerceAuthentication;
        private readonly ECommerceDatabaseContext _db;
        public OAuthController(ITokenEcommerceAuthentication tokenEcommerceAuthentication, ECommerceDatabaseContext db)
        {
            _tokenEcommerceAuthentication = tokenEcommerceAuthentication;
            _db = db;
        }
        
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public IActionResult GetAuthentication(UserDto model)
        {
            var token = _tokenEcommerceAuthentication.Authentication(model);
            if (token != null)
            {
                return Ok(new { token });
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;


                var user = _db.Users.FirstOrDefault(c => c.UserName == userId);
                return Ok(new
                {
                    user.UserName,
                    user.Email
                });


            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostTest(TestClass1 model)
        {
            if (ModelState.IsValid)
            {
                _db.TestClass1s.Add(model);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult ArticleSizeVariant(ArticleVariantDto Age)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_db.Customers);
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpGet]
        // GET: api/Order
        public IActionResult GetOrders()
        {
            var result = (from a in _db.Orders
                          join b in _db.Customers on a.CustomerID equals b.CustomerID

                          select new
                          {
                              a.OrderID,
                              a.OrderNo,
                              Customer = b.Name,
                              a.PMethod,
                              a.GTotal
                          }).ToList();

            return Ok(result);
        }

        [HttpGet]
        // GET: api/Order/5
        [ResponseType(typeof(Order))]
        public IActionResult GetOrder(long id)
        {
            var order = (from a in _db.Orders
                         where a.OrderID == id

                         select new
                         {
                             a.OrderID,
                             a.OrderNo,
                             a.CustomerID,
                             a.PMethod,
                             a.GTotal,
                             DeletedOrderItemIDs = ""
                         }).FirstOrDefault();

            var orderDetails = (from a in _db.OrderItems
                                join b in _db.Items on a.ItemID equals b.ItemID
                                where a.OrderID == id

                                select new
                                {
                                    a.OrderID,
                                    a.OrderItemID,
                                    a.ItemID,
                                    ItemName = b.Name,
                                    b.Price,
                                    a.Quantity,
                                    Total = a.Quantity * b.Price
                                }).ToList();

            return Ok(new { order, orderDetails });
        }
        [HttpPost]
        // POST: api/Order
        [ResponseType(typeof(Order))]
        public IActionResult PostOrder(Order order)
        {
            try
            {
                //Order table
                if (order.OrderID == 0)
                    _db.Orders.Add(order);
                else
                    _db.Entry(order).State = EntityState.Modified;

                //OrderItems table
                foreach (var item in order.OrderItems)
                {
                    if (item.OrderItemID == 0)
                        _db.OrderItems.Add(item);
                    else
                        _db.Entry(item).State = EntityState.Modified;
                }

                //Delete for OrderItems
                foreach (var id in order.DeletedOrderItemIDs.Split(',').Where(x => x != ""))
                {
                    OrderItem x = _db.OrderItems.Find(Convert.ToInt64(id));
                    _db.OrderItems.Remove(x);
                }


                _db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete]
        // DELETE: api/Order/5
        [ResponseType(typeof(Order))]
        public IActionResult DeleteOrder(long id)
        {
            Order order = _db.Orders.Include(y => y.OrderItems)
                .SingleOrDefault(x => x.OrderID == id);

            foreach (var item in order.OrderItems.ToList())
            {
                _db.OrderItems.Remove(item);
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return Ok(order);
        }



        private bool OrderExists(long id)
        {
            return _db.Orders.Count(e => e.OrderID == id) > 0;
        }
    }
}

