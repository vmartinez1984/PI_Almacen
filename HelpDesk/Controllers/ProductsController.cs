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
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var list = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductStatus)
                .ToListAsync();
            list.ForEach(p =>
            {
                p.ProductStatus = _context.ProductStatus.FirstOrDefault(x=> x.Id == p.ProductStatusId);
                p.Category = _context.Category.FirstOrDefault(x=> x.Id == p.CategoryId);
            });
            return View(list);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["ProductStatusId"] = new SelectList(_context.ProductStatus, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,SerieNumber,DateStart,DateStop,CategoryId,ProductStatusId,Id,DateRegistration,IsActive")] ProductEntity productEntity)
        {
            productEntity.IsActive = true;
            productEntity.DateRegistration = DateTime.Now;  
            if (ModelState.IsValid)
            {
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", productEntity.CategoryId);
            ViewData["ProductStatusId"] = new SelectList(_context.ProductStatus, "Id", "Name", productEntity.ProductStatusId);
            return View(productEntity);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Product.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", productEntity.CategoryId);
            ViewData["ProductStatusId"] = new SelectList(_context.ProductStatus, "Id", "Name", productEntity.ProductStatusId);
            return View(productEntity);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,SerieNumber,DateStart,DateStop,CategoryId,ProductStatusId,Id,DateRegistration,IsActive")] ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductEntityExists(productEntity.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", productEntity.CategoryId);
            ViewData["ProductStatusId"] = new SelectList(_context.ProductStatus, "Id", "Name", productEntity.ProductStatusId);
            return View(productEntity);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productEntity = await _context.Product.FindAsync(id);
            _context.Product.Remove(productEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
