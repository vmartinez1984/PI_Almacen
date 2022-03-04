using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using HelpDesk.Helpers;
using Microsoft.AspNetCore.Http;
using Rotativa.AspNetCore;

namespace HelpDesk.Controllers
{
    public class KitsController : Controller
    {
        private readonly AppDbContext _context;
        const int Activo = 1;

        public KitsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Pdf(int id)
        {

            var kitEntity = await _context.Kit
                .Include(x => x.ListProductAssignments)
                    .ThenInclude(x => x.Product)
                .Include(x => x.ListProductAssignments)
                    .ThenInclude(x => x.Person)
                .FirstOrDefaultAsync(m => m.Id == id);

            
            return new ViewAsPdf("Pdf", kitEntity)
            {
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                FileName = $"kit_{1}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.Letter, 
                ContentType = "application/pdf"
            };

            //// Define la URL de la Cabecera 
            //string _headerUrl = Url.Action("ContactHeaderPDF", "Customers", null, "https");
            //// Define la URL del Pie de página
            //string _footerUrl = Url.Action("ContactFooterPDF", "Customers", null, "https");

            //return new ViewAsPdf("ContactPDF", kitEntity)
            //{
            //    // Establece la Cabecera y el Pie de página
            //    CustomSwitches = "--header-html " + _headerUrl + " --header-spacing 13 " +
            //                     "--footer-html " + _footerUrl + " --footer-spacing 0"
            //    ,
            //    PageMargins = new Margins(50, 10, 12, 10)
            //};
        }

        public IActionResult HeaderPDF()
        {
            return View("HeaderPDF");
        }

        public IActionResult FooterPDF()
        {
            return View("FooterPDF");
        }

        // GET: Kits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kit.Include(x => x.ListProductAssignments.Where(x => x.IsActive)).Where(x => x.IsActive).ToListAsync());
        }

        // GET: Kits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitEntity = await _context.Kit
                .Include(x => x.ListProductAssignments)
                    .ThenInclude(x => x.Product)
                .Include(x => x.ListProductAssignments)
                    .ThenInclude(x => x.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitEntity == null)
            {
                return NotFound();
            }

            return View(kitEntity);
        }

        // GET: Kits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Id,DateRegistration,IsActive")] KitEntity kitEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddProducts), "Kits", new { kitId = kitEntity.Id });
            }
            return View(kitEntity);
        }

        [HttpGet]
        public ActionResult AddProducts(int kitId)
        {

            ViewData["Kit"] = _context.Kit
                .Include(x => x.ListProductAssignments.Where(x => x.IsActive))
                    .ThenInclude(x => x.Product)
                .Where(x => x.Id == kitId).FirstOrDefault();
            ViewData["PersonId"] = new SelectList(_context.Person.Where(x => x.IsActive).ToList(), "Id", nameof(PersonEntity.FullName));
            ViewData["ProductId"] = new SelectList(_context.Product.Where(x => x.ProductStatusId == Activo).ToList(), "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddProducts(ProductAssignmentEntity productAssignmentEntity)
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            productAssignmentEntity.UserId = (int)HttpContext.Session.GetInt32(SessionUser.Id);
            if (ModelState.IsValid)
            {
                const int Asignado = 2;
                _context.Add(productAssignmentEntity);
                var producto = _context.Product.Where(x => x.Id == productAssignmentEntity.ProductId).FirstOrDefault();
                producto.ProductStatusId = Asignado;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddProducts), "Kits", new { kitId = productAssignmentEntity.KitId });
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Kits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitEntity = await _context.Kit.FindAsync(id);
            if (kitEntity.ListProductAssignments.Count != 0)
                kitEntity.DateAssignment = kitEntity.ListProductAssignments[0].DateAssignment;
            if (kitEntity == null)
            {
                return NotFound();
            }
            return View(kitEntity);
        }

        // POST: Kits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Id,DateRegistration,IsActive, DateAssignment")] KitEntity kitEntity)
        {
            if (id != kitEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitEntityExists(kitEntity.Id))
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
            return View(kitEntity);
        }

        // GET: Kits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitEntity = await _context.Kit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitEntity == null)
            {
                return NotFound();
            }

            return View(kitEntity);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitEntity = await _context.Kit.FindAsync(id);
            kitEntity.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitEntityExists(int id)
        {
            return _context.Kit.Any(e => e.Id == id);
        }
    }
}
