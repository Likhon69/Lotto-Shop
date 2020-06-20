using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
