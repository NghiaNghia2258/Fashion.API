using Fashion.Domain.Abstractions;

namespace Fashion.Domain.Entities;

public partial class Role : EntityBase<Guid>
{

    public string Name { get; set; } = null!;

    public virtual ICollection<RoleGroup> RoleGroups { get; set; } = new List<RoleGroup>();
}
