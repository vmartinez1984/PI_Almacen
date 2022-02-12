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
    public class BranchsController : Controller
    {
        private readonly AppDbContext _context;

        public BranchsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Branchs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branch.ToListAsync());
        }

        // GET: Branchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.Branch
                .Include(x => x.ListPerson)
                .Include(x=> x.Company)
                .Include(x=> x.TypeBranch)
                .FirstOrDefaultAsync(m => m.Id == id);
            branchEntity.Company = _context.Company.Where(x => x.Id == branchEntity.CompanyId).FirstOrDefault();
            branchEntity.TypeBranch = _context.BranchType.Where(x => x.Id == id).FirstOrDefault();
            branchEntity.ListPerson = await _context.Person.Where(x => x.BranchId == id)
                .ToListAsync();
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // GET: Branchs/Create
        public IActionResult Create(int? idCompany)
        {
            ViewBag.IdCompany = idCompany;
            ViewBag.ListTypeBranchs = new SelectList(_context.BranchType.Where(x => x.IsActive).ToList(), "Id", "Name");
            //ViewBag.ListCompanies = new SelectList(_context.Company.Where(x => x.IsActive).ToList(), "Id", "Name");

            return View();
        }

        // POST: Branchs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email,Note,IdCompany,IdTypeBranch,ZipCode,Street,Id,DateRegistration,IsActive")] BranchEntity branchEntity)
        {
            branchEntity.IsActive = true;
            branchEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(branchEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Companies", new { Id = branchEntity.CompanyId });
            }
            ViewBag.IdCompany = branchEntity.CompanyId;
            ViewBag.ListTypeBranchs = new SelectList(_context.BranchType.Where(x => x.IsActive).ToList(), "Id", "Name");
            return View(branchEntity);
        }

        // GET: Branchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.Branch.FindAsync(id);
            if (branchEntity == null)
            {
                return NotFound();
            }
            return View(branchEntity);
        }

        // POST: Branchs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,Email,Note,IdCompany,IdTypeBranch,ZipCode,Street,Id,DateRegistration,IsActive")] BranchEntity branchEntity)
        {
            if (id != branchEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchEntityExists(branchEntity.Id))
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
            return View(branchEntity);
        }

        // GET: Branchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _context.Branch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // POST: Branchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchEntity = await _context.Branch.FindAsync(id);
            _context.Branch.Remove(branchEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchEntityExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }
    }
}
