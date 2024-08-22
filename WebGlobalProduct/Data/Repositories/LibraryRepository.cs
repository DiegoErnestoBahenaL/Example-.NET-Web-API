using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public class LibraryRepository : EntityRepository<LibraryEntity>, ILibraryRepository
    {
        public LibraryRepository(LibrarySystemDbContext dbContext) : base(dbContext, dbContext.Libraries) {}

        public List<LibraryEntity> GetAll()
        {
            return _dbContext.Libraries.ToList();
        }

        public LibraryEntity? FindById(long id)
        {
            return _dbContext.Libraries.FirstOrDefault(x => x.Id == id);
        }

        public LibraryEntity? FindByName(string name)
        {
            return _dbContext.Libraries.FirstOrDefault(x => x.Name == name);
        }
    }
}
