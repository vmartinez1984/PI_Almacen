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
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.Where(x => x.IsActive).ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        
            var companyEntity = await _context.Company
                .Include(x => x.ListBranches)
                    .ThenInclude(x=>x.TypeBranch)
                .FirstOrDefaultAsync(m => m.Id == id);
            companyEntity.ListBranches = _context.Branch.Include(x=> x.TypeBranch)
                .Include(x=>x.ListPerson)
                .Where(x=> x.CompanyId == id).ToList();
            companyEntity.ListBranches.ForEach(branch =>
            {
                branch.CountPersons = _context.Person.Count(x => x.BranchId == branch.Id);
            });
            if (companyEntity == null)
            {
                return NotFound();
            }

            return View(companyEntity);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Note,ZipCode,Street,Id,DateRegistration,IsActive")] CompanyEntity companyEntity)
        {
            companyEntity.IsActive = true;
            companyEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(companyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyEntity);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Company.FindAsync(id);
            if (companyEntity == null)
            {
                return NotFound();
            }
            return View(companyEntity);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Note,ZipCode,Street,Id,DateRegistration,IsActive")] CompanyEntity companyEntity)
        {
            if (id != companyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyEntityExists(companyEntity.Id))
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
            return View(companyEntity);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyEntity == null)
            {
                return NotFound();
            }

            return View(companyEntity);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyEntity = await _context.Company.FindAsync(id);
            _context.Company.Remove(companyEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyEntityExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}
