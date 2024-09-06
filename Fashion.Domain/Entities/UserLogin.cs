using Fashion.Domain.Abstractions;

namespace Fashion.Domain.Entities;

public partial class UserLogin : EntityBase<Guid>
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid RoleGroupId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual RoleGroup RoleGroup { get; set; } = null!;

}
