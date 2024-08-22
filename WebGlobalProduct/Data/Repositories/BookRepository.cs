using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public class BookRepository : EntityRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibrarySystemDbContext dbContext) : base(dbContext, dbContext.Books) {}

        public BookEntity? FindById(long id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public BookEntity? FindByName(string name)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Title == name);
        }

        public List<BookEntity> GetAll()
        {
            return _dbContext.Books.ToList();
        }
    }
}
