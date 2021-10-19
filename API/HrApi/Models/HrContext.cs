using Microsoft.EntityFrameworkCore;
using HrApi.Models;

namespace HrApi.Models
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HrApi.Models.Company_Employee> Company_Employee { get; set; }
        public  DbSet<AppUser> AppUsers { get; set; }
    }
}