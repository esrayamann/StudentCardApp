using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
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
        Task<IEnumerable<Role>> AllRolesAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterUserAsync(ApplicationViewModel model);
        Task GetAllRolesAsync();
        Task<bool> UploadPhotoAsync(int userId, IFormFile file);
        Task<string> GetPhotoAsync(int userId);


        //Task UpdateUserRolesAsync(int userId, object selectedRoles);
    }
}
