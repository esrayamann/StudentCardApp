using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.ViewComponents
{
	public class UserList:ViewComponent
	{
		UserManager um=new UserManager(new EfUserRepository());
		public IViewComponentResult Invoke()
		{
			var values = um.GetList();
			return View(values);
		}
	}
}
