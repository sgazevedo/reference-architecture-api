using ReferenceArchitecture.Shared.Domain;

namespace ReferenceArchitecture.Shared.Repositories
{
  public interface IRepositoryBase<T> where T : EntityBase
  {
    Task<T?> GetByIdAsync(Guid id);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IList<T> entities);
    void Update(T entity);
    Task AddAsync(T entity);
  }
}
