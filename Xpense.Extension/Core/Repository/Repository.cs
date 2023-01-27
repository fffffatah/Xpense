using Xpense.Extension.Core.Database;

namespace Xpense.Extension.Core.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly XpenseDatabaseContext _dbContext;

        public Repository(XpenseDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<T> Get()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
