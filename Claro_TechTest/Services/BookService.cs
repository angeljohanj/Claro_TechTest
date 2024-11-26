using Claro_TechTest.Data;
using Claro_TechTest.Interfaces;
using Claro_TechTest.Models;
using Newtonsoft.Json;

namespace Claro_TechTest.Services
{
    public class BookService : IBookService
    {
        private readonly ApiServices _api;
        public BookService()
        {
            _api = new ApiServices();
        }

        public async Task<List<BookModel>> ListAllBooks()
        {
            var books = new List<BookModel>();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_api.MainUrl}/api/v1/Books");
                var result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<BookModel>>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                books = null;
            }

            return books;
        }
    }
}
