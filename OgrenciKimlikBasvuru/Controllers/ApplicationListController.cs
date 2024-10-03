using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public async Task<IActionResult> UserApplications()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(); 
            }

            var userBasvurular = await _applicationService.GetApplicationsByUserIdAsync(userId);
            return View(userBasvurular);
        }

    }
}
