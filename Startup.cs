using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register services to be used
            services.AddControllersWithViews();

            services.AddScoped<ITemperature, Temperature>();

            //services.AddScoped<GuessNumber>(sp=>GuessNumber.GetGame(sp));
            services.AddScoped<GuessNumber>();
            services.AddHttpContextAccessor();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //Observe: The order in which we add different components/services IS IMPORTANT
        //since they rely on one another passing information back and forth.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseStatusCodePages();

            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Place UseSession() after UseRouting() if .NET Core 6.0
            //See https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0
            app.UseSession();

            app.UseRouting();

            // endpoint mapping
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "Fevercheck",
                    pattern: "Fevercheck",
                    defaults: new { controller = "Doctor", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "GuessMe",
                    pattern: "GuessMe",
                    defaults: new { controller = "Guess", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=My}/{Action=Home}/{id?}");

            });

            
        }
    }
}
