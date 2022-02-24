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
    public class CommentsController : Controller
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Comment.Include(c => c.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntity = await _context.Comment
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentEntity == null)
            {
                return NotFound();
            }

            return View(commentEntity);
        }

        // GET: Comments/Create
        public IActionResult Create(int rowId)
        {
            ViewBag.Row = _context.Row.Find(rowId);

            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RowId,UserId,Content,Id,DateRegistration,IsActive")] CommentEntity commentEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            commentEntity.UserId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            commentEntity.DateRegistration = DateTime.Now;
            commentEntity.IsActive = true;
            if (ModelState.IsValid)
            {
                _context.Add(commentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Activities");
            }
            
            return View(commentEntity);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntity = await _context.Comment.FindAsync(id);
            if (commentEntity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", commentEntity.UserId);
            return View(commentEntity);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RowId,UserId,Content,Id,DateRegistration,IsActive")] CommentEntity commentEntity)
        {
            if (id != commentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentEntityExists(commentEntity.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", commentEntity.UserId);
            return View(commentEntity);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntity = await _context.Comment
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentEntity == null)
            {
                return NotFound();
            }

            return View(commentEntity);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentEntity = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(commentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentEntityExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
