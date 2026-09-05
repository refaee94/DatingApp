using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entites;
using API.Extentions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController(AppDbContext dbContext, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {

                    if (await UserExists(registerDTO.Email)) return BadRequest("Email is already taken");

            var DisplayName = registerDTO.DisplayName;
            var Email = registerDTO.Email;
            var Password = registerDTO.Password;    
        {

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Email = Email.ToLower(),
                DisplayName = DisplayName,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(); 
        {

    return user.ToDto(tokenService);       }


          
    }}
    
    [HttpPost("login")] 
public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email);

            if (user == null) return Unauthorized("Invalid email");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

        return user.ToDto(tokenService);       }


    private async Task<bool> UserExists(string email)
        {
            return await dbContext.Users.AnyAsync(x => x.Email == email.ToLower());
        } 
}


}