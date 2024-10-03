using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace StudentCardApp.Models
{
    public class BasvuruViewModel
    {
        [Required]
        public string BasvuruNedeni { get; set; }
        [Required]
        public string Adres { get; set; }
        public IEnumerable<Basvuru> Basvurular { get; set; }

    }
}
