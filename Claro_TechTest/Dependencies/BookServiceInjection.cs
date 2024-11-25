using Claro_TechTest.Interfaces;
using Claro_TechTest.Services;

namespace Claro_TechTest.Dependencies
{
    public static class BookServiceInjection
    {
        public static IServiceCollection AddBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
