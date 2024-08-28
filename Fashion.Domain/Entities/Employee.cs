using Fashion.Domain.Abstractions;

namespace Domain.Entities;

public partial class Employee : EntityBase<Guid>
{

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public Guid? UserLoginId { get; set; }

    public virtual UserLogin? UserLogin { get; set; }
}
