using System.Linq.Expressions;

namespace Xpense.Extension.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> Add(T entity);
        ValueTask<T> Update(T entity);
        ValueTask<T> Delete(T entity);
        ValueTask<T> Get(long id);
        ValueTask<List<T>> List();
        ValueTask<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}
