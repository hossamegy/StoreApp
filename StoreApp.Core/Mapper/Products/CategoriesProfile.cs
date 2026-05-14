using AutoMapper;
using StoreApp.Core.Entities.Products;
using StoreApp.Contracts.Products.Responses;

namespace StoreApp.Services.Mapping;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Categories, CategoryNameDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id));
    }
}