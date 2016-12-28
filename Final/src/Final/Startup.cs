using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Final.Data;
using Final.Models;
using Final.Services;
using Microsoft.AspNetCore.Http;
using Final.Infrastructure;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace Final
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddIdentity<BlogMember, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:Final:ConnectionString"]));
            services.AddIdentity<BlogMember, IdentityRole>(opts =>
            {
                opts.Cookies.ApplicationCookie.LoginPath = "/wp-admin/account/login";
                //opts.Cookies.ApplicationCookie.LoginPath = "/QuanLyWebsite/Account/Login";
                //opts.User.RequireUniqueEmail = true;
                //// opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                //opts.Password.RequiredLength = 6;
                //opts.Password.RequireNonAlphanumeric = false;
                //opts.Password.RequireLowercase = false;
                //opts.Password.RequireUppercase = false;
                //opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.RegisterServices();
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = Configuration["6Lfd2A8UAAAAAEBsxMi4memnS3SB3IZnXnZddGMb"],
                SecretKey = Configuration["6Lfd2A8UAAAAAMFtAvL2niwNrmFnWQktq07tSZ-t"],
                ValidationMessage = "Are you a robot?"
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "MyCookies",
                SlidingExpiration = true,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/Account/Login")
            });
            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715


            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = "<enter client id here>",
                ClientSecret = "<enter client secret here>"
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                     template: "{area:exists}/{controller=Admin}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            ApplicationDbContext.CreateExampleAccount(app.ApplicationServices, Configuration).Wait();
            ApplicationDbContext.CreateExampleCategory(app.ApplicationServices).Wait();
            ApplicationDbContext.CreateExampleAuth(app.ApplicationServices).Wait();
            ApplicationDbContext.CreateExamplePost(app.ApplicationServices).Wait();
        }
    }
}
