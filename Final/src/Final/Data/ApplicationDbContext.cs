﻿using System;
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
    public class ApplicationDbContext : IdentityDbContext<BlogMember>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public static async Task CreateExampleAccount(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            UserManager<BlogMember> userManager = serviceProvider.GetRequiredService<UserManager<BlogMember>>();
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
                BlogMember useradmin = new BlogMember
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
                BlogMember userguest = new BlogMember
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
        public static void CreateExampleCategory(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {


                if (context.Category.Any())
                {
                    return;   // DB has been seeded
                }
                context.Category.AddRange(
                 new BlogCategory
                 {
                     CategoryName = "Đăng nhập facebook",
                     OrderNo = 1,
                     Status = "U",
                     UserId = 1
                 },
                 new BlogCategory
                 {
                     CategoryName = "Nạp tiền điện thoại",
                     OrderNo = 1,
                     Status = "U",
                     UserId = 1
                 },
                 new BlogCategory
                 {
                     CategoryName = "Nạp thẻ game",
                     OrderNo = 1,
                     Status = "U",
                     UserId = 1
                 }
                );

                context.SaveChanges();
            }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<BlogPost> Post { get; set; }
        public DbSet<BlogCategory> Category { get; set; }
    }
}
