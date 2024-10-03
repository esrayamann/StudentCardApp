﻿using DataAccessLayer.Abstract;
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
        private readonly IApplicationDal _applicationDal;

        public ApplicationService(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }

        public ApplicationService(Context context)
        {
            _context = context;
        }
        public async Task ApplicationUserAsync(Basvuru basvuru)
        {
            try
            {
                _context.Basvurular.Add(basvuru);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veri kaydedilirken bir hata oluştu: {ex.Message}");
                throw;
            }
        }
        public async Task<IEnumerable<Basvuru>> GetAllApplicationsAsync()
        {
            return await _context.Basvurular.Include(b => b.User).ToListAsync();

        }

        public async Task<Basvuru> GetApplicationByIdAsync(int id)
        {
            return await _context.Basvurular.FindAsync(id);
        }

        public async Task<IEnumerable<Basvuru>> GetApplicationsByUserIdAsync(int userId)
        {
            return await _context.Basvurular.Where(a => a.User.Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<Basvuru>> GetApplicationsByUserIdAsync(string userId)
        {
            {
                return await _applicationDal.GetListAsync(x => x.User.Ad == userId);
            }
        }
    }
}
