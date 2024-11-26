namespace Front_End.Data
{
    public class DataConnection
    {
        private readonly string _api = string.Empty;

        public DataConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _api = builder.GetSection("Service:API").Value;
        }

        public string? MainUrl { get => _api; }
    }
}
