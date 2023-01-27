namespace Xpense.Extension.Core.Repository
{
    public interface IRepository<T>
    {
        ValueTask<T> Add(T entity);
        ValueTask<T> Update(T entity);
        ValueTask<T> Delete(T entity);
        ValueTask<T> Get();
        ValueTask<List<T>> List();
    }
}
