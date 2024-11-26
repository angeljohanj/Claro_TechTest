using Claro_TechTest.Interfaces;
using Claro_TechTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Claro_TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpGet("/api/Books")]
        public async Task<JsonResult> List()
        {
            try
            {
                var books = await _bookService.ListAllBooks();

                if (ModelState.IsValid)
                {
                    return new JsonResult(books);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
