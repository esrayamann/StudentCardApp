using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public class UserDal : IUserDal
    {
        private readonly Context _context;

        public UserDal(Context context)
        {
            _context = context;
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetListAll()
        {
            return _context.Users.ToList();
        }

        public List<User> GetListByType(Expression<Func<User, bool>> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public void Insert(User t)
        {
            _context.Users.Add(t);
            _context.SaveChanges();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
