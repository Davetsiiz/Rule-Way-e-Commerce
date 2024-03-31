using CaseRW.Core.Entities;
using CaseRW.Core.Repositories;
using CaseRW.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseRW.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            //Eager Loading:Product ile category aynı anda çekilirse bu eager loadingtir
            return await _appDbContext.Products.Include(p => p.Category).ToListAsync();
            //lazy loading:Eğer productı çektikten sonra ihtiyaç halinde category çekilir. Bu da lazy loadingtir
        }

        public async Task<List<Product>> GetProductTitleBySearchAsync(string key)
        {
            return await _appDbContext.Products.Where(x => x.Title.Contains(key)).ToListAsync();
        }
        public async Task<List<Product>> GetProductDescriptionBySearch(string key)
        {
            return await _appDbContext.Products.Where(x => x.Description.Contains(key)).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByStockQuantityRange(int max, int min)
        {
            return await _appDbContext.Products.Where(p => p.StockQuantity >= min && p.StockQuantity <= max).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryMinStockAsync()
        {
            return await _appDbContext.Products
               .Include(x => x.Category)
               .Where(p => p.Category.MinStock <= p.StockQuantity)
               .ToListAsync();
        }

    }
}
