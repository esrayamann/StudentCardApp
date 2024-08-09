using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Abstract
{
	public interface IUserService
	{
		void UserAdd(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterUserAsync(RegisterViewModel model);


    }
}
