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
        public IActionResult Register(RegisterViewModel avm)
        {
            if (ModelState.IsValid)
            {
                AccountModel account = new AccountModel(); //this can and should be done via a new constructor e.g AccountModel(AccountViewModel)
                account.FirstName = avm.FirstName;
                account.LastName = avm.LastName;
                account.Address1 = avm.Address1;
                account.Address2 = avm.Address2;
                account.City = avm.City;
                account.County = avm.County;
                account.Eircode = avm.Eircode;
                account.Email = avm.Email;
                account.PhoneNumber = avm.PhoneNumber;

                //Add additional values that shouldn't be from the user.
                account.Transactions = new List<TransactionModel>();
                //PIN, probably done elsewhere once we have identities?
                Random r = new Random();
                account.PIN = r.Next(100000, 999999);

                //TempData for registration success notification
                TempData["success"] = true;
                TempData["success-id"] = account.UserID;
                TempData["success-pin"] = account.PIN;

                ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                return View();
            }
            return View(avm);
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
