using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealStateManager.Infrastructure;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Threading.Tasks;

namespace RealStateManage.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<RealStateContext>();

                await context.Database.MigrateAsync();

                await RealStateSeedData.SeedAsync(context);

                host.Run();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                    {
                        IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    })
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
