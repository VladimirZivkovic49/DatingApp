using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly DataContext _context;
    private readonly ITokenService _tokenService;
        public   AccountController(DataContext context,ITokenService tokenService)
        {
           _tokenService=tokenService;
            _context=context;
        }
  
   [HttpPost("register")]
   public async Task <ActionResult<UserDTO/*AppUser*/>>Register(RegisterDto registerDto/*string username, string password*/)
   {
      
      if(await UserExsists(registerDto.Username)) return BadRequest("Username is taken");
     
      
       using var hmac= new HMACSHA512();

       var user = new AppUser
       {

        UserName= registerDto.Username.ToLower()/*username*/,
        PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password/*password*/)),
        PasswordSalt = hmac.Key

       };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return /*user*/ new UserDTO
            {
                    Username=user.UserName,
                    Token=_tokenService.CreateToken(user)

            };
   }
[HttpPost("login")]
public async Task <ActionResult<UserDTO/*AppUser*/>>Login(LoginDto loginDto/*string username, string password*/)
   {
  
  var user =await _context.Users.SingleOrDefaultAsync(x=>x.UserName==loginDto.Username);
  if(user==null) return Unauthorized("Invalid Username");
 using var hmac= new HMACSHA512(user.PasswordSalt);
 var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password/*password*/));

 for (int i=0;i<computedHash.Length;i++)
 
   {
   if(computedHash[i]!= user.PasswordHash[i]) return Unauthorized("Wrong password");
   
   }
 return /*user*/ new UserDTO
            {
                    Username=user.UserName,
                    Token=_tokenService.CreateToken(user)

            };
  
  
  
   }
private async Task<bool> UserExsists(string username)
{
return await _context.Users.AnyAsync(x=>x.UserName==username.ToLower());
}
 
  
    }
}