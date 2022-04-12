using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activities.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Api/Users")]
        public async Task<IActionResult> GetUsers()
        {

            var list = await _context.User.Include(x => x.Role).Where(x => x.IsActive)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    lastName = x.LastName
                })
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet]
        [Route("/Api/Chat/{userIdSource}/{userIdDestiny}")]
        public async Task<IActionResult> GetChat(int userIdSource,int userIdDestiny)
        {
            return Ok();
        }
    }
}
