using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController: BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
           _context = context;
        }
   // api/users/
   [HttpGet]
   [AllowAnonymous]
  /* public ActionResult<IEnumerable<AppUser>> GetUsers()
   {
       var users = _context.Users.ToList();
       return users;
    
   }*/

 public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
   {
      return await _context.Users.ToListAsync();
       
    
   }

// api/users/id
 [Authorize]
 [HttpGet("{id}")]

 
  /* public ActionResult <AppUser> GetUser(int id)
   {
       var user = _context.Users.Find(id);
       return user;
    
   }*/

 public async Task<ActionResult <AppUser>> GetUser(int id)
   {
       return await _context.Users.FindAsync(id);
       
    
   }
  }
}