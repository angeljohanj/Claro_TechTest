namespace Claro_TechTest.Dependencies
{
    public static class ControllersInjection
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen().AddEndpointsApiExplorer();

            return services;
        }
    }
}
