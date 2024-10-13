﻿using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.Abstractions.RepositoryBase
{
    public interface IRepositoryWriteSideUsingEF<T,TKey>
    {
        Task<TKey> CreateAsync(T entity, PayloadToken payloadToken);
        Task DeleteAsync(T entity, PayloadToken payloadToken);
        Task UpdateAsync(T entity, PayloadToken payloadToken);

    }
}
