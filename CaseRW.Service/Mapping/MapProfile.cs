using AutoMapper;
using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;

namespace CaseRW.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
        }
    }
}
