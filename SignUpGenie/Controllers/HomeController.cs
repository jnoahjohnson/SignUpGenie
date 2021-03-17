using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUpGenie.Models;
using SignUpGenie.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IGenieRepository _genieRepository;
        public int PageSize = 10;

        public HomeController(ILogger<HomeController> logger, IGenieRepository genieRepo)
        {
            _logger = logger;
            _genieRepository = genieRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointments(int pageNum = 1)
        {
            TourListViewModel viewModel = new TourListViewModel
            {
                Tours = _genieRepository.Tours.OrderBy(t => t.DateTime).Skip((pageNum - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _genieRepository.Tours.Count()
                }
            };
            return View(viewModel);
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
