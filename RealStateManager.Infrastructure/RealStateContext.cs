using Microsoft.EntityFrameworkCore;
using RealStateManager.Domain.Models;

namespace RealStateManager.Infrastructure
{
    public class RealStateContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public RealStateContext(DbContextOptions options) : base(options) { }
    }
}
