using Microsoft.AspNetCore.Mvc;

namespace Claro_TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("/api/Books")]
        public JsonResult ListBooks()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(JsonResult);
        }
    }
}
