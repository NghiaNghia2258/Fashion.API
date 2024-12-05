namespace Fashion.Domain.Abstractions.Entities
{
    public interface IAuditableEntity: ICreateTracking, IUpdateTracking, ISoftDelete
    {
    }
}
