using CaseRW.Core.Entities;
using CaseRW.Core.Repositories;
using CaseRW.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseRW.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryBySearchAsync(string key)
        {
            return await _appDbContext.Categories.Where(x => x.Name.Contains(key)).ToListAsync();
        }



    }
}
