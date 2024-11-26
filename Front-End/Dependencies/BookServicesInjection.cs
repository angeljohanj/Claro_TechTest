using Front_End.Interfaces;
using Front_End.Services;

namespace Front_End.Dependencies
{
    public static class BookServicesInjection
    {
        public static IServiceCollection AddBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookServices, BookServices>();
            return services;
        }
    }
}
