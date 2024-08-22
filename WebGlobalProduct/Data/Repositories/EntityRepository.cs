using Microsoft.EntityFrameworkCore;

namespace WebGlobalProduct.Data.Repositories
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        protected readonly LibrarySystemDbContext _dbContext;
        private readonly DbSet<T> _collection;

        public EntityRepository(LibrarySystemDbContext dbContext, DbSet<T> collection) 
        {
            _dbContext = dbContext;
            _collection = collection;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Add(T entity)
        {
            _collection.Add(entity);
        }
        public void Remove(T entity)
        {
            _collection.Remove(entity);
        }
    }
}
