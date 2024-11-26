using Front_End.Interfaces;
using Front_End.Models;
using Front_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookServices _bookServices;
        public HomeController(ILogger<HomeController> logger, BookServices bookServices)
        {
            _logger = logger;
            _bookServices = bookServices;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookServices.Books();
            if (ModelState.IsValid) return View(books);
            return RedirectToAction("Error");
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
