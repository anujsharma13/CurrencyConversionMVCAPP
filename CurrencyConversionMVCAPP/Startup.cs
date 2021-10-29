
using CurrencyConversionMVCAPP.Models;
using CurrencyConversionMVCAPP.Models.Interfaces;
using CurrencyConversionMVCAPP.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP
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
            services.AddControllersWithViews();
            services.AddScoped<IJsonToList, JsonToList>();
            services.AddScoped<ICopyJsonData, CopyJsonData>();
            services.AddScoped<IGetCountryCodes, GetCountryCodes>();
            services.AddScoped<IGetNames, GetNames>();

            services.AddRefitClient<apicall>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(@"https://currency-exchange.p.rapidapi.com");
                c.DefaultRequestHeaders.Add("x-rapidapi-key", "64892e83d5msh2c4dfea8d121897p1f23a7jsnafd1a9f55ca0");
                c.Timeout = TimeSpan.FromSeconds(10);
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Currency}/{action=Index}/{id?}");
            });
        }
    }
}
