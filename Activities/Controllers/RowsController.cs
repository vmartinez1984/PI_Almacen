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
    public class RowsController : Controller
    {
        private readonly AppDbContext _context;

        public RowsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RowEntities
        public async Task<IActionResult> Index(int? idActivity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            return View(await _context.Row.Where(x => x.ActivityId == idActivity && x.IsActive == true).ToListAsync());
        }

        // GET: RowEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row
                .Include(x => x.Activity)
                .Include(x => x.ListFiles.Where(x => x.IsActive))
                    .ThenInclude(x => x.User)
                .Include(x => x.ListComments.Where(x => x.IsActive))
                    .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rowEntity == null)
            {
                return NotFound();
            }

            return View(rowEntity);
        }

        // GET: RowEntities/Create
        public IActionResult Create(int idActivity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            ViewBag.IdActivity = idActivity;
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View();
        }

        // POST: RowEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,UserId,RowStatusId,DateStop,DateStart,Name,Description,Id,DateRegistration,IsActive")] RowEntity rowEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            rowEntity.IsActive = true;
            rowEntity.DateRegistration = DateTime.Now;
            rowEntity.UserId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            if (ModelState.IsValid)
            {
                _context.Add(rowEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Activities");
            }

            ViewBag.IdActivity = rowEntity.ActivityId;
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRowStatus([Bind("ActivityId,UserId,RowStatusId,DateStop,DateStart,Name,Description,Id,DateRegistration,IsActive")] RowEntity rowEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            RowEntity rowEntityOriginal;

            rowEntityOriginal = _context.Row.Where(x => x.Id == rowEntity.Id).FirstOrDefault();
            rowEntityOriginal.RowStatusId = rowEntity.RowStatusId;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Activities");
        }

        // GET: RowEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row.FindAsync(id);
            if (rowEntity == null)
            {
                return NotFound();
            }
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View(rowEntity);
        }

        // POST: RowEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,UserId,RowStatusId,DateStop,DateStart,Name,Description,Id,DateRegistration,IsActive")] RowEntity rowEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id != rowEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rowEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RowEntityExists(rowEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Activities");
            }

            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);
            return View(rowEntity);
        }

        // GET: RowEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row.Include(x => x.Activity).Include(x => x.RowStatus).Include(x => x.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rowEntity == null)
            {
                return NotFound();
            }

            return View(rowEntity);
        }

        // POST: RowEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            var rowEntity = await _context.Row.FindAsync(id);
            rowEntity.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Activities");
        }

        private bool RowEntityExists(int id)
        {
            return _context.Row.Any(e => e.Id == id);
        }
    }
}
