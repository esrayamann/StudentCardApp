using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class StudentController : Controller
    {
        [Authorize(Roles = "User")]
        //[Authorize(Policy ="AdminOnly")]//
        public IActionResult Index()
        {
            return View();
        }
    }
}
