using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class TypeBranchsController : Controller
    {
        private readonly AppDbContext _context;

        public TypeBranchsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TypeBranchs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BranchType.ToListAsync());
        }

        // GET: TypeBranchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBranchEntity = await _context.BranchType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBranchEntity == null)
            {
                return NotFound();
            }

            return View(typeBranchEntity);
        }

        // GET: TypeBranchs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeBranchs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id,DateRegistration,IsActive")] BranchTypeEntity typeBranchEntity)
        {
            typeBranchEntity.IsActive = true;
            typeBranchEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(typeBranchEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeBranchEntity);
        }

        // GET: TypeBranchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBranchEntity = await _context.BranchType.FindAsync(id);
            if (typeBranchEntity == null)
            {
                return NotFound();
            }
            return View(typeBranchEntity);
        }

        // POST: TypeBranchs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Id,DateRegistration,IsActive")] BranchTypeEntity typeBranchEntity)
        {
            if (id != typeBranchEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeBranchEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeBranchEntityExists(typeBranchEntity.Id))
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
            return View(typeBranchEntity);
        }

        // GET: TypeBranchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeBranchEntity = await _context.BranchType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBranchEntity == null)
            {
                return NotFound();
            }

            return View(typeBranchEntity);
        }

        // POST: TypeBranchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeBranchEntity = await _context.BranchType.FindAsync(id);
            _context.BranchType.Remove(typeBranchEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeBranchEntityExists(int id)
        {
            return _context.BranchType.Any(e => e.Id == id);
        }
    }
}
