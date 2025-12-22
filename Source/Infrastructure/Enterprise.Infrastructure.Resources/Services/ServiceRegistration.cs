using Enterprise.Application.Interfaces.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.Infrastructure.Resources.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();

            return services;
        }
    }
}
