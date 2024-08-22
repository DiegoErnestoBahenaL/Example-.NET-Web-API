using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public interface IBookRepository : IEntityRepository<BookEntity>
    {
        List<BookEntity> GetAll();
        BookEntity? FindById(long id);
        BookEntity? FindByName(string name);
    }
}
