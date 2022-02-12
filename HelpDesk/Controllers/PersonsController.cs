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
    public class PersonsController : Controller
    {
        private readonly AppDbContext _context;

        public PersonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: PersonEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEntity = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personEntity == null)
            {
                return NotFound();
            }

            return View(personEntity);
        }

        // GET: PersonEntities/Create
        public IActionResult Create(int idBranch)
        {
            ViewBag.IdBranch = idBranch;    
            return View();
        }

        // POST: PersonEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LastName,Phone,Email,IdBranch,Id,DateRegistration,IsActive")] PersonEntity personEntity)
        {
            personEntity.IsActive = true;
            personEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(personEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Branchs", new {Id = personEntity.IdBranch});
            }
            return View(personEntity);
        }

        // GET: PersonEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEntity = await _context.Person.FindAsync(id);
            if (personEntity == null)
            {
                return NotFound();
            }
            return View(personEntity);
        }

        // POST: PersonEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LastName,Phone,Email,IdBranch,Id,DateRegistration,IsActive")] PersonEntity personEntity)
        {
            if (id != personEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonEntityExists(personEntity.Id))
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
            return View(personEntity);
        }

        // GET: PersonEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEntity = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personEntity == null)
            {
                return NotFound();
            }

            return View(personEntity);
        }

        // POST: PersonEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personEntity = await _context.Person.FindAsync(id);
            _context.Person.Remove(personEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonEntityExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
