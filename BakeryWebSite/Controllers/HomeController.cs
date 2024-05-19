using BakeryWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BakeryWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BakeryContext db;

        public HomeController(ILogger<HomeController> logger, BakeryContext context)
        {
            db= context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Main()
        {
            using(db)
            {
                Category category = new Category("Торты");
                db.Categories.Add(category);
                db.SaveChanges();
            }
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