using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRoleRepository
    {
        private readonly Context _context;
        public UserRoleRepository(Context context)
        {
            _context = context;
        }
        //public void UpdateUserRole(int userId, int newRoleId)
        //{
        //    var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
        //    if (userRole != null)
        //    {
        //        userRole.RoleId = newRoleId;
        //        _context.SaveChanges();
        //    }
        //}
    }
}
