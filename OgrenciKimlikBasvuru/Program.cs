using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentCardApp.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/GirisYap/Login";
	});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<Context>();//
// Program.cs veya Startup.cs'deki ConfigureServices metoduna ekleyin:
//builder.Services.AddDbContext<Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//þimdi 17.09.2024 14:33 ekledim
builder.Services.AddScoped<UserRoleRepository>();////////
builder.Services.AddScoped<IRoleRepository, RoleRepository>(); // Use correct interface

builder.Services.AddScoped<UserRepository/*, UserRepository*/>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddTransient<IRoleService, RoleService>();//
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
//builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IUserDal, UserDal>(); 


builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.Cookie.Name = "UserLoginCookie";
        options.LoginPath = "/Login/GirisYap";
        options.LogoutPath = "/Login/Logout";   
        options.AccessDeniedPath = "/Home/AccessDenied"; 
    });

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

