using CaseRW.Core.Entities;

namespace CaseRW.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoryAsync();
        Task<List<Product>> GetProductTitleBySearchAsync(string key);
        Task<List<Product>> GetProductDescriptionBySearch(string key);
        Task<List<Product>> GetProductsByStockQuantityRange(int max, int min);
        Task<List<Product>> GetProductsByCategoryMinStockAsync();

    }
}
