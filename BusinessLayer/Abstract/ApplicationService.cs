using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public class ApplicationService : IApplicationService
	{
		private readonly Context _context;

        public ApplicationService(Context context)
        {
            _context = context;
        }

        public async Task ApplicationUserAsync(ApplicationViewModel model, int userId)
        {
            var application = new Application
            {
                BasvuruNedeni = model.BasvuruNedeni,
                Adres = model.Adres,
                UserId = userId
            };

            try
            {
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veri kaydedilirken bir hata oluştu: {ex.Message}");
                throw;
            }

            // Kullanıcının kimlik doğrulamasının yapıldığını doğrulama
            //if (User.Identity.IsAuthenticated)
            //{
            //    // Kullanıcının ID'sini Claims'den alıyoruz
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //    // Application modelini oluşturuyoruz ve UserId'yi set ediyoruz
            //    var application = new Application
            //    {
            //        BasvuruNedeni = model.BasvuruNedeni,
            //        Adres = model.Adres,
            //        UserId = int.Parse(userId)  // Kullanıcının ID'sini burada set ediyoruz
            //    };

            //    try
            //    {
            //        _context.Applications.Add(application);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Veri kaydedilirken bir hata oluştu: {ex.Message}");
            //        throw;
            //    }
            //}
            //else
            //{
            //    throw new Exception("Kullanıcı kimliği doğrulanmadı.");
            //}
        }
        public async Task<IEnumerable<Basvuru>> GetAllApplicationsAsync()
		{
			//return await _context.Basvurular.ToListAsync();
            return await _context.Basvurular.Include(b => b.User).ToListAsync();

        }

		public async Task<Basvuru> GetApplicationByIdAsync(int id)
		{
			return await _context.Basvurular.FindAsync(id);
		}
	}
}
