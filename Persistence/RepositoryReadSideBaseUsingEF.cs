using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence
{
    public abstract class RepositoryReadSideBaseUsingEF<T, TKey> : IRepositoryReadSideBaseUsingEF<T, TKey> where T : EntityBase<TKey>
    {
        private readonly FashionStoresContext _dbContext;
        public RepositoryReadSideBaseUsingEF(FashionStoresContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IQueryable<T> FindAll(bool trackChanges = false)
        {
            return !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(TKey primaryKey)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(primaryKey));
        }

        public async Task<T?> GetByIdAsync(TKey primaryKey, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = _dbContext.Set<T>().Where(x => x.Id.Equals(primaryKey));
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return await items.FirstOrDefaultAsync();
        }
    }
}
