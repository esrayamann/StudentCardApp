using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class UserService : IUserService
    { 
        private readonly Context _context;
        private readonly IPasswordHasher<User> _passwordHasher;


        public UserService(Context context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role).ToListAsync();

        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task RegisterUserAsync(ApplicationViewModel model)
        {
            if (model.Sifre != model.ConfirmPassword)
            {
                throw new Exception("Şifreler eşleşmiyor.");
            }

            var user = new User
            {
                Email = model.Email,
                Sifre = _passwordHasher.HashPassword(null, model.Sifre) // Şifre hash'leme
            };

            var userRole = new UserRole
            {
                User = user,
                Role = await _context.Roles.FirstOrDefaultAsync(r => r.Ad == "User")
            };

            _context.Users.Add(user);
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateUserAsync(string email, string Sifre)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;

            // Şifreyi doğrulayın
            var result = _passwordHasher.VerifyHashedPassword(user, user.Sifre, Sifre);
            return result == PasswordVerificationResult.Success;
        }

        public void UserAdd(User user)
        {
            throw new NotImplementedException();
        }

        public Task GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> AllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

    }
}
