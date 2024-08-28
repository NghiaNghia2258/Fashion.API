using AutoMapper;
using Domain.Entities;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<UserLogin, PayloadToken>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleGroup.Roles))
                .ForMember(dest => dest.UserLoginId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Employees.FirstOrDefault().Name))
            ;

            CreateMap<RoleDto, Role>();
            CreateMap<RoleGroupDto, RoleGroup>();
            CreateMap<RoleGroup, RoleGroupDto>();
            CreateMap<Role, RoleDto>();



        }
    }
}
