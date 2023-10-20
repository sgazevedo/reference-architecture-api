using ReferenceArchitecture.Data.Context;
using ReferenceArchitecture.Domain.CustomerContext.Entities;
using ReferenceArchitecture.Domain.CustomerContext.Repositories;

namespace ReferenceArchitecture.Data.Repositories.CustomerContext
{
  public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
  {
    public CustomerRepository(DefaultDbContext context)
      : base(context)
    {
    }
  }
}
