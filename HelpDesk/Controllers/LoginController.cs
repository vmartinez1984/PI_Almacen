using HelpDesk.Dtos;
using HelpDesk.Helpers;
using HelpDesk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelpDesk.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LoginUsersController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginDto userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserEntity userEntity;

                    userEntity = _context.User.Where(x=> x.IsActive == true && x.UserName == userDto.UserName && x.Password == userDto.Password).FirstOrDefault();
                    if (userDto is null)
                    {
                        ViewBag.Error = "Usuario y/o contraseña no validos";
                        return View();
                    }
                    else
                    {
                        HttpContext.Session.SetInt32(SessionUser.Id, userEntity.Id);
                        HttpContext.Session.SetInt32("userRolId", userEntity.RolId);
                        HttpContext.Session.SetString("userName", $"{userEntity.Name} {userEntity.LastName}");

                        return RedirectToAction("Index", "Home");
                        //switch (userEntity.RolId)
                        //{
                        //    case Rol.Administrador:
                        //        return RedirectToAction("Index", "Administration");
                        //    //break;
                        //    case Rol.Empleado:
                        //        return RedirectToAction("Index", "EmployeeAssistance", new { area = "Employees" });
                        //    //break;
                        //    default:
                        //        return RedirectToAction("Index", "Home");
                        //        //break;
                        //}
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
