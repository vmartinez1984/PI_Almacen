using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Models;
using Activities.Dtos;
using Activities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Activities.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly AppDbContext _context;

        public ActivitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ActivityEntities
        public async Task<IActionResult> Index(bool isActive = true)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<ActivityEntity> list;
            switch (HttpContext.Session.GetInt32(SessionUser.RoleId))
            {
                case Role.Administrador:

                    list = await GetAsync(null);
                    ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

                    return View(list);
                case Role.LiderDeEquipo:

                    list = await GetAsync((int)HttpContext.Session.GetInt32(SessionUser.Id));
                    ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

                    return View(list);
                case Role.Colaborador:

                    return RedirectToAction("Rows");
            }

            return View();
        }

        public async Task<ActionResult> Rows()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<RowEntity> list;

            list = await GetListRowsFromCollaborator();
            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);

            return View(list);
        }

        private async Task<List<RowEntity>> GetListRowsFromCollaborator()
        {
            int userId;
            List<RowEntity> listRows;

            userId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            listRows = await _context.UsersInRow
                .Include(x => x.Row)
                    .Include(x => x.Row.ListUsersInRow)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Row.ListComments)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Row.ListFiles)
                    .Include(x => x.Row.RowStatus)
                .Where(x => x.UserId == userId && x.IsActive)
                .Select(x => x.Row)
                .ToListAsync();

            return listRows;
        }

        private async Task<List<ActivityEntity>> GetAsync(int? userId)
        {
            List<ActivityEntity> entities;

            var query = _context.Activity
                    .Include(x => x.ListRows.Where(x => x.IsActive))
                        .ThenInclude(x => x.ListUsersInRow.Where(x => x.IsActive))
                            .ThenInclude(x => x.User)
                    .Include(x => x.ListRows.Where(x => x.IsActive))
                        .ThenInclude(x => x.ListComments.Where(x => x.IsActive))
                            .ThenInclude(x => x.User)
                    .Include(x => x.ListRows.Where(x => x.IsActive))
                        .ThenInclude(x => x.ListFiles.Where(x => x.IsActive))
                    .Include(x => x.ActivityStatus)
                    .Include(x=> x.User);
            if (userId == null)
            {
                entities = await
                query.Where(x => x.IsActive == true)
                .ToListAsync();
            }
            else
            {
                entities = await
                query.Where(x => x.IsActive == true && x.UserId == userId)
                .ToListAsync();
            }


            return entities;
        }

        // GET: ActivityEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var activityEntity = await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityEntity == null)
            {
                return NotFound();
            }

            return View(activityEntity);
        }

        // GET: ActivityEntities/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            ViewData["ListActivityStatus"] = new SelectList(_context.ActivityStatus.Where(x => x.IsActive).ToList(), "Id", "Name");

            return View();
        }

        // POST: ActivityEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ActivityStatusId,Name,Description,Id,DateRegistration,IsActive")] ActivityEntity activityEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            activityEntity.IsActive = true;
            activityEntity.DateRegistration = DateTime.Now;
            activityEntity.UserId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            //activityEntity.Id = 1;
            //if (ModelState.IsValid)
            //{
            //    activityEntity.Id = 0;
            _context.Activity.Add(activityEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //return View(activityEntity);
        }

        // GET: ActivityEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var activityEntity = await _context.Activity.FindAsync(id);
            if (activityEntity == null)
            {
                return NotFound();
            }
            return View(activityEntity);
        }

        // POST: ActivityEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ActivityStatusId,Name,Description,Id,DateRegistration,IsActive")] ActivityEntity activityEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id != activityEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityEntityExists(activityEntity.Id))
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
            return View(activityEntity);
        }

        // GET: ActivityEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            if (id == null)
            {
                return NotFound();
            }

            var activityEntity = await _context.Activity.Include(x => x.User)
                .Include(x => x.ActivityStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityEntity == null)
            {
                return NotFound();
            }

            return View(activityEntity);
        }

        // POST: ActivityEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            var activityEntity = await _context.Activity.FindAsync(id);
            //_context.Activity.Remove(activityEntity);
            activityEntity.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityEntityExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}
