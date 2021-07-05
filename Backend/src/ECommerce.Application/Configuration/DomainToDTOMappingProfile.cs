using AutoMapper;
using ECommerce.Application.DTO;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Configuration
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Brand, BrandResponseDTO>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<Subcategory, SubcategoryResponseDTO>();
            CreateMap<Product, ProductResponseDTO>()
                .ForMember(to => to.SubcategoryName, opt => opt.MapFrom(src => src.Subcategory.Name))
                .ForMember(to => to.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Image, ImageResponseDTO>();
            CreateMap<ShoppingCart, ShoppingCartResponseDTO>();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponseDTO>();
        } 
    }
}
