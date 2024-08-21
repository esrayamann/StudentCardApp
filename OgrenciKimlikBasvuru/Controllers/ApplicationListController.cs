using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class ApplicationListController : Controller
	{
		private readonly IApplicationService _applicationService;

		public ApplicationListController(IApplicationService ApplicationService)
		{
			_applicationService = ApplicationService;
		}

		public async Task<IActionResult> Index()
		{
			var basvurular = await _applicationService.GetAllApplicationsAsync();
			return View(basvurular);
		}
	}
}
