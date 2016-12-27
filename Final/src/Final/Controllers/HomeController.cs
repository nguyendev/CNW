using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO;
using Final.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final.Models;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit()
        {
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit([Bind("ID,Auth_status,AuthorId,CategoryId,Checker_ID,Content,Create_DT,Notes,Publish_DT,URL")] BlogPost blogPost)
        {
            blogPost.ID = blogPost.URL;
            if (ModelState.IsValid)
            {
                blogPost.Auth_status = "U";
                blogPost.Create_DT = DateTime.Now;
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }
        //public async Task<string> UploadImage()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();
        //    //string pathmap = "";
        //    //if (Request.Form.Files.Any())
        //    //{
        //    //    var httpPostedFile = HttpContext.Request.Form.Files["file"];
        //    //    if (httpPostedFile != null && httpPostedFile.Length > 0)
        //    //    {

        //    //        Stream uploadFileStream = httpPostedFile.OpenReadStream();
        //    //        var client = new ImgurClient("...", "...");
        //    //        var imageEndpoint = new ImageEndpoint(client);
        //    //        var image = await imageEndpoint.UploadImageStreamAsync(uploadFileStream, null, "Awesome pic!", "Took me weeks to get this shot.");
        //    //        pathmap = image.Link;

        //    //    }
        //    //}


        //    return pathmap;
        //}
        public IActionResult CreateTicket()
        {
            return View();
        }
    }
}