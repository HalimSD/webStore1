using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp1.Models;
using DinkToPdf.Contracts;
using DinkToPdf;
using WebApp1.Controllers;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApp1.Models.Database;
using WebPWrecover.Services;

namespace WebApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<WebshopContext>(opt => opt.UseNpgsql(@"Host=localhost;Database=webShop34234324234234;Username=postgres;Password=wanne"));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });

            services.AddIdentity<Users, IdentityRole>()
            .AddEntityFrameworkStores<WebshopContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebshopContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {   
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var userRole = app.ApplicationServices.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();
                new Roles(userRole).Seed();
            }
        }
    }
}
