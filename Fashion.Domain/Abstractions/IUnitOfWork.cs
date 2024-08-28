using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Fashion.Domain
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task EndTransactionAsync();
        DbContext GetDbContext();
        Task RollbackTransactionAsync();
    }
}
