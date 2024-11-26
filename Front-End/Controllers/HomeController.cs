using Front_End.Models;
using Front_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookServices _bookServices;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _bookServices = new BookServices();
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var books = await _bookServices.Books(id);
            if (ModelState.IsValid) return View(books);
            return RedirectToAction("Error");
        }
        public async Task<IActionResult> ViewBook(int id)
        {
            var book = await _bookServices.FetchBook(id);
            if (ModelState.IsValid) return View(book);
            else return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookModel book)
        {
            var ans = await _bookServices.NewBook(book);
            if (ModelState.IsValid) return RedirectToAction("Index");
            else return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var book = await _bookServices.FetchBook(id);
            if (ModelState.IsValid) return View(book);
            else return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookModel changes)
        {
            var ans = await _bookServices.EditBook(changes);
            var result = ans == true;
            if (result) return RedirectToAction("Index");
            else return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookServices.FetchBook(id);
            if (ModelState.IsValid) return View(book);
            else return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BookModel book)
        {
            var ans = await _bookServices.DeleteABookById(book.Id);
            var result = ans == true;
            if (result) return RedirectToAction("Index");
            else return View();
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
