using Microsoft.Extensions.DependencyInjection;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Infrastructure.Repository;

namespace RealStateManager.Infrastructure.Extensions
{
    public static class RealStateInfrastructureExtensions
    {
        public static IServiceCollection AddRealStateInfrastructureExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IPropertyRepository, PropertyRepository>();

            return services;
        }
    }
}
