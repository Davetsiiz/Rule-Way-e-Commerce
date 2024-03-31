using CaseRW.Core.Entities;

namespace CaseRW.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdWithProductsAsync(int categoryId);
        Task<List<Category>> GetCategoryBySearchAsync(string key);

    }
}
