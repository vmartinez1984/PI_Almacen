using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Dtos;
using Activities.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Activities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Activities.Controllers
{
    public class FilesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: FileDtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.File.ToListAsync());
        }

        // GET: FileDtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDto = await _context.File
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDto == null)
            {
                return NotFound();
            }

            return View(fileDto);
        }

        // GET: FileDtoes/Create
        public IActionResult Create(int rowId)
        {
            ViewBag.Row = _context.Row.Find(rowId);

            return View();
        }

        // POST: FileDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,FormFile, RowId")] FileDto file)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                string filePath;
                FileStream fileStream;

                filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "files", file.FormFile.FileName);
                fileStream = new FileStream(filePath, FileMode.Create);
                await file.FormFile.CopyToAsync(fileStream);
                FileEntity fileEntity = new FileEntity
                {
                    Url = $@"/files/{file.FormFile.FileName}",
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    RowId = file.RowId,
                    UserId = (int)HttpContext.Session.GetInt32(SessionUser.Id),
                    Name = file.FormFile.FileName
                };
                _context.Add(fileEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index),"Activities");
            }

            return View(file);
        }

        // GET: FileDtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDto = await _context.File.FindAsync(id);
            if (fileDto == null)
            {
                return NotFound();
            }
            return View(fileDto);
        }

        // POST: FileDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url")] FileDto fileDto)
        {
            if (id != fileDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileDtoExists(fileDto.Id))
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
            return View(fileDto);
        }

        // GET: FileDtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDto = await _context.File
                .Include(x => x.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDto == null)
            {
                return NotFound();
            }

            return View(fileDto);
        }

        // POST: FileDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileDto = await _context.File.FindAsync(id);
            fileDto.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Activities");
        }

        private bool FileDtoExists(int id)
        {
            return _context.File.Any(e => e.Id == id);
        }
    }
}
