using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data
{
    public class LibrarySystemDbContext : DbContext
    {
        public DbSet<LibraryEntity> Libraries { get; set; }

        public DbSet<BookEntity> Books { get; set; }

        
        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
