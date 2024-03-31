using System.Linq.Expressions;

namespace CaseRW.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T emtity);
        void Remove(T entity);
    }
}
