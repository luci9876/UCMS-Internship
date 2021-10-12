﻿using Microsoft.EntityFrameworkCore;

namespace HrApi.Models
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees{ get; set; }
    }
}