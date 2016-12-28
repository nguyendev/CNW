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
    [Authorize]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post.Include(b => b.Author).Include(b => b.Category);
            return View(await applicationDbContext.Where(b => b.Record_Status == 1).ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.Post.SingleOrDefaultAsync(m => m.ID == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["Auth_status"] = new SelectList(_context.SYS_AUTH_STATUS, "AUTH_STATUS", "AUTH_STATUS_NAME", blogPost.Auth_status);
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", blogPost.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", blogPost.CategoryId);
            return View(blogPost);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Auth_status,AuthorId,CategoryId,Checker_ID,Content,Create_DT,Notes,Publish_DT,URL")] BlogPost blogPost)
        {
            blogPost.ID = blogPost.URL;
            if (ModelState.IsValid)
            {
                blogPost.Auth_status = "U";
                blogPost.Create_DT = DateTime.Now;
                blogPost.Record_Status = 1;
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var blogPost = await _context.Post.SingleOrDefaultAsync(m => m.ID == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["Auth_status"] = new SelectList(_context.SYS_AUTH_STATUS, "AUTH_STATUS", "AUTH_STATUS_NAME", blogPost.Auth_status);
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", blogPost.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", blogPost.CategoryId);
            return View(blogPost);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Auth_status,AuthorId,CategoryId,Checker_ID,Content,Notes,Publish_DT,URL")] BlogPost blogPost)
        {
            if (id != blogPost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blogPost.Publish_DT = DateTime.Now;
                    blogPost.Record_Status = 1;
                    blogPost.Create_DT = DateTime.Now;
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.ID))
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
            return View(blogPost);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.Post.SingleOrDefaultAsync(m => m.ID == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blogPost = await _context.Post.SingleOrDefaultAsync(m => m.ID == id);
            try
            {
                if (blogPost.Auth_status.Equals("U"))
                    _context.Post.Remove(blogPost);
                else
                    blogPost.Record_Status = 0;
                await _context.SaveChangesAsync();
            }
            catch (Exception) { }
            return RedirectToAction("Index");
        }

        private bool BlogPostExists(string id)
        {
            return _context.Post.Any(e => e.ID == id);
        }
    }
}
