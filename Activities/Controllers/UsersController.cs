using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Activities.Helpers;

namespace Activities.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserEntities
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<UserEntity> list;

            list = await _context.User.Include(x => x.Role).Where(x=> x.IsActive).ToListAsync();

            return View(list);
        }      

        // GET: UserEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User.Include(x=> x.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // GET: UserEntities/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            ViewBag.ListRoles = new SelectList(_context.Role.Where(x => x.IsActive).ToList(), "Id", "Name");
            return View();
        }

        // POST: UserEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,ConfirmPassword,RoleId,Name,LastName,Phone,Email,Id,DateRegistration,IsActive")] UserEntity userEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            userEntity.IsActive = true;
            userEntity.DateRegistration = DateTime.Now;            
            if (ModelState.IsValid)
            {
                _context.Add(userEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ListRoles = new SelectList(_context.Role.Where(x => x.IsActive).ToList(), "Id", "Name");
            return View(userEntity);
        }

        // GET: UserEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            ViewBag.ListRoles = new SelectList(_context.Role.Where(x => x.IsActive).ToList(), "Id", "Name");

            return View(userEntity);
        }

        // POST: UserEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserName,Password,ConfirmPassword, RoleId,Name,LastName,Phone,Email,Id")] UserEntity userEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id != userEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UserEntity userEntityOriginal;

                    userEntityOriginal = _context.User.Where(x => x.Id == id).FirstOrDefault();
                    userEntityOriginal.UserName = userEntity.UserName;  
                    userEntityOriginal.Email = userEntity.Email;
                    userEntityOriginal.Password = userEntity.Password;
                    userEntityOriginal.LastName = userEntity.LastName;  
                    userEntityOriginal.Name = userEntity.Name;  
                    userEntityOriginal.RoleId = userEntity.RoleId;  
                    userEntityOriginal.Phone = userEntity.Phone;
                    userEntityOriginal.Email = userEntity.Email;
                    _context.Update(userEntityOriginal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEntityExists(userEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userEntity);
        }

        // GET: UserEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // POST: UserEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            var userEntity = await _context.User.FindAsync(id);
            //_context.User.Remove(userEntity);
            userEntity.IsActive = false;    
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEntityExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
