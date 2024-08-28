using Fashion.Domain.DTOs.Identity;
using Microsoft.AspNetCore.Http;

namespace Fashion.Domain.Abstractions.Repositories.Identity
{
    public interface IAuthoziRepository
    {
        Task<bool> IsAuthozi(HttpContext httpContext, string role = null);
        Task UpdatePermissionForRolegroup(UpdateRoleGroup pramas);
    }
}
