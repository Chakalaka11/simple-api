using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductApi;
using ProductApi.Context;

namespace ProductAPITests
{
    public class ProductApiApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }
        );
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(ProductApi.Common.Environments.Testing);
            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
                // Create a scope to obtain a reference to the database contexts
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<ProductContext>();

                    // Ensure the database is created.
                    appDb.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with some specific test data.
                        SeedData.PopulateTestData(appDb);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }
    }
}
