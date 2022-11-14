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
                transaction.Date = new DateOnly(); //assuming this is current date
                transaction.Message = "DEPOSIT";

                TempData["success"] = true;
                TempData["success-amount"] = depositViewModel.Amount.ToString();

                ModelState.Clear(); //Clears the form, no need for it to be filled anymore.
                return View();
            }
            return View(depositViewModel);
        }
    }
}