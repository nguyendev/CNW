using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;
using Final.Areas.Wp_admin.ViewModels;

namespace Final.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Posts/Details/5
        [Route("url/{id}", Name = "PostsInfo")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DashboardViewModels vm = new DashboardViewModels();
            vm.Cateogory = await _context.Category.Include(b => b.Author).Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToListAsync();
            vm.Post = await _context.Post.Where(p => p.ID == id).ToListAsync();
            if (vm.Post == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Posts/Create
       

        private bool BlogPostExists(string id)
        {
            return _context.Post.Any(e => e.ID == id);
        }
    }
}
