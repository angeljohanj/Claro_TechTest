using Claro_TechTest.Data;
using Claro_TechTest.DTOs.Requests;
using Claro_TechTest.Interfaces;
using Claro_TechTest.Models;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<BookModel> GetBookById(int id)
        {
            var book = new BookModel();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_api.MainUrl}/api/v1/Books/{id}");
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

        public async Task<bool> CreateANewBook(CreateANewBookDTO newBook)
        {
            bool ans = false;
            try
            {
                HttpClient client = new HttpClient();
                var data = JsonConvert.SerializeObject(newBook);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_api.MainUrl}/api/v1/Books");
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

        public async Task<bool> EditABook(UpdateABookDTO book)
        {
            bool ans = false;
            try
            {
                HttpClient client = new HttpClient();
                var data = JsonConvert.SerializeObject(book);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{_api.MainUrl}/api/v1/Books/{book.Id}");
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
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{_api.MainUrl}/api/v1/Books/{id}");
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

