using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCardApp.Models;

namespace StudentCardApp.Controllers
{
	public class RegisterController:Controller
	{
		private readonly IUserService _userService;
		private readonly Context _context;

		public RegisterController(Context context, IUserService userservice)
		{
			_context = context;
			_userService = userservice;
		}          
        

        UserManager um=new UserManager(new EfUserRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(BusinessLayer.Abstract.RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _userService.RegisterUserAsync(model);
				return RedirectToAction("Login", "GirisYap");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult Index(User p)
		{
			UserValidator uv = new UserValidator();
			ValidationResult results = uv.Validate(p);
			if (results.IsValid)
			{
				um.UserAdd(p);
				return RedirectToAction("Index", "Kullanici");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}				
			}
			return View();
		}


	}
}
