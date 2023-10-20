using Microsoft.EntityFrameworkCore;
using ReferenceArchitecture.Data.Context;
using ReferenceArchitecture.Shared.Domain;
using ReferenceArchitecture.Shared.Repositories;

namespace ReferenceArchitecture.Data.Repositories
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
  {
    internal readonly DefaultDbContext _context;

    protected RepositoryBase(DefaultDbContext context) => _context = context;

    public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public async Task DeleteAsync(T entity) => await Task.Run(() => _context.Set<T>().Remove(entity));

    public async Task DeleteRangeAsync(IList<T> entities) => await Task.Run(() => _context.Set<T>().RemoveRange(entities));
  }
}
