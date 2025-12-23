using Enterprise.Application.Interfaces.Common;
using Enterprise.Infrastructure.Resources.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.Infrastructure.Resources
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
