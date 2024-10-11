using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Fashion.Domain
{
    public interface IUnitOfWork
    {
        public DbContext DbContext { get; }
        public SqlConnection SqlConnection { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task EndTransactionAsync();
        DbContext GetDbContext();
        Task RollbackTransactionAsync();
    }
}
