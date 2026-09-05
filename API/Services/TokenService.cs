using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using API.Entites;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string CreateToken(AppUser user)
        {
            var tokenKey = configuration["TokenKey"] ?? throw new Exception("Token key is missing in configuration.");
            if (tokenKey.Length < 64)
            {
                throw new Exception("Token key is less than 64 characters.");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.DisplayName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  
        }
    }}