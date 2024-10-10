using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
        public int Version { get; set; }
    }
}
