//using Dapper;
//using Fashion.Domain.Abstractions.RepositoryBase;
//using Fashion.Domain.Parameters;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//namespace Persistence
//{
//    public abstract class RepositoryReadSideBaseUsingDapper<T, TKey> : IRepositoryReadSideBaseUsingDapper<T, TKey> 
//    {
//        private readonly FashionStoresContext _dbContext;
//        private readonly SqlConnection _connection;
//        public RepositoryReadSideBaseUsingDapper(FashionStoresContext dbContext)
//        {
//            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
//            _connection = new SqlConnection(_dbContext.Database.GetConnectionString());
//        }
//        #region method private

      
//        #endregion

//        public async Task<IEnumerable<T>> FindAll(PagingRequestParameters paging, params Expression<Func<T, object>>[] includeProperties)
//        {
//            var columns = new List<string>();
//            var joins = new List<string>();

//            foreach (var propertyInclude in includeProperties)
//            {
//                var property = typeof(T).GetProperty(propertyInclude.Name);
//                if (typeof(IEnumerable<>).IsAssignableFrom(property.PropertyType))
//                {
//                    joins.Add($@"LEFT JOIN {propertyInclude.Name} ON {typeof(T).Name}s.Id = {propertyInclude.Name}.{typeof(T).Name}Id");
//                    columns.Add($"{propertyInclude.Name}.*");
//                }
//                else if (property.PropertyType.IsClass)
//                {
//                    joins.Add($@"LEFT JOIN {propertyInclude.Name}s ON {typeof(T).Name}s.Id = {propertyInclude.Name}s.{typeof(T).Name}Id");
//                    columns.Add($"{propertyInclude.Name}s.*");
//                }
//                else
//                {
//                    columns.Add(propertyInclude.Name);
//                }
//            }

//            string selectClause = columns.Any() ? string.Join(", ", columns) : "*";
//            string joinClause = string.Join(" ", joins);

//            string query = @$"
//               SELECT {selectClause} 
//                FROM {typeof(T).Name}s
//                {joinClause}
//                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
//";
//            var parameters = new { Offset = (paging.PageIndex - 1) * paging.PageSize, PageSize = paging.PageSize };
//            IEnumerable<object> result = await _connection.QueryAsync<object>(query, parameters);
//            return await _connection.QueryAsync<T>(query,parameters);
//        }

//        public Task<T> FindById(TKey key, params Expression<Func<T, object>>[] includeProperties)
//        {
//            string query = @$"";
//            return _connection.QueryFirstAsync<T>(query);
//        }

//    }
//}
