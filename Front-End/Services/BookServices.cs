using Front_End.Data;
using Front_End.Interfaces;
using Front_End.Models;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<bool> NewBook(BookModel book)
        {
            bool ans = false;
            try
            {
                HttpClient client = new HttpClient();
                var data = JsonConvert.SerializeObject(book);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_api.MainUrl}/api/Books/");
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    ans = response != null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                ans = false;
            }

            return ans;
        }

        public async Task<BookModel> FetchBook(int id)
        {
            var book = new BookModel();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_api.MainUrl}/api/Books/{id}");
                var result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<BookModel>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                book = null;
            }

            return book;
        }

        public async Task<bool> EditBook(BookModel changes)
        {
            bool ans = false;
            try
            {
                HttpClient client = new HttpClient();
                var data = JsonConvert.SerializeObject(changes);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{_api.MainUrl}/api/Books/{changes.Id}");
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    ans = response != null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                ans = false;
            }

            return ans;
        }

        public async Task<bool> DeleteABookById(int id)
        {
            bool ans = false;
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{_api.MainUrl}/api/Books/{id}");
                var result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    ans = response != null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                ans = false;
            }

            return ans;
        }

    }
}
