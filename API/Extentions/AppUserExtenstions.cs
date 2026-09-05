using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entites;
using API.Interfaces;

namespace API.Extentions
{
    public static class AppUserExtenstions
    {
        public static UserDTO ToDto(this AppUser user,ITokenService tokenService)
        {
            return new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}