using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Security.Principal;

namespace BankApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            var transactions = _db.Transactions.Where(t => t.ApplicationUser == user).ToList();
            transactions.Reverse();
            user.Transactions = transactions;

            return View(user);
        }

        public IActionResult Tos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                TransactionModel transaction = new TransactionModel(dvm.Amount, "DEPOSIT", DateTime.Today);
                var user = await _userManager.FindByIdAsync(User.Identity.Name);
                user.Transactions.Add(transaction);
                user.Balance += dvm.Amount;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["prompt-title"] = "Deposit Successful!";
                    TempData["prompt-body"] = @"
                    <p>Successfully deposited €" + dvm.Amount +
                    ".<br>Your balance is now €" + user.Balance + ".</p>";
                    ModelState.Clear();
                }
                else
                {
                    TempData["prompt-title"] = "Something went wrong.";
                    TempData["prompt-body"] = "<p>Error!";
                    foreach (var error in result.Errors)
                    {
                        TempData["prompt-body"] += "<br>" + error;
                    }
                    TempData["prompt-body"] += "</p>";
                }
            }
            return View();
        }

        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                //Check if destination account exists.
                var destUser = await _userManager.FindByIdAsync(tvm.DestinationID.ToString());
                if (destUser != null)
                {
                    //Get source account.
                    var sourceUser = await _userManager.FindByIdAsync(User.Identity.Name);
                    //Check if source account has enough balance.
                    if(sourceUser.Balance >= tvm.Amount)
                    {
                        //Create transactions for both users.
                        TransactionModel sourceTransaction = new TransactionModel(tvm.Amount, "TRANSFER TO " + tvm.DestinationID, DateTime.Today);
                        TransactionModel destTransaction = new TransactionModel(tvm.Amount, "TRANSFER FROM " + User.Identity.Name, DateTime.Today);

                        //Update user balances.
                        sourceUser.Balance -= tvm.Amount;
                        destUser.Balance += tvm.Amount;

                        //Add transactions to both users.
                        sourceUser.Transactions.Add(sourceTransaction);
                        destUser.Transactions.Add(destTransaction);

                        //Ideally this would be done simultaniously so that if something goes wrong the transaction doesn't 'complete' on one side only.
                        //Not 100% sure how to implement this - could possibly create backups of the users and put those up if something fails?
                        var sourceResult = await _userManager.UpdateAsync(sourceUser);
                        var destResult = await _userManager.UpdateAsync(destUser);

                        if(sourceResult.Succeeded && destResult.Succeeded)
                        {
                            TempData["prompt-title"] = "Transfer Successful!";
                            TempData["prompt-body"] = @"
                              <p>Successfully transfered €" + tvm.Amount + " to User ID " + tvm.DestinationID +
                            ".<br>Your balance is now €" + sourceUser.Balance + ".</p>";
                            ModelState.Clear();
                        }
                        else //userManager errors.
                        {
                            var errors = sourceResult.Errors.Concat(destResult.Errors);
                            TempData["prompt-title"] = "Something went wrong.";
                            TempData["prompt-body"] = "<p>Error!";
                            foreach (var error in errors)
                            {
                                TempData["prompt-body"] += "<br>" + error;
                            }
                            TempData["prompt-body"] += "</p>";
                        }
                        return View();
                    }
                    //Not enough balance.
                    TempData["prompt-title"] = "Transfer failed!";
                    TempData["prompt-body"] = "<p>You do not have enough balance to complete this transaction.</p>";
                    return View();
                }
                //Dest user doesn't exist.
                TempData["prompt-title"] = "Transfer failed!";
                TempData["prompt-body"] = "<p>User ID " + tvm.DestinationID + " could not be found.</p>";
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}