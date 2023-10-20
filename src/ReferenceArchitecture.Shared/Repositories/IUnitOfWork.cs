namespace ReferenceArchitecture.Shared.Repositories
{
  public interface IUnitOfWork
  {
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task<int> SaveChangesAsync();
  }
}
