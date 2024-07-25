using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
