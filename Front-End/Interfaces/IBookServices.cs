using Front_End.Models;

namespace Front_End.Interfaces
{
    public interface IBookServices
    {
        public Task<List<BookModel>> Books(int? id);
        public Task<bool> NewBook(BookModel book);
        public Task<BookModel> FetchBook(int? id);
        public Task<bool> EditBook(BookModel changes);
        public Task<bool> DeleteABookById(int id);


    }
}
