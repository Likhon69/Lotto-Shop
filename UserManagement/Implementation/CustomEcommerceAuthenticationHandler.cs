using ECommerceDbContext;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace UserManagement.Implementation
{
    public class CustomEcommerceAuthenticationHandler
    {
        public class BasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
        {

        }
        public class CustomauthenticationHandler : AuthenticationHandler<BasicAuthenticationSchemeOptions>
        {
            private readonly ECommerceDatabaseContext _db;
            public CustomauthenticationHandler(
                IOptionsMonitor<BasicAuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock,
                ECommerceDatabaseContext db
                ) : base(options, logger, encoder, clock)
            {
                _db = db;
            }
            protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                string res = "";
                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.Fail("UnAuthorized");
                string authorization = Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorization))
                    return AuthenticateResult.Fail("UnAuthorized");
                if (!authorization.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                    return AuthenticateResult.Fail("UnAuthorized");

                string token = authorization.Substring("bearer".Length).Trim();

                if (string.IsNullOrEmpty(token))
                    return AuthenticateResult.Fail("UnAuthorized");

                try
                {
                    string stream = token;
                    var handler = new JwtSecurityTokenHandler();
                    var read = handler.ReadToken(stream);
                    var readToken = handler.ReadToken(stream) as JwtSecurityToken;

                    var user = readToken.Claims.First(c => c.Type == ClaimTypes.Name).Value;
                    return TokenValidate(user);

                }
                catch (Exception ex)
                {
                    res = ex.Message;

                    return AuthenticateResult.Fail(ex.Message);
                }
            }

            private AuthenticateResult TokenValidate(string userId)
            {
                var id = Int32.Parse(userId);
                var user = _db.Users.FirstOrDefault(c => c.User_Id == id);

                var claim = new List<Claim>{
                new Claim(ClaimTypes.Name,user.UserName)
                   };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new GenericPrincipal(identity, null);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
        }
    }
}
