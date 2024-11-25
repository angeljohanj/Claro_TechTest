using Newtonsoft.Json.Serialization;

namespace Claro_TechTest.Dependencies
{
    public static class NewtonSoftInjection
    {
        public static IServiceCollection AddNewtonSoftService(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());
            return services;
        }
    }
}
