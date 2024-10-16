﻿using Fashion.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FashionStoresContext _dbContext;
        private SqlConnection _sqlConnection;

        public DbContext DbContext => _dbContext;

        public SqlConnection SqlConnection => _sqlConnection;

        public UnitOfWork(FashionStoresContext dbContext)
        {
            _dbContext = dbContext;
            _sqlConnection = new SqlConnection(_dbContext.Database.GetConnectionString());
        }
        public DbContext GetDbContext()
        {
            return _dbContext;
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _dbContext.Database.BeginTransactionAsync();
        }
        public Task RollbackTransactionAsync()
        {
            return _dbContext.Database.RollbackTransactionAsync();
        }
        public async Task EndTransactionAsync()
        {
            await CommitAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }
    }
}
