using Microsoft.AspNetCore.Mvc;
using StockControlApp.Models;
using System.Diagnostics;

namespace StockControlApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
;        }

    }
}