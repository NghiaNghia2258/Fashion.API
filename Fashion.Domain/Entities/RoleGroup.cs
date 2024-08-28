using Fashion.Domain.Abstractions;

namespace Domain.Entities;

public partial class RoleGroup : EntityBase<Guid>
{

    public string Name { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
