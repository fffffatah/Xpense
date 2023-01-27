using Microsoft.AspNetCore.Mvc;

namespace Xpense.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
