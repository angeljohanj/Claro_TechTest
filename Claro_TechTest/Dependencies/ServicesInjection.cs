namespace Claro_TechTest.Dependencies
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddNewtonSoftService()
                .AddBookService();
            return services;
        }

    }
}
