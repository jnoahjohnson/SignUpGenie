using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUpGenie.Models;
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

        private GenieDbContext _context;

        public HomeController(ILogger<HomeController> logger, IGenieRepository genieRepo, GenieDbContext context)
        {
            _logger = logger;
            _genieRepository = genieRepo;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointments()
        {
            return View(_genieRepository.Tours);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(_genieRepository.Tours.Where(t => t.Group == null).OrderBy(t => t.DateTime));
        }

        [HttpGet]
        public IActionResult Form(int tourId)
        {
            return View(_genieRepository.Tours.Where(t => t.TourId == tourId).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Form(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(tour.Group);
                _context.SaveChanges();
                
                var tourToUpdate = _context.Tours.Where(t => t.TourId == tour.TourId).FirstOrDefault();

                tourToUpdate.Group = tour.Group;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
