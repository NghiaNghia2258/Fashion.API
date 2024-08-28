using Fashion.Domain.Parameters;
using System.Linq.Expressions;

namespace Fashion.Domain.Abstractions.RepositoryBase
{
    public interface IRepositoryReadSideBaseUsingDapper<T,TKey>
    {
        Task<IEnumerable<T>> FindAll(PagingRequestParameters paging, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindById(TKey key, params Expression<Func<T, object>>[] includeProperties);
    }
}
