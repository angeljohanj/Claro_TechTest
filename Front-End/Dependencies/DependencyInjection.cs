namespace Front_End.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddBookService();
            return services;
        }
    }
}
