using EntityLayer.Concrete;

namespace StudentCardApp.Models
{
    /// <summary>
    /// ////
    /// </summary>
    public class UpdateRoleViewModel
    {
        public int UserId { get; set; }
        public List<int> SelectedRoles { get; set; }  // Kullanıcının yeni seçeceği roller
        public List<Role> AllRoles { get; set; }  // Tüm roller
        public List<int> UserRoles { get; set; }  // Kullanıcının mevcut rollerinin ID'leri
    }


}