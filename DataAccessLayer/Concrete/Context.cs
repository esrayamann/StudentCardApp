using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-IEH31APK;database=StudentCard;user id=sa;password=1234;TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Application> Applications { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// User ile Application arasındaki ilişki tanımladık!!!
			modelBuilder.Entity<Application>()
				.HasOne(a => a.User)
				.WithMany(u => u.Applications)
				.HasForeignKey(a => a.UserId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
