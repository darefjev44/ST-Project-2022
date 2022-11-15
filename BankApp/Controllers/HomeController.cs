using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Deposit()
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
                TransactionModel transaction = new TransactionModel();
                transaction.Amount = depositViewModel.Amount;
                transaction.Date = DateTime.Today;
                transaction.Message = "DEPOSIT";

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

                TransactionModel userTransaction = new TransactionModel();
                userTransaction.Amount = -transferViewModel.Amount;
                userTransaction.Date = DateTime.Today;
                userTransaction.Message = "TRANSFER - " + transferViewModel.DestinationID;

                TransactionModel destTransaction = new TransactionModel();
                destTransaction.Amount = transferViewModel.Amount;
                destTransaction.Date = DateTime.Today;
                destTransaction.Message = "TRANSFER - 999999"; //sender's UserID here

                //add to appropriate account model's Transactions lists, DB update

                TempData["success"] = true;
                TempData["prompt-message"] = "Transferred €" + transferViewModel.Amount + " to User ID " + transferViewModel.DestinationID + " successfully.";

                ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                return View();
            }
            return View(transferViewModel);
        }
    }
}