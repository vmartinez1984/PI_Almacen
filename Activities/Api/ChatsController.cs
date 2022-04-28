using Activities.Dtos;
using Activities.Helpers;
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
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");
            int userId;

            userId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            var list = await _context.User.Include(x => x.Role).Where(x => x.IsActive && x.Id != userId)
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
        [Route("/Api/Users/Online")]
        public async Task<IActionResult> GetUsersOnline()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");
            int userId;

            userId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            var list = await _context.UserOnline.Include(x => x.User)
                .Where(x => x.Id != userId)
                .Select(x => new
                {
                    userId = x.UserId,
                    name = x.User.Name,
                    lastName = x.User.LastName,
                    online = x.IsActive
                })
                .ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Route("/Api/Users/Online")]
        public async Task<IActionResult> SetUserOnline(UserOnLine userOnLine)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");
            int userId;
            UserOnlineEntity userOnlineEntity;

            userId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            userOnlineEntity = await _context.UserOnline.Where(x => x.UserId == userOnLine.UserId).FirstOrDefaultAsync();
            if (userOnlineEntity != null)
            {
                userOnlineEntity.IsActive = true;
                await _context.SaveChangesAsync();
            };

            return Ok(new { online = true });
        }

        [HttpGet]
        [Route("/Api/Chat/{userIdSource}/{userIdDestiny}")]
        public async Task<IActionResult> GetChat(int userIdSource, int userIdDestiny)
        {
            var listChat = await _context.Chat
                .Where(x =>
                    (x.UserIdSource == userIdSource && x.UserIdDestiny == userIdDestiny)
                    ||
                    (x.UserIdSource == userIdDestiny && x.UserIdDestiny == userIdSource)
                )
                .OrderByDescending(x => x.Id)
                .Take(100)
                .ToListAsync();

            listChat.ForEach(item =>
            {
                item.UserSource = _context.User.Where(x => x.Id == item.UserIdSource).FirstOrDefault();
            });
            var list = listChat.Select(x => new
            {
                Id = x.Id,
                UserIdSource = x.UserIdSource,
                UserNameSource = x.UserSource.Name,
                Message = x.Message,
                Date = x.DateRegistration.ToShortTimeString()
            });


            return Ok(list);
        }

        [HttpGet]
        [Route("/Api/Chat/{chatId}/IsLast")]
        public async Task<IActionResult> IsLastChatId(int chatId)
        {
            var chat = await _context.Chat.Where(x => x.Id == chatId).FirstOrDefaultAsync();
            var lastChat = await _context.Chat
                 .Where(x =>
                    (x.UserIdSource == chat.UserIdSource && x.UserIdDestiny == chat.UserIdDestiny)
                    ||
                    (x.UserIdSource == chat.UserIdDestiny && x.UserIdDestiny == chat.UserIdSource)
                )
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (chatId == lastChat.Id)
                return Ok(new { IsLast = true });
            else
            {
                if (chatId < lastChat.Id)
                    return Ok(new { IsLast = false });
                else
                    return Ok(new { IsLast = true });
            }
        }

        [HttpGet]
        [Route("/Api/Chat/Messages/{userIdSource}")]
        public async Task<IActionResult> GetMessage(int userIdSource)
        {
            var list = await _context.Chat.Where(x => x.UserIdDestiny == userIdSource)
                .ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Route("/Api/Chat/")]
        public async Task<IActionResult> SendMessage(ChatEntity chat)
        {
            _context.Chat.Add(chat);
            await _context.SaveChangesAsync();

            return Ok(new { Id = chat.Id });
        }
    }
}
