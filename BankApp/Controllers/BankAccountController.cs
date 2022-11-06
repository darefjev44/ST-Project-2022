using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class BankAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
