using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Abstract
{
    public class ApplicationViewModel
    {
       
            [Required(ErrorMessage = "E-posta adresi gereklidir.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Şifre gereklidir.")]
            [DataType(DataType.Password)]
            public string Sifre { get; set; }

            [Required(ErrorMessage = "Şifreyi onaylayın.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
            public string ConfirmPassword { get; set; }
        public string BasvuruNedeni { get; internal set; }
        public string Adres { get; internal set; }
    }
}