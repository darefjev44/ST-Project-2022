using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDBContext _db;

        public RegisterController(ApplicationDBContext db){
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //REGISTRATION FORM (POST)
        [HttpPost]
        public IActionResult Index(RegisterViewModel avm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser account = new ApplicationUser(); //this can and should be done via a new constructor e.g AccountModel(AccountViewModel)
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
                account.PIN = r.Next(100000, 999999).ToString();

                _db.Accounts.Add(account);
                _db.SaveChanges();

                //TempData for registration success notification
                TempData["success"] = true;
                TempData["success-id"] = account.UserID;
                TempData["success-pin"] = account.PIN;

                ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                return View();
            }
            return View(avm);
        }
    }
}
