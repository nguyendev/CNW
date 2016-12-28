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
using Final.Areas.Wp_admin.ViewModels;

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
            DashboardViewModels vm = new DashboardViewModels();
            vm.Cateogory = _context.Category.Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToList();
            vm.Post = _context.Post.Where(p => p.Auth_status == "A" && p.Record_Status == 1).ToList();
            return View(vm);
        }

        public IActionResult Submit()
        {
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }
        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit([Bind("ID,Auth_status,AuthorId,CategoryId,Checker_ID,Content,Create_DT,Notes,Publish_DT,URL")] BlogPost blogPost)
        {
            var host = new System.Uri(blogPost.URL).Host;
            var domain = host.Substring(host.LastIndexOf('.', host.LastIndexOf('.') - 1) + 1);
            blogPost.ID = domain;
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
        public  IActionResult Success()
        {
            return View(); 
        }
        public IActionResult NotFound()
        {
            return View();
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