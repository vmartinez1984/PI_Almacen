using Activities.Dtos;
using Activities.Helpers;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Activities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(SessionUser.Id) is null)
                return RedirectToAction("Index", "Login");

            List<ActivitySummaryDto> list;

            list = GetListActivitySumery();

            return View(list);
        }

        private List<ActivitySummaryDto> GetListActivitySumery()
        {
            List<ActivitySummaryDto> list;
            List<ActivityEntity> entities;

            list = new List<ActivitySummaryDto>();
            entities = _context.Activity.Where(x => x.IsActive)
                .Include(x => x.ListRows.Where(x => x.IsActive))
                    .ThenInclude(x => x.RowStatus)
                .ToList();
            entities.ForEach(entity =>
            {
                list.Add(
                    new ActivitySummaryDto { Id = entity.Id, Name = entity.Name, Data = GetData(entity.ListRows) }
                );
            });

            return list;
        }

        private Dictionary<string, int> GetData(List<RowEntity> listRows)
        {
            Dictionary<string, int> dictionary;
            List<string> listName;

            dictionary = new Dictionary<string, int>();
            listName = listRows.Distinct().Select(x => x.RowStatus.Name).ToList();
            listName.ForEach(rowStatusName =>
            {
                dictionary.Add(rowStatusName, listRows.Count(x => x.RowStatus.Name == rowStatusName));
            });

            return dictionary;
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
