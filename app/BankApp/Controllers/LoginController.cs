using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.UserID, lvm.PIN, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["prompt-title"] = "Something went wrong.";
                    TempData["prompt-body"] = "<p>Invalid account details entered. Please try again.</p>";
                }
            }
            return View();
        }
    }
}
