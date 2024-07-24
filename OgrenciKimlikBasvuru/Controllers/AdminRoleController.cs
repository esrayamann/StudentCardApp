using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class AdminRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
