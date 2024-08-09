using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();//

builder.Services.AddScoped<UserRepository/*, UserRepository*/>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddTransient<IRoleService, RoleService>();//
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();


builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.Cookie.Name = "UserLoginCookie";
        options.LoginPath = "/Login/GirisYap"; 
        options.AccessDeniedPath = "/Home/AccessDenied"; 
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

