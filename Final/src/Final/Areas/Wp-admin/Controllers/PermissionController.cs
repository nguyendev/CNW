using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Final.Data;
using Final.Models;

namespace QuanLyWebsite.Areas.Admin.Controllers
{
    [Area("wp-admin")]
    [Authorize()]
    public class PermissionController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public PermissionController(ApplicationDbContext context)
        //{
        //    _context = context;    
        //}

        //// GET: Permission
        //public async Task<IActionResult> Index(string id)
        //{
        //    var FinalDbContext = _context.blogPermission.Where(x => x.BussinessCode == id);
        //    return View(await FinalDbContext.ToListAsync());
        //}

        //// GET: Permission/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
        //    if (blogPermission == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogPermission);
        //}

        //// GET: Permission/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Permission/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PermissionId,BussinessCode,Description,PermissionName")] BlogPermission blogPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(blogPermission);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogPermission);
        //}

        //// GET: Permission/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
        //    if (blogPermission == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(blogPermission);
        //}

        //// POST: Permission/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PermissionId,BussinessCode,Description,PermissionName")] BlogPermission blogPermission)
        //{
        //    if (id != blogPermission.PermissionId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(blogPermission);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BlogPermissionExists(blogPermission.PermissionId))
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
        //    return View(blogPermission);
        //}

        //// GET: Permission/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
        //    if (blogPermission == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogPermission);
        //}

        //// POST: Permission/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blogPermission = await _context.blogPermission.SingleOrDefaultAsync(m => m.PermissionId == id);
        //    _context.blogPermission.Remove(blogPermission);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool BlogPermissionExists(int id)
        //{
        //    return _context.blogPermission.Any(e => e.PermissionId == id);
        //}

        //public JsonResult getPermission(string id, int usertemp)
        //{
        //    //var listpermission = from p in _context.blogPermission
        //    //                     where p.BussinessCode == id
        //    //                     select new Permi
        //    return Json(null);
        //}
    }
}
