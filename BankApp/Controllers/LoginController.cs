using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class LoginController : Controller
    {
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
                //if login details are correct, create session, redirect user, etc.
                if (true)
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
