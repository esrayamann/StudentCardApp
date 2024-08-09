using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}		

		public void UserAdd(User user)
		{
			_userDal.Insert(user);
		}
		public List<User> GetList()
		{
			return _userDal.GetListAll();
		}
		public bool ValidateUser(string Email, string Sifre)///
		{
			User user = _userDal.GetListByType(u => u.Email == Email && u.Sifre == Sifre).FirstOrDefault();
			return user != null;
		}

        public Task<User> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUserAsync(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
