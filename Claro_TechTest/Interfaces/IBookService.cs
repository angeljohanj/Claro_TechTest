using Claro_TechTest.Models;

namespace Claro_TechTest.Interfaces
{
    public interface IBookService
    {
        public Task<List<BookModel>> ListAllBooks();
    }
}
