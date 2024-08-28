namespace Fashion.Domain.Abstractions.RepositoryBase
{
    public interface IRepositoryBase<T,TKey>
       : IRepositoryReadSideBaseUsingEF<T,TKey>, IRepositoryWriteSideUsingEF<T,TKey> where T : EntityBase<TKey>
    {

    }
}
