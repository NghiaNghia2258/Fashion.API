using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.RepositoryBase;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Persistence
{
    public abstract class RepositoryBase<T, TKey> : IRepositoryWriteSideUsingEF<T, TKey>, IRepositoryReadSideBaseUsingEF<T,TKey> where T : EntityBase<TKey>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        private readonly FashionStoresContext _dbContext;

        protected RepositoryBase(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _dbContext = unitOfWork.GetDbContext() as FashionStoresContext ?? throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task UpdateAsync(T update, PayloadToken payloadToken)
        {
            if (_dbContext.Entry(update).State == EntityState.Unchanged) return;
            T? exist = _dbContext.Set<T>().Find(update.Id);
            if (exist == null) { throw new Exception("Record for update not found"); }
            PropertyInfo? propertyVersion = exist.GetType().GetProperty("Version");
            if (propertyVersion != null)
            {
                object? valueNewUpdate = propertyVersion.GetValue(update);
                object? valueOldUpdate = exist.Version;
                if (Comparer.Default.Compare(valueNewUpdate, valueOldUpdate) == 0)
                {
                    int plusVersion = Convert.ToInt32(valueNewUpdate) + 1;
                    propertyVersion.SetValue(update, plusVersion);
                }
                else { throw new VersionIsOldException(); }
            }
            //if (httpContext != null)
            //{
            //    PayloadToken payload = JwtToken.VerifyJwtToken(httpContext, _configuration);
            //    PropertyInfo? propertyInfoUpdatedBy = update.GetType().GetProperty("UpdatedBy");
            //    if (propertyInfoUpdatedBy != null)
            //    {
            //        update.UpdatedBy = payload.UserName;
            //    }
            //    PropertyInfo? propertyInfoUpdatedName = update.GetType().GetProperty("UpdatedName");
            //    if (propertyInfoUpdatedName != null)
            //    {
            //        update.UpdatedName = payload.UserName;
            //    }
            //    PropertyInfo? propertyInfoUpdatedAt = update.GetType().GetProperty("UpdatedAt");
            //    if (propertyInfoUpdatedAt != null)
            //    {
            //        update.UpdatedAt = DateTime.Now;
            //    }
            //}
            _dbContext.Entry(exist).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TKey> CreateAsync(T entity, PayloadToken payloadToken)
        {
            T? exist = _dbContext.Set<T>().Find(entity.Id);
            if (exist != null) { throw new Exception("Record for create already exist"); }
            PropertyInfo? propertyInfoCreateAt = entity.GetType().GetProperty("CreatedAt");
            if (propertyInfoCreateAt != null)
            {
                propertyInfoCreateAt.SetValue(entity, DateTime.Now);
            }
            //PropertyInfo? propertyInfoCreateBy = entity.GetType().GetProperty("CreatedAt");
            //if (propertyInfoCreateAt != null)
            //{
            //    propertyInfoCreateAt.SetValue(entity, DateTime.Now);
            //}
            PropertyInfo? propertyInfoCreatedName = entity.GetType().GetProperty("CreatedName");
            if (propertyInfoCreatedName != null)
            {
                propertyInfoCreatedName.SetValue(entity, payloadToken.FullName);
            }
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
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
