using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public HomeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var accounts = _dbContext.Accounts.Include(x => x.Transactions).Where(x => x.UserID == 1);
            var account = accounts.FirstOrDefault();
            return View(account);
        }

        public IActionResult Deposit()
        {
            return View();
        }

        public IActionResult Tos()
        {
            return View();
        }
		
        public IActionResult Transfer()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Deposit(DepositViewModel depositViewModel)
        {
            if (ModelState.IsValid)
            {
                //create the transaction
                TransactionModel transaction = new TransactionModel();
                transaction.Amount = depositViewModel.Amount;
                transaction.Date = DateTime.Today;
                transaction.Message = "DEPOSIT";

                //get user and add transaction to their user entity
                var user = _dbContext.Accounts.Find(1);
                user.Transactions.Add(transaction);
                user.Balance += depositViewModel.Amount;

                //update & save db
                _dbContext.Accounts.Update(user);
                _dbContext.SaveChanges();

                TempData["success"] = true;
                TempData["success-amount"] = depositViewModel.Amount.ToString();
                TempData["prompt-message"] = "Deposited €" + depositViewModel.Amount + " successfully.";

                ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                return View();
            }
            return View(depositViewModel);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel transferViewModel)
        {
            if (ModelState.IsValid)
            {
                //check if destination id exists
                var destUserFromDb = _dbContext.Accounts.Find(transferViewModel.DestinationID);

                if (destUserFromDb != null)
                {
                    var sourceUserFromDb = _dbContext.Accounts.Find(1);

                    //handle source user entity
                    TransactionModel userTransaction = new TransactionModel();
                    userTransaction.Amount = -transferViewModel.Amount;
                    userTransaction.Date = DateTime.Today;
                    userTransaction.Message = "TRANSFER - " + transferViewModel.DestinationID;
                    sourceUserFromDb.Transactions.Add(userTransaction);
                    sourceUserFromDb.Balance -= transferViewModel.Amount;

                    //handle destination user entity
                    TransactionModel destTransaction = new TransactionModel();
                    destTransaction.Amount = transferViewModel.Amount;
                    destTransaction.Date = DateTime.Today;
                    destTransaction.Message = "TRANSFER - 1"; //sender's UserID here
                    destUserFromDb.Transactions.Add(destTransaction);
                    destUserFromDb.Balance += transferViewModel.Amount;

                    _dbContext.Accounts.Update(sourceUserFromDb);
                    _dbContext.Accounts.Update(destUserFromDb);
                    _dbContext.SaveChanges();

                    TempData["success"] = true;
                    TempData["prompt-message"] = "Transferred €" + transferViewModel.Amount + " to User ID " + transferViewModel.DestinationID + " successfully.";

                    ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                    return View();
                } else
                {
                    //error handle please thanks
                }
            }
            return View(transferViewModel);
        }
    }
}