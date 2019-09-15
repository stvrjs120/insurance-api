using Microsoft.EntityFrameworkCore;
using System;

namespace InsuranceAPI.Models.Context
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInsurance> CustomerInsurances { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurance>()
                .Property(i => i.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Customer>()
                .Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CustomerInsurance>()
                .HasKey(c => new { c.InsuranceID, c.CustomerID });
        }
    }
}
