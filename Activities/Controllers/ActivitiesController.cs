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

            List<ActivityDto> list;

            ViewData["ListRowStatus"] = new SelectList(_context.RowStatus.Where(x => x.IsActive).ToArray(), SelectProperty.Id, SelectProperty.Name);
            list = await GetAsync();

            return View(list);
        }

        #region GetAsync
        private async Task<List<ActivityDto>> GetAsync()
        {
            List<ActivityDto> list;
            List<ActivityEntity> entities;

            list = new List<ActivityDto>();
            entities = await _context.Activity
                .Include(x => x.ListRows)
                    .ThenInclude(x=>x.ListComments)
                        .ThenInclude(x=>x.User)
                .Include(x => x.ActivityStatus)
                .Where(x => x.IsActive == true).ToListAsync();
            entities.ForEach(entitie =>
            {
                list.Add(GetActivityDto(entitie));
            });

            return list;
        }

        private ActivityDto GetActivityDto(ActivityEntity entitie)
        {
            ActivityDto activityDto;

            activityDto = new ActivityDto
            {
                Id = entitie.Id,
                Name = entitie.Name,
                Description = entitie.Description,
                ListRows = GetListRowDtos(entitie),
            };

            return activityDto;
        }

        private List<RowDto> GetListRowDtos(ActivityEntity entity)
        {
            List<RowDto> list;

            list = new List<RowDto>();
            entity.ListRows.ForEach(row =>
            {
                list.Add(GetRowDto(row));
            });

            return list;
        }

        private RowDto GetRowDto(RowEntity entity)
        {
            RowDto rowDto;

            rowDto = new RowDto
            {
                Id = entity.Id,
                Name = entity.Name,
                RowStatusId = entity.RowStatusId,
                ActivityId = entity.ActivityId,
                Description = entity.Description,
                DateRegistration = entity.DateRegistration,
                DateStart = entity.DateStart,
                DateStop = entity.DateStop,
                Status = _context.RowStatus.FirstOrDefault(x => x.Id == entity.RowStatusId).Name,
                ListUsers = GetListUser(entity.Id),
                ListFiles = GetListFiles(entity.Id),
                ListComments = GetListComments(entity.ListComments)
            };

            return rowDto;
        }

        private List<CommentDto> GetListComments(List<CommentEntity> listComments)
        {
            List<CommentDto> list;

            list = new List<CommentDto>();
            listComments.ForEach(comment =>
            {
                list.Add(new CommentDto
                {
                    Content = comment.Content,
                    DateRegistration = comment.DateRegistration,
                    UserFullName = comment.User.FullName                
                });
            });

            return list;
        }

        private List<FileDto> GetListFiles(int id)
        {
            List<FileDto> list;

            list = new List<FileDto>();

            return list;
        }

        private List<UserInRowDto> GetListUser(int idRow)
        {
            List<UsersInRowEntity> entities;
            List<UserInRowDto> list;

            list = new List<UserInRowDto>();
            entities = _context.UsersInRow
                .Include(x => x.User)
                .Where(x => x.RowId == idRow && x.IsActive)
                .ToList();
            entities.ForEach(entity =>
            {
                list.Add(GetUserDto(entity));
            });

            return list;
        }

        private UserInRowDto GetUserDto(UsersInRowEntity entity)
        {
            UserInRowDto dto;

            dto = new UserInRowDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                FullName = $"{entity.User.Name} {entity.User.LastName}"
            };

            return dto;
        }
        #endregion

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
