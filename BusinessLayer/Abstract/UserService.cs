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

        public UserService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public void UserAdd(User user)
        {
            throw new NotImplementedException();
        }

        //Task<List<User>> IUserService.GetAllUsersAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
