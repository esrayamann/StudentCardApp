using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
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

        public Task<Role> GetRoleByIdAsync(int id)
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

        public Task RegisterUserAsync(ApplicationViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> AllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadPhotoAsync(int userId, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhotoAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRolesAsync(int userId,/* object selectedRoles,*/ List<int> newRoleIds)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRoleAsync(int userId, object selectedRoles)
        {
            throw new NotImplementedException();
        }
    }
}
