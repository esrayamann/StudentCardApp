using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StudentCardApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly Context _context;
        public ApplicationController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ApplicationUserAsync(Application model)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (int.TryParse(userId, out int UserId))
                    {
                        model.UserId = UserId;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı kimliği geçersiz.");
                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "GirisYap");
                }



                _context.Applications.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Kullanici");
            }

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
