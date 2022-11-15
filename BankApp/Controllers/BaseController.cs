using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
