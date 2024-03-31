using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;

namespace CaseRW.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategoryAsync();
        Task<CustomResponseDto<List<ProductDto>>> GetProductTitleBySearchAsync(string key);
        Task<CustomResponseDto<List<ProductDto>>> GetProductDescriptionBySearchAsync(string key);
        Task<CustomResponseDto<List<ProductDto>>> GetProductsByStockQuantityRangeAsync(int max, int min);
        Task<CustomResponseDto<List<ProductDto>>> GetProductsByCategoryMinStockAsync();
    }
}
