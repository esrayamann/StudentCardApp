using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly Context _context;

        public RoleRepository(Context context)
        {
            _context = context;
        }

        public Task DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public Role GetRoleById(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
