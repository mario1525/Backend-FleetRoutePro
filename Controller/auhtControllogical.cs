using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entity;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Data.Models;

namespace Controller
{
    public class authControllogical
    {

        public authControllogical()
        {

        }

        public Token GenerateJwtToken(UsersModels user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6F4A5D7B0E3C1A8F2B9D0C1E4F5A2C1B1A0D3F6E7B8A9C0B2D1E2F3C4A5B6"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, user.User),
                 new Claim("role", user.Rol),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Puedes agregar más claims según tus necesidades
            };

            var token = new JwtSecurityToken(
                issuer: "TuIssuer",
                audience: "TuAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Ajusta la expiración según tus necesidades
                signingCredentials: credentials
            );
            Token token1 = new Token();
            token1.token = new JwtSecurityTokenHandler().WriteToken(token);

            return token1;
        }
    }
}
