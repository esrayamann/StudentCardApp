using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        public UserService(Context context) {  _context = context; }
        public async Task AddRoleToUserAsync(int userId, string roleName)
        {
            var user = await _context.Users.FindAsync(userId);
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Ad == roleName);
            if (user != null && role != null)
            {
                _context.UserRoles.Add(new UserRole { Id = userId, RoleId = role.Id });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
