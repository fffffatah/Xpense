using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Xpense.Extension.Core.Database;

namespace Xpense.Extension.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly XpenseDatabaseContext _dbContext;

        public Repository(XpenseDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<T> Add(T entity)
        {
            var response = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return response.Entity;
        }

        public async ValueTask<T> Delete(T entity)
        {
            var response = await Task.Run(() =>
            {
                return _dbContext.Set<T>().Remove(entity);
            });

            await _dbContext.SaveChangesAsync();

            return response.Entity;
        }

        public async ValueTask<T> Get(long id)
        {
            var response = await _dbContext.Set<T>().FindAsync(id);

            return response;
        }

        public async ValueTask<List<T>> List()
        {
            var response = await _dbContext.Set<T>().ToListAsync();

            return response;
        }

        public async ValueTask<T> Update(T entity)
        {
            var response = await Task.Run(() =>
            {
                return _dbContext.Set<T>().Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return response.Entity;
        }

        public async ValueTask<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            var response = await Task.Run(() =>
            {
                return _dbContext.Set<T>().Where(expression);
            });

            return response;
        }

    }
}
