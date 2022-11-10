using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
           
        }
    }
}
