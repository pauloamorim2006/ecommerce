using AutoMapper;
using ECommerce.Application.DTO;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Configuration
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<CategoryAddRequestDTO, Category>().
                ConstructUsing(c => new Category(c.Name, c.Image));
            CreateMap<CategoryUpdateRequestDTO, Category>().
                ConstructUsing(c => new Category(c.Id, c.Name, c.Image));

            CreateMap<SubcategoryAddRequestDTO, Subcategory>().
                ConstructUsing(c => new Subcategory(c.Name, c.CategoryId));
            CreateMap<SubcategoryUpdateRequestDTO, Subcategory>().
                ConstructUsing(c => new Subcategory(c.Id, c.Name, c.CategoryId));

            CreateMap<BrandAddRequestDTO, Brand>().
                ConstructUsing(c => new Brand(c.Name));
            CreateMap<BrandUpdateRequestDTO, Brand>().
                ConstructUsing(c => new Brand(c.Id, c.Name));

            CreateMap<ProductAddRequestDTO, Product>().
                ConstructUsing(c => new Product(c.Name, c.Color, c.Price, c.Maker, c.Model, c.Certification, c.TypeMaterial, c.Quantity, c.Size, c.Details, c.Rating, c.FreeShipping, c.BrandId, c.SubcategoryId));
            CreateMap<ProductUpdateRequestDTO, Product>().
                ConstructUsing(c => new Product(c.Id, c.Name, c.Color, c.Price, c.Maker, c.Model, c.Certification, c.TypeMaterial, c.Quantity, c.Size, c.Details, c.Rating, c.FreeShipping, c.BrandId, c.SubcategoryId));

            CreateMap<ShoppingCartItemRequestDTO, ShoppingCartItem>().
                ConstructUsing(c => new ShoppingCartItem(c.ProductId, c.Quantity, 0));
            CreateMap<ShoppingCartItemRemoveRequestDTO, ShoppingCartItem>().
                ConstructUsing(c => new ShoppingCartItem(c.ProductId, 0, 0));
        }
    }
}
