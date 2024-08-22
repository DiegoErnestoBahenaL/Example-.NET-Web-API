namespace WebGlobalProduct.Data.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        Task<int> SaveChangesAsync();
        void Add(T entity);
        void Remove(T entity);
        void Update (T entity);
    }
}
