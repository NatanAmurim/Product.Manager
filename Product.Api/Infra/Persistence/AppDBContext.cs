using Microsoft.EntityFrameworkCore;
using ProductManager.Api.Domain.Entities;

namespace ProductManager.Api.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
