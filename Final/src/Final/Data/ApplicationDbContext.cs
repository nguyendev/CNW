using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Final.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public static async Task CreateExampleAccount(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string usernameadmin = configuration["Data:AdminUser:Name"];
            string emailadmin = configuration["Data:AdminUser:Email"];
            string passwordadmin = configuration["Data:AdminUser:Password"];
            string roleadmin = configuration["Data:AdminUser:Role"];

            string usernameguest = configuration["Data:GuestUser:Name"];
            string emailguest = configuration["Data:GuestUser:Email"];
            string passwordguest = configuration["Data:GuestUser:Password"];
            string roleguest = configuration["Data:GuestUser:Role"];


            //Tao tai khoan admin
            if (await userManager.FindByNameAsync(usernameadmin) == null)
            {
                if (await roleManager.FindByNameAsync(roleadmin) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleadmin));
                }
                ApplicationUser useradmin = new ApplicationUser
                {
                    UserName = usernameadmin,
                    Email = emailadmin
                };
                IdentityResult result = await userManager
                .CreateAsync(useradmin, passwordadmin);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(useradmin, roleadmin);
                }
            }

            //tao tai khoan khach
            if (await userManager.FindByNameAsync(usernameguest) == null)
            {
                if (await roleManager.FindByNameAsync(roleguest) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleguest));
                }
                ApplicationUser userguest = new ApplicationUser
                {
                    UserName = usernameguest,
                    Email = emailguest
                };
                IdentityResult result = await userManager
                .CreateAsync(userguest, passwordguest);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userguest, roleguest);
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
