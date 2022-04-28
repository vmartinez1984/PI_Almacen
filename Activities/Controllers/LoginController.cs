using Activities.Dtos;
using Activities.Helpers;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Activities.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
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

                user = _context.User.Where(x => x.IsActive == true && x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault();
                if (user is null)
                {
                    ViewBag.Error = "Usuario y/o contraseña incorrectos";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetInt32(SessionUser.Id, user.Id);
                    HttpContext.Session.SetInt32(SessionUser.RoleId, user.RoleId);
                    HttpContext.Session.SetString(SessionUser.FullName, user.FullName);
                    UserOnlineEntity userOnlineEntity;
                    List<UserOnlineEntity> list;

                    list = _context.UserOnline.ToList();
                    list.ForEach(item =>
                    {
                        item.IsActive = false;
                    });
                    userOnlineEntity = _context.UserOnline.Where(x => x.UserId == user.Id).FirstOrDefault();
                    if (userOnlineEntity is null)
                    {
                        userOnlineEntity = new UserOnlineEntity
                        {
                            DateRegistration = DateTime.Now,
                            IsActive = true,
                            UserId = user.Id
                        };
                        _context.UserOnline.Add(userOnlineEntity);
                    }
                    else
                    {
                        userOnlineEntity.IsActive = true;
                        userOnlineEntity.DateRegistration = DateTime.Now;
                    }
                    _context.SaveChanges();

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

            if (HttpContext.Session.GetInt32(SessionUser.Id) != null)
            {
                UserOnlineEntity userOnlineEntity;
                userOnlineEntity = _context.UserOnline
                    .Where(x => x.UserId == (int)HttpContext.Session.GetInt32(SessionUser.Id))
                    .FirstOrDefault();
                userOnlineEntity.IsActive = false;
                _context.SaveChanges();
            }
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    }
}
