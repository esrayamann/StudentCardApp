using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace StudentCardApp.Controllers
{  
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(User p)
        {          
            var user = _context.Users
               .Include(u => u.UserRoles)
               .ThenInclude(ur => ur.Role)
               .FirstOrDefault(x => x.Email == p.Email && x.Sifre == p.Sifre);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                    //new Claim(ClaimTypes.Email, p.Email)
                };

                foreach (var role in user.UserRoles.Select(ur => ur.Role.Ad))
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var useridentity = new ClaimsIdentity(claims, "CookieAuthentication");
                //ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);//
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);

                if (user.UserRoles.Any(ur => ur.RoleId==1))
                {
                    return RedirectToAction("Index", "Sidebar");
                }
                else if (user.UserRoles.Any(ur => ur.RoleId==2))
                {
                    return RedirectToAction("Index", "Kullanici");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "Login");
        }
    }
}
