using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public async Task AddRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleDal.InsertAsync(role);
        }

        public Task<IEnumerable<Role>> AllRolesAsync()
        {
            throw new NotImplementedException();
        }//

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _roleDal.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException("Rol bulunamadı");
            }

            await _roleDal.DeleteAsync(role);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
             return await _roleDal.GetAllAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleDal.GetByIdAsync(id);
        }


        public async Task UpdateRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleDal.UpdateAsync(role);
        }
    }
}
