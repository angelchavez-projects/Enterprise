using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Enterprise.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
