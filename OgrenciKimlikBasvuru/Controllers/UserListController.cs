using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
    public class UserListController : Controller
    {
        private readonly IUserService _userService;

        public UserListController(IUserService UserService)
        {
            _userService = UserService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
