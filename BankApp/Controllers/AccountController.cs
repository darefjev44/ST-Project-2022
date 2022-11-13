using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //REGISTRATION FORM (POST)
        [HttpPost]
        public IActionResult Register(AccountModel account)
        {
            account.Transactions = new List<TransactionModel>();
            account.PIN = 100000; //temp
            ModelState.Append()
            if (ModelState.IsValid)
            {
                TempData["success"] = "Account succesfully registered!";
                return RedirectToAction("Index");
            }
            return View(account);
        }
    }
}
