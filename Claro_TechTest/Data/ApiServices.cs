namespace Claro_TechTest.Data
{
    public class ApiServices
    {
        private readonly string _ApiMainUrl = string.Empty;
        public ApiServices()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _ApiMainUrl = builder.GetSection("Services:API").Value;
        }

        public string? MainUrl { get => _ApiMainUrl; }
    }
}
