using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReferenceArchitecture.Data.Context;
using ReferenceArchitecture.Data.Repositories.CustomerContext;
using ReferenceArchitecture.Data.UnitOfWork;
using ReferenceArchitecture.Domain.CustomerContext.Repositories;
using ReferenceArchitecture.Shared.Repositories;

namespace ReferenceArchitecture.IoC
{
  public static class NativeInjectorBootStrapper
  {
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
      RegisterEntityFramework(services, configuration);
    }

    private static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<DefaultDbContext>(opt =>
      {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        opt.UseSqlite(connectionString);
      });
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

  }
}
