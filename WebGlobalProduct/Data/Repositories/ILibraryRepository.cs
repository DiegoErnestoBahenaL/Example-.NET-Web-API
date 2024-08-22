using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data.Repositories
{
    public interface ILibraryRepository : IEntityRepository<LibraryEntity>
    {
        List<LibraryEntity> GetAll();

        LibraryEntity? FindById(long id);

        LibraryEntity? FindByName(string name);
    }
}
