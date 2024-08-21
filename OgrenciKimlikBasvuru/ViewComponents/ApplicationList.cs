using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.ViewComponents
{
    public class ApplicationList:ViewComponent
    {
        ApplicationManager am=new ApplicationManager(new EfApplicationRepository());

        public IViewComponentResult Invoke()
        {
            var values = am.GetList();
            return View(values);
        }
    }
}
