using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace StudentCardApp.Controllers
{
	public class UserContoller:Controller
	{
		UserManager um=new UserManager(new EfUserRepository());
		private readonly IUserService _userService;

        public UserContoller(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file, int userId)
        {
            var result = await _userService.UploadPhotoAsync(userId, file);
            if (!result)
                return BadRequest("Fotoğraf yüklenirken bir hata oluştu.");

            return Ok("Fotoğraf başarıyla yüklendi ve veritabanına kaydedildi.");
        }
        [HttpGet("getphoto")]
        public async Task<IActionResult> GetPhoto(int userId)
        {
            var photo = await _userService.GetPhotoAsync(userId);
            if (string.IsNullOrEmpty(photo))
                return NotFound("Fotoğraf bulunamadı.");

            return Ok(photo);  
        }
        public IActionResult Index()
		{
			var values = um.GetList();
			return View(values);
		}
        //[HttpPost]
        //public IActionResult UpdateUserRole(int userId, int roleId)
        //{
        //    _userService.UpdateUserRole(userId, roleId);
        //    return RedirectToAction("Index","Admin");
        //}
    }
}
