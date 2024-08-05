using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string OgrNo { get; set; }
        public string Bolum { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
