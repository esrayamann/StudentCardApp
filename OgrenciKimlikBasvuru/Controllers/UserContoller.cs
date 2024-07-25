using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class UserContoller:Controller
	{
		UserManager um=new UserManager(new EfUserRepository());
		public IActionResult Index()
		{
			var values = um.GetList();
			return View(values);
		}
	}
}
