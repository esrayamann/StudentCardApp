using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfApplicationRepository : GenericRepository<Basvuru>, IApplicationDal
    {
        public Task<Basvuru> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Basvuru>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Basvuru>> GetListAsync(Func<Basvuru, bool> filter)//
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Application application)
        {
            throw new NotImplementedException();
        }
    }
}
