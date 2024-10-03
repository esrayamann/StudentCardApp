using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ApplicationManager : IApplicationService
    {
        IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }
        
        public async Task<IEnumerable<Basvuru>> GetAllApplicationsAsync()
        {
            return await _applicationDal.GetListAsync();
        }
        public List<Basvuru> GetList()
        {
            return _applicationDal.GetListAll();
        }
        public async Task<Basvuru> GetApplicationByIdAsync(int id)
        {
            return await _applicationDal.GetByIdAsync(id);

        }
        
        //public async Task ApplicationUserAsync(ApplicationViewModel model,int userId)
        //{
        //    var application = new Application
        //    {
        //        BasvuruNedeni = model.BasvuruNedeni,
        //        Adres = model.Adres,
        //        UserId = userId
        //    };
        //    await _applicationDal.InsertAsync(application);

        //}

        public Task ApplicationUserAsync(Basvuru basvuru)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Basvuru>> GetApplicationsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Basvuru>> GetApplicationsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
