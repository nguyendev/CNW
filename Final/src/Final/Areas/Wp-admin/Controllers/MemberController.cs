using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Final.Models;
using Final.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Final.Areas.Admin.Controllers
{
    [Area("wp-admin")]
    [Authorize]
    public class MemberController : Controller
    {
        // GET: /<controller>/
        private UserManager<BlogMember> _userManager;
        private IUserValidator<BlogMember> _userValidator;
        private IPasswordValidator<BlogMember> _passwordValidator;
        private IPasswordHasher<BlogMember> _passwordHasher;
        public MemberController(UserManager<BlogMember> userManager,
            IUserValidator<BlogMember> userValid,
            IPasswordValidator<BlogMember> passValid,
            IPasswordHasher<BlogMember> passwordHash)
        {
            _userManager = userManager;
            _userValidator = userValid;
            _passwordHasher = passwordHash;
            _passwordValidator = passValid;
        }
        public ViewResult Index()
        {
            return View(_userManager.Users);
        }
        //[Route("create")]
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                BlogMember user = new BlogMember
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            BlogMember user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            BlogMember user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email,
        string password)
        {
            BlogMember user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager,
                    user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user,
                        password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                || (validEmail.Succeeded
                && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }
    }
}
