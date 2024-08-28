namespace Fashion.Domain.DTOs.Identity
{
    public class RoleGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
