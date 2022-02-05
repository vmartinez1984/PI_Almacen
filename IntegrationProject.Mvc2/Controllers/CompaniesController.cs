using Microsoft.AspNetCore.Mvc;
using IntegrationProject.Mvc2.Models;
using System.Collections.Generic;
using IntegrationProject.Mvc2.Services;

namespace IntegrationProject.Mvc2.Controllers
{
    public class CompaniesController : Controller
    {
        private CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            List<CompanyViewModel> list;

            list = _companyService.Get();

            return View(list);
        }
    }
}
