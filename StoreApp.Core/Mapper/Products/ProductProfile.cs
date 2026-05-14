using AutoMapper;
using StoreApp.Core.Entities.Products;
using StoreApp.Contracts.Products.Responses;

namespace StoreApp.Services.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.BrandName,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages.Select(x => x.ImageUrl)));
    }
}