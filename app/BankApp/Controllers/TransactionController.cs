using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
