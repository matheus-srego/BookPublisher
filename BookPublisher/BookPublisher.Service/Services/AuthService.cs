using BookPublisher.Domain.Constants;
using BookPublisher.Domain.DTOs;
using BookPublisher.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookPublisher.Service.Services
{
    public static class AuthService
    {
        public static string GenerateToken(LoginDTO dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(CONFIGURATION.SECRET_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    // new Claim(ClaimTypes.Name, model.Name.ToString()),
                    new Claim(ClaimTypes.Email, dto.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
