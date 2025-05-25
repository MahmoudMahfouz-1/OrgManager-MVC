using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVC_Core.Models;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        public async Task<IActionResult> SaveRegister(RegisterUserViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Save in th DB
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = registerViewModel.UserName;
                appUser.PasswordHash = registerViewModel.Password;
                appUser.Address = registerViewModel.Address;

                var result = await userManager.CreateAsync(appUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    // Create Cookie 
                    await signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("Details", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", registerViewModel);
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        public async Task<IActionResult> SaveLogin(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid && userViewModel != null)
            {
                var user = await userManager.FindByNameAsync(userViewModel.UserName);
                if (user != null)
                {
                    // Check Password 
                    bool found = await userManager.CheckPasswordAsync(user,userViewModel.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, userViewModel.RememberMe);
                        return RedirectToAction("Details", "Department");
                    }
                }
                ModelState.AddModelError("", "UserName or Password is Wrong");
            }
            return View("Login",userViewModel);
            // Get the account based on the name
        }
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }

    }
}
