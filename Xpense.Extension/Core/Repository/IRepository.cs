namespace Xpense.Extension.Core.Repository
{
    interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Get();
        List<T> List();
    }
}
