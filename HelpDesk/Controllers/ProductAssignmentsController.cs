using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using HelpDesk.Helpers;

namespace HelpDesk.Controllers
{
    public class ProductAssignmentsController : Controller
    {
        private readonly AppDbContext _context;
        const int Activo = 1;
        const int Asignado = 2;

        public ProductAssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductAssignments
        public async Task<IActionResult> Index()
        {
            var list = await _context.ProductAssignment
                .Include(p => p.Person)                    
                    .ThenInclude(x=> x.Branch)
                        .ThenInclude(x=> x.Company)
                .Include(p => p.Product)
                    .ThenInclude(x=> x.Category)
                .Include(p => p.User)
                .ToListAsync();
         
            return View(list);
        }

        // GET: ProductAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAssignmentEntity = await _context.ProductAssignment
                .Include(p => p.Person)
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAssignmentEntity == null)
            {
                return NotFound();
            }

            return View(productAssignmentEntity);
        }

        // GET: ProductAssignments/Create
        public IActionResult Create()
        {           
            ViewData["PersonId"] = new SelectList(_context.Person.Where(x=> x.IsActive).ToList(), "Id", nameof(PersonEntity.FullName));
            ViewData["ProductId"] = new SelectList(_context.Product.Where(x=> x.ProductStatusId == Activo).ToList(), "Id", "Name");
            
            return View();
        }

        // POST: ProductAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,PersonId,UserId,DateAssignment,Id,DateRegistration,KitId, IsActive")] ProductAssignmentEntity productAssignmentEntity)
        {
            productAssignmentEntity.IsActive = true;
            productAssignmentEntity.DateRegistration = DateTime.Now;
            productAssignmentEntity.UserId = 1;
            if (ModelState.IsValid)
            {
                _context.Add(productAssignmentEntity);
                var producto = _context.Product.Where(x=> x.Id == productAssignmentEntity.ProductId).FirstOrDefault();
                producto.ProductStatusId = Asignado;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person.Where(x => x.IsActive).ToList(), "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Product.Where(x => x.ProductStatusId == Activo).ToList(), "Id", "Name");
            return View(productAssignmentEntity);
        }

        // GET: ProductAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAssignmentEntity = await _context.ProductAssignment.FindAsync(id);
            if (productAssignmentEntity == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "LastName", productAssignmentEntity.PersonId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", productAssignmentEntity.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", productAssignmentEntity.UserId);
            return View(productAssignmentEntity);
        }

        // POST: ProductAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,PersonId,UserId,DateAssignment,Id,DateRegistration,IsActive")] ProductAssignmentEntity productAssignmentEntity)
        {
            if (id != productAssignmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAssignmentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAssignmentEntityExists(productAssignmentEntity.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "LastName", productAssignmentEntity.PersonId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", productAssignmentEntity.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", productAssignmentEntity.UserId);
            return View(productAssignmentEntity);
        }

        // GET: ProductAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAssignmentEntity = await _context.ProductAssignment
                .Include(p => p.Person)
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAssignmentEntity == null)
            {
                return NotFound();
            }

            return View(productAssignmentEntity);
        }

        // POST: ProductAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? kitId)
        {
            var productAssignmentEntity = await _context.ProductAssignment.FindAsync(id);
            productAssignmentEntity.IsActive = false;
            var product = await _context.Product.FindAsync(productAssignmentEntity.ProductId);
            product.ProductStatusId = ProductStatus.Activo;
            await _context.SaveChangesAsync();

            if(kitId == null)
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Index), "Kits");
        }

        private bool ProductAssignmentEntityExists(int id)
        {
            return _context.ProductAssignment.Any(e => e.Id == id);
        }
    }
}
