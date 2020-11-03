using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;
using ExchangeBureauxApi.Controllers;
using ExchangeBureauxApi.Data.Models;
using ExchangeBureauxApi.Repository;
using ExchangeBureauxApi.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace ExchangeBureauxApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<CurrencyExchangeDbContext>(
                optios => optios.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                connection => connection.MigrationsAssembly("ExchangeBureauxApi.Data")));

            var assembly = Assembly.Load("ExchangeBureauxApi.Service");
            
            //Add Dependency Injection Here..
            AddDependecyToServices(services, assembly);
            services.AddScoped<IUow, Uow>();
            services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<CurrencyController>>());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
        public void AddDependecyToServices(IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested);
            foreach (var type in types)
            {
                var iface = type.GetInterface("I" + type.Name);
                if (iface != null && !iface.Name.Contains("Auth"))
                    services.AddScoped(iface, type);
            }
        }
    }
}
