using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace StudentCardApp.Models
{
    public class UserModel:IdentityUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
