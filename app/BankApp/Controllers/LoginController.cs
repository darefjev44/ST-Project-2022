using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //LOGIN FORM (POST)
        [HttpPost]
        public IActionResult Index(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var account = _db.Accounts.Find(lvm.UserID);

                //if login details are correct, create session, redirect user, etc.
                if (account != null && account.PIN == lvm.PIN) //replace this with actual authentication for the love of god
                {
                    return RedirectToAction("Index", "Home");
                } 
                else //otherwise return current view, with failure prompt
                { 
                    TempData["message"] = "Invalid account details entered. Please try again.";
                    return View();
                }
            }
            return View(lvm);
        }
    }
}
