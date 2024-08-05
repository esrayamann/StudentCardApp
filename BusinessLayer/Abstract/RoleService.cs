using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class RoleService : IRoleService
    {
        private readonly Context _context;

        public RoleService(Context context)
        {
            _context = context;
        }

        public async Task AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
