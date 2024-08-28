namespace Fashion.Domain.DTOs.Identity
{
    public class PayloadToken
    {
        public Guid UserLoginId { get; set; }
        public string Username { get; set;}
        public string FullName { get; set;}

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
