using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Models;
using Activities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Activities.Controllers
{
    public class UsersInRowsController : Controller
    {
        private readonly AppDbContext _context;

        public UsersInRowsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UsersInRowEntities
        public async Task<IActionResult> Index(int idRow)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<UsersInRowEntity> list;

            list = await _context.UsersInRow
                .Where(x => x.RowId == idRow && x.IsActive)
                .ToListAsync();
            list.ForEach(item =>
            {
                item.User = _context.User.Where(x => x.Id == item.UserId).FirstOrDefault();
            });

            ViewBag.IdRow = idRow;
            return View(list);
        }

        // GET: UsersInRowEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var usersInRowEntity = await _context.UsersInRow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersInRowEntity == null)
            {
                return NotFound();
            }

            return View(usersInRowEntity);
        }

        // GET: UsersInRowEntities/Create
        public IActionResult Create(int idRow)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<UserEntity> list;
            List<UserEntity> listFiltered;
            List<UserEntity> listUser;

            listUser = _context.UsersInRow.Where(x => x.RowId == idRow && x.IsActive).Select(x =>x.User).ToList();
            list = _context.User.Where(x => x.IsActive).ToList();
            listFiltered = list.Except(listUser).ToList();            

            ViewData["ListUsers"] = new SelectList(listFiltered, SelectProperty.Id, SelectProperty.Name);
            ViewData["IdRow"] = idRow;

            return View();
        }

        // POST: UsersInRowEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RowId,Id,DateRegistration,IsActive")] UsersInRowEntity usersInRowEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            usersInRowEntity.IsActive = true;
            usersInRowEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(usersInRowEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Activities");
            }
            ViewData["ListUsers"] = new SelectList(_context.User.Where(x => x.IsActive).ToList(), SelectProperty.Id, SelectProperty.Name);
            ViewData["IdRow"] = usersInRowEntity.RowId;

            return View(usersInRowEntity);
        }

        // GET: UsersInRowEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var usersInRowEntity = await _context.UsersInRow.FindAsync(id);
            if (usersInRowEntity == null)
            {
                return NotFound();
            }
            return View(usersInRowEntity);
        }

        // POST: UsersInRowEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdRow,Id,DateRegistration,IsActive")] UsersInRowEntity usersInRowEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id != usersInRowEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersInRowEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersInRowEntityExists(usersInRowEntity.Id))
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
            return View(usersInRowEntity);
        }

        // GET: UsersInRowEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var usersInRowEntity = await _context.UsersInRow
                .Include(x => x.Row)
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (usersInRowEntity == null)
            {
                return NotFound();
            }

            return View(usersInRowEntity);
        }

        // POST: UsersInRowEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            var usersInRowEntity = await _context.UsersInRow
                .FindAsync(id);
            usersInRowEntity.IsActive = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Activities");
        }

        private bool UsersInRowEntityExists(int id)
        {
            return _context.UsersInRow.Any(e => e.Id == id);
        }
    }
}
