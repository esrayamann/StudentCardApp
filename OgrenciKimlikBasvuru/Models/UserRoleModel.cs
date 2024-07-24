using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace StudentCardApp.Models
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
