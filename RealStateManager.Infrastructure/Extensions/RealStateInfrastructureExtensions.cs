using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Infrastructure.Repository;
using RealStateManager.Infrastructure.Services;
using StackExchange.Redis;

namespace RealStateManager.Infrastructure.Extensions
{
    public static class RealStateInfrastructureExtensions
    {
        public static IServiceCollection AddRealStateInfrastructureExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IPropertyRepository, PropertyRepository>();

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            services.AddDbContext<RealStateContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnectionDev")));

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisDev"), true);

                return ConnectionMultiplexer.Connect(config);
            });

            return services;
        }
    }
}
