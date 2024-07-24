using Microsoft.AspNetCore.Identity;

namespace StudentCardApp.Models
{
    public class RoleModel:IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
