using Microsoft.AspNetCore.Mvc;
using OnelineWalmart.Auth.Models;
using OnelineWalmart.Auth.Services;

namespace OnelineWalmart.Auth.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("order")]
    public ActionResult<AuthToken> GetProductsAuthentication(AuthUser user)
    {
        if (user.Username != "order_user" || user.Password != "123")
        {
            return BadRequest(new { message = "Username or Password is invalid" });
        }

        return new ProductsApiTokenService().GenerateToken(user);
    }
}
