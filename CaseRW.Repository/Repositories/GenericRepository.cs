using CaseRW.Core.Repositories;
using CaseRW.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CaseRW.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            //_appDbContext.Entry(entity).State = EntityState.Deleted;
            //iki metod da aynı 
            _dbSet.Remove(entity);
        }

        public void Update(T emtity)
        {
            _dbSet.Update(emtity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
