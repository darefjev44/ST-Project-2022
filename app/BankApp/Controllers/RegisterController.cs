using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankApp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<RegisterController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Address1 = rvm.Address1,
                    Address2 = rvm.Address2,
                    City = rvm.City,
                    County = rvm.County,
                    Eircode = rvm.Eircode,
                    PhoneNumber = rvm.PhoneNumber,
                    Email = rvm.Email,
                    UserName = rvm.Email
                };

                Random r = new Random();
                var pin = r.Next(100000, 999999).ToString();

                var result = await _userManager.CreateAsync(user, pin);

                if (result.Succeeded)
                {
                    TempData["prompt-title"] = "Successfully registered!";
                    TempData["prompt-body"] = @"
                    <p>Your account details are:
                        <br>User ID: " + user.Id +
                        "<br>PIN: " + pin +
                        @"<br /><span class='text-muted'>Please keep this information safe!</span>
                    </p>";
                    return View();
                } else
                {
                    TempData["prompt-title"] = "Something went wrong.";
                    TempData["prompt-body"] = "<p>Error!";
                    foreach(var error in result.Errors)
                    {
                        TempData["prompt-body"] += "<br>" + error;
                    }
                    TempData["prompt-body"] += "</p>";
                }
            }
            return View();
        }
    }
}
