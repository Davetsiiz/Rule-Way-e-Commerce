using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;

namespace CaseRW.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int categoryId);
        Task<CustomResponseDto<List<CategoryDto>>> GetCategoryBySearchAsync(string key);
    }
}
