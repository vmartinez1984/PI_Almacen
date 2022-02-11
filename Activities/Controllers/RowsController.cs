using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Models;
using Activities.Helpers;

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
        public async Task<IActionResult> Index(int idActivity)
        {
            return View(await _context.Row.Where(x => x.IdActivity == idActivity && x.IsActive == true).ToListAsync());
        }

        // GET: RowEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row
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
            ViewBag.IdActivity = idActivity;
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View();
        }

        // POST: RowEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActivity,IdUser,IdRowStatus,DateStop,DateStart,Name,Description,Id,DateRegistration,IsActive")] RowEntity rowEntity)
        {
            rowEntity.IsActive = true;
            rowEntity.DateRegistration = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(rowEntity);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Activities");
            }
            
            ViewBag.IdActivity = rowEntity.IdActivity;
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View();
        }

        // GET: RowEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row.FindAsync(id);
            if (rowEntity == null)
            {
                return NotFound();
            }
            return View(rowEntity);
        }

        // POST: RowEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActivity,IdUser,IdRowStatus,DateStop,DateStart,Name,Description,Id,DateRegistration,IsActive")] RowEntity rowEntity)
        {
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
                return RedirectToAction(nameof(Index));
            }
            return View(rowEntity);
        }

        // GET: RowEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rowEntity = await _context.Row
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
            var rowEntity = await _context.Row.FindAsync(id);
            _context.Row.Remove(rowEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RowEntityExists(int id)
        {
            return _context.Row.Any(e => e.Id == id);
        }
    }
}
