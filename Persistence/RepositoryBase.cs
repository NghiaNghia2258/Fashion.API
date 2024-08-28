using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.RepositoryBase;
using Fashion.Domain.DTOs.Identity;
using System.Reflection;

namespace Persistence
{
    public abstract class RepositoryBase<T, TKey> : RepositoryReadSideBaseUsingEF<T,TKey>, IRepositoryWriteSideUsingEF<T, TKey> where T : EntityBase<TKey>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        private readonly FashionStoresContext _dbContext;

        protected RepositoryBase(FashionStoresContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
    }
}
