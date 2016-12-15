using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Final.Data;
using Final.Infrastructure;
using Final.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Final.Areas.Admin.Controllers
{

    [Area("wp-admin")]
    public class BusinessController : Controller
    {
        //// GET: /<controller>/
        //private readonly ApplicationDbContext _context;
        //public BusinessController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.blogBusiness.ToListAsync());
        //}
        //public ActionResult UpdateBusiness()
        //{
        //    ReflectionControllerAction rc = new ReflectionControllerAction();
        //    List<Type> listControllerType = rc.GetControllers("Controllers");
        //    List<string> listControllerOld = _context.blogBusiness.Select(c => c.BusinessCode).ToList();
        //    List<string> listPermistionOld = _context.blogPermission.Select(p => p.PermissionName).ToList();
        //    foreach (var c in listControllerType)
        //    {
        //        if (!listControllerOld.Contains(c.Name))
        //        {
        //            BlogBusiness b = new BlogBusiness() { BusinessCode = c.Name, BusinessName = "Chua có mô ta" };
        //            _context.blogBusiness.Add(b);
        //        }
        //        List<string> listPermission = rc.GetActions(c);
        //        foreach (var p in listPermission)
        //        {
        //            if (!listPermistionOld.Contains(c.Name + "-" + p))
        //            {
        //                BlogPermission permission = new BlogPermission() { PermissionName = c.Name + "-" + p, Description = "Ch?a có mô t?", BussinessCode = c.Name };
        //                _context.blogPermission.Add(permission);
        //            }
        //        }
        //    }
        //    _context.SaveChanges();
        //    //TempData["err"] = "<div class='alert alert-info' role='alert'><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class='sr-only'></span> C?p nh?t thành công</div>";
        //    return RedirectToAction("Index");
        //}
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BusinessId == id);
        //    if (blogBusiness == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogBusiness);
        //}
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BusinessId == id);
        //    if (blogBusiness == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(blogBusiness);
        //}

        //// POST: BlogBusiness/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BusinessId,BusinessCode,BusinessName")] BlogBusiness blogBusiness)
        //{
        //    //if (id != blogBusiness.BusinessId)
        //    //{
        //    //    return NotFound();
        //    //}

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(blogBusiness);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BlogBusinessExists(blogBusiness.BusinessId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogBusiness);
        //}

        //// GET: BlogBusiness/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BusinessId == id);
        //    if (blogBusiness == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogBusiness);
        //}

        //// POST: BlogBusiness/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blogBusiness = await _context.blogBusiness.SingleOrDefaultAsync(m => m.BusinessId == id);
        //    _context.blogBusiness.Remove(blogBusiness);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool BlogBusinessExists(int id)
        //{
        //    return _context.blogBusiness.Any(e => e.BusinessId == id);
        //}
    }
}