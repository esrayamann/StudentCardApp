using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class SidebarController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
