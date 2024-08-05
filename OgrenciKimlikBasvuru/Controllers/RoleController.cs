using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace StudentCardApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            var roles= await _roleService.GetAllRolesAsync();
            return View(roles); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleAsync(id);

            return NoContent();
        }
        
    }
}
