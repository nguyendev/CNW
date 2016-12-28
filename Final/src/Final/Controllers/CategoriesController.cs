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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            DashboardViewModels vm = new DashboardViewModels();
            vm.Cateogory = await _context.Category.Include(b => b.Author).Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToListAsync();
            vm.Post = await _context.Post.Include(b => b.Author).Include(b => b.Category).Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToListAsync();
            return View(vm);
        }

        // GET: Categories/Details/5
        [Route("danh-muc/{id}", Name = "CategoriesInfo")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            DashboardViewModels vm = new DashboardViewModels();
            vm.Cateogory = await _context.Category.Include(b => b.Author).Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToListAsync();
            vm.Post = await _context.Post.Where(p => p.CategoryId == id).ToListAsync();
            if (vm.Post == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        private bool BlogCategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
