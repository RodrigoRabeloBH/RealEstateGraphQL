using Microsoft.Extensions.DependencyInjection;
using RealStateManager.Application.Services;
using RealStateManager.Domain.Interfaces;

namespace RealStateManager.Application.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPropertyServices, PropertyServices>();

            return services;
        }
    }
}