using Domain.Entities;
using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.Abstractions.Repositories.Identity
{
    public interface IAuthenticationRepository
    {
        IEnumerable<RoleGroupDto> GetRoleGroups();
        IEnumerable<RoleDto> GetRoles();
        Task<PayloadToken> SignIn(ParamasSignInRequest paramas);
        Task<bool> SignUp(ParamasSignUpRequest paramas);
    }
}
