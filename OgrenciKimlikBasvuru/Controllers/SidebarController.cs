using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class SidebarController:Controller
	{
        private readonly IRoleService _roleService;
        public SidebarController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
		{
            var roles = await _roleService.GetAllRolesAsync();
            return View(roles);
        }
	}
}
