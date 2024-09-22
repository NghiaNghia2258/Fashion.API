using AutoMapper;
using Fashion.Domain.Entities;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.DTOs.Entities.ProductImage;
using Fashion.Domain.DTOs.Entities.ProductVariant;
using Fashion.Domain.DTOs.Entities.OrderItem;
using Fashion.Domain.DTOs.Entities.Order;
using Fashion.Domain.DTOs.Entities.Customer;

namespace Fashion.Domain.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ProductGetByIdDto>().ReverseMap();
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

            CreateMap<ProductImageDto, ProductImage>().ReverseMap();
            CreateMap<CreateProductVariantDto, ProductVariant>();

            CreateMap<CreateProductVariantDto, ProductVariant>();
            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();

            CreateMap<Order, OrderGetByIdDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerGetById>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
