using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final.Areas.Wp_admin.ViewModels;
using Final.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Final.Areas.Wp_admin.Controllers
{
    [Area("wp-admin")]
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var vm = new DashboardViewModels();
            vm.Post = _context.Post.Where(p => p.Record_Status != 0).ToList();
            vm.Cateogory = _context.Category.Where(p => p.Record_Status != 0).ToList();
            vm.CountUser = _context.Users.Count();
            _context.Roles.Count();
            int temp1 = _context.UserRoles.Where((p => p.RoleId == _context.Roles.Where(e => e.Name == "Admins").SingleOrDefault().Id)).Count();
            int temp2 = _context.UserRoles.Where((p => p.RoleId == _context.Roles.Where(e => e.Name == "Collaborator").SingleOrDefault().Id)).Count();
            vm.CountManager = temp1 + temp2;
            vm.Member = _context.Users.ToList();
            return View(vm);
        }
    }
}
