using Activities.Dtos;
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
                UserEntity usuario;

                usuario = _context.User.Where(x=> x.IsActive == true && x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault(); 
                if (usuario is null)
                {
                    ViewBag.Error = "Usuario y/o contraseña incorrectos";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetInt32("usuarioId", usuario.Id);
                    HttpContext.Session.SetInt32("perfilId", usuario.RoleId);
                    HttpContext.Session.SetString("usuarioNombre", $"{usuario.Name} {usuario.LastName}");                    

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }
            
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut(int id, IFormCollection collection)
        {            
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    }
}
