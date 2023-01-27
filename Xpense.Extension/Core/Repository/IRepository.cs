using System.Linq.Expressions;

namespace Xpense.Extension.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> AddAsync(T entity);
        ValueTask<T> UpdateAsync(T entity);
        ValueTask<T> DeleteAsync(T entity);
        ValueTask<T> GetAsync(long id);
        ValueTask<List<T>> GetAsync();
        ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
    }
}
