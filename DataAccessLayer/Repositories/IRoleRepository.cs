using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRoleRepository
    {
        Role GetRoleById(int roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task DeleteRoleAsync(int id);

    }
}
