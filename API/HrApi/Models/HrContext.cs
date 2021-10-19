using Microsoft.EntityFrameworkCore;
using HrApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HrApi.Models
{
    public class HrContext : IdentityDbContext
    {
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HrApi.Models.Company_Employee> Company_Employee { get; set; }
        public  DbSet<AppUser> AppUsers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}