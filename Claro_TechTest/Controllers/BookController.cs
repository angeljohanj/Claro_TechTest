using Claro_TechTest.DTOs.Requests;
using Claro_TechTest.Interfaces;
using Claro_TechTest.Models;
using Claro_TechTest.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Claro_TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
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
        [HttpGet("/api/Books/{id}")]
        public async Task<JsonResult> Get([FromRoute] int id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);

                if (ModelState.IsValid)
                {
                    return new JsonResult(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
        [HttpPost("/api/Books/")]
        public async Task<JsonResult> Create(BookModel book)
        {
            bool ans = false;
            try
            {
                CreateANewBookDTO bookDTO = book.Adapt<CreateANewBookDTO>();
                ans = await _bookService.CreateANewBook(bookDTO);
                if (ans) new JsonResult(ans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ans = false;
            }
            return new JsonResult(ans);
        }
        [HttpPut("/api/Books/{id}")]
        public async Task<JsonResult> Update(BookModel book, [FromRoute] int id)
        {
            var ans = false;
            try
            {
                var bookDTO = book.Adapt<UpdateABookDTO>();
                bookDTO.Id = id;
                ans = await _bookService.EditABook(bookDTO);
                if (ans) new JsonResult(ans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(ans);
        }
        [HttpDelete("/api/Books/{id}")]
        public async Task<JsonResult> Delete([FromRoute] int id)
        {
            var ans = false;
            try
            {
                ans = await _bookService.DeleteABookById(id);
                if (ans) new JsonResult(ans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(ans);
        }
    }
}
