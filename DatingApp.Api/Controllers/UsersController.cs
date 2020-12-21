using DatingApp.Api.Data;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.Api.Controllers
{
    
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context): base(context)
        {
            _context = context;
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetUsers(){
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        //api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            return Ok(user);
        }
    }
}