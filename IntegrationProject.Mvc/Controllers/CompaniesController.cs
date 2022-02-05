using IntegrationProject.Mvc.Contracts.IServices;
using IntegrationProject.Mvc.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IntegrationProject.Mvc.Controllers
{
    public class CompaniesController : Controller
    {        
        private IServiceFactory _serviceFactory;

        public CompaniesController(IServiceFactory serviceFactory)
        {            
            _serviceFactory = serviceFactory;
        }
        // GET: CompaniesController
        public ActionResult Index()
        {
            System.Collections.Generic.List<Dtos.Outputs.CompanyDtoOut> list;

            list = _serviceFactory.CompanyService.Get();
            
            return View();
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
