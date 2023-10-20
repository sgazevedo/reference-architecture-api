using Microsoft.EntityFrameworkCore;
using ReferenceArchitecture.Domain.CustomerContext.Entities;

namespace ReferenceArchitecture.Data.Context
{
  public class DefaultDbContext : DbContext
  {
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
          .UseLazyLoadingProxies();
    }
  }
}
