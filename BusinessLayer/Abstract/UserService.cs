using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
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
        private readonly UserRoleRepository _userRoleRepository;


        public UserService(Context context, IPasswordHasher<User> passwordHasher, UserRoleRepository userRoleRepository)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _userRoleRepository = userRoleRepository;
        }
        //public void UpdateUserRole(int userId, int newRoleId)
        //{
        //    _userRoleRepository.UpdateUserRole(userId, newRoleId);
        //}
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role).ToListAsync();

        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            //return await _context.Users.FindAsync(id);
            return await _context.Users
             .Include(u => u.UserRoles)  
             .ThenInclude(ur => ur.Role) 
             .FirstOrDefaultAsync(u => u.Id == id);
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

        public async Task<bool> UploadPhotoAsync(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return false;

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                user.Foto = Convert.ToBase64String(fileBytes); // Base64 formatına çevirmek
            }

            _context.SaveChanges();

            return true;
        }
        public async Task<string> GetPhotoAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || string.IsNullOrEmpty(user.Foto))
            {
                return null;
            }

            return user.Foto;  // Base64 string formatındaki fotoğrafı döner.
        }
        public async Task UpdateUserRolesAsync(int userId, /*object selectedRoles,*/ List<int> newRoleIds)
        {
            var user = await _context.Users.Include(u => u.UserRoles)
                                              .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                _context.UserRoles.RemoveRange(user.UserRoles);

                foreach (var roleId in newRoleIds)
                {
                    var role = await _context.Roles.FindAsync(roleId);
                    if (role != null)
                    {
                        user.UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId });
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        public void UpdateUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRoleAsync(int userId, object selectedRoles)
        {
            throw new NotImplementedException();
        }
    }
}
