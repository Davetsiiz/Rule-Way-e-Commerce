using System.Linq.Expressions;

namespace CaseRW.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T emtity);
        Task RemoveAsync(T entity);
    }
}
