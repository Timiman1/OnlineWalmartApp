using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnlineWallmart.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("products")]
        public ActionResult<AuthToken> GetProductsAuthentication(AuthUser user)
        {
            if (user.Username != "products_user" || user.Password != "123")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new ProductsApiTokenService().GenerateToken(user);
        }
    }
}