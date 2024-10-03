using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IApplicationDal : IGenericDal<Basvuru>
    {
        Task<Basvuru> GetByIdAsync(int id);
        Task<IEnumerable<Basvuru>> GetListAsync();
        Task InsertAsync(Application application);
        Task<List<Basvuru>> GetListAsync(Func<Basvuru, bool> filter);//

    }
}
