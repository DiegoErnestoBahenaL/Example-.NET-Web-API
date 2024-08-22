using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public interface ITaskRepository : IEntityRepository<TaskEntity>
    {
        Task<List<TaskEntity>> GetAllForCommonUserAsync(long userId, CancellationToken token);
        Task<List<TaskEntity>> GetAllAsync(CancellationToken token);
        Task<TaskEntity?> FindByIdAsync(long id, CancellationToken token);
    }
}
