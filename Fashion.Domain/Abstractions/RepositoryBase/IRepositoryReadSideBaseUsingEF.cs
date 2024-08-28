using System.Linq.Expressions;

namespace Fashion.Domain.Abstractions.RepositoryBase
{
    public interface IRepositoryReadSideBaseUsingEF<T, TKey>
    {
        IQueryable<T> FindAll(bool trackChanges = false);
        Task<T?> GetByIdAsync(TKey primaryKey);
        Task<T?> GetByIdAsync(TKey primaryKey, params Expression<Func<T, object>>[] includeProperties);
    }
}
