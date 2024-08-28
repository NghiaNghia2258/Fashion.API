
namespace Fashion.Domain.DTOs.Identity;

public class UpdateRoleGroup
{
    public Guid Id { get; set; }
    public IEnumerable<RoleDto> GrantRoles { get; set; }
    public IEnumerable<RoleDto> RevokeRoles { get; set; }
}
