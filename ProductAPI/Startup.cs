using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using ProductApi.Context;
using ProductApi.Common;
using ProductApi.Services;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using System;

namespace ProductApi
{
    public class Startup
    {
        public Startup(
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            Configuration = configuration;
            ConsoleLoggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                }
            );
            CurrentEnvironment = env;
        }
        public IWebHostEnvironment CurrentEnvironment { get; }
        public ILoggerFactory ConsoleLoggerFactory { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProductService, ProductService>();

            if (!CurrentEnvironment.IsEnvironment(Common.Environments.Testing))
            {
                services.AddDbContext<ProductContext>(options =>
                {
                    options.UseLoggerFactory(ConsoleLoggerFactory);
                    options.UseMySql(Configuration["Database:ConnectionString"]);
                });
            }
            else
            {
                services.AddDbContext<ProductContext>(options =>
                {
                    options.UseLoggerFactory(ConsoleLoggerFactory);
                    options.UseInMemoryDatabase("SimpleApiDb");
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
