﻿using BankApp.Models;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;

namespace BankApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            var transactions = _db.Transactions.Where(t => t.ApplicationUser == user).ToList();
            user.Transactions = transactions;

            return View(user);
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
        public async Task<IActionResult> Deposit(DepositViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                TransactionModel transaction = new TransactionModel(dvm.Amount, "DEPOSIT", DateTime.Today);
                var user = await _userManager.FindByIdAsync(User.Identity.Name);
                user.Transactions.Add(transaction);
                await _userManager.UpdateAsync(user);
                /*
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
                */
            }
            return View(dvm);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel transferViewModel)
        {
            if (ModelState.IsValid)
            {
                /*
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
                */
            }
            return View(transferViewModel);
        }
    }
}