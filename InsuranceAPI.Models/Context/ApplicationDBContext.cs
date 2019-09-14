using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Models.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Insurance> Insurance { get; set; }
    }
}
