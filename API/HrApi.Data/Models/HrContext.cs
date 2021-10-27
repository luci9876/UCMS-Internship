using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HrApi.Models
{
    public class HrContext : IdentityDbContext
    {
        private  IConfiguration Configuration { get; }
        public HrContext(DbContextOptions<HrContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        public   DbSet<Company> Companies { get; set; }
        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<CompanyEmployee> CompanyEmployee { get; set; }
        public  DbSet<AppUser> AppUsers { get; set; }
        public  DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
            .Entity<CompanyEmployee>(
            x =>
            {
                x.HasNoKey();
            });
            builder.ApplyConfiguration(new RoleConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}