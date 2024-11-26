using Front_End.Models;

namespace Front_End.Interfaces
{
    public interface IBookServices
    {
        public Task<List<BookModel>> Books();
    }
}
