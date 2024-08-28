using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Basvuru
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Adres { get; set; }
        public string BasvuruNedeni { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
