using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using StudentCardApp.Models;
using System.Security.Claims;

namespace StudentCardApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BasvuruViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return RedirectToAction("GirisYap", "Login");
                }

                if (int.TryParse(userIdClaim.Value, out int userId))
                {
                    var basvuru = new Basvuru
                    {
                        UserId = userId,
                        BasvuruNedeni = model.BasvuruNedeni,
                        Adres = model.Adres
                    };

                    await _applicationService.ApplicationUserAsync(basvuru);

                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı kimliği.");
                }
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
