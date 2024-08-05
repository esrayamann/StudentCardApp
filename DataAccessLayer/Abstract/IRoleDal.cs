using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRoleDal : IGenericDal<Role>
    {
        //void InsertRole(Role role);
        Task InsertAsync(Role role);
        Task DeleteAsync(Role role);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task UpdateAsync(Role role);
    }
}
