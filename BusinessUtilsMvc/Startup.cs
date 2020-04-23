using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BusinessUtilsMvc.Models;
using BusinessUtilsMvc.Data;
using BusinessUtilsMvc.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessUtilsMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // configuration Banco de dados
            string connectionString = "";



            if (Env.IsProduction())
            {
                connectionString = Configuration.GetConnectionString("PRD-BusinessUtilsMvcContext");
            }
            else
            {
                connectionString = Configuration.GetConnectionString("BusinessUtilsMvcContext");
            }


            services.AddDbContext<BusinessUtilsMvcContext>(options =>
                    options.UseMySql(connectionString, builder =>
                   builder.MigrationsAssembly("BusinessUtilsMvc")));

            // services Banco de dados
            services.AddScoped<SeedingService>();
            services.AddScoped<SellersService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<SalesRecordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService, ILogger<Startup> logger)
        {

            // formatando a linguagem padrao da aplicacao
            var enUS = new CultureInfo("en-US");
            var localzationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            // adicionando a opcao
            app.UseRequestLocalization(localzationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Sellers}/{action=Index}/{id?}");
            });
        }
    }
}
