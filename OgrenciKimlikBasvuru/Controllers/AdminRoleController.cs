using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class AdminRoleController : Controller
    {
        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
