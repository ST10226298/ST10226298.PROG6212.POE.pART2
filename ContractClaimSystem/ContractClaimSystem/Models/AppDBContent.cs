using Microsoft.EntityFrameworkCore;

namespace ContractClaimSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClaimModel> Claims { get; set; } // DbSet for Claims
    }
}