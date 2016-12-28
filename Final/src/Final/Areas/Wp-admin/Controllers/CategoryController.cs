using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Authorization;

namespace Final.Areas.Wp_admin.Controllers
{
    [Area("wp-admin")]
    [Authorize(Roles = "Collaborator")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.Where(b => b.Record_Status == 1).ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }

            return View(blogCategory);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDes,OrderNo,Status,UserId")] BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                blogCategory.Auth_status = "A";
                blogCategory.Create_DT = DateTime.Now;
                blogCategory.Record_Status = 1;
                _context.Add(blogCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogCategory);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return View(blogCategory);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDes,OrderNo,Notes,Record_Status,Publish_DT")] BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    blogCategory.Auth_status = "A";
                    blogCategory.Publish_DT = DateTime.Now;
                    blogCategory.Record_Status = 1;

                    _context.Update(blogCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogCategoryExists(blogCategory.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blogCategory);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            try
            {
                if (blogCategory.Auth_status.Equals("U"))
                    _context.Category.Remove(blogCategory);
                else
                { 
                    blogCategory.Record_Status = 0;
                    _context.Update(blogCategory);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception) { }
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blogCategory = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
        //    try
        //    {
        //        if (blogCategory.Auth_status.Equals("U"))
        //            _context.Category.Remove(blogCategory);
        //        else
        //            blogCategory.Record_Status = 0;
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception) { }
            
        //    return RedirectToAction("Index");
        //}

        private bool BlogCategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
