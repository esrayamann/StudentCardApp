using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IApplicationService
	{
		Task<Basvuru> GetApplicationByIdAsync(int id);
		Task<IEnumerable<Basvuru>> GetAllApplicationsAsync();
        Task ApplicationUserAsync(ApplicationViewModel model,int userId);

    }
}
