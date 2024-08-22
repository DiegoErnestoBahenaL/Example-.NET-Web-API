using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public class TaskRepository : EntityRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(TaskManagerSystemDbContext dbContext) : base(dbContext, dbContext.Tasks) { }

        public Task<TaskEntity?> FindByIdAsync(long id, CancellationToken token)
        {
            return _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<TaskEntity>> GetAllAsync(CancellationToken token)
        {
            return _dbContext.Tasks.ToListAsync(token);
        }

        public Task<List<TaskEntity>> GetAllForCommonUserAsync(long userId, CancellationToken token)
        {
            return _dbContext.Tasks
                .Where(x => x.UserId == userId)
                .ToListAsync(token);
        }
    }
}
