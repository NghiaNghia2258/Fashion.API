using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;
using Fashion.Domain.Abstractions.RepositoryBase;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence
{
    public abstract class RepositoryBase<T, TKey> : IRepositoryWriteSideUsingEF<T, TKey>, IRepositoryReadSideBaseUsingEF<T, TKey> where T : EntityBase<TKey>
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
            if (exist.Version == update.Version)
            {
                update.Version += 1;
            }
            else { throw new VersionIsOldException(); }
            if (update is IUpdateTracking trackingEntity)
            {
                trackingEntity.UpdatedAt = TimeConst.Now;
                trackingEntity.UpdatedBy = payloadToken.Username;
                trackingEntity.UpdatedName = payloadToken.FullName;
            }
            _dbContext.Entry(exist).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TKey> CreateAsync(T entity, PayloadToken payloadToken)
        {
            T? exist = _dbContext.Set<T>().Find(entity.Id);
            if (exist != null) { throw new Exception("Record for create already exist"); }
            if (entity is ICreateTracking createTracking)
            {
                createTracking.CreatedAt = TimeConst.Now;
                createTracking.CreatedBy = payloadToken.Username;
                createTracking.CreatedName = payloadToken.FullName;
            }
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity, PayloadToken payloadToken)
        {
            T? exist = _dbContext.Set<T>().Find(entity.Id);
            if (exist == null) { throw new Exception("Record for delete does not exist"); }
            if (entity is ISoftDelete softDelete)
            {
                softDelete.IsDeleted = true;
                softDelete.DeletedBy = payloadToken.Username;
                softDelete.DeletedAt = TimeConst.Now;
                softDelete.DeletedName = payloadToken.FullName;
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            }
            else
            {
                _dbContext.Set<T>().Remove(entity);
            }
            await _dbContext.SaveChangesAsync();
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
