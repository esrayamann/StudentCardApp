using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCardApp.Models;

namespace StudentCardApp.Controllers
{
    public class UserListController : Controller
    {

        private readonly IUserService _userService;
        private readonly Context _context;

        public UserListController(IUserService userService, Context context)
        {
            _userService = userService;
            _context = context;
        }

        //public IUserService Get_userService()
        //{
        //    return _userService;
        //}

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            //var role = await _userService.GetAllRolesAsync();
            //ViewBag.Roles = role;

            return View(users);

        }
        //[HttpPost]
        //public async Task<IActionResult> UpdateUserRole(int userId, int newRoleId)
        //{
        //    var user = await _context.Users
        //        .Include(u => u.UserRoles)
        //        .FirstOrDefaultAsync(u => u.Id == userId);

        //    if (user != null)
        //    {
        //        var userRole = user.UserRoles.FirstOrDefault(ur => ur.RoleId == newRoleId);
        //        if (userRole == null)
        //        {
        //            user.UserRoles.Add(new UserRole { UserId = userId, RoleId = newRoleId });
        //        }
        //        else
        //        {
        //        }

        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> EditRole(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var allRoles = await _userService.AllRolesAsync();

            var model = new EditRoleViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,
                CurrentRoles = user.UserRoles.Select(ur => ur.RoleId).ToList(),
                AllRoles = allRoles.ToList()
            };

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> EditRole(EditRoleViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _userService.UpdateUserRolesAsync(model.UserId, model.SelectedRoles);
        //        return RedirectToAction("Index");
        //    }

        //    var user = await _userService.GetUserByIdAsync(model.UserId);
        //    model.UserEmail = user.Email;
        //    model.AllRoles = (await _userService.AllRolesAsync()).ToList();

        //    return View(model);
        //}

    }
}
