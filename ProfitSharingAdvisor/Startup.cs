using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HRServices.EmployeeServices;
using HRServices.IncentiveServices;
using HRServices.PerformanceServices;
using System;


namespace ProfitSharingAdvisor
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
            services.ConfigureAll(new Action<EmployeeServiceApiConfig>(x => x.ApiUrl = Configuration.GetSection("EmployeeServiceApiUrl").Value));
            services.AddHttpClient<IEmployeeService, EmployeeServiceApi>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
            services.AddTransient<IEmployeeService, EmployeeServiceApi>();
            services.AddTransient<ITargetBonusService, TargetBonusService>();
            services.AddTransient<IEvaluationService, EvaluationService>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
