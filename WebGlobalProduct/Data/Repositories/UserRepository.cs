using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public class UserRepository : EntityRepository<UserEntity>, IUserRepository
    {
        public UserRepository(TaskManagerSystemDbContext dbContext) : base(dbContext, dbContext.Users) { }

        public Task<UserEntity?> FindByIdAsync(long id, CancellationToken token)
        {
            return _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, token);
        }

        public Task<UserEntity?> FindAsync (string email, string password, CancellationToken token)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password, token);
        }

        public Task<List<UserEntity>> GetAllAsync(CancellationToken token)
        {
            return _dbContext.Users.ToListAsync(token);
        }
    }
}
