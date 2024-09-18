using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.RepositoryBase;
using Fashion.Domain.DTOs.Identity;
using Microsoft.EntityFrameworkCore;
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
