using AutoMapper;
using Fashion.Domain.Entities;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.Identity;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Exceptions;
using Fashion.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Repositories
{
    public class IdentityRepository : RepositoryBase<UserLogin,Guid>, IAuthenticationRepository, IAuthoziRepository
    {
        private IConfiguration _configuration;
        public IdentityRepository(FashionStoresContext dbContext, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(dbContext, unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
        {
            UserLogin? userLogin = await FindAll()
                .Include(x => x.Employees)
                .Include(x => x.RoleGroup)
                .ThenInclude(x => x.Roles)
                .Where(x => x.Username == paramas.Username)
                .FirstOrDefaultAsync();
            if (userLogin == null)
            {
                throw new AuthenticationException("Wrong username");
            }
            else if(userLogin.Password != paramas.Password) {
                throw new AuthenticationException("Wrong pass");
            }
            return _mapper.Map<PayloadToken>(userLogin);
        }

        public async Task<bool> SignUp(ParamasSignUpRequest paramas)
        {
            await CreateAsync(new UserLogin()
            {
                Username = paramas.Username,
                Password = paramas.Password,
                RoleGroupId = paramas.RoleGroupId
            }, new PayloadToken());
            return true;
        }
        public async Task<LoginResponse> RefreshToken(string refreshToken)
        {
            return new LoginResponse();
        }
        public async Task UpdatePermissionForRolegroup(UpdateRoleGroup pramas)
        {
            using (await _unitOfWork.BeginTransactionAsync())
            {
                FashionStoresContext dbContext = _unitOfWork.GetDbContext() as FashionStoresContext;
                RoleGroup? roleGroup = dbContext.RoleGroups.Include(x => x.Roles).FirstOrDefault(x => x.Id == pramas.Id);
                if (roleGroup == null)
                {

                }
                foreach (var item in pramas.GrantRoles)
                {
                    roleGroup.Roles.Add(_mapper.Map<Role>(item));
                }
                foreach (var item in pramas.RevokeRoles)
                {
                    roleGroup.Roles.Remove(roleGroup.Roles.FirstOrDefault(x => x.Id == item.Id));
                }

                await _unitOfWork.EndTransactionAsync();
            }
            
        }
       
        public async Task<bool> IsAuthozi(HttpContext httpContext, string role = null)
        {
            PayloadToken payloadToken = TokenHelper.GetPayloadToken(httpContext, _configuration);
            UserLogin user = await FindAll().Include(x => x.RoleGroup).ThenInclude(x => x.Roles).FirstOrDefaultAsync(x => x.Id == payloadToken.UserLoginId);
            if(role == null || user.RoleGroup.Roles.FirstOrDefault(x => x.Id.ToString() == role) != null)
            {
                return true;
            }else
            {
                throw new AuthenticationException("403 Unauthorize");
            }    
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            FashionStoresContext dbContext = _unitOfWork.GetDbContext() as FashionStoresContext;
            var roles = dbContext.Roles.AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public IEnumerable<RoleGroupDto> GetRoleGroups()
        {
            FashionStoresContext dbContext = _unitOfWork.GetDbContext() as FashionStoresContext;
            var roleGroups = dbContext.RoleGroups.Include(x => x.Roles).AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<RoleGroupDto>>(roleGroups);
        }
    }
}
