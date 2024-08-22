using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public interface IUserRepository : IEntityRepository<UserEntity>
    {
        Task<UserEntity?> FindAsync(string email, string password, CancellationToken token);
        Task<List<UserEntity>> GetAllAsync(CancellationToken token);
        Task<UserEntity?> FindByIdAsync(long id, CancellationToken token);
    }
}
