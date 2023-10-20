using ReferenceArchitecture.Data.Context;
using ReferenceArchitecture.Shared.Repositories;

namespace ReferenceArchitecture.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DefaultDbContext _context;

    public UnitOfWork(DefaultDbContext context) => _context = context;    

    public bool IsTransactioned => _context.Database.CurrentTransaction != null;

    public async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
      if (!IsTransactioned)
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
      if (IsTransactioned)
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
      if (IsTransactioned)
        await _context.Database.RollbackTransactionAsync();
    }
  }
}
