using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
