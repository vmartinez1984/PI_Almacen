using Activities.Dtos;
using Activities.Helpers;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Activities.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController (AppDbContext context)
        {
            _context = context;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }


        // POST: LoginController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginDto userLogin)
        {
            if (ModelState.IsValid)
            {
                UserEntity user;

                user = _context.User.Where(x=> x.IsActive == true && x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault(); 
                if (user is null)
                {
                    ViewBag.Error = "Usuario y/o contraseña incorrectos";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetInt32(SessionUser.Id, user.Id);
                    HttpContext.Session.SetInt32("rolId", user.RoleId);
                    HttpContext.Session.SetString("userName", $"{user.Name} {user.LastName}");                    

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }
            
        [HttpGet]        
        public ActionResult LogOut()
        {            
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    }
}
