using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public class RoleDal : IRoleDal
    {
        private readonly Context _context;

        public RoleDal(Context context)
        {
            _context = context;
        }

        public void Delete(Role t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public Role GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public List<Role> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetListByType(Expression<Func<Role, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Role t)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public void Update(Role t)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
