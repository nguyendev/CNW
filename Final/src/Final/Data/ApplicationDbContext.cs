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

            string usernamecollaborator = configuration["Data:CollaboratorUser:Name"];
            string emailcollaborator = configuration["Data:CollaboratorUser:Email"];
            string passwordcollaborator = configuration["Data:CollaboratorUser:Password"];
            string rolecollaborator = configuration["Data:CollaboratorUser:Role"];

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
            //Tao tai khoan collaborator
            if (await userManager.FindByNameAsync(usernamecollaborator) == null)
            {
                if (await roleManager.FindByNameAsync(rolecollaborator) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(rolecollaborator));
                }
                BlogMember userco = new BlogMember
                {
                    UserName = usernamecollaborator,
                    Email = emailcollaborator
                };
                IdentityResult result = await userManager
                .CreateAsync(userco, passwordcollaborator);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userco, rolecollaborator);
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
        public static async Task CreateExampleCategory(IServiceProvider serviceProvider)
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
                     CategoryId = 1,
                     OrderNo = 1,
                     Auth_status = "A",
                     Record_Status = 1,
                     CategoryDes = "Các trang web giả mạo giao diện facebook, khiến người dùng đăng nhập vào",
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example"
                 },
                 new BlogCategory
                 {
                     CategoryName = "Nạp tiền điện thoại",
                     OrderNo = 1,
                     CategoryId = 2,
                     Auth_status = "A",
                     Record_Status = 1,
                     CategoryDes = "Các trang web đề nghị nạp tiền điện thoại",
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example"
                 },
                 new BlogCategory
                 {
                     CategoryName = "Nạp thẻ game",
                     OrderNo = 1,
                     CategoryId = 3,
                     Auth_status = "A",
                     Record_Status = 1,
                     CategoryDes = "Các trang web đề nghị nạp thẻ game",
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example"
                 }
                );

                await context.SaveChangesAsync();
            }

        }
        public static async Task CreateExamplePost(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {


                if (context.Post.Any())
                {
                    return;   // DB has been seeded
                }
                context.Post.AddRange(
                 new BlogPost
                 {
                     
                     CategoryId = 1,
                     URL = "http://letrianthang.com",
                     Content = "Trang web này thông báo rằng bạn đã trúng thưởng trên Zalo và yêu cần bạn nhập tài khoản Zalo vào để lãnh thưởng",
                     Auth_status = "A",
                     Record_Status = 1,
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example",
                     ID = "http://letrianthang.com"
                 },
                 new BlogPost
                 {
                     CategoryId = 2,
                     URL = "http://traogiaichinhthuc.net",
                     Content = "Trang web này thông báo rằng bạn đã trúng thưởng trên điện thoại và yêu cần bạn nhập tài khoản facebook vào để lãnh thưởng",
                     Auth_status = "A",
                     Record_Status = 1,
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example",
                     ID = "http://traogiaichinhthuc.net"
                 },
                 new BlogPost
                 {
                     CategoryId = 3,
                     URL = "http://websitechinhchu.com",
                     Content = "Trang web này thông báo rằng bạn đã trúng thưởng trên facebook và yêu cần bạn nhập tài khoản Zalo vào để lãnh thưởng",
                     Auth_status = "A",
                     Record_Status = 1,
                     Publish_DT = DateTime.Now,
                     Create_DT = DateTime.Now,
                     Notes = "example",
                     ID = "http://websitechinhchu.com"
                 }
                );

                await context.SaveChangesAsync();
            }

        }
        public static async Task CreateExampleAuth(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {


                if (context.SYS_AUTH_STATUS.Any())
                {
                    return;   // DB has been seeded
                }
                context.SYS_AUTH_STATUS.AddRange(
                new SYS_AUTH_STATUS
                {
                    AUTH_STATUS_NAME = "Đã duyệt",
                    AUTH_STATUS = "A"
                },
                 new SYS_AUTH_STATUS
                 {
                     AUTH_STATUS_NAME = "Chờ duyệt",
                     AUTH_STATUS = "U"
                 });

                await context.SaveChangesAsync();
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
        public DbSet<SYS_AUTH_STATUS> SYS_AUTH_STATUS { get; set; }
    }
}
