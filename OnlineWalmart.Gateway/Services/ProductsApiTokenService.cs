﻿using Gateway.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gateway.Services;

public class ProductsApiTokenService
{
    public AuthToken GenerateToken(AuthUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_products_api_secret"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var expirationDate = DateTime.UtcNow.AddMinutes(5);

        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(audience: "productsAudience",
                                         issuer: "productsIssuer",
                                         claims: claims,
                                         expires: expirationDate,
                                         signingCredentials: credentials);

        var authToken = new AuthToken();
        authToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
        authToken.ExpirationDate = expirationDate;

        return authToken;
    }
}
