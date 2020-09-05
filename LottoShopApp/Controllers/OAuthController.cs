using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Description;
using ECommerceDbContext;

using ECommerceDbContext.ECOMDBENTITIES;
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
        private readonly ECOMDBContext _db;
        public OAuthController(ITokenEcommerceAuthentication tokenEcommerceAuthentication, ECOMDBContext db)
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

       /* [HttpPost]
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
        }*/
        

       
                         
               
       

           
               
        
    }
}

