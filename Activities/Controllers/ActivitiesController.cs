using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activities.Models;
using Activities.Dtos;

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
        public async Task<IActionResult> Index()
        {
            List<ActivityDto> list;

            list = await GetAsync();

            return View(list);
        }

        private async Task<List<ActivityDto>> GetAsync()
        {
            List<ActivityDto> list;
            List<ActivityEntity> entities;

            list = new List<ActivityDto>();
            entities = await _context.Activity.Where(x=>x.IsActive).ToListAsync();
            entities.ForEach(entitie =>
            {
                list.Add(Get(entitie));
            });

            return list;
        }

        private ActivityDto Get(ActivityEntity entitie)
        {
            ActivityDto activityDto;

            activityDto = new ActivityDto
            {
                Id = entitie.Id,
                Name = entitie.Name,
                Description = entitie.Description,
                ListRows = GetListRows(entitie.Id),                
            };

            return activityDto;
        }

        private List<RowDto> GetListRows(int idActivity)
        {
            List<RowEntity> entities;
            List<RowDto> list;

            list = new List<RowDto>();
            entities = _context.Row.Include(x => x.RowStatus).Where(x => x.ActivityId == idActivity).ToList();
            entities.ForEach(row =>
            {
                list.Add(GetRowDto(row));
            });

            return list;
        }

        private RowDto GetRowDto(RowEntity row)
        {
            RowDto rowDto;

            rowDto = new RowDto
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                DateRegistration = row.DateRegistration,
                DateStart = row.DateStart,
                DateStop = row.DateStop,
                Status = _context.RowStatus.FirstOrDefault(x => x.Id == row.RowStatusId).Name,
                ListUsers = GetListUser(row.Id),
                ListFiles = GetListFiles(row.Id)
            };

            return rowDto;
        }

        private List<FileDto> GetListFiles(int id)
        {
            List<FileDto> list;

            list = new List<FileDto>();

            return list;
        }

        private List<UserDto> GetListUser(int idRow)
        {
            List<UsersInRowEntity> entities;
            List<UserDto> list;

            list = new List<UserDto>();
            entities = _context.UsersInRow.Include(x => x.User).Where(x => x.RowId == idRow).ToList();
            entities.ForEach(entity =>
            {
                entity.User = _context.User.Where(x => x.Id == entity.UserId).FirstOrDefault();
                list.Add(GetUserDto(entity.User));
            });

            return list;
        }

        private UserDto GetUserDto(UserEntity user)
        {
            UserDto dto;

            dto = new UserDto
            {
                Id = user.Id,
                FullName = $"{user.Name} {user.LastName}"
            };

            return dto;
        }

        // GET: ActivityEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
            ViewData["ListActivityStatus"] = new SelectList(_context.ActivityStatus.Where(x => x.IsActive).ToList(), "Id", "Name");

            return View();
        }

        // POST: ActivityEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdActivityStatus,Name,Description,Id,DateRegistration,IsActive")] ActivityEntity activityEntity)
        {
            activityEntity.IsActive = true;
            activityEntity.DateRegistration = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(activityEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityEntity);
        }

        // GET: ActivityEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdActivityStatus,Name,Description,Id,DateRegistration,IsActive")] ActivityEntity activityEntity)
        {
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

        // POST: ActivityEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityEntity = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(activityEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityEntityExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}
