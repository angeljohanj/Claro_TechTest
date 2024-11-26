using Front_End.Data;
using Front_End.Interfaces;
using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Services
{
    public class BookServices : IBookServices
    {
        private readonly DataConnection _api;
        public BookServices()
        {
            _api = new DataConnection();
        }

        public async Task<List<BookModel>> Books()
        {
            var books = new List<BookModel>();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_api.MainUrl}/api/Books");
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
                Console.WriteLine(ex.Message); ;
            }
            return books;
        }
    }
}
