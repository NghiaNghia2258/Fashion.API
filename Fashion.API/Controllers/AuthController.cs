using Fashion.Domain.Abstractions.Repositories.Identity;
using Fashion.Domain.ApiResult;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticationRepository _authenticationRepository;
        private IAuthoziRepository _authoziRepository;
        private IConfiguration _configuration;

        public AuthController(IAuthenticationRepository authenticationRepository, IAuthoziRepository authoziRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _authoziRepository = authoziRepository;
            _configuration = configuration;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(ParamasSignUpRequest paramas)
        {
            await _authenticationRepository.SignUp(paramas);
            return Ok(new ApiSuccessResult());
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(ParamasSignInRequest paramas)
        {
            PayloadToken token = await _authenticationRepository.SignIn(paramas);
            LoginResponse response = new LoginResponse()
            {
                AccessToken = TokenHelper.GenerateJwtToken(token,_configuration),
                RefreshToken = TokenHelper.GenerateJwtToken(token, _configuration)
            };
            return Ok(new ApiSuccessResult<LoginResponse>(response));
        }

        [HttpGet("get-roles")]
        public IActionResult GetRoles() {
            var roles = _authenticationRepository.GetRoles();
            return Ok(new ApiSuccessResult<IEnumerable<RoleDto>>(roles));
        }

        [HttpPost("update-rolegroup")]
        public async Task<IActionResult> UpdatePermissionForRolegroup(UpdateRoleGroup pramas)
        {
            await _authoziRepository.UpdatePermissionForRolegroup(pramas);
            return Ok(new ApiSuccessResult());
        }

        [HttpGet("get-rolegroups")]
        public IActionResult GetRoleGroups()
        {
            var roleGroups = _authenticationRepository.GetRoleGroups();
            return Ok(new ApiSuccessResult<IEnumerable<RoleGroupDto>>(roleGroups));
        }
    }
}
