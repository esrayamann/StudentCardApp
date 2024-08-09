using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class ApplicationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
