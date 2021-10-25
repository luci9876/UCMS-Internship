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
        public  virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Company_Employee> Company_Employee { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
            .Entity<Company_Employee>(
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